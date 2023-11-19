using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces.Internal;

internal interface IClientConstructor
{
    Task<DiscordShardedClient> ConstructClient(CancellationToken cancellationToken);
}