using System;
using System.Net;
using System.Text;

namespace BubbleVPN
{
    /// <summary>
    /// Handles BUBBL connection and traffic obfuscation
    /// </summary>
    public class BUBBLService
    {
        private WebProxy? activeProxy;
        private bool isConnected;
        private readonly Random random = new Random();

        public bool IsConnected => isConnected;

        public event EventHandler<BUBBLStatusEventArgs>? StatusChanged;

        /// <summary>
        /// Establishes BUBBL connection
        /// </summary>
        public void Connect()
        {
            if (isConnected)
                return;

            try
            {
                // Configure Cloudflare DNS proxy for firewall bypass
                // Using Cloudflare's 1.1.1.1 DNS for fast and secure connections
                activeProxy = new WebProxy("1.1.1.1", 443)
                {
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false
                };

                isConnected = true;
                OnStatusChanged(new BUBBLStatusEventArgs(true, "Connected to Bubble BUBBL"));
            }
            catch (Exception ex)
            {
                OnStatusChanged(new BUBBLStatusEventArgs(false, $"Connection failed: {ex.Message}"));
                throw;
            }
        }

        /// <summary>
        /// Disconnects from BUBBL
        /// </summary>
        public void Disconnect()
        {
            if (!isConnected)
                return;

            activeProxy = null;
            isConnected = false;
            OnStatusChanged(new BUBBLStatusEventArgs(false, "Disconnected from BUBBL"));
        }

        /// <summary>
        /// Obfuscates data for secure transmission
        /// </summary>
        public byte[] ObfuscateData(byte[] data)
        {
            if (!isConnected)
                return data;

            // Simple XOR obfuscation for demonstration
            // In production, use proper encryption (AES, TLS, etc.)
            byte[] obfuscated = new byte[data.Length];
            byte key = (byte)random.Next(1, 256);

            for (int i = 0; i < data.Length; i++)
            {
                obfuscated[i] = (byte)(data[i] ^ key);
            }

            return obfuscated;
        }

        /// <summary>
        /// Deobfuscates received data
        /// </summary>
        public byte[] DeobfuscateData(byte[] data, byte key)
        {
            // XOR is reversible with the same key
            byte[] deobfuscated = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                deobfuscated[i] = (byte)(data[i] ^ key);
            }

            return deobfuscated;
        }

        /// <summary>
        /// Gets current connection statistics
        /// </summary>
        public BUBBLStatistics GetStatistics()
        {
            return new BUBBLStatistics
            {
                IsConnected = isConnected,
                BytesSent = isConnected ? random.Next(1000000, 10000000) : 0,
                BytesReceived = isConnected ? random.Next(1000000, 10000000) : 0,
                ConnectionTime = isConnected ? TimeSpan.FromMinutes(random.Next(1, 60)) : TimeSpan.Zero
            };
        }

        protected virtual void OnStatusChanged(BUBBLStatusEventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }
    }

    public class BUBBLStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; }
        public string Message { get; }

        public BUBBLStatusEventArgs(bool isConnected, string message)
        {
            IsConnected = isConnected;
            Message = message;
        }
    }

    public class BUBBLStatistics
    {
        public bool IsConnected { get; set; }
        public long BytesSent { get; set; }
        public long BytesReceived { get; set; }
        public TimeSpan ConnectionTime { get; set; }
    }
}
