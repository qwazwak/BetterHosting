﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class EventsNextBackgroundHost<TManager> : BackgroundService where TManager : IEventHandlerManager
{
    private readonly ILogger logger;
    private readonly TManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHost(ILogger logger, TManager manager, IConnectedClientProvider clientProvider)
    {
        this.logger = logger;
        this.manager = manager;
        this.clientProvider = clientProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(stoppingToken);
        }
        catch (OperationCanceledException)
        {
            return;
        }

        if (stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Startup cancellation requested, not starting event manager {type}", typeof(TManager).Name);
            return;
        }

        if (!manager.CanBeTriggered(client))
        {
            logger.LogInformation("Events for handlers {HandlerType} were declared to not happen, so exiting quick", typeof(TManager).Name);
            return;
        }

        try
        {
            manager.Start(client);
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        finally
        {
            manager.Stop();
        }
    }
}