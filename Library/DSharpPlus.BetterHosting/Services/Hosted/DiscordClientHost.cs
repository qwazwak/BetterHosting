using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal class DiscordClientHost : IHostedService
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

    public async Task StartAsync(CancellationToken stoppingToken)
    {
        Debug.Assert(this.client == null);
        DiscordShardedClient client;

        try
        {
            try
            {
                client = await clientConstructor.ConstructClient().WaitAsync(stoppingToken);
            }
            catch (Exception ex) when (ex is not TaskCanceledException)
            {
                logger.LogError(ex, $"There was a problem building/configuring the {nameof(DiscordShardedClient)}. Unable to startup client due to unexpected exception {{type}}: {{message}}", ex.GetType(), ex.Message);
                clientManager.SetException(ex);
                throw;
            }

            stoppingToken.ThrowIfCancellationRequested();

            logger.LogTrace("Connecting to discord...");
            try
            {
                await client.StartAsync().WaitAsync(stoppingToken);
            }
            catch (Exception ex) when(ex is not TaskCanceledException)
            {
                logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
                clientManager.SetException(ex);
                throw;
            }

            logger.LogTrace("Discord connected");
        }
        catch (TaskCanceledException ex)
        {
            clientManager.SetCancelled(ex.CancellationToken);
            return;
        }
        clientManager.Set(client);
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous Stop operation.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        DiscordShardedClient? client = this.client;
        // Stop called without start
        if (client == null)
            return Task.CompletedTask;
        this.client = null;

        clientManager.SetCancelled(cancellationToken);
        return client.StopAsync();
    }
}