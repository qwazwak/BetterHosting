using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

internal interface IMasterClientConfigurator
{
    public Task Configure(DiscordShardedClient client);
}