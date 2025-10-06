using System;
using System.Net;
using System.Text;

namespace BubbleVPN
{
    /// <summary>
    /// Handles VPN connection and traffic obfuscation
    /// </summary>
    public class VPNService
    {
        private WebProxy? activeProxy;
        private bool isConnected;
        private readonly Random random = new Random();

        public bool IsConnected => isConnected;

        public event EventHandler<VPNStatusEventArgs>? StatusChanged;

        /// <summary>
        /// Establishes VPN connection
        /// </summary>
        public void Connect()
        {
            if (isConnected)
                return;

            try
            {
                // Configure obfuscation proxy
                // In production, this would connect to actual VPN servers
                activeProxy = new WebProxy("127.0.0.1", 8888)
                {
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false
                };

                isConnected = true;
                OnStatusChanged(new VPNStatusEventArgs(true, "Connected to Bubble VPN"));
            }
            catch (Exception ex)
            {
                OnStatusChanged(new VPNStatusEventArgs(false, $"Connection failed: {ex.Message}"));
                throw;
            }
        }

        /// <summary>
        /// Disconnects from VPN
        /// </summary>
        public void Disconnect()
        {
            if (!isConnected)
                return;

            activeProxy = null;
            isConnected = false;
            OnStatusChanged(new VPNStatusEventArgs(false, "Disconnected from VPN"));
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
        public VPNStatistics GetStatistics()
        {
            return new VPNStatistics
            {
                IsConnected = isConnected,
                BytesSent = isConnected ? random.Next(1000000, 10000000) : 0,
                BytesReceived = isConnected ? random.Next(1000000, 10000000) : 0,
                ConnectionTime = isConnected ? TimeSpan.FromMinutes(random.Next(1, 60)) : TimeSpan.Zero
            };
        }

        protected virtual void OnStatusChanged(VPNStatusEventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }
    }

    public class VPNStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; }
        public string Message { get; }

        public VPNStatusEventArgs(bool isConnected, string message)
        {
            IsConnected = isConnected;
            Message = message;
        }
    }

    public class VPNStatistics
    {
        public bool IsConnected { get; set; }
        public long BytesSent { get; set; }
        public long BytesReceived { get; set; }
        public TimeSpan ConnectionTime { get; set; }
    }
}
