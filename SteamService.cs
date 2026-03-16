/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Services/DiscordService.cs         ║
 * ║  Discord Rich Presence integration.                     ║
 * ║  Shows "In Elstract Launcher" when idle,                ║
 * ║  and "Playing <GameName>" with timestamps when          ║
 * ║  a game is running.                                     ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using DiscordRPC;
using DiscordRPC.Logging;
using ElstractLauncher.Models;

namespace ElstractLauncher.Services;

/// <summary>
/// Wraps the DiscordRichPresence library.
/// Uses a public Elstract Discord Application ID —
/// replace the constant below with your own App ID from
/// https://discord.com/developers/applications
/// </summary>
public class DiscordService : IDisposable
{
    // ── Discord Application ID ────────────────────────────────────────
    // TODO: Replace with your registered Discord application client ID
    private const string ClientId = "1234567890123456789";

    private DiscordRpcClient? _client;
    private bool _initialized;

    // ── Initialization ────────────────────────────────────────────────

    public void Initialize()
    {
        try
        {
            _client = new DiscordRpcClient(ClientId)
            {
                Logger = new NullLogger()
            };

            _client.OnReady += (_, e)
                => System.Diagnostics.Debug.WriteLine($"[Discord] Connected as {e.User.Username}");
            _client.OnError += (_, e)
                => System.Diagnostics.Debug.WriteLine($"[Discord] Error: {e.Message}");

            _client.Initialize();
            _initialized = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Discord] Init failed: {ex.Message}");
            _initialized = false;
        }
    }

    // ── Presence helpers ──────────────────────────────────────────────

    /// <summary>
    /// Sets presence to the launcher idle state:
    /// "In Elstract Launcher" with the Elstract logo.
    /// </summary>
    public void SetIdlePresence()
    {
        if (!_initialized || _client is null) return;

        _client.SetPresence(new RichPresence
        {
            Details = "Browsing Library",
            State   = "Elstract Launcher",
            Assets  = new Assets
            {
                LargeImageKey  = "elstract_logo",
                LargeImageText = "Elstract Launcher",
            },
            Timestamps = Timestamps.Now
        });
    }

    /// <summary>
    /// Sets presence to playing a specific game.
    /// Image key is the Steam App ID (if available) so Discord
    /// can optionally show the game's icon.
    /// </summary>
    public void SetGamePresence(Game game)
    {
        if (!_initialized || _client is null) return;

        _client.SetPresence(new RichPresence
        {
            Details    = $"Playing {game.Name}",
            State      = "via Elstract Launcher",
            Assets     = new Assets
            {
                LargeImageKey  = game.SteamAppId > 0
                                    ? game.SteamAppId.ToString()
                                    : "elstract_logo",
                LargeImageText = game.Name,
                SmallImageKey  = "elstract_logo",
                SmallImageText = "Elstract Launcher"
            },
            Timestamps = Timestamps.Now
        });
    }

    // ── Disposal ──────────────────────────────────────────────────────

    public void Dispose()
    {
        _client?.ClearPresence();
        _client?.Dispose();
    }
}
