using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Interface to allow configuration of the <see cref="DiscordShardedClient"/> before connection is made
/// </summary>
public interface IDiscordClientConfigurator
{
    /// <summary>
    /// Called once before connection to setup various things
    /// </summary>
    /// <param name="client"></param>
    /// <returns>A valuetask representing configuration completion</returns>
    ValueTask Configure(DiscordShardedClient client);
}