<div align="center">

<img src="https://img.shields.io/badge/Elstract-Launcher-FF1A7A?style=for-the-badge&logo=gamepad&logoColor=white" alt="Elstract Launcher"/>

# Elstract Launcher

**A beautiful, open-source game launcher for Windows — built with C# & WPF**

[![License: MIT](https://img.shields.io/badge/License-MIT-FF1A7A.svg?style=flat-square)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com)
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=flat-square&logo=windows)](https://microsoft.com/windows)
[![Open Source](https://img.shields.io/badge/Open%20Source-❤-FF1A7A?style=flat-square)](https://github.com)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen?style=flat-square)](CONTRIBUTING.md)

[**Download**](#-installation) · [**Features**](#-features) · [**Screenshots**](#-screenshots) · [**Build from Source**](#-building-from-source) · [**Contributing**](#-contributing)

---

> **No accounts. No telemetry. No ads. Just your games.**  
> Elstract is 100% local — everything stays on your PC.

</div>

---

## 📖 What is Elstract Launcher?

Elstract Launcher is a free, open-source game launcher for Windows that lets you organize and launch **any game** from a single beautiful interface — whether it's on Steam, bought DRM-free, or your own custom build.

Think of it as a personal Steam-style library that **you own and control**. Add any `.exe`, search Steam for metadata and cover art, track your playtime, and show off what you're playing in Discord — all without giving your data to anyone.

The project is built with **C# + WPF on .NET 8** and is designed to be easy to understand, modify, and extend. Whether you're a gamer who wants a clean launcher or a developer who wants to learn WPF MVVM architecture, Elstract is a great starting point.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🎮 **Game Library** | Add any game by `.exe` path. Search Steam / SteamDB to auto-fill metadata |
| 🖼 **Custom Icons & Backgrounds** | Set your own cover art and banner per game, or auto-fetch from Steam CDN |
| ⏱ **Playtime Tracking** | Automatic per-session timer. Lifetime hours displayed on every card |
| 💬 **Discord Rich Presence** | Shows "Playing X" with game art in your Discord status |
| 🔒 **100% Local & Private** | Zero telemetry, zero accounts, zero cloud. JSON files on your own machine |
| 🚀 **One-click Launch** | Double-click any card to launch. Optionally minimises the launcher on start |
| 🌑 **Dark Pink Theme** | Modern dark UI with vivid `#FF1A7A` pink accents and glow effects |
| ✏️ **Custom Games** | Add non-Steam games with custom name, description, icon, background, developer |
| 🔄 **Auto-save** | Library auto-saves every 30 seconds and on every game exit |
| 📦 **GitHub Update Feed** | Home page shows available releases and highlights when a new version is out |
| ⚙️ **Configurable** | Toggle Discord RPC, minimize-on-launch, close-on-exit, and more |

---

## 🖥 System Requirements

| Requirement | Minimum |
|---|---|
| **OS** | Windows 10 / Windows 11 (64-bit) |
| **Runtime** | [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0) |
| **RAM** | 128 MB |
| **Disk** | 50 MB |
| **Internet** | Optional (needed for Steam search & Discord RPC only) |

---

## 📥 Installation

### Option 1 — Download a Release (Easiest)

1. Go to the [**Releases page**](../../releases)
2. Download the latest `ElstractLauncher-vX.X.X.zip`
3. Extract to any folder (e.g. `C:\Program Files\Elstract`)
4. Run `ElstractLauncher.exe`

> **No installer needed.** Elstract is portable — just extract and run.

### Option 2 — Build from Source

See [Building from Source](#-building-from-source) below.

---

## 🚀 Quick Start Guide

### 1. Adding a Steam game

1. Click **"+ Add Game"** in the Library tab
2. Type the game name in the search box and press **Search**
3. Click the game in the results — metadata, developer, genre, and cover art are fetched automatically
4. A file picker opens — navigate to the game's `.exe` and select it
5. The game appears in your library, ready to launch!

### 2. Adding a custom game (non-Steam)

1. Click **"+ Add Game"**
2. Click **"🎮 Add Custom Game"**
3. Fill in the name, description, developer, genre
4. Click the icon preview to set a cover image
5. Click the background preview to set a banner image
6. Click **"Add Game"** — then select the `.exe` in the file picker

### 3. Launching a game

- **Double-click** any game card in the library, **or**
- **Single-click** the card to open the detail panel → click **Play**

### 4. Setting up Discord Rich Presence

1. Go to [discord.com/developers/applications](https://discord.com/developers/applications)
2. Create a new Application (name it "Elstract Launcher" or anything you like)
3. Copy the **Application ID** (Client ID)
4. Open `Services/DiscordService.cs` and replace the value of `ClientId`
5. Rebuild and run

> Discord RPC is **optional** — the launcher works fine without it. You can also disable it in Settings.

---

## 🏗 Building from Source

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows 10 or 11
- Any IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended), [Rider](https://www.jetbrains.com/rider/), or VS Code

### Steps

```bash
# 1. Clone the repository
git clone https://github.com/elstract-community/elstract-launcher.git
cd elstract-launcher

# 2. Restore NuGet packages
dotnet restore

# 3. Build
dotnet build

# 4. Run
dotnet run --project ElstractLauncher
```

### Build a release binary

```bash
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```

The output in `./publish` contains a single `ElstractLauncher.exe` you can distribute.

---

## 📁 Project Structure

```
ElstractLauncher/
│
├── App.xaml / App.xaml.cs          ← Application entry point, global services
│
├── Models/
│   ├── Game.cs                     ← Core game data model (name, exe, playtime, icons…)
│   ├── AppSettings.cs              ← User preferences model
│   └── SteamDbGame.cs              ← Steam API response DTOs
│
├── Services/
│   ├── LibraryService.cs           ← Game library CRUD, launch, playtime tracking
│   ├── DiscordService.cs           ← Discord Rich Presence integration
│   ├── SteamService.cs             ← Steam Store API (search + app details)
│   ├── SettingsService.cs          ← Settings persistence (JSON)
│   └── UpdateService.cs            ← GitHub Releases API for update checks
│
├── ViewModels/                     ← MVVM ViewModels (no code-behind logic)
│   ├── MainWindowViewModel.cs      ← Navigation between pages
│   ├── HomePageViewModel.cs        ← Home page data (version, GitHub releases)
│   ├── LibraryViewModel.cs         ← Library filtering, Steam search, game CRUD
│   └── SettingsViewModel.cs        ← Settings page bindings
│
├── Views/                          ← XAML user interfaces
│   ├── MainWindow.xaml             ← App shell (titlebar + sidebar + content)
│   ├── HomePageView.xaml           ← Welcome page with version and release feed
│   ├── LibraryView.xaml            ← Game grid, detail panel, Steam search overlay
│   ├── SettingsView.xaml           ← Settings toggles and info
│   ├── CustomGameDialog.xaml       ← Dialog for adding a custom game
│   ├── FeatureRow.xaml             ← Reusable feature highlight row
│   ├── StatRow.xaml                ← Reusable label+value stat row
│   ├── SettingsSection.xaml        ← Settings section header
│   └── SettingsToggleRow.xaml      ← Custom toggle switch row
│
├── Themes/
│   ├── ElstractTheme.xaml          ← Color palette, brushes, gradients
│   ├── ControlStyles.xaml          ← Styled buttons, inputs, scrollbars
│   └── Converters.xaml             ← IValueConverter registrations
│
├── Converters/
│   └── Converters.cs               ← All WPF value converters
│
└── app.manifest                    ← Windows app manifest (DPI, UAC, OS compat)
```

---

## 🎨 Theme & Customisation

Elstract uses a custom dark pink theme defined in `Themes/ElstractTheme.xaml`. Every colour is a named resource — changing the theme is as simple as editing a few hex values.

### Key colour variables

```xml
<!-- Primary accent -->
<Color x:Key="PinkPrimary">#FF1A7A</Color>
<Color x:Key="PinkLight">#FF5FA3</Color>
<Color x:Key="PinkDark">#C4004F</Color>

<!-- Backgrounds -->
<Color x:Key="BgBase">#130F18</Color>
<Color x:Key="BgCard">#1C1625</Color>
<Color x:Key="BgSidebar">#160F1E</Color>
```

To create your own theme, duplicate `ElstractTheme.xaml`, change the colour values, and swap the reference in `App.xaml`.

---

## 🛠 Architecture Overview

Elstract follows the **MVVM (Model-View-ViewModel)** pattern throughout:

```
View (XAML)  ←→  ViewModel (C#)  ←→  Service (C#)  ←→  Data (JSON / API)
```

- **Models** are plain C# classes with `INotifyPropertyChanged`
- **Services** are singletons held on the `App` class, accessible everywhere
- **ViewModels** bind to Views via WPF data binding — no code-behind logic
- **Views** are pure XAML with minimal code-behind (only window chrome / dialog helpers)

This means you can change any layer independently. Want to swap the JSON storage for SQLite? Replace `LibraryService`. Want a different UI? Replace the XAML files.

---

## 🤝 Contributing

Contributions of all kinds are welcome — code, design, translations, documentation, bug reports. Here's how to get started:

### Reporting a bug

1. Check [existing issues](../../issues) to make sure it's not already reported
2. Open a [new issue](../../issues/new) with:
   - What happened
   - Steps to reproduce
   - Your Windows version and .NET version
   - The contents of `%AppData%\Elstract\crash.log` if available

### Submitting a Pull Request

1. **Fork** the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Make your changes — keep them focused on one thing per PR
4. Make sure the project builds: `dotnet build`
5. **Push** and open a Pull Request against `main`
6. Describe what you changed and why

### Good first issues

Look for issues tagged `good first issue` — these are small, well-defined tasks perfect for first-time contributors.

### Ideas for contributions

- 🌍 **Translations** — add a `Resources.xx.resx` for your language
- 🎨 **New themes** — light mode, cyberpunk, monochrome
- 🏷 **Game categories / tags** — organise games into groups
- 📊 **Statistics page** — charts of playtime per game, per week
- 🔔 **Notifications** — system tray icon, toast when a game exits
- 🛒 **GOG / Epic integration** — search other stores for metadata
- 📤 **Export / Import** — share your library as a JSON file

---

## 📄 Data & Privacy

Elstract stores all data **locally on your machine** in `%AppData%\Elstract\`:

```
%AppData%\Elstract\
├── library.json      ← Your game library
├── settings.json     ← Your preferences
├── crash.log         ← Error log (only written on crash)
└── Icons\            ← Cached Steam cover images
```

**No data is ever sent anywhere.** The only outbound network requests are:
- Steam Store API — to search for games and fetch metadata (read-only, no auth)
- Steam CDN — to download cover images
- GitHub API — to check for new releases on the Home page
- Discord RPC — local IPC socket to your Discord client (no internet)

All of these are **opt-in by behaviour** (you have to click Search / open the app), and Discord RPC can be disabled in Settings.

---

## 📜 License

```
MIT License

Copyright (c) 2025 Elstract Community

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
```

**TL;DR:** You can use, copy, modify, merge, publish, distribute, sublicense, and sell this software freely. The only requirement is to keep the copyright notice. You can fork it, rebrand it, build a product on top of it — no restrictions.

---

## 🙏 Acknowledgements

- [DiscordRichPresence](https://github.com/Lachee/discord-rpc-csharp) — Discord RPC library for C#
- [Newtonsoft.Json](https://www.newtonsoft.com/json) — JSON serialisation
- [Octokit](https://github.com/octokit/octokit.net) — GitHub API client
- [Valve / Steam](https://store.steampowered.com) — Game metadata API (public, read-only)

---

<div align="center">

Made with ❤️ and a lot of `#FF1A7A` pink

**[⬆ Back to top](#elstract-launcher)**

</div>
