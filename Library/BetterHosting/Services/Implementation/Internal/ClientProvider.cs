using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Interfaces.Internal;
using System.Threading.Tasks;
using System.Threading;
using DSharpPlus;

namespace BetterHosting.Services.Implementation.Internal;

internal class ClientProvider(IClientManager manager) : SingletonProvider<DiscordShardedClient>(manager), IConnectedClientProvider
{
    public ValueTask<DiscordShardedClient> GetClientAsync(CancellationToken cancellationToken = default) => WaitAsync(cancellationToken);
}
