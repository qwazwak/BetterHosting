using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;

namespace BetterHosting.Services.Interfaces;

/// <summary>
/// Interface to allow configuration of the <see cref="DiscordShardedClient"/> before connection is made
/// </summary>
public interface IDiscordClientConfigurator
{
    /// <summary>
    /// Called once before connection to setup various things
    /// </summary>
    /// <param name="client"></param>
    /// <returns>A <see cref="ValueTask"/> representing configuration completion</returns>
    /// <param name="cancellationToken"></param>
    ValueTask Configure(DiscordShardedClient client, CancellationToken cancellationToken);
}