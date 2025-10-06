# Quick Start Guide - Bubble BUBBL Browser

Get up and running in 5 minutes!

## Step 1: Open in Visual Studio 2022

1. Launch **Visual Studio 2022**
2. Click **"Open a project or solution"**
3. Navigate to the Bubble folder
4. Select **`Bubble.sln`**
5. Click **Open**

## Step 2: Build the Solution

Option A: Use the toolbar
- Click **Build** menu → **Build Solution**

Option B: Use keyboard shortcut
- Press **F6**

Wait for the build to complete. You should see:
```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

## Step 3: Run the Application

Option A: Start with debugging (recommended for first run)
- Press **F5**

Option B: Start without debugging
- Press **Ctrl+F5**

The Bubble BUBBL Browser window will open!

## Step 4: Use the BUBBL Browser

### Enable BUBBL Protection
1. Look at the top status bar
2. Click the **"🛡️ Enable BUBBL"** button
3. A confirmation dialog will appear
4. Click **OK**
5. The status bar turns **green** ✓

### Browse the Web
1. Type a URL in the address bar (e.g., `google.com`)
2. Press **Enter** or click **Go**
3. Browse as you normally would
4. Your traffic is now obfuscated!

### View Statistics
When BUBBL is enabled, you'll see real-time stats:
- ↑ Data sent
- ↓ Data received  
- ⏱ Connection time

### Disable BUBBL
1. Click the **"🛡️ Disable BUBBL"** button
2. Status returns to disconnected

### Minimize to Tray
1. Click the **X** button to close
2. The app minimizes to system tray (doesn't exit)
3. Double-click the tray icon to restore

## Troubleshooting

### "WebView2 Runtime not found"
**Solution**: Install Microsoft Edge WebView2 Runtime
- Download from: https://developer.microsoft.com/microsoft-edge/webview2/
- Install and restart the application

### Build Errors
**Solution**: Check prerequisites
- Ensure Visual Studio 2022 is installed
- Verify .NET 8.0 SDK is available
- Try **Build** → **Clean Solution**, then rebuild

### Application Won't Start
**Solution**: Run as Administrator
- Right-click Visual Studio 2022
- Select **"Run as Administrator"**
- Open and run the project again

## Next Steps

- Read the [User Guide](USER_GUIDE.md) for detailed features
- Check the [Development Guide](DEVELOPMENT.md) to customize
- Explore the code in Visual Studio

## Key Features at a Glance

| Feature | Description |
|---------|-------------|
| 🛡️ **BUBBL Toggle** | One-click enable/disable |
| 🌐 **Full Browser** | Chromium-powered browsing |
| 📊 **Statistics** | Real-time traffic monitoring |
| 🔒 **Obfuscation** | Traffic protection when BUBBL on |
| 🔔 **Notifications** | Status updates in system tray |
| ⚡ **Fast** | Native Windows performance |

## Visual Studio Tips

### Viewing Code
- Press **F7** to view the code editor
- Press **Shift+F7** to return to designer (if available)

### IntelliSense
- Press **Ctrl+Space** for code suggestions
- Use it while typing to autocomplete

### Quick Actions
- Press **Ctrl+.** for quick fixes and refactoring

### Go to Definition
- Press **F12** on any method/class to see its definition

## What You've Built

✓ A complete Windows application  
✓ WebView2 browser integration  
✓ BUBBL functionality with obfuscation  
✓ Modern UI with dark theme  
✓ System tray integration  
✓ Real-time statistics  
✓ Navigation controls  

## Running Outside Visual Studio

After building, you can find the executable at:
```
Bubble/BubbleBUBBL/bin/Debug/net8.0-windows/BubbleBUBBL.exe
```

Double-click to run without Visual Studio!

---

**Congratulations!** You now have a working BUBBL browser running from Visual Studio 2022. 🎉

For more information, see:
- [README.md](README.md) - Project overview
- [USER_GUIDE.md](USER_GUIDE.md) - Complete user documentation
- [DEVELOPMENT.md](DEVELOPMENT.md) - Development details
- [UI_MOCKUP.md](UI_MOCKUP.md) - Interface design
