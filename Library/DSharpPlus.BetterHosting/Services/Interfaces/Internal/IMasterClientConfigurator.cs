using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces.Internal;

internal interface IMasterClientConfigurator
{
    public Task Configure(DiscordShardedClient client);
}