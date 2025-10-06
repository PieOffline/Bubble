# Build Instructions - Bubble BUBBL Browser

## Prerequisites

Before building, ensure you have:

### Required Software
1. **Windows 10 or Windows 11**
   - 64-bit version recommended
   - Latest updates installed

2. **Visual Studio 2022** (any edition)
   - Community (free): https://visualstudio.microsoft.com/vs/community/
   - Professional or Enterprise
   - Version 17.0 or later

3. **Visual Studio Workloads**
   When installing Visual Studio 2022, select:
   - ✅ ".NET desktop development" workload
   - This includes:
     - .NET 8.0 SDK
     - Windows Forms components
     - NuGet package manager

4. **Microsoft Edge WebView2 Runtime**
   - Usually pre-installed on Windows 10/11
   - If not installed: https://developer.microsoft.com/microsoft-edge/webview2/
   - Download the "Evergreen Standalone Installer"

### Verify Installation

**Check .NET SDK:**
```cmd
dotnet --version
```
Should show version 8.0.x or later

**Check Visual Studio:**
- Open Visual Studio
- Help → About Microsoft Visual Studio
- Should show version 17.x (Visual Studio 2022)

## Building from Visual Studio 2022

### Method 1: Using Visual Studio GUI

1. **Open the Solution**
   - Launch Visual Studio 2022
   - File → Open → Project/Solution (or Ctrl+Shift+O)
   - Navigate to the Bubble folder
   - Select `Bubble.sln`
   - Click "Open"

2. **Restore NuGet Packages** (automatic)
   - Visual Studio automatically restores packages
   - Wait for "Ready" to appear in status bar
   - If not automatic: Tools → NuGet Package Manager → Restore NuGet Packages

3. **Select Configuration**
   - In toolbar, select configuration dropdown
   - Choose "Debug" (for development) or "Release" (for production)
   - Platform: "Any CPU" (default)

4. **Build the Solution**
   - Option A: Press **F6**
   - Option B: Build menu → Build Solution
   - Option C: Ctrl+Shift+B

5. **Check Build Output**
   ```
   ========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
   ```

6. **Run the Application**
   - Option A: Press **F5** (with debugging)
   - Option B: Press **Ctrl+F5** (without debugging)
   - Option C: Debug menu → Start Debugging/Start Without Debugging

### Method 2: Using Visual Studio Code

**Not recommended** - This is a Windows Forms project best opened in Visual Studio 2022.

However, if you prefer VS Code:
1. Install C# Dev Kit extension
2. Open folder in VS Code
3. Use Terminal to build: `dotnet build`
4. Run: `dotnet run --project BubbleBUBBL`

## Building from Command Line

### Open Developer Command Prompt

**Option A:** From Start Menu
1. Search for "Developer Command Prompt for VS 2022"
2. Click to open

**Option B:** From Windows Terminal
1. Open Windows Terminal
2. Select "Developer Command Prompt for VS 2022" profile

**Option C:** From Regular Command Prompt
1. Open Command Prompt
2. Navigate to Visual Studio installation
3. Run `VsDevCmd.bat`

### Build Commands

**Navigate to project directory:**
```cmd
cd C:\path\to\Bubble
```

**Restore packages:**
```cmd
dotnet restore
```

**Build Debug configuration:**
```cmd
dotnet build
```

**Build Release configuration:**
```cmd
dotnet build -c Release
```

**Build and run:**
```cmd
dotnet run --project BubbleBUBBL
```

**Clean build:**
```cmd
dotnet clean
dotnet build
```

## Build Output Locations

### Debug Build
```
Bubble/BubbleBUBBL/bin/Debug/net8.0-windows/
├── BubbleBUBBL.exe          (Main executable)
├── BubbleBUBBL.dll
├── BubbleBUBBL.pdb          (Debug symbols)
├── BubbleBUBBL.deps.json
├── BubbleBUBBL.runtimeconfig.json
└── runtimes/              (WebView2 files)
```

### Release Build
```
Bubble/BubbleBUBBL/bin/Release/net8.0-windows/
├── BubbleBUBBL.exe          (Optimized executable)
├── BubbleBUBBL.dll
├── BubbleBUBBL.deps.json
├── BubbleBUBBL.runtimeconfig.json
└── runtimes/              (WebView2 files)
```

## Publishing for Distribution

### Create Self-Contained Executable

**For 64-bit Windows:**
```cmd
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

**Output location:**
```
Bubble/BubbleBUBBL/bin/Release/net8.0-windows/win-x64/publish/
└── BubbleBUBBL.exe (Self-contained, ~100 MB)
```

**For 32-bit Windows:**
```cmd
dotnet publish -c Release -r win-x86 --self-contained -p:PublishSingleFile=true
```

### Create Framework-Dependent Executable

**Smaller file size, requires .NET 8.0 installed:**
```cmd
dotnet publish -c Release -r win-x64 --no-self-contained
```

**Output:**
```
Bubble/BubbleBUBBL/bin/Release/net8.0-windows/win-x64/publish/
└── BubbleBUBBL.exe (~5 MB, requires .NET 8.0 Runtime)
```

## Build Configurations Explained

### Debug Configuration
- **Purpose**: Development and debugging
- **Optimizations**: Disabled
- **Debug Symbols**: Included (.pdb files)
- **File Size**: Larger
- **Performance**: Slower
- **When to use**: During development, testing, debugging

### Release Configuration
- **Purpose**: Production deployment
- **Optimizations**: Enabled
- **Debug Symbols**: Optional
- **File Size**: Smaller
- **Performance**: Faster
- **When to use**: Final builds for users

## Troubleshooting Build Issues

### Issue: "WebView2 SDK not found"

**Solution:**
```cmd
dotnet add package Microsoft.Web.WebView2 --version 1.0.2420.47
```

### Issue: "Target framework 'net8.0-windows' not found"

**Solution:**
1. Install .NET 8.0 SDK: https://dotnet.microsoft.com/download/dotnet/8.0
2. Verify installation: `dotnet --list-sdks`
3. Restart Visual Studio

### Issue: "MSBuild not found"

**Solution:**
- Open "Developer Command Prompt for VS 2022"
- Or add MSBuild to PATH:
  ```
  C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin
  ```

### Issue: "NuGet package restore failed"

**Solution:**
1. Check internet connection
2. Clear NuGet cache:
   ```cmd
   dotnet nuget locals all --clear
   ```
3. Restore again:
   ```cmd
   dotnet restore
   ```

### Issue: "Cannot build on Linux/Mac"

**Explanation:**
- This is a Windows Forms application
- Can only be built on Windows
- Requires Windows SDK

**Workaround for viewing code:**
- Clone repository on Linux/Mac
- View and edit code
- Build using Windows VM or CI/CD

### Issue: Build succeeds but app won't run

**Possible causes:**
1. WebView2 Runtime not installed
   - Install from Microsoft website
2. .NET Runtime not installed (framework-dependent builds)
   - Install .NET 8.0 Desktop Runtime
3. Missing dependencies
   - Build in Release mode
   - Check output folder for all files

## Continuous Integration / CI/CD

### GitHub Actions (Windows Runner)

```yaml
name: Build

on: [push, pull_request]

jobs:
  build:
    runs-on: windows-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '8.0.x'
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --configuration Release --no-restore
    
    - name: Test
      run: dotnet test --no-build --verbosity normal
    
    - name: Publish
      run: dotnet publish -c Release -r win-x64 --self-contained
```

### Azure DevOps Pipeline

```yaml
trigger:
- main

pool:
  vmImage: 'windows-latest'

steps:
- task: UseDotNet@2
  inputs:
    version: '8.0.x'

- task: DotNetCoreCLI@2
  displayName: 'Restore packages'
  inputs:
    command: restore

- task: DotNetCoreCLI@2
  displayName: 'Build project'
  inputs:
    command: build
    arguments: '--configuration Release'

- task: DotNetCoreCLI@2
  displayName: 'Publish application'
  inputs:
    command: publish
    arguments: '-c Release -r win-x64 --self-contained'
    zipAfterPublish: true
```

## Build Performance Tips

### Speed up builds:

1. **Use SSD**: Build on SSD drive, not HDD
2. **Exclude from antivirus**: Add project folder to antivirus exclusions
3. **Close other applications**: Free up system resources
4. **Use incremental builds**: Don't clean unless necessary
5. **Parallel builds**: Visual Studio uses parallel builds by default

### Typical Build Times:

- **Clean build**: 10-30 seconds
- **Incremental build**: 2-5 seconds
- **Publish**: 30-60 seconds

## Build Verification

### After building, verify:

1. **Executable exists**
   - Navigate to output folder
   - Confirm `BubbleBUBBL.exe` is present

2. **Dependencies included**
   - Check for WebView2 runtime files
   - Verify .dll files present

3. **Application runs**
   - Double-click BubbleBUBBL.exe
   - Window should open
   - No error messages

4. **Features work**
   - BUBBL button clickable
   - Browser loads pages
   - System tray icon appears

## Next Steps

After successful build:
1. Run the application (F5 in Visual Studio)
2. Test BUBBL functionality
3. Browse some websites
4. Check system tray integration
5. Try minimizing and restoring
6. Review the [User Guide](USER_GUIDE.md)

## Getting Help

If build fails:
1. Check error messages in Output window
2. Review Error List (View → Error List)
3. Check this troubleshooting guide
4. Search error message online
5. Open GitHub issue with:
   - Visual Studio version
   - .NET SDK version
   - Full error message
   - Steps to reproduce

## Success Indicators

✅ NuGet packages restored  
✅ Build succeeded (0 errors)  
✅ Executable created  
✅ Application launches  
✅ BUBBL toggle works  
✅ Browser loads pages  
✅ System tray icon appears  

**You're ready to use Bubble BUBBL Browser!** 🎉

---

**Note:** These instructions are for Windows only. The application cannot be built on Linux or macOS due to Windows Forms and Windows-specific dependencies.
