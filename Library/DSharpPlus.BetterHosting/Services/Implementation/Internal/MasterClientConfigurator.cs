using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;

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

    public async Task Configure(DiscordShardedClient client)
    {
        List<Exception>? exceptions = null;
        foreach (IDiscordClientConfigurator configurator in configurators)
        {
            try
            {
                await configurator.Configure(client);
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