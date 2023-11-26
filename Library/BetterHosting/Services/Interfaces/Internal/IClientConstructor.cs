using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;

namespace BetterHosting.Services.Interfaces.Internal;

internal interface IClientConstructor
{
    Task<DiscordShardedClient> ConstructClient(CancellationToken cancellationToken);
}