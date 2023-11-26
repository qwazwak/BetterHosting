using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using BetterHosting.EventsNext.Entities.Internal;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DSharpPlus;

namespace BetterHosting.EventsNext.Services.Implementations;

internal abstract class EventHandlerManager<TInterface, TArgument> : IEventHandlerManager
    where TInterface : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    private readonly ILogger<EventHandlerManager<TInterface, TArgument>> logger;
    private readonly IHandlerProvider<TInterface> registry;
    private readonly IServiceProvider provider;
    private readonly AsyncEventHandler<DiscordClient, TArgument> handlerMethod;
    private DiscordShardedClient client = null!;
    private bool started;

    protected EventHandlerManager(ILogger<EventHandlerManager<TInterface, TArgument>> logger, IServiceProvider provider, IHandlerProvider<TInterface> registry)
    {
        this.logger = logger;
        this.provider = provider;
        this.registry = registry;
        handlerMethod = logger.IsEnabled(LogLevel.Debug) ? OnEventLoggingWrapper : OnEventCore;
    }

    public virtual bool CanBeTriggered() => registry.Count != 0;
    public virtual bool CanBeTriggered(DiscordShardedClient client) => true;

    public void Start(DiscordShardedClient client)
    {
        this.client = client;
        Stopwatch sw = new();
        try
        {
            logger.LogTrace("Setting up event handler");
            sw.Start();
            SetBindingState(true);
            started = true;
        }
        finally
        {
            sw.Stop();
            logger.LogInformation("Finished event handler setup in {time}", sw.Elapsed);
        }
    }

    public void Stop()
    {
        if (!started)
        {
            logger.LogTrace("No need to shutdown manager as it was not started");
            return;
        }
        started = false;

        Stopwatch sw = new();
        try
        {
            logger.LogTrace("Tearing down event handler");
            sw.Start();
            SetBindingState(false);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation("Finished event handler teardown in {time}", sw.Elapsed);
        }
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
            BindHandler(client, handlerMethod);
        else
            UnbindHandler(client, handlerMethod);

        sw.Stop();
        logger.LogDebug("Finished binding change in {time}", sw.Elapsed);
    }

    private async Task OnEventLoggingWrapper(DiscordClient sender, TArgument args)
    {
        Stopwatch sw = new();
        logger.LogDebug("Meta-handler invocation started for interface {handlerName}", typeof(TInterface).Name);
        sw.Start();
        await OnEventCore(sender, args).ConfigureAwait(false);
        sw.Stop();
        logger.LogDebug("Finished calling of {count} handlers in {elapsed}", registry.Count, sw.Elapsed);
    }

    private static ArrayPool<Task> OnEventArrayPool => ArrayPool<Task>.Shared;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task OnEventCore(DiscordClient sender, TArgument args)
    {
        Task[] tasks = OnEventArrayPool.Rent(registry.Count);
        try
        {
            Parallel.For(0, registry.Count, i => tasks[i] = OnEventSingle(sender, registry[i], args));
            int extraArrayElements = tasks.Length - registry.Count;
            if (extraArrayElements > 0)
                Array.Fill(tasks, Task.CompletedTask, registry.Count, extraArrayElements);

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        finally
        {
            OnEventArrayPool.Return(tasks);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private async Task OnEventSingle(DiscordClient sender, IHandlerBuilder<TInterface> factory, TArgument args)
    {
        try
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            await using DisposingWrapper<TInterface> wrapper = factory.CreateInstance(scope.ServiceProvider);
            await Invoke(wrapper.Instance, sender, args).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "A problem occurred while handling event handler {HandlerName}", factory.Name);
            throw;
        }
    }

    protected abstract void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);
    protected abstract void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    protected abstract ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument args);
}