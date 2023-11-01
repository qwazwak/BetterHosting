using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Provides <see cref="DiscordShardedClient"/>, only after they have connected
/// </summary>
public interface IConnectedClientProvider
{
    ValueTask<DiscordShardedClient> GetClientAsync(CancellationToken cancellationToken = default);
}
