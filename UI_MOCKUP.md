# Bubble VPN Browser - UI Mockup

## Main Window Layout

```
┌─────────────────────────────────────────────────────────────────────────┐
│  Bubble VPN Browser                                              [_][□][X]│
├─────────────────────────────────────────────────────────────────────────┤
│  STATUS PANEL (Green when connected, Gray when disconnected)            │
│  ┌─────────────────────────────────────────────────────────────────┐   │
│  │  VPN: CONNECTED ✓                    ┌──────────────────────┐   │   │
│  │  ↑ 2.5 MB | ↓ 5.3 MB | ⏱ 05:23      │  🛡️ Disable VPN    │   │   │
│  │                                       └──────────────────────┘   │   │
│  └─────────────────────────────────────────────────────────────────┘   │
├─────────────────────────────────────────────────────────────────────────┤
│  NAVIGATION BAR                                                          │
│  ┌──┬──┬──┬────────────────────────────────────────────────────┬─────┐ │
│  │◀ │▶ │⟳ │ https://www.example.com                          │ Go  │ │
│  └──┴──┴──┴────────────────────────────────────────────────────┴─────┘ │
├─────────────────────────────────────────────────────────────────────────┤
│                                                                           │
│                                                                           │
│                        WEB BROWSER CONTENT                                │
│                        (Microsoft Edge WebView2)                          │
│                                                                           │
│                                                                           │
│                                                                           │
│                                                                           │
│                                                                           │
│                                                                           │
└─────────────────────────────────────────────────────────────────────────┘
```

## UI Components

### Status Panel (Top Bar)
- **Background**: Dark gray (#2D2D30) when disconnected
- **Background**: Dark green (#004000) when connected
- **Height**: 80 pixels

#### VPN Status Label
- **Text**: "VPN: DISCONNECTED" or "VPN: CONNECTED ✓"
- **Color**: Orange-red when disconnected, Lime green when connected
- **Font**: Segoe UI, 12pt, Bold

#### Statistics Label
- **Text**: "↑ [sent] | ↓ [received] | ⏱ [time]"
- **Color**: Light gray
- **Font**: Segoe UI, 9pt
- **Visible**: Only when VPN is connected

#### VPN Toggle Button
- **Text**: "🛡️ Enable VPN" or "🛡️ Disable VPN"
- **Color**: Blue (#007ACC) when disconnected, Orange-red when connected
- **Size**: 160x50 pixels
- **Font**: Segoe UI, 11pt, Bold

### Navigation Bar
- **Background**: Dark gray (#252526)
- **Height**: 50 pixels

#### Navigation Buttons
- **Back (◀)**: Navigate to previous page
- **Forward (▶)**: Navigate to next page
- **Refresh (⟳)**: Reload current page
- **Size**: 40x30 pixels each
- **Color**: Dark gray background, white text

#### URL Text Box
- **Font**: Segoe UI, 11pt
- **Width**: Expandable (fills available space)
- **Accepts**: Any valid URL

#### Go Button
- **Color**: Blue (#007ACC)
- **Size**: 70x30 pixels

### Browser Window
- **Control**: Microsoft Edge WebView2
- **Size**: Fills remaining space
- **Features**: Full Chromium browser engine

## Color Scheme

### Disconnected State
```
Status Panel:  #2D2D30 (Dark Gray)
Status Text:   #FF4500 (Orange-Red)
Button:        #007ACC (Blue)
```

### Connected State
```
Status Panel:  #004000 (Dark Green)
Status Text:   #32CD32 (Lime Green)
Button:        #FF4500 (Orange-Red)
Stats Text:    #D3D3D3 (Light Gray)
```

### Navigation Bar
```
Background:    #252526 (Very Dark Gray)
Button:        #3E3E40 (Medium Dark Gray)
Text:          #FFFFFF (White)
Active Button: #007ACC (Blue)
```

## System Tray

```
┌─────────────────────────┐
│   🛡️ Bubble VPN        │
├─────────────────────────┤
│   Show                  │
│   Toggle VPN            │
│   ──────────────────    │
│   Exit                  │
└─────────────────────────┘
```

### States
- **Icon**: Shield (🛡️)
- **Tooltip**: "Bubble VPN Browser - Connected" or "- Disconnected"
- **Notifications**: Shows balloon tips for status changes

## Dialog Boxes

### VPN Connected Dialog
```
┌──────────────────────────────────────┐
│  ℹ VPN Connected                     │
├──────────────────────────────────────┤
│  VPN Enabled!                         │
│                                       │
│  ✓ Traffic Obfuscation: Active       │
│  ✓ Firewall Bypass: Enabled          │
│  ✓ Secure Connection: Established    │
│                                       │
│  Your browsing is now protected.     │
│                                       │
│              [ OK ]                   │
└──────────────────────────────────────┘
```

### Error Dialog
```
┌──────────────────────────────────────┐
│  ✕ Error                             │
├──────────────────────────────────────┤
│  [Error message here]                 │
│                                       │
│              [ OK ]                   │
└──────────────────────────────────────┘
```

## Responsive Behavior

### Window Resizing
- **Minimum Size**: 800x600 pixels
- **URL Bar**: Expands/contracts with window width
- **Browser**: Fills all available space
- **Buttons**: Fixed size and position

### States
1. **Normal**: Full window visible
2. **Minimized to Tray**: Window hidden, tray icon visible
3. **Maximized**: Full screen mode

## Keyboard Shortcuts

| Key Combination | Action |
|-----------------|--------|
| F5 | Refresh page |
| Ctrl+W | Close to tray |
| Alt+Left | Go back |
| Alt+Right | Go forward |
| Enter (in URL bar) | Navigate to URL |

## Visual Hierarchy

```
┌─ Window ────────────────────────────────────────┐
│                                                  │
│  ┌─ Status Panel (Fixed Height) ──────────────┐ │
│  │  Connection Status + Controls               │ │
│  └─────────────────────────────────────────────┘ │
│                                                  │
│  ┌─ Navigation Bar (Fixed Height) ─────────────┐ │
│  │  Browser Controls + URL Bar                 │ │
│  └─────────────────────────────────────────────┘ │
│                                                  │
│  ┌─ Browser Content (Fill Remaining) ──────────┐ │
│  │  WebView2                                    │ │
│  │                                              │ │
│  │  (Full height and width)                    │ │
│  │                                              │ │
│  └─────────────────────────────────────────────┘ │
│                                                  │
└──────────────────────────────────────────────────┘
```

## User Flow

### Starting the Application
1. Launch from Visual Studio 2022 or executable
2. Window opens with VPN disconnected
3. Browser loads Google.com
4. User can browse normally

### Enabling VPN
1. Click "🛡️ Enable VPN" button
2. Status panel turns green
3. Confirmation dialog appears
4. Statistics begin updating
5. VPN is now active

### Browsing with VPN
1. Enter URL in address bar
2. Press Enter or click Go
3. Traffic is obfuscated
4. Statistics update in real-time
5. Browse securely

### Disabling VPN
1. Click "🛡️ Disable VPN" button
2. Status panel returns to gray
3. Statistics stop updating
4. Normal browsing resumes

### Minimizing to Tray
1. Click X to close window
2. Window hides (doesn't exit)
3. Tray icon remains
4. Notification appears
5. Double-click tray icon to restore

## Design Philosophy

### Dark Theme
- Modern, professional appearance
- Reduces eye strain
- Matches Visual Studio 2022 theme
- Clear status indicators

### Visual Feedback
- Color changes show status clearly
- Real-time statistics provide information
- Notifications keep user informed
- Button states are obvious

### Simplicity
- Clean, uncluttered interface
- Essential controls only
- Intuitive layout
- Easy to understand

---

This mockup represents the user interface design for the Bubble VPN Browser as implemented in the code.
