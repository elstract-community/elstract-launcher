/*
 * Elstract Launcher — Models/Game.cs
 * Core domain model for a library game entry.
 */
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ElstractLauncher.Models;

public class Game : INotifyPropertyChanged
{
    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    private string _name = string.Empty;
    [JsonProperty("name")]
    public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

    private string? _exePath;
    [JsonProperty("exePath")]
    public string? ExePath
    {
        get => _exePath;
        set { _exePath = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsExeLinked)); }
    }

    [JsonIgnore]
    public bool IsExeLinked => !string.IsNullOrEmpty(ExePath) && File.Exists(ExePath);

    private string? _iconPath;
    [JsonProperty("iconPath")]
    public string? IconPath
    {
        get => _iconPath;
        set { _iconPath = value; OnPropertyChanged(); OnPropertyChanged(nameof(DisplayIconPath)); }
    }

    [JsonIgnore]
    public string? DisplayIconPath => _iconPath is { Length: > 0 } ? _iconPath : SteamHeaderUrl;

    private string? _headerImagePath;
    [JsonProperty("headerImagePath")]
    public string? HeaderImagePath { get => _headerImagePath; set { _headerImagePath = value; OnPropertyChanged(); } }

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
        ? $"https://cdn.akamai.steamstatic.com/steam/apps/{SteamAppId}/header.jpg" : null;

    [JsonIgnore]
    public string? SteamIconUrl => SteamAppId > 0
        ? $"https://cdn.akamai.steamstatic.com/steam/apps/{SteamAppId}/capsule_231x87.jpg" : null;

    private string? _developer;
    [JsonProperty("developer")]
    public string? Developer { get => _developer; set { _developer = value; OnPropertyChanged(); } }

    private string? _publisher;
    [JsonProperty("publisher")]
    public string? Publisher { get => _publisher; set { _publisher = value; OnPropertyChanged(); } }

    private string? _description;
    [JsonProperty("description")]
    public string? Description { get => _description; set { _description = value; OnPropertyChanged(); } }

    private string? _genres;
    [JsonProperty("genres")]
    public string? Genres { get => _genres; set { _genres = value; OnPropertyChanged(); } }

    private DateTime? _releaseDate;
    [JsonProperty("releaseDate")]
    public DateTime? ReleaseDate { get => _releaseDate; set { _releaseDate = value; OnPropertyChanged(); } }

    private TimeSpan _totalPlayTime;
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
            if (t.TotalHours >= 1)  return $"{(int)t.TotalHours}h {t.Minutes}m";
            if (t.TotalMinutes >= 1) return $"{(int)t.TotalMinutes}m";
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
    public int LaunchCount { get => _launchCount; set { _launchCount = value; OnPropertyChanged(); } }

    private bool _isRunning;
    [JsonIgnore]
    public bool IsRunning { get => _isRunning; set { _isRunning = value; OnPropertyChanged(); } }

    private bool _isFavourite;
    [JsonProperty("isFavourite")]
    public bool IsFavourite { get => _isFavourite; set { _isFavourite = value; OnPropertyChanged(); } }

    [JsonProperty("addedDate")]
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
