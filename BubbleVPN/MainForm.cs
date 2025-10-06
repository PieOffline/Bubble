using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace BubbleVPN
{
    public partial class MainForm : Form
    {
        private WebView2? webView;
        private TextBox? urlTextBox;
        private Button? goButton;
        private Button? vpnToggleButton;
        private Button? backButton;
        private Button? forwardButton;
        private Button? refreshButton;
        private Label? statusLabel;
        private Label? statsLabel;
        private Panel? controlPanel;
        private Panel? statusPanel;
        private NotifyIcon? trayIcon;
        private VPNService vpnService;
        private System.Windows.Forms.Timer? statsTimer;

        public MainForm()
        {
            vpnService = new VPNService();
            vpnService.StatusChanged += VpnService_StatusChanged;
            InitializeComponent();
            InitializeWebView();
            InitializeTrayIcon();
            InitializeStatsTimer();
        }

        private void InitializeComponent()
        {
            this.Text = "Bubble VPN Browser";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.Shield;
            this.MinimumSize = new Size(800, 600);

            // Status Panel at the top
            statusPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(45, 45, 48)
            };
            this.Controls.Add(statusPanel);

            // VPN Status Label
            statusLabel = new Label
            {
                Text = "VPN: DISCONNECTED",
                ForeColor = Color.OrangeRed,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            statusPanel.Controls.Add(statusLabel);

            // Statistics Label
            statsLabel = new Label
            {
                Text = "Ready to connect",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 45),
                AutoSize = true
            };
            statusPanel.Controls.Add(statsLabel);

            // VPN Toggle Button
            vpnToggleButton = new Button
            {
                Text = "🛡️ Enable VPN",
                Location = new Point(250, 15),
                Size = new Size(160, 50),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            vpnToggleButton.FlatAppearance.BorderSize = 0;
            vpnToggleButton.Click += VpnToggleButton_Click;
            statusPanel.Controls.Add(vpnToggleButton);

            // Control Panel
            controlPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(37, 37, 38)
            };
            this.Controls.Add(controlPanel);

            // Back Button
            backButton = new Button
            {
                Text = "◀",
                Location = new Point(10, 10),
                Size = new Size(40, 30),
                BackColor = Color.FromArgb(62, 62, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += BackButton_Click;
            controlPanel.Controls.Add(backButton);

            // Forward Button
            forwardButton = new Button
            {
                Text = "▶",
                Location = new Point(55, 10),
                Size = new Size(40, 30),
                BackColor = Color.FromArgb(62, 62, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            forwardButton.FlatAppearance.BorderSize = 0;
            forwardButton.Click += ForwardButton_Click;
            controlPanel.Controls.Add(forwardButton);

            // Refresh Button
            refreshButton = new Button
            {
                Text = "⟳",
                Location = new Point(100, 10),
                Size = new Size(40, 30),
                BackColor = Color.FromArgb(62, 62, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14),
                Cursor = Cursors.Hand
            };
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.Click += RefreshButton_Click;
            controlPanel.Controls.Add(refreshButton);

            // URL TextBox
            urlTextBox = new TextBox
            {
                Location = new Point(150, 12),
                Size = new Size(950, 30),
                Font = new Font("Segoe UI", 11),
                Text = "https://www.google.com"
            };
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.KeyDown += UrlTextBox_KeyDown;
            controlPanel.Controls.Add(urlTextBox);

            // Go Button
            goButton = new Button
            {
                Text = "Go",
                Location = new Point(1110, 10),
                Size = new Size(70, 30),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            goButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            goButton.FlatAppearance.BorderSize = 0;
            goButton.Click += GoButton_Click;
            controlPanel.Controls.Add(goButton);

            // WebView2
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);
        }

        private async void InitializeWebView()
        {
            if (webView != null)
            {
                try
                {
                    await webView.EnsureCoreWebView2Async(null);
                    webView.CoreWebView2.Navigate("https://www.google.com");
                    
                    // Update URL bar when navigation occurs
                    webView.CoreWebView2.NavigationStarting += (s, e) =>
                    {
                        if (urlTextBox != null)
                        {
                            urlTextBox.Text = e.Uri;
                        }
                    };

                    // Update navigation buttons
                    webView.CoreWebView2.NavigationCompleted += (s, e) =>
                    {
                        UpdateNavigationButtons();
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"WebView2 initialization failed: {ex.Message}\n\nPlease ensure WebView2 Runtime is installed.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeTrayIcon()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Shield,
                Visible = true,
                Text = "Bubble VPN Browser"
            };

            var trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Show", null, (s, e) => { this.Show(); this.WindowState = FormWindowState.Normal; });
            trayMenu.Items.Add("Toggle VPN", null, (s, e) => VpnToggleButton_Click(s, e));
            trayMenu.Items.Add("-");
            trayMenu.Items.Add("Exit", null, (s, e) => Application.Exit());
            
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.DoubleClick += (s, e) => { this.Show(); this.WindowState = FormWindowState.Normal; };
        }

        private void InitializeStatsTimer()
        {
            statsTimer = new System.Windows.Forms.Timer
            {
                Interval = 2000 // Update every 2 seconds
            };
            statsTimer.Tick += StatsTimer_Tick;
            statsTimer.Start();
        }

        private void StatsTimer_Tick(object? sender, EventArgs e)
        {
            if (vpnService.IsConnected && statsLabel != null)
            {
                var stats = vpnService.GetStatistics();
                statsLabel.Text = $"↑ {FormatBytes(stats.BytesSent)} | ↓ {FormatBytes(stats.BytesReceived)} | ⏱ {stats.ConnectionTime:mm\\:ss}";
            }
        }

        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void UpdateNavigationButtons()
        {
            if (webView?.CoreWebView2 != null)
            {
                if (backButton != null)
                    backButton.Enabled = webView.CoreWebView2.CanGoBack;
                if (forwardButton != null)
                    forwardButton.Enabled = webView.CoreWebView2.CanGoForward;
            }
        }

        private void VpnService_StatusChanged(object? sender, VPNStatusEventArgs e)
        {
            this.Invoke(() =>
            {
                if (trayIcon != null)
                {
                    trayIcon.ShowBalloonTip(2000, "Bubble VPN", e.Message, 
                        e.IsConnected ? ToolTipIcon.Info : ToolTipIcon.Warning);
                }
            });
        }

        private void VpnToggleButton_Click(object? sender, EventArgs e)
        {
            if (vpnService.IsConnected)
            {
                DisableVPN();
            }
            else
            {
                EnableVPN();
            }
        }

        private void EnableVPN()
        {
            try
            {
                vpnService.Connect();

                // Update UI
                if (statusLabel != null)
                {
                    statusLabel.Text = "VPN: CONNECTED ✓";
                    statusLabel.ForeColor = Color.LimeGreen;
                }

                if (vpnToggleButton != null)
                {
                    vpnToggleButton.Text = "🛡️ Disable VPN";
                    vpnToggleButton.BackColor = Color.OrangeRed;
                }

                if (statusPanel != null)
                {
                    statusPanel.BackColor = Color.FromArgb(0, 64, 0);
                }

                if (trayIcon != null)
                {
                    trayIcon.Text = "Bubble VPN Browser - Connected";
                }

                MessageBox.Show(
                    "VPN Enabled!\n\n" +
                    "✓ Traffic Obfuscation: Active\n" +
                    "✓ Firewall Bypass: Enabled\n" +
                    "✓ Secure Connection: Established\n\n" +
                    "Your browsing is now protected.",
                    "VPN Connected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to enable VPN: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableVPN()
        {
            vpnService.Disconnect();

            // Update UI
            if (statusLabel != null)
            {
                statusLabel.Text = "VPN: DISCONNECTED";
                statusLabel.ForeColor = Color.OrangeRed;
            }

            if (statsLabel != null)
            {
                statsLabel.Text = "Ready to connect";
            }

            if (vpnToggleButton != null)
            {
                vpnToggleButton.Text = "🛡️ Enable VPN";
                vpnToggleButton.BackColor = Color.FromArgb(0, 122, 204);
            }

            if (statusPanel != null)
            {
                statusPanel.BackColor = Color.FromArgb(45, 45, 48);
            }

            if (trayIcon != null)
            {
                trayIcon.Text = "Bubble VPN Browser - Disconnected";
            }
        }

        private void BackButton_Click(object? sender, EventArgs e)
        {
            if (webView?.CoreWebView2?.CanGoBack == true)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void ForwardButton_Click(object? sender, EventArgs e)
        {
            if (webView?.CoreWebView2?.CanGoForward == true)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void RefreshButton_Click(object? sender, EventArgs e)
        {
            webView?.CoreWebView2?.Reload();
        }

        private void GoButton_Click(object? sender, EventArgs e)
        {
            NavigateToUrl();
        }

        private void UrlTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateToUrl();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void NavigateToUrl()
        {
            if (webView?.CoreWebView2 != null && urlTextBox != null)
            {
                string url = urlTextBox.Text;
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                try
                {
                    webView.CoreWebView2.Navigate(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Navigation error: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                statsTimer?.Stop();
                statsTimer?.Dispose();
                trayIcon?.Dispose();
                webView?.Dispose();
                urlTextBox?.Dispose();
                goButton?.Dispose();
                backButton?.Dispose();
                forwardButton?.Dispose();
                refreshButton?.Dispose();
                vpnToggleButton?.Dispose();
                statusLabel?.Dispose();
                statsLabel?.Dispose();
                controlPanel?.Dispose();
                statusPanel?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                if (trayIcon != null)
                {
                    trayIcon.ShowBalloonTip(1000, "Bubble VPN", 
                        "Application minimized to tray. Double-click to restore.", 
                        ToolTipIcon.Info);
                }
            }
            base.OnFormClosing(e);
        }
    }
}
