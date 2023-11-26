using System;
using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces.Internal;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BetterHosting.Services.Implementation.Internal;

internal sealed class ShortClientConstructor : IShortClientConstructor
{
    private readonly ILogger<ShortClientConstructor> logger;
    private readonly IServiceScopeFactory provider;
    public ShortClientConstructor(ILogger<ShortClientConstructor> logger, IServiceScopeFactory provider)
    {
        this.logger = logger;
        this.provider = provider;
    }

    public async Task<DiscordShardedClient> ConstructClient(CancellationToken cancellationToken)
    {
        try
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IClientConstructor constructor = scope.ServiceProvider.GetRequiredService<IClientConstructor>();
            return await constructor.ConstructClient(cancellationToken);
        }
        catch (Exception ex) when (ex is not TaskCanceledException)
        {
            logger.LogError(ex, $"There was a problem building/configuring the {nameof(DiscordShardedClient)}. Unable to startup client due to unexpected exception {{type}}: {{message}}", ex.GetType(), ex.Message);
            throw;
        }
    }
}
