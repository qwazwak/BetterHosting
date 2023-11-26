using System;
using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BetterHosting.EventsNext.Services.Implementations;

internal class EventsNextBackgroundHostBase : IHostedService
{
    private readonly ILogger<EventsNextBackgroundHostBase> logger;
    private readonly IEventHandlerManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHostBase(ILogger<EventsNextBackgroundHostBase> logger, IEventHandlerManager manager, IConnectedClientProvider clientProvider)
    {
        this.logger = logger;
        this.manager = manager;
        this.clientProvider = clientProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken) => manager.CanBeTriggered() ? StartAsyncFull(cancellationToken) : Task.CompletedTask;
    private async Task StartAsyncFull(CancellationToken cancellationToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            logger.LogDebug("Startup cancellation requested, not starting event manager");
            return;
        }

        if (manager.CanBeTriggered(client))
            manager.Start(client);
        else
            logger.LogInformation("Events for this manager were declared to not happen, so exiting quick");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        manager.Stop();
        return Task.CompletedTask;
    }
}

internal class EventsNextBackgroundHost<TEventInterface> : EventsNextBackgroundHostBase
{
    [ActivatorUtilitiesConstructor]
    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TEventInterface>> logger, IServiceProvider provider, IConnectedClientProvider clientProvider) : base(logger, provider.GetRequiredKeyedService<IEventHandlerManager>(typeof(TEventInterface)), clientProvider) { }
    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TEventInterface>> logger, IEventHandlerManager manager, IConnectedClientProvider clientProvider) : base(logger, manager, clientProvider) { }
}