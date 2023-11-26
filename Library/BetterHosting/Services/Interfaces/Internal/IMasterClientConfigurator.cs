using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;

namespace BetterHosting.Services.Interfaces.Internal;

internal interface IMasterClientConfigurator
{
    public Task Configure(DiscordShardedClient client, CancellationToken cancellationToken);
}