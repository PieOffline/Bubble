# Bubble VPN Browser - User Guide

## Table of Contents
1. [Installation](#installation)
2. [Getting Started](#getting-started)
3. [Features](#features)
4. [Using the VPN](#using-the-vpn)
5. [Browser Controls](#browser-controls)
6. [System Tray](#system-tray)
7. [Troubleshooting](#troubleshooting)

## Installation

### Prerequisites
- Windows 10 or Windows 11
- Visual Studio 2022 (Community, Professional, or Enterprise)
- .NET 8.0 SDK (included with Visual Studio 2022)
- Microsoft Edge WebView2 Runtime (usually pre-installed)

### Steps
1. Clone or download the Bubble repository
2. Open `Bubble.sln` in Visual Studio 2022
3. Build the solution (F6 or Build > Build Solution)
4. Run the application (F5 or Debug > Start Debugging)

## Getting Started

When you first launch Bubble VPN Browser, you'll see:

- **Status Bar** (top): Shows VPN connection status
- **Navigation Bar**: Contains browser controls and URL bar
- **Main Browser**: WebView2-powered browser window

### First Launch
1. The browser will automatically navigate to Google
2. VPN will be **disabled** by default
3. The application will minimize to the system tray when closed

## Features

### 🛡️ VPN Protection
- **One-Click Enable/Disable**: Toggle VPN with a single button click
- **Traffic Obfuscation**: All data is obfuscated when VPN is active
- **Firewall Bypass**: Designed to work around restrictive firewalls
- **Real-time Statistics**: View data sent/received and connection time

### 🌐 Modern Browser
- **Full Chromium Support**: Powered by Microsoft Edge WebView2
- **Standard Navigation**: Back, forward, refresh buttons
- **URL Bar**: Direct navigation to any website
- **Modern Web Standards**: Supports all modern web technologies

### 💾 System Tray Integration
- **Minimize to Tray**: Application continues running in background
- **Quick Access**: Double-click tray icon to restore
- **Context Menu**: Right-click for quick actions

## Using the VPN

### Enabling VPN
1. Click the **"🛡️ Enable VPN"** button in the status bar
2. Wait for connection confirmation dialog
3. Status changes to **"VPN: CONNECTED ✓"** in green
4. Statistics begin updating every 2 seconds

### What Happens When VPN is Enabled
- Traffic obfuscation activates
- Proxy configuration applies
- Status bar turns green
- System tray icon updates
- Real-time statistics display

### Disabling VPN
1. Click the **"🛡️ Disable VPN"** button
2. Status changes to **"VPN: DISCONNECTED"**
3. Status bar turns back to default color
4. Statistics stop updating

### VPN Status Indicators
| Status | Color | Meaning |
|--------|-------|---------|
| DISCONNECTED | Red/Orange | VPN is off, normal browsing |
| CONNECTED ✓ | Green | VPN is active, traffic protected |

## Browser Controls

### Navigation Buttons
- **◀ Back**: Navigate to previous page (keyboard: Alt+Left)
- **▶ Forward**: Navigate to next page (keyboard: Alt+Right)
- **⟳ Refresh**: Reload current page (keyboard: F5)

### URL Bar
- Type any URL and press **Enter** or click **Go**
- Automatically adds `https://` if not specified
- Updates automatically as you navigate

### Keyboard Shortcuts
- **F5**: Refresh current page
- **Alt+Left**: Go back
- **Alt+Right**: Go forward
- **Ctrl+W**: Close to tray
- **Enter** (in URL bar): Navigate to URL

## System Tray

### Accessing System Tray
Look for the shield icon (🛡️) in your Windows system tray (bottom-right corner).

### Tray Actions
- **Double-Click**: Restore the main window
- **Right-Click Menu**:
  - **Show**: Restore the main window
  - **Toggle VPN**: Enable/disable VPN without opening window
  - **Exit**: Completely close the application

### Balloon Notifications
The application shows notifications for:
- VPN connection status changes
- Application minimized to tray
- Important status updates

## Troubleshooting

### WebView2 Not Found
**Problem**: Error message about WebView2 Runtime

**Solution**:
1. Download WebView2 Runtime from [Microsoft's website](https://developer.microsoft.com/microsoft-edge/webview2/)
2. Install the runtime
3. Restart the application

### Application Won't Start
**Problem**: Application crashes on startup

**Solution**:
1. Verify .NET 8.0 is installed
2. Run Visual Studio as Administrator
3. Clean and rebuild the solution
4. Check Windows Event Viewer for errors

### VPN Connection Issues
**Problem**: VPN won't enable

**Solution**:
1. Check firewall settings
2. Ensure no other VPN is running
3. Try running as Administrator
4. Check the application logs

### Navigation Problems
**Problem**: Websites won't load

**Solution**:
1. Verify internet connection
2. Try disabling VPN temporarily
3. Clear WebView2 cache
4. Check if website is accessible in other browsers

### Performance Issues
**Problem**: Browser is slow

**Solution**:
1. Close unnecessary tabs/windows
2. Disable VPN if not needed
3. Clear browser cache
4. Check system resources

## Advanced Configuration

### Proxy Settings
The VPN uses a local proxy configuration. Default settings:
- **Host**: 127.0.0.1
- **Port**: 8888

### Data Obfuscation
When VPN is enabled:
- XOR-based obfuscation (demonstration)
- Real-time data encryption
- Automatic key generation

**Note**: For production use, implement stronger encryption (AES-256, TLS 1.3).

## Security Considerations

### What This Protects
✓ Traffic obfuscation
✓ Basic firewall bypass
✓ Network anonymization layer

### What This Doesn't Protect
✗ End-to-end encryption (add HTTPS)
✗ DNS leaks (requires DNS configuration)
✗ Advanced traffic analysis

### Best Practices
1. Always use HTTPS websites
2. Keep the application updated
3. Use trusted networks when possible
4. Don't share sensitive data over unencrypted connections

## Support

### Getting Help
- Check this user guide first
- Review the README.md for technical details
- Check GitHub issues for known problems
- Create a new issue for bugs or feature requests

### Contributing
Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## Version Information
- **Application**: Bubble VPN Browser
- **Version**: 1.0.0
- **Framework**: .NET 8.0
- **Platform**: Windows 10/11

---

**Note**: This is a demonstration VPN browser. For production use, implement proper encryption protocols, secure VPN servers, and follow security best practices.
