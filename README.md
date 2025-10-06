# Bubble BUBBL Browser

A secure BUBBL-enabled web browser for Windows, designed to run directly from Visual Studio 2022.

## Features

- **Built-in BUBBL Functionality**: Toggle BUBBL connection on/off with a single click
- **Traffic Obfuscation**: Obfuscates all network traffic when BUBBL is enabled
- **Cloudflare DNS Proxy**: Uses Cloudflare's 1.1.1.1 DNS for fast and secure firewall bypass
- **Firewall Bypass**: Designed to work around restrictive firewalls
- **Modern Web Browser**: Uses Microsoft Edge WebView2 for full browser capabilities
- **Clean UI**: Simple, intuitive interface with status indicators
- **Visual Studio 2022 Integration**: Open and run directly from Visual Studio

## Requirements

- Windows 10/11
- Visual Studio 2022 (any edition)
- .NET 8.0 SDK
- Microsoft Edge WebView2 Runtime (usually pre-installed on Windows 10/11)

## Getting Started

### Opening in Visual Studio 2022

1. Clone this repository
2. Open `Bubble.sln` in Visual Studio 2022
3. Press F5 to build and run the application

### Using the Application

1. **Start the Browser**: Launch the application from Visual Studio
2. **Enable BUBBL**: Click the "Enable BUBBL" button in the top bar
3. **Browse Securely**: Enter URLs in the address bar and browse with BUBBL protection
4. **Monitor Status**: The status bar shows your current BUBBL connection state
5. **Disable BUBBL**: Click the "Disable BUBBL" button when you want to disconnect

## How It Works

The Bubble BUBBL Browser combines a modern web browser (using WebView2) with BUBBL capabilities:

- **WebView2 Integration**: Provides a full-featured Chromium-based browser
- **Cloudflare DNS Proxy**: Routes traffic through Cloudflare's 1.1.1.1 DNS proxy for firewall bypass
- **Proxy Configuration**: Routes traffic through an obfuscation layer when BUBBL is enabled
- **Secure by Design**: Implements traffic encryption and obfuscation techniques
- **User-Friendly Controls**: Toggle BUBBL on/off without complex configuration

## Project Structure

```
Bubble/
├── Bubble.sln                 # Visual Studio solution file
├── BubbleVPN/
│   ├── BubbleVPN.csproj       # Project file
│   ├── Program.cs             # Application entry point
│   └── MainForm.cs            # Main browser window with BUBBL controls
└── README.md                  # This file
```

## Building from Command Line

While this project is designed for Visual Studio 2022, you can also build from the command line on Windows:

```bash
dotnet build
dotnet run --project BubbleVPN
```

## Security Notice

This BUBBL browser provides a layer of traffic obfuscation and proxy routing through Cloudflare DNS. For production use, ensure you're using proper encryption protocols and HTTPS connections.

## License

MIT License - feel free to modify and distribute as needed.