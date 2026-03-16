/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Models/Game.cs                     ║
 * ║  Core domain model for a library game entry.            ║
 * ║  Stores all metadata: name, exe, icon, playtime,        ║
 * ║  Steam/SteamDB info, and launch state.                  ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ElstractLauncher.Models;

/// <summary>
/// Represents a single game in the Elstract library.
/// </summary>
public class Game : INotifyPropertyChanged
{
    // ── Identity ──────────────────────────────────────────────────────

    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    private string _name = string.Empty;
    [JsonProperty("name")]
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }

    // ── File system ───────────────────────────────────────────────────

    private string? _exePath;
    /// <summary>Full path to the game executable (.exe).</summary>
    [JsonProperty("exePath")]
    public string? ExePath
    {
        get => _exePath;
        set { _exePath = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsExeLinked)); }
    }

    /// <summary>True when an exe has been attached and the file exists.</summary>
    [JsonIgnore]
    public bool IsExeLinked => !string.IsNullOrEmpty(ExePath) && File.Exists(ExePath);

    // ── Visuals ───────────────────────────────────────────────────────

    private string? _iconPath;
    /// <summary>Path to a custom icon image (png/jpg). May be null → use Steam CDN.</summary>
    [JsonProperty("iconPath")]
    public string? IconPath
    {
        get => _iconPath;
        set { _iconPath = value; OnPropertyChanged(); OnPropertyChanged(nameof(DisplayIconPath)); }
    }

    /// <summary>
    /// Effective icon: custom override → Steam CDN → null (placeholder used by UI).
    /// </summary>
    [JsonIgnore]
    public string? DisplayIconPath =>
        _iconPath is { Length: > 0 } ? _iconPath : SteamHeaderUrl;

    private string? _headerImagePath;
    /// <summary>Wide banner / header image for the game detail page.</summary>
    [JsonProperty("headerImagePath")]
    public string? HeaderImagePath
    {
        get => _headerImagePath;
        set { _headerImagePath = value; OnPropertyChanged(); }
    }

    // ── Steam / SteamDB metadata ──────────────────────────────────────

    private int _steamAppId;
    [JsonProperty("steamAppId")]
    public int SteamAppId
    {
        get => _steamAppId;
        set
        {
            _steamAppId = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SteamHeaderUrl));
            OnPropertyChanged(nameof(SteamIconUrl));
            OnPropertyChanged(nameof(DisplayIconPath));
        }
    }

    [JsonIgnore]
    public string? SteamHeaderUrl => SteamAppId > 0
        ? $"https://cdn.akamai.steamstatic.com/steam/apps/{SteamAppId}/header.jpg"
        : null;

    [JsonIgnore]
    public string? SteamIconUrl => SteamAppId > 0
        ? $"https://cdn.akamai.steamstatic.com/steam/apps/{SteamAppId}/capsule_231x87.jpg"
        : null;

    private string? _developer;
    [JsonProperty("developer")]
    public string? Developer
    {
        get => _developer;
        set { _developer = value; OnPropertyChanged(); }
    }

    private string? _publisher;
    [JsonProperty("publisher")]
    public string? Publisher
    {
        get => _publisher;
        set { _publisher = value; OnPropertyChanged(); }
    }

    private string? _description;
    [JsonProperty("description")]
    public string? Description
    {
        get => _description;
        set { _description = value; OnPropertyChanged(); }
    }

    private string? _genres;
    [JsonProperty("genres")]
    public string? Genres
    {
        get => _genres;
        set { _genres = value; OnPropertyChanged(); }
    }

    private DateTime? _releaseDate;
    [JsonProperty("releaseDate")]
    public DateTime? ReleaseDate
    {
        get => _releaseDate;
        set { _releaseDate = value; OnPropertyChanged(); }
    }

    // ── Playtime ──────────────────────────────────────────────────────

    private TimeSpan _totalPlayTime;
    /// <summary>Cumulative playtime across all sessions.</summary>
    [JsonProperty("totalPlayTime")]
    public TimeSpan TotalPlayTime
    {
        get => _totalPlayTime;
        set { _totalPlayTime = value; OnPropertyChanged(); OnPropertyChanged(nameof(PlayTimeDisplay)); }
    }

    [JsonIgnore]
    public string PlayTimeDisplay
    {
        get
        {
            var t = _totalPlayTime;
            if (t.TotalHours >= 1)
                return $"{(int)t.TotalHours}h {t.Minutes}m";
            if (t.TotalMinutes >= 1)
                return $"{(int)t.TotalMinutes}m";
            return "< 1 min";
        }
    }

    private DateTime? _lastPlayed;
    [JsonProperty("lastPlayed")]
    public DateTime? LastPlayed
    {
        get => _lastPlayed;
        set { _lastPlayed = value; OnPropertyChanged(); OnPropertyChanged(nameof(LastPlayedDisplay)); }
    }

    [JsonIgnore]
    public string LastPlayedDisplay =>
        _lastPlayed.HasValue ? _lastPlayed.Value.ToString("dd MMM yyyy") : "Never";

    private int _launchCount;
    [JsonProperty("launchCount")]
    public int LaunchCount
    {
        get => _launchCount;
        set { _launchCount = value; OnPropertyChanged(); }
    }

    // ── State ─────────────────────────────────────────────────────────

    private bool _isRunning;
    [JsonIgnore]
    public bool IsRunning
    {
        get => _isRunning;
        set { _isRunning = value; OnPropertyChanged(); }
    }

    private bool _isFavourite;
    [JsonProperty("isFavourite")]
    public bool IsFavourite
    {
        get => _isFavourite;
        set { _isFavourite = value; OnPropertyChanged(); }
    }

    [JsonProperty("addedDate")]
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;

    // ── INPC ──────────────────────────────────────────────────────────

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
