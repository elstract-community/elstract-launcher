/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Models/AppSettings.cs              ║
 * ║  Serialisable user preferences / configuration model    ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using Newtonsoft.Json;

namespace ElstractLauncher.Models;

/// <summary>
/// Persisted application preferences. Saved to %AppData%\Elstract\settings.json.
/// </summary>
public class AppSettings
{
    // ── Launch behavior ───────────────────────────────────────────────
    [JsonProperty("minimizeOnLaunch")]
    public bool MinimizeOnLaunch { get; set; } = true;

    [JsonProperty("closeOnGameExit")]
    public bool CloseOnGameExit { get; set; } = false;

    [JsonProperty("trackPlayTime")]
    public bool TrackPlayTime { get; set; } = true;

    // ── Discord RPC ───────────────────────────────────────────────────
    [JsonProperty("discordRpcEnabled")]
    public bool DiscordRpcEnabled { get; set; } = true;

    [JsonProperty("discordRpcShowGameName")]
    public bool DiscordRpcShowGameName { get; set; } = true;

    // ── UI ────────────────────────────────────────────────────────────
    [JsonProperty("libraryViewMode")]
    public LibraryViewMode LibraryViewMode { get; set; } = LibraryViewMode.Grid;

    [JsonProperty("defaultSortOrder")]
    public SortOrder DefaultSortOrder { get; set; } = SortOrder.LastPlayed;

    // ── Data paths ────────────────────────────────────────────────────
    [JsonProperty("customIconsFolder")]
    public string CustomIconsFolder { get; set; } =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Elstract", "Icons");
}

public enum LibraryViewMode { Grid, List }
public enum SortOrder { Name, LastPlayed, MostPlayed, DateAdded }
