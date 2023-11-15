using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces.Internal;

internal interface IShortClientConstructor
{
    Task<DiscordShardedClient> ConstructClient();
}
