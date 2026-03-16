/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Models/SteamDbGame.cs              ║
 * ║  DTO for a game returned by the Steam search API.       ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using Newtonsoft.Json;

namespace ElstractLauncher.Models;

/// <summary>
/// Lightweight DTO representing a Steam app search result.
/// Populated by <see cref="ElstractLauncher.Services.SteamService"/>.
/// </summary>
public class SteamSearchResult
{
    [JsonProperty("appid")]
    public int AppId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public string IconUrl =>
        $"https://cdn.akamai.steamstatic.com/steam/apps/{AppId}/capsule_231x87.jpg";

    [JsonIgnore]
    public string HeaderUrl =>
        $"https://cdn.akamai.steamstatic.com/steam/apps/{AppId}/header.jpg";

    public override string ToString() => $"{Name} ({AppId})";
}

/// <summary>
/// Detailed metadata fetched from the Steam store API for a specific AppID.
/// </summary>
public class SteamAppDetails
{
    public int AppId              { get; set; }
    public string Name            { get; set; } = string.Empty;
    public string? Developer      { get; set; }
    public string? Publisher      { get; set; }
    public string? ShortDesc      { get; set; }
    public string? Genres         { get; set; }
    public DateTime? ReleaseDate  { get; set; }
    public string? HeaderImageUrl { get; set; }
}
