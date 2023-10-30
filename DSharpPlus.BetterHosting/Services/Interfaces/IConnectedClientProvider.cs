using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IConnectedClientProvider
{
    DiscordShardedClient GetClient(CancellationToken cancellationToken = default);
    ValueTask<DiscordShardedClient> GetClientAsync(CancellationToken cancellationToken = default);
}