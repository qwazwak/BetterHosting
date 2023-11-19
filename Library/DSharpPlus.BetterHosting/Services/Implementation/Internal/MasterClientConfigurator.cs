using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using System.Threading;

namespace DSharpPlus.BetterHosting.Services.Implementation.Internal;

internal sealed class MasterClientConfigurator : IMasterClientConfigurator
{
    private readonly ILogger<MasterClientConfigurator> logger;
    private readonly IEnumerable<IDiscordClientConfigurator> configurators;

    public MasterClientConfigurator(ILogger<MasterClientConfigurator> logger, IEnumerable<IDiscordClientConfigurator> configurators)
    {
        this.logger = logger;
        this.configurators = configurators;
    }

    public async Task Configure(DiscordShardedClient client, CancellationToken cancellationToken)
    {
        List<Exception>? exceptions = null;
        foreach (IDiscordClientConfigurator configurator in configurators)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            try
            {
                await configurator.Configure(client, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "configurator of type {typeName} failed to run: {message}", configurator.GetType().Name, ex.Message);
                (exceptions ??= new()).Add(ex);
            }
        }

        if (exceptions != null)
            throw new AggregateException("One or more exceptions occured while setting up DiscordShardedClient", exceptions);
    }
}