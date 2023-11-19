using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class EventsNextBackgroundHost<TManager> : IHostedService where TManager : IEventHandlerManager
{
    private readonly ILogger<EventsNextBackgroundHost<TManager>> logger;
    private readonly TManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TManager>> logger, TManager manager, IConnectedClientProvider clientProvider)
    {
        this.logger = logger;
        this.manager = manager;
        this.clientProvider = clientProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(cancellationToken).AsTask().WaitAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Startup cancellation requested, not starting event manager {type}", typeof(TManager).Name);
            return;
        }

        if (manager.CanBeTriggered(client))
            manager.Start(client);
        else
            logger.LogInformation("Events for handlers managed by {HandlerType} were declared to not happen, so exiting quick", typeof(TManager).Name);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        manager.Stop();
        return Task.CompletedTask;
    }
}