using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Provides <see cref="DiscordShardedClient"/>, only after they have connected
/// </summary>
//TODO: rename to IClientProvider
public interface IConnectedClientProvider
{
    /// <summary>
    /// Gets the <see cref="DiscordShardedClient"/>, only returning after it is ready
    /// </summary>
    /// <param name="cancellationToken"></param>
    ValueTask<DiscordShardedClient> GetClientAsync(CancellationToken cancellationToken = default);
}
