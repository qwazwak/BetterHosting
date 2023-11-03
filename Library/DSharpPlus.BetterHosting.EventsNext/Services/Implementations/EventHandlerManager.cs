using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal abstract class EventHandlerManager<THandler, TArgument> : IEventHandlerManager
    where THandler : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    private readonly ILogger<EventHandlerManager<THandler, TArgument>> logger;
    protected readonly DiscordConfiguration discordConfig;
    protected readonly HandlerRegistryOptions<THandler> registry;
    private readonly IServiceProvider provider;
    private DiscordShardedClient client = null!;

    protected EventHandlerManager(ILogger<EventHandlerManager<THandler, TArgument>> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<THandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider)
    {
        this.logger = logger;
        this.discordConfig = discordConfig.Value;
        this.registry = registry;
        this.provider = provider;
    }

    public virtual bool CanBeTriggered(DiscordShardedClient client) => registry.Registrations.Count != 0;

    public void Start(DiscordShardedClient client)
    {
        this.client = client;
        Debug.Assert(client == null);
        Setup();
    }

    public void Stop()
    {
        TearDown();
        SetBindingState(false);
    }

    private void Setup()
    {
        Stopwatch sw = new();
        logger.LogTrace("Setting up event handler");
        sw.Start();
        SetBindingState(true);
        sw.Stop();
        logger.LogInformation("Finished event handler setup in {time}", sw.Elapsed);
    }

    private void TearDown()
    {
        Stopwatch sw = new();
        logger.LogTrace("Tearing down event handler");
        sw.Start();
        SetBindingState(false);
        sw.Stop();
        logger.LogInformation("Finished event handler teardown in {time}", sw.Elapsed);
    }

    private bool _bindingState;
    private void SetBindingState(bool value)
    {
        Debug.Assert(_bindingState != value, "Binding state was set to the same value twice in a row!");
        if (_bindingState == value)
            throw new InvalidOperationException("Binding state was set to the same value twice in a row!");
        _bindingState = value;

        Stopwatch sw = new();
        logger.LogTrace("Changing event handler binding state to {state}", value ? "bound" : "unbound");
        sw.Start();

        if (value)
            BindHandler(client, HandlerMethod);
        else
            UnbindHandler(client, HandlerMethod);

        sw.Stop();
        logger.LogDebug("Finished binding change in {time}", sw.Elapsed);
    }

    private AsyncEventHandler<DiscordClient, TArgument> HandlerMethod => logger.IsEnabled(LogLevel.Debug) ? OnEventLoggingWrapper : OnEventCore;
    private async Task OnEventLoggingWrapper(DiscordClient sender, TArgument args)
    {
        Stopwatch sw = new();
        logger.LogDebug("Meta-handler invocation started for interface {handlerName}", typeof(THandler).Name);
        sw.Start();
        await OnEventCore(sender, args);
        sw.Stop();
        int count = registry.Registrations.Count;
        logger.LogDebug("Finished calling of {count} handlers in {elapsed}", count, sw.Elapsed);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task OnEventCore(DiscordClient sender, TArgument args)
    {
        return Parallel.ForEachAsync(registry.Registrations, async (handlerRegistration, cancellationToken) =>
        {
            using IServiceScope scope = this.provider.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;
            {
                THandler handler = provider.GetRequiredKeyedService<THandler>(handlerRegistration.Key);
                if (cancellationToken.IsCancellationRequested)
                {
                    logger.LogDebug("Cancellation requested, skipping invocation of event handler");
                    return;
                }

                try
                {
                    await Invoke(handler, sender, args);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "A problem occured while handling event with {EventName} with handler: {HandlerName}", typeof(THandler).Name, handler.GetType().Name);
                    throw;
                }
            }
        });
    }
#if AutoCalling
    protected virtual void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
        => EventHandlerReflector.BindEvent<THandler, TArgument>(client, HandlerMethod);
    protected virtual void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
        => EventHandlerReflector.UnbindEvent<THandler, TArgument>(client, HandlerMethod);

    protected virtual ValueTask Invoke(THandler handler, DiscordClient sender, TArgument args)
        => EventHandlerReflector.AutoCallEventHandler<THandler, TArgument>(handler, sender, args);
#else

    protected abstract void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);
    protected abstract void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);
    protected abstract ValueTask Invoke(THandler handler, DiscordClient sender, TArgument args);
#endif
}