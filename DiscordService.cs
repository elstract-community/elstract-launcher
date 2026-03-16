/*
 * Elstract Launcher — Services/UpdateService.cs
 * Queries GitHub Releases API to detect newer versions.
 */
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ElstractLauncher.Services;

public record GitHubRelease(string TagName, string Name, string Body,
    string HtmlUrl, DateTime PublishedAt, bool IsPreRelease);

public class UpdateService
{
    private readonly string _currentVersion;
    private readonly string _repo;
    private readonly HttpClient _http;

    public UpdateService(string currentVersion, string repo)
    {
        _currentVersion = currentVersion;
        _repo           = repo;
        _http           = new HttpClient();
        _http.DefaultRequestHeaders.UserAgent
            .Add(new ProductInfoHeaderValue("ElstractLauncher", currentVersion));
    }

    public async Task<GitHubRelease?> GetLatestReleaseAsync()
    {
        try
        {
            var json = await _http.GetStringAsync($"https://api.github.com/repos/{_repo}/releases/latest");
            return ParseRelease(JObject.Parse(json));
        }
        catch { return null; }
    }

    public async Task<List<GitHubRelease>> GetAllReleasesAsync()
    {
        try
        {
            var json = await _http.GetStringAsync($"https://api.github.com/repos/{_repo}/releases?per_page=10");
            return JArray.Parse(json)
                .Select(r => ParseRelease((JObject)r))
                .Where(r => r is not null)
                .Cast<GitHubRelease>()
                .ToList();
        }
        catch { return new(); }
    }

    public bool IsNewer(GitHubRelease release)
    {
        var tag     = release.TagName.TrimStart('v');
        var current = _currentVersion.TrimStart('v');
        return Version.TryParse(tag, out var rv) &&
               Version.TryParse(current, out var lv) && rv > lv;
    }

    private static GitHubRelease? ParseRelease(JObject o)
    {
        try
        {
            return new GitHubRelease(
                (string?)o["tag_name"]     ?? "",
                (string?)o["name"]         ?? "",
                (string?)o["body"]         ?? "",
                (string?)o["html_url"]     ?? "",
                (DateTime?)o["published_at"] ?? DateTime.MinValue,
                (bool?)o["prerelease"]     ?? false);
        }
        catch { return null; }
    }
}
