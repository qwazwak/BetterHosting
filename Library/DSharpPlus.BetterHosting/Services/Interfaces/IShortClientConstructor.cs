using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

internal interface IShortClientConstructor
{
    Task<DiscordShardedClient> ConstructClient();
}
