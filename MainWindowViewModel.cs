/*
 * Elstract Launcher — Services/DiscordService.cs
 * Discord Rich Presence integration.
 */
using DiscordRPC;
using DiscordRPC.Logging;
using ElstractLauncher.Models;

namespace ElstractLauncher.Services;

public class DiscordService : IDisposable
{
    // TODO: Replace with your own Discord Application Client ID
    // Register at: https://discord.com/developers/applications
    private const string ClientId = "1234567890123456789";

    private DiscordRpcClient? _client;
    private bool _initialized;

    public void Initialize()
    {
        try
        {
            _client = new DiscordRpcClient(ClientId) { Logger = new NullLogger() };
            _client.OnReady += (_, e) => System.Diagnostics.Debug.WriteLine($"[Discord] Connected as {e.User.Username}");
            _client.OnError += (_, e) => System.Diagnostics.Debug.WriteLine($"[Discord] Error: {e.Message}");
            _client.Initialize();
            _initialized = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Discord] Init failed: {ex.Message}");
            _initialized = false;
        }
    }

    public void SetIdlePresence()
    {
        if (!_initialized || _client is null) return;
        _client.SetPresence(new RichPresence
        {
            Details = "Browsing Library",
            State   = "Elstract Launcher",
            Assets  = new Assets { LargeImageKey = "elstract_logo", LargeImageText = "Elstract Launcher" },
            Timestamps = Timestamps.Now
        });
    }

    public void SetGamePresence(Game game)
    {
        if (!_initialized || _client is null) return;
        _client.SetPresence(new RichPresence
        {
            Details = $"Playing {game.Name}",
            State   = "via Elstract Launcher",
            Assets  = new Assets
            {
                LargeImageKey  = game.SteamAppId > 0 ? game.SteamAppId.ToString() : "elstract_logo",
                LargeImageText = game.Name,
                SmallImageKey  = "elstract_logo",
                SmallImageText = "Elstract Launcher"
            },
            Timestamps = Timestamps.Now
        });
    }

    public void Dispose()
    {
        _client?.ClearPresence();
        _client?.Dispose();
    }
}
