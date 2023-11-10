using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class ShortClientConstructor : IShortClientConstructor
{
    private readonly IServiceScopeFactory provider;
    public ShortClientConstructor(IServiceScopeFactory provider) => this.provider = provider;

    public async Task<DiscordShardedClient> ConstructClient()
    {
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        IClientConstructor constructor = scope.ServiceProvider.GetRequiredService<IClientConstructor>();
        return await constructor.ConstructClient();
    }
}
