using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal class DiscordClientHost : BackgroundService
{
    private readonly ILogger<DiscordClientHost> logger;
    private readonly IClientManager clientManager;
    private readonly IShortClientConstructor clientConstructor;

    public DiscordClientHost(ILogger<DiscordClientHost> logger, IShortClientConstructor clientConstructor, IClientManager clientManager)
    {
        this.logger = logger;
        this.clientConstructor = clientConstructor;
        this.clientManager = clientManager;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using CancellationTokenRegistration _2 = stoppingToken.Register(SetCancelledHandler, stoppingToken);
        DiscordShardedClient client;
        try
        {
            client = await clientConstructor.ConstructClient();
            if (stoppingToken.IsCancellationRequested)
                return;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to startup client due to unexpected exception {type}: {message}", ex.GetType(), ex.Message);
            clientManager.SetFailed(ex);
            Debug.Fail("No exceptions should occur while connecting");
#if DEBUG
            throw;
#else
            return;
#endif
        }

        try
        {
            logger.LogTrace("Connecting to discord...");
            await client.StartAsync();
            logger.LogTrace("Discord connected");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
            clientManager.SetFailed(ex);
            throw;
        }

        try
        {
            clientManager.SetConnected(client);
            // And now we wait infinitely so that our bot actually stays connected.
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            clientManager.SetCancelled(stoppingToken);
            await client.StopAsync();
        }
    }

    private void SetCancelledHandler(object? token)
    {
        if (token is not CancellationToken stoppingToken)
            throw new InvalidOperationException();
        clientManager.SetCancelled(stoppingToken);
    }
}