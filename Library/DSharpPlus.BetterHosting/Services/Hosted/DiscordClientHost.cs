﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal class DiscordClientHost : BackgroundLifecycleService
{
    private readonly ILogger<DiscordClientHost> logger;
    private readonly IClientManager clientManager;
    private readonly IShortClientConstructor clientConstructor;

    private DiscordShardedClient? client;

    public DiscordClientHost(ILogger<DiscordClientHost> logger, IShortClientConstructor clientConstructor, IClientManager clientManager)
    {
        this.logger = logger;
        this.clientConstructor = clientConstructor;
        this.clientManager = clientManager;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    protected override async Task Start(CancellationToken stoppingToken)
    {
        if(client == null)
        {
            logger.LogWarning("Service restarted without shutdown, how??");
            return;
        }

        logger.LogInformation("Starting discord setup...");

        try
        {

            client = await clientConstructor.ConstructClient(stoppingToken);

            stoppingToken.ThrowIfCancellationRequested();
            logger.LogDebug("Constructed discord client");

            try
            {
                await client.StartAsync().WaitAsync(stoppingToken);
            }
            catch (Exception ex) when (ex is not TaskCanceledException)
            {
                logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
                throw;
            }
        }
        catch (TaskCanceledException ex)
        {
            clientManager.SetCancelled(ex.CancellationToken);
            return;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to startup client because of {message}", ex.Message);
            clientManager.SetException(ex);
            throw;
        }

        logger.LogInformation("Discord connected");

        Debug.Assert(client != null);
        if (stoppingToken.IsCancellationRequested)
            clientManager.SetCancelled(stoppingToken);
        else
            clientManager.Set(client);
    }

    protected override Task Stop(CancellationToken cancellationToken)
    {
        DiscordShardedClient? client = this.client;
        // Stop called without start
        if (client == null)
            return Task.CompletedTask;
        logger.LogInformation("Starting discord shutdown...");

        this.client = null;

        clientManager.SetCancelled(cancellationToken);
        return client.StopAsync();
    }
}