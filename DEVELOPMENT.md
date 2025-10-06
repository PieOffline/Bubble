# Development Guide - Bubble VPN Browser

## Visual Studio 2022 Setup

### Opening the Project
1. Launch Visual Studio 2022
2. Click **Open a project or solution**
3. Navigate to the Bubble folder
4. Select `Bubble.sln`
5. Wait for the solution to load

### Project Structure
```
Bubble/
├── Bubble.sln              # Visual Studio solution
└── BubbleVPN/              # Main project
    ├── BubbleVPN.csproj    # Project configuration
    ├── Program.cs          # Application entry point
    ├── MainForm.cs         # Main UI form
    ├── VPNService.cs       # VPN connection logic
    └── Properties/         # Project properties
        └── launchSettings.json
```

## Building the Project

### Debug Build
1. Select **Debug** configuration in toolbar
2. Press **F6** or **Build > Build Solution**
3. Output appears in `bin/Debug/net8.0-windows/`

### Release Build
1. Select **Release** configuration
2. Build the solution
3. Output appears in `bin/Release/net8.0-windows/`

### Build Configuration
The project targets:
- **Framework**: .NET 8.0 Windows
- **Output Type**: Windows Application (WinExe)
- **Platform**: x64 (default)

## Running and Debugging

### Starting with Debugging (F5)
- Launches with debugger attached
- Breakpoints will pause execution
- Can inspect variables and call stack
- Console output visible in Output window

### Starting without Debugging (Ctrl+F5)
- Launches without debugger
- Faster startup
- Use for performance testing

### Debug Features
1. **Breakpoints**: Click left margin in code editor
2. **Watch Windows**: Monitor variable values
3. **Immediate Window**: Execute code during debugging
4. **Call Stack**: View execution path

## Code Architecture

### MainForm.cs
The primary UI component containing:
- WebView2 browser control
- VPN status panel
- Navigation controls
- System tray integration
- Event handlers

**Key Methods**:
- `InitializeComponent()`: Sets up UI elements
- `InitializeWebView()`: Configures WebView2
- `EnableVPN()`: Activates VPN connection
- `DisableVPN()`: Deactivates VPN

### VPNService.cs
Handles VPN functionality:
- Connection management
- Data obfuscation
- Statistics tracking
- Status notifications

**Key Methods**:
- `Connect()`: Establishes VPN connection
- `Disconnect()`: Closes VPN connection
- `ObfuscateData()`: Encrypts data
- `GetStatistics()`: Returns connection stats

### Program.cs
Application entry point:
- Initializes Windows Forms
- Creates and shows MainForm
- Manages application lifecycle

## Adding Features

### Adding New UI Elements
1. Open `MainForm.cs`
2. Add field declaration (e.g., `private Button? newButton;`)
3. Create element in `InitializeComponent()`
4. Add to appropriate container
5. Wire up event handlers

### Adding VPN Features
1. Open `VPNService.cs`
2. Add new method or property
3. Update `MainForm.cs` to use new feature
4. Test thoroughly

### Example: Adding a Settings Button
```csharp
// In MainForm.cs

// Field
private Button? settingsButton;

// In InitializeComponent()
settingsButton = new Button
{
    Text = "⚙",
    Location = new Point(420, 15),
    Size = new Size(40, 50),
    // ... other properties
};
settingsButton.Click += SettingsButton_Click;
statusPanel.Controls.Add(settingsButton);

// Event handler
private void SettingsButton_Click(object? sender, EventArgs e)
{
    // Show settings dialog
    MessageBox.Show("Settings dialog would appear here");
}
```

## Testing

### Manual Testing Checklist
- [ ] Application launches successfully
- [ ] WebView2 loads Google.com
- [ ] URL bar accepts input
- [ ] Navigation buttons work
- [ ] VPN enables/disables correctly
- [ ] Status updates properly
- [ ] System tray functions work
- [ ] Statistics update when VPN active
- [ ] Application minimizes to tray
- [ ] Application restores from tray

### Testing VPN Functionality
1. Enable VPN
2. Verify status changes to green
3. Check statistics update
4. Browse to different websites
5. Disable VPN
6. Verify status returns to disconnected

### Testing UI Responsiveness
1. Resize window
2. Minimize/maximize
3. Close to tray
4. Restore from tray
5. Test all buttons

## Common Development Tasks

### Changing Colors/Themes
Colors are defined in `InitializeComponent()`:
```csharp
BackColor = Color.FromArgb(45, 45, 48)  // Dark theme
BackColor = Color.FromArgb(0, 122, 204) // Blue accent
```

### Adding New Pages/Forms
1. **Add New Item** > **Form (Windows Forms)**
2. Name the form
3. Design in the Forms Designer
4. Show from MainForm: `new MyForm().Show()`

### Modifying WebView2 Behavior
```csharp
// In InitializeWebView()
webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
webView.CoreWebView2.Settings.AreDevToolsEnabled = true;
```

### Adding NuGet Packages
1. Right-click project > **Manage NuGet Packages**
2. Search for package
3. Click Install
4. Package added to `.csproj`

## Deployment

### Creating Executable
1. Build in **Release** configuration
2. Navigate to `bin/Release/net8.0-windows/`
3. `BubbleVPN.exe` is ready to distribute

### Publishing
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

This creates a self-contained deployment including .NET runtime.

### Creating Installer
Consider using:
- **WiX Toolset**: MSI installers
- **Inno Setup**: Free installer creator
- **MSIX**: Modern Windows packaging

## Debugging Tips

### WebView2 DevTools
Enable developer tools:
```csharp
webView.CoreWebView2.OpenDevToolsWindow();
```

### Common Issues

**Issue**: WebView2 won't initialize
- Check WebView2 Runtime is installed
- Try running as Administrator
- Check for .NET runtime errors

**Issue**: Forms Designer won't open
- Rebuild the project
- Close and reopen Visual Studio
- Check for compilation errors

**Issue**: UI elements not appearing
- Verify Dock/Anchor properties
- Check Z-order (bring to front/send to back)
- Ensure added to correct container

## Performance Optimization

### Reducing Memory Usage
- Dispose of unused controls
- Clear WebView2 cache periodically
- Use `using` statements for IDisposable

### Improving Startup Time
- Lazy-load heavy components
- Initialize WebView2 asynchronously
- Defer non-critical initializations

### Smooth UI
- Use async/await for long operations
- Don't block UI thread
- Update UI on UI thread only

## Best Practices

### Code Style
- Use nullable reference types (`?`)
- Follow C# naming conventions
- Add XML documentation comments
- Keep methods focused and small

### Error Handling
```csharp
try
{
    // Risky operation
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

### Resource Management
```csharp
protected override void Dispose(bool disposing)
{
    if (disposing)
    {
        component?.Dispose();
    }
    base.Dispose(disposing);
}
```

## Visual Studio Shortcuts

### Essential Shortcuts
- **F5**: Start debugging
- **Ctrl+F5**: Start without debugging
- **F6**: Build solution
- **F7**: View code
- **Shift+F7**: View designer
- **Ctrl+K, Ctrl+D**: Format document
- **Ctrl+.**: Show quick actions
- **F12**: Go to definition
- **Ctrl+Space**: IntelliSense

### Navigation
- **Ctrl+,**: Go to file/type
- **Ctrl+T**: Go to all
- **Ctrl+-**: Navigate backward
- **Ctrl+Shift+-**: Navigate forward

### Debugging
- **F9**: Toggle breakpoint
- **F10**: Step over
- **F11**: Step into
- **Shift+F11**: Step out
- **Ctrl+Shift+F9**: Delete all breakpoints

## Resources

### Documentation
- [.NET 8 Documentation](https://docs.microsoft.com/dotnet/)
- [Windows Forms Guide](https://docs.microsoft.com/dotnet/desktop/winforms/)
- [WebView2 Documentation](https://docs.microsoft.com/microsoft-edge/webview2/)

### Tools
- **Visual Studio 2022**: Primary IDE
- **NuGet**: Package management
- **GitHub**: Version control

## Contributing

When contributing code:
1. Follow existing code style
2. Add comments for complex logic
3. Test thoroughly
4. Update documentation
5. Create meaningful commit messages

## Getting Help

### In Visual Studio
- **View > Error List**: See compilation errors
- **View > Output**: See build/debug output
- **Help > View Help**: Access documentation

### Online Resources
- Visual Studio documentation
- Stack Overflow
- GitHub Issues
- .NET community forums

---

Happy coding! 🚀
