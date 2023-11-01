
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.AsyncEvents;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DSharpPlus.EventsNext.BetterHosting.Options.Internal;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.EventsNext.BetterHosting.Services.Hosted;


internal partial class MetaSocketErroredHandler : EventHandlerManager<ISocketErroredEventHandler, SocketErrorEventArgs>
{    
    public MetaSocketErroredHandler(ILogger<MetaSocketErroredHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ISocketErroredEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketErrorEventArgs> handler) => client.SocketErrored += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketErrorEventArgs> handler) => client.SocketErrored -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketErroredEventHandler handler, DiscordClient sender, SocketErrorEventArgs args) => handler.OnSocketErrored(sender, args);
}

internal partial class MetaSocketOpenedHandler : EventHandlerManager<ISocketOpenedEventHandler, SocketEventArgs>
{    
    public MetaSocketOpenedHandler(ILogger<MetaSocketOpenedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ISocketOpenedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketEventArgs> handler) => client.SocketOpened += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketEventArgs> handler) => client.SocketOpened -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketOpenedEventHandler handler, DiscordClient sender, SocketEventArgs args) => handler.OnSocketOpened(sender, args);
}

internal partial class MetaSocketClosedHandler : EventHandlerManager<ISocketClosedEventHandler, SocketCloseEventArgs>
{    
    public MetaSocketClosedHandler(ILogger<MetaSocketClosedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ISocketClosedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketCloseEventArgs> handler) => client.SocketClosed += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketCloseEventArgs> handler) => client.SocketClosed -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketClosedEventHandler handler, DiscordClient sender, SocketCloseEventArgs args) => handler.OnSocketClosed(sender, args);
}

internal partial class MetaSessionCreatedHandler : EventHandlerManager<ISessionCreatedEventHandler, SessionReadyEventArgs>
{    
    public MetaSessionCreatedHandler(ILogger<MetaSessionCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ISessionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISessionCreatedEventHandler handler, DiscordClient sender, SessionReadyEventArgs args) => handler.OnSessionCreated(sender, args);
}

internal partial class MetaSessionResumedHandler : EventHandlerManager<ISessionResumedEventHandler, SessionReadyEventArgs>
{    
    public MetaSessionResumedHandler(ILogger<MetaSessionResumedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ISessionResumedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionResumed += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionResumed -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISessionResumedEventHandler handler, DiscordClient sender, SessionReadyEventArgs args) => handler.OnSessionResumed(sender, args);
}

internal partial class MetaHeartbeatedHandler : EventHandlerManager<IHeartbeatedEventHandler, HeartbeatEventArgs>
{    
    public MetaHeartbeatedHandler(ILogger<MetaHeartbeatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IHeartbeatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, HeartbeatEventArgs> handler) => client.Heartbeated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, HeartbeatEventArgs> handler) => client.Heartbeated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IHeartbeatedEventHandler handler, DiscordClient sender, HeartbeatEventArgs args) => handler.OnHeartbeated(sender, args);
}

internal partial class MetaZombiedHandler : EventHandlerManager<IZombiedEventHandler, ZombiedEventArgs>
{    
    public MetaZombiedHandler(ILogger<MetaZombiedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IZombiedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ZombiedEventArgs> handler) => client.Zombied += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ZombiedEventArgs> handler) => client.Zombied -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IZombiedEventHandler handler, DiscordClient sender, ZombiedEventArgs args) => handler.OnZombied(sender, args);
}

internal partial class MetaApplicationCommandPermissionsUpdatedHandler : EventHandlerManager<IApplicationCommandPermissionsUpdatedEventHandler, ApplicationCommandPermissionsUpdatedEventArgs>
{    
    public MetaApplicationCommandPermissionsUpdatedHandler(ILogger<MetaApplicationCommandPermissionsUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IApplicationCommandPermissionsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> handler) => client.ApplicationCommandPermissionsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> handler) => client.ApplicationCommandPermissionsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IApplicationCommandPermissionsUpdatedEventHandler handler, DiscordClient sender, ApplicationCommandPermissionsUpdatedEventArgs args) => handler.OnApplicationCommandPermissionsUpdated(sender, args);
}

internal partial class MetaChannelCreatedHandler : EventHandlerManager<IChannelCreatedEventHandler, ChannelCreateEventArgs>
{    
    public MetaChannelCreatedHandler(ILogger<MetaChannelCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IChannelCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> handler) => client.ChannelCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> handler) => client.ChannelCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelCreatedEventHandler handler, DiscordClient sender, ChannelCreateEventArgs args) => handler.OnChannelCreated(sender, args);
}

internal partial class MetaChannelUpdatedHandler : EventHandlerManager<IChannelUpdatedEventHandler, ChannelUpdateEventArgs>
{    
    public MetaChannelUpdatedHandler(ILogger<MetaChannelUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IChannelUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> handler) => client.ChannelUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> handler) => client.ChannelUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelUpdatedEventHandler handler, DiscordClient sender, ChannelUpdateEventArgs args) => handler.OnChannelUpdated(sender, args);
}

internal partial class MetaChannelDeletedHandler : EventHandlerManager<IChannelDeletedEventHandler, ChannelDeleteEventArgs>
{    
    public MetaChannelDeletedHandler(ILogger<MetaChannelDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IChannelDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> handler) => client.ChannelDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> handler) => client.ChannelDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelDeletedEventHandler handler, DiscordClient sender, ChannelDeleteEventArgs args) => handler.OnChannelDeleted(sender, args);
}

internal partial class MetaDmChannelDeletedHandler : EventHandlerManager<IDmChannelDeletedEventHandler, DmChannelDeleteEventArgs>
{    
    public MetaDmChannelDeletedHandler(ILogger<MetaDmChannelDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IDmChannelDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> handler) => client.DmChannelDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> handler) => client.DmChannelDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IDmChannelDeletedEventHandler handler, DiscordClient sender, DmChannelDeleteEventArgs args) => handler.OnDmChannelDeleted(sender, args);
}

internal partial class MetaChannelPinsUpdatedHandler : EventHandlerManager<IChannelPinsUpdatedEventHandler, ChannelPinsUpdateEventArgs>
{    
    public MetaChannelPinsUpdatedHandler(ILogger<MetaChannelPinsUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IChannelPinsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> handler) => client.ChannelPinsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> handler) => client.ChannelPinsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelPinsUpdatedEventHandler handler, DiscordClient sender, ChannelPinsUpdateEventArgs args) => handler.OnChannelPinsUpdated(sender, args);
}

internal partial class MetaGuildCreatedHandler : EventHandlerManager<IGuildCreatedEventHandler, GuildCreateEventArgs>
{    
    public MetaGuildCreatedHandler(ILogger<MetaGuildCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildCreatedEventHandler handler, DiscordClient sender, GuildCreateEventArgs args) => handler.OnGuildCreated(sender, args);
}

internal partial class MetaGuildAvailableHandler : EventHandlerManager<IGuildAvailableEventHandler, GuildCreateEventArgs>
{    
    public MetaGuildAvailableHandler(ILogger<MetaGuildAvailableHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildAvailableEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildAvailable += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildAvailable -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildAvailableEventHandler handler, DiscordClient sender, GuildCreateEventArgs args) => handler.OnGuildAvailable(sender, args);
}

internal partial class MetaGuildUpdatedHandler : EventHandlerManager<IGuildUpdatedEventHandler, GuildUpdateEventArgs>
{    
    public MetaGuildUpdatedHandler(ILogger<MetaGuildUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> handler) => client.GuildUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> handler) => client.GuildUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildUpdatedEventHandler handler, DiscordClient sender, GuildUpdateEventArgs args) => handler.OnGuildUpdated(sender, args);
}

internal partial class MetaGuildDeletedHandler : EventHandlerManager<IGuildDeletedEventHandler, GuildDeleteEventArgs>
{    
    public MetaGuildDeletedHandler(ILogger<MetaGuildDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildDeletedEventHandler handler, DiscordClient sender, GuildDeleteEventArgs args) => handler.OnGuildDeleted(sender, args);
}

internal partial class MetaGuildUnavailableHandler : EventHandlerManager<IGuildUnavailableEventHandler, GuildDeleteEventArgs>
{    
    public MetaGuildUnavailableHandler(ILogger<MetaGuildUnavailableHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildUnavailableEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildUnavailable += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildUnavailable -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildUnavailableEventHandler handler, DiscordClient sender, GuildDeleteEventArgs args) => handler.OnGuildUnavailable(sender, args);
}

internal partial class MetaGuildDownloadCompletedHandler : EventHandlerManager<IGuildDownloadCompletedEventHandler, GuildDownloadCompletedEventArgs>
{    
    public MetaGuildDownloadCompletedHandler(ILogger<MetaGuildDownloadCompletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildDownloadCompletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> handler) => client.GuildDownloadCompleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> handler) => client.GuildDownloadCompleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildDownloadCompletedEventHandler handler, DiscordClient sender, GuildDownloadCompletedEventArgs args) => handler.OnGuildDownloadCompleted(sender, args);
}

internal partial class MetaGuildEmojisUpdatedHandler : EventHandlerManager<IGuildEmojisUpdatedEventHandler, GuildEmojisUpdateEventArgs>
{    
    public MetaGuildEmojisUpdatedHandler(ILogger<MetaGuildEmojisUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildEmojisUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> handler) => client.GuildEmojisUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> handler) => client.GuildEmojisUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildEmojisUpdatedEventHandler handler, DiscordClient sender, GuildEmojisUpdateEventArgs args) => handler.OnGuildEmojisUpdated(sender, args);
}

internal partial class MetaGuildStickersUpdatedHandler : EventHandlerManager<IGuildStickersUpdatedEventHandler, GuildStickersUpdateEventArgs>
{    
    public MetaGuildStickersUpdatedHandler(ILogger<MetaGuildStickersUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildStickersUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> handler) => client.GuildStickersUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> handler) => client.GuildStickersUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildStickersUpdatedEventHandler handler, DiscordClient sender, GuildStickersUpdateEventArgs args) => handler.OnGuildStickersUpdated(sender, args);
}

internal partial class MetaGuildIntegrationsUpdatedHandler : EventHandlerManager<IGuildIntegrationsUpdatedEventHandler, GuildIntegrationsUpdateEventArgs>
{    
    public MetaGuildIntegrationsUpdatedHandler(ILogger<MetaGuildIntegrationsUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildIntegrationsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> handler) => client.GuildIntegrationsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> handler) => client.GuildIntegrationsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildIntegrationsUpdatedEventHandler handler, DiscordClient sender, GuildIntegrationsUpdateEventArgs args) => handler.OnGuildIntegrationsUpdated(sender, args);
}

internal partial class MetaGuildAuditLogCreatedHandler : EventHandlerManager<IGuildAuditLogCreatedEventHandler, GuildAuditLogCreatedEventArgs>
{    
    public MetaGuildAuditLogCreatedHandler(ILogger<MetaGuildAuditLogCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildAuditLogCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> handler) => client.GuildAuditLogCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> handler) => client.GuildAuditLogCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildAuditLogCreatedEventHandler handler, DiscordClient sender, GuildAuditLogCreatedEventArgs args) => handler.OnGuildAuditLogCreated(sender, args);
}

internal partial class MetaScheduledGuildEventCreatedHandler : EventHandlerManager<IScheduledGuildEventCreatedEventHandler, ScheduledGuildEventCreateEventArgs>
{    
    public MetaScheduledGuildEventCreatedHandler(ILogger<MetaScheduledGuildEventCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> handler) => client.ScheduledGuildEventCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> handler) => client.ScheduledGuildEventCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventCreatedEventHandler handler, DiscordClient sender, ScheduledGuildEventCreateEventArgs args) => handler.OnScheduledGuildEventCreated(sender, args);
}

internal partial class MetaScheduledGuildEventUpdatedHandler : EventHandlerManager<IScheduledGuildEventUpdatedEventHandler, ScheduledGuildEventUpdateEventArgs>
{    
    public MetaScheduledGuildEventUpdatedHandler(ILogger<MetaScheduledGuildEventUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> handler) => client.ScheduledGuildEventUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> handler) => client.ScheduledGuildEventUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUpdatedEventHandler handler, DiscordClient sender, ScheduledGuildEventUpdateEventArgs args) => handler.OnScheduledGuildEventUpdated(sender, args);
}

internal partial class MetaScheduledGuildEventDeletedHandler : EventHandlerManager<IScheduledGuildEventDeletedEventHandler, ScheduledGuildEventDeleteEventArgs>
{    
    public MetaScheduledGuildEventDeletedHandler(ILogger<MetaScheduledGuildEventDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> handler) => client.ScheduledGuildEventDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> handler) => client.ScheduledGuildEventDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventDeletedEventHandler handler, DiscordClient sender, ScheduledGuildEventDeleteEventArgs args) => handler.OnScheduledGuildEventDeleted(sender, args);
}

internal partial class MetaScheduledGuildEventCompletedHandler : EventHandlerManager<IScheduledGuildEventCompletedEventHandler, ScheduledGuildEventCompletedEventArgs>
{    
    public MetaScheduledGuildEventCompletedHandler(ILogger<MetaScheduledGuildEventCompletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventCompletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> handler) => client.ScheduledGuildEventCompleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> handler) => client.ScheduledGuildEventCompleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventCompletedEventHandler handler, DiscordClient sender, ScheduledGuildEventCompletedEventArgs args) => handler.OnScheduledGuildEventCompleted(sender, args);
}

internal partial class MetaScheduledGuildEventUserAddedHandler : EventHandlerManager<IScheduledGuildEventUserAddedEventHandler, ScheduledGuildEventUserAddEventArgs>
{    
    public MetaScheduledGuildEventUserAddedHandler(ILogger<MetaScheduledGuildEventUserAddedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventUserAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> handler) => client.ScheduledGuildEventUserAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> handler) => client.ScheduledGuildEventUserAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUserAddedEventHandler handler, DiscordClient sender, ScheduledGuildEventUserAddEventArgs args) => handler.OnScheduledGuildEventUserAdded(sender, args);
}

internal partial class MetaScheduledGuildEventUserRemovedHandler : EventHandlerManager<IScheduledGuildEventUserRemovedEventHandler, ScheduledGuildEventUserRemoveEventArgs>
{    
    public MetaScheduledGuildEventUserRemovedHandler(ILogger<MetaScheduledGuildEventUserRemovedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IScheduledGuildEventUserRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> handler) => client.ScheduledGuildEventUserRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> handler) => client.ScheduledGuildEventUserRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUserRemovedEventHandler handler, DiscordClient sender, ScheduledGuildEventUserRemoveEventArgs args) => handler.OnScheduledGuildEventUserRemoved(sender, args);
}

internal partial class MetaGuildBanAddedHandler : EventHandlerManager<IGuildBanAddedEventHandler, GuildBanAddEventArgs>
{    
    public MetaGuildBanAddedHandler(ILogger<MetaGuildBanAddedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildBanAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> handler) => client.GuildBanAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> handler) => client.GuildBanAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildBanAddedEventHandler handler, DiscordClient sender, GuildBanAddEventArgs args) => handler.OnGuildBanAdded(sender, args);
}

internal partial class MetaGuildBanRemovedHandler : EventHandlerManager<IGuildBanRemovedEventHandler, GuildBanRemoveEventArgs>
{    
    public MetaGuildBanRemovedHandler(ILogger<MetaGuildBanRemovedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildBanRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> handler) => client.GuildBanRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> handler) => client.GuildBanRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildBanRemovedEventHandler handler, DiscordClient sender, GuildBanRemoveEventArgs args) => handler.OnGuildBanRemoved(sender, args);
}

internal partial class MetaGuildMemberAddedHandler : EventHandlerManager<IGuildMemberAddedEventHandler, GuildMemberAddEventArgs>
{    
    public MetaGuildMemberAddedHandler(ILogger<MetaGuildMemberAddedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildMemberAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> handler) => client.GuildMemberAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> handler) => client.GuildMemberAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberAddedEventHandler handler, DiscordClient sender, GuildMemberAddEventArgs args) => handler.OnGuildMemberAdded(sender, args);
}

internal partial class MetaGuildMemberRemovedHandler : EventHandlerManager<IGuildMemberRemovedEventHandler, GuildMemberRemoveEventArgs>
{    
    public MetaGuildMemberRemovedHandler(ILogger<MetaGuildMemberRemovedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildMemberRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> handler) => client.GuildMemberRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> handler) => client.GuildMemberRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberRemovedEventHandler handler, DiscordClient sender, GuildMemberRemoveEventArgs args) => handler.OnGuildMemberRemoved(sender, args);
}

internal partial class MetaGuildMemberUpdatedHandler : EventHandlerManager<IGuildMemberUpdatedEventHandler, GuildMemberUpdateEventArgs>
{    
    public MetaGuildMemberUpdatedHandler(ILogger<MetaGuildMemberUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildMemberUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> handler) => client.GuildMemberUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> handler) => client.GuildMemberUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberUpdatedEventHandler handler, DiscordClient sender, GuildMemberUpdateEventArgs args) => handler.OnGuildMemberUpdated(sender, args);
}

internal partial class MetaGuildMembersChunkedHandler : EventHandlerManager<IGuildMembersChunkedEventHandler, GuildMembersChunkEventArgs>
{    
    public MetaGuildMembersChunkedHandler(ILogger<MetaGuildMembersChunkedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildMembersChunkedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> handler) => client.GuildMembersChunked += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> handler) => client.GuildMembersChunked -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMembersChunkedEventHandler handler, DiscordClient sender, GuildMembersChunkEventArgs args) => handler.OnGuildMembersChunked(sender, args);
}

internal partial class MetaGuildRoleCreatedHandler : EventHandlerManager<IGuildRoleCreatedEventHandler, GuildRoleCreateEventArgs>
{    
    public MetaGuildRoleCreatedHandler(ILogger<MetaGuildRoleCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildRoleCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> handler) => client.GuildRoleCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> handler) => client.GuildRoleCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleCreatedEventHandler handler, DiscordClient sender, GuildRoleCreateEventArgs args) => handler.OnGuildRoleCreated(sender, args);
}

internal partial class MetaGuildRoleUpdatedHandler : EventHandlerManager<IGuildRoleUpdatedEventHandler, GuildRoleUpdateEventArgs>
{    
    public MetaGuildRoleUpdatedHandler(ILogger<MetaGuildRoleUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildRoleUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> handler) => client.GuildRoleUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> handler) => client.GuildRoleUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleUpdatedEventHandler handler, DiscordClient sender, GuildRoleUpdateEventArgs args) => handler.OnGuildRoleUpdated(sender, args);
}

internal partial class MetaGuildRoleDeletedHandler : EventHandlerManager<IGuildRoleDeletedEventHandler, GuildRoleDeleteEventArgs>
{    
    public MetaGuildRoleDeletedHandler(ILogger<MetaGuildRoleDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IGuildRoleDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> handler) => client.GuildRoleDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> handler) => client.GuildRoleDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleDeletedEventHandler handler, DiscordClient sender, GuildRoleDeleteEventArgs args) => handler.OnGuildRoleDeleted(sender, args);
}

internal partial class MetaInviteCreatedHandler : EventHandlerManager<IInviteCreatedEventHandler, InviteCreateEventArgs>
{    
    public MetaInviteCreatedHandler(ILogger<MetaInviteCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IInviteCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteCreateEventArgs> handler) => client.InviteCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteCreateEventArgs> handler) => client.InviteCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInviteCreatedEventHandler handler, DiscordClient sender, InviteCreateEventArgs args) => handler.OnInviteCreated(sender, args);
}

internal partial class MetaInviteDeletedHandler : EventHandlerManager<IInviteDeletedEventHandler, InviteDeleteEventArgs>
{    
    public MetaInviteDeletedHandler(ILogger<MetaInviteDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IInviteDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> handler) => client.InviteDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> handler) => client.InviteDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInviteDeletedEventHandler handler, DiscordClient sender, InviteDeleteEventArgs args) => handler.OnInviteDeleted(sender, args);
}

internal partial class MetaMessageCreatedHandler : EventHandlerManager<IMessageCreatedEventHandler, MessageCreateEventArgs>
{    
    public MetaMessageCreatedHandler(ILogger<MetaMessageCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageCreateEventArgs> handler) => client.MessageCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageCreateEventArgs> handler) => client.MessageCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageCreatedEventHandler handler, DiscordClient sender, MessageCreateEventArgs args) => handler.OnMessageCreated(sender, args);
}

internal partial class MetaMessageAcknowledgedHandler : EventHandlerManager<IMessageAcknowledgedEventHandler, MessageAcknowledgeEventArgs>
{    
    public MetaMessageAcknowledgedHandler(ILogger<MetaMessageAcknowledgedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageAcknowledgedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> handler) => client.MessageAcknowledged += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> handler) => client.MessageAcknowledged -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageAcknowledgedEventHandler handler, DiscordClient sender, MessageAcknowledgeEventArgs args) => handler.OnMessageAcknowledged(sender, args);
}

internal partial class MetaMessageUpdatedHandler : EventHandlerManager<IMessageUpdatedEventHandler, MessageUpdateEventArgs>
{    
    public MetaMessageUpdatedHandler(ILogger<MetaMessageUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> handler) => client.MessageUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> handler) => client.MessageUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageUpdatedEventHandler handler, DiscordClient sender, MessageUpdateEventArgs args) => handler.OnMessageUpdated(sender, args);
}

internal partial class MetaMessageDeletedHandler : EventHandlerManager<IMessageDeletedEventHandler, MessageDeleteEventArgs>
{    
    public MetaMessageDeletedHandler(ILogger<MetaMessageDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> handler) => client.MessageDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> handler) => client.MessageDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageDeletedEventHandler handler, DiscordClient sender, MessageDeleteEventArgs args) => handler.OnMessageDeleted(sender, args);
}

internal partial class MetaMessagesBulkDeletedHandler : EventHandlerManager<IMessagesBulkDeletedEventHandler, MessageBulkDeleteEventArgs>
{    
    public MetaMessagesBulkDeletedHandler(ILogger<MetaMessagesBulkDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessagesBulkDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> handler) => client.MessagesBulkDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> handler) => client.MessagesBulkDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessagesBulkDeletedEventHandler handler, DiscordClient sender, MessageBulkDeleteEventArgs args) => handler.OnMessagesBulkDeleted(sender, args);
}

internal partial class MetaMessageReactionAddedHandler : EventHandlerManager<IMessageReactionAddedEventHandler, MessageReactionAddEventArgs>
{    
    public MetaMessageReactionAddedHandler(ILogger<MetaMessageReactionAddedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageReactionAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> handler) => client.MessageReactionAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> handler) => client.MessageReactionAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionAddedEventHandler handler, DiscordClient sender, MessageReactionAddEventArgs args) => handler.OnMessageReactionAdded(sender, args);
}

internal partial class MetaMessageReactionRemovedHandler : EventHandlerManager<IMessageReactionRemovedEventHandler, MessageReactionRemoveEventArgs>
{    
    public MetaMessageReactionRemovedHandler(ILogger<MetaMessageReactionRemovedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageReactionRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> handler) => client.MessageReactionRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> handler) => client.MessageReactionRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionRemovedEventHandler handler, DiscordClient sender, MessageReactionRemoveEventArgs args) => handler.OnMessageReactionRemoved(sender, args);
}

internal partial class MetaMessageReactionsClearedHandler : EventHandlerManager<IMessageReactionsClearedEventHandler, MessageReactionsClearEventArgs>
{    
    public MetaMessageReactionsClearedHandler(ILogger<MetaMessageReactionsClearedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageReactionsClearedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> handler) => client.MessageReactionsCleared += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> handler) => client.MessageReactionsCleared -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionsClearedEventHandler handler, DiscordClient sender, MessageReactionsClearEventArgs args) => handler.OnMessageReactionsCleared(sender, args);
}

internal partial class MetaMessageReactionRemovedEmojiHandler : EventHandlerManager<IMessageReactionRemovedEmojiEventHandler, MessageReactionRemoveEmojiEventArgs>
{    
    public MetaMessageReactionRemovedEmojiHandler(ILogger<MetaMessageReactionRemovedEmojiHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IMessageReactionRemovedEmojiEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> handler) => client.MessageReactionRemovedEmoji += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> handler) => client.MessageReactionRemovedEmoji -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionRemovedEmojiEventHandler handler, DiscordClient sender, MessageReactionRemoveEmojiEventArgs args) => handler.OnMessageReactionRemovedEmoji(sender, args);
}

internal partial class MetaPresenceUpdatedHandler : EventHandlerManager<IPresenceUpdatedEventHandler, PresenceUpdateEventArgs>
{    
    public MetaPresenceUpdatedHandler(ILogger<MetaPresenceUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IPresenceUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> handler) => client.PresenceUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> handler) => client.PresenceUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IPresenceUpdatedEventHandler handler, DiscordClient sender, PresenceUpdateEventArgs args) => handler.OnPresenceUpdated(sender, args);
}

internal partial class MetaUserSettingsUpdatedHandler : EventHandlerManager<IUserSettingsUpdatedEventHandler, UserSettingsUpdateEventArgs>
{    
    public MetaUserSettingsUpdatedHandler(ILogger<MetaUserSettingsUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IUserSettingsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> handler) => client.UserSettingsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> handler) => client.UserSettingsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUserSettingsUpdatedEventHandler handler, DiscordClient sender, UserSettingsUpdateEventArgs args) => handler.OnUserSettingsUpdated(sender, args);
}

internal partial class MetaUserUpdatedHandler : EventHandlerManager<IUserUpdatedEventHandler, UserUpdateEventArgs>
{    
    public MetaUserUpdatedHandler(ILogger<MetaUserUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IUserUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserUpdateEventArgs> handler) => client.UserUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserUpdateEventArgs> handler) => client.UserUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUserUpdatedEventHandler handler, DiscordClient sender, UserUpdateEventArgs args) => handler.OnUserUpdated(sender, args);
}

internal partial class MetaVoiceStateUpdatedHandler : EventHandlerManager<IVoiceStateUpdatedEventHandler, VoiceStateUpdateEventArgs>
{    
    public MetaVoiceStateUpdatedHandler(ILogger<MetaVoiceStateUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IVoiceStateUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> handler) => client.VoiceStateUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> handler) => client.VoiceStateUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IVoiceStateUpdatedEventHandler handler, DiscordClient sender, VoiceStateUpdateEventArgs args) => handler.OnVoiceStateUpdated(sender, args);
}

internal partial class MetaVoiceServerUpdatedHandler : EventHandlerManager<IVoiceServerUpdatedEventHandler, VoiceServerUpdateEventArgs>
{    
    public MetaVoiceServerUpdatedHandler(ILogger<MetaVoiceServerUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IVoiceServerUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> handler) => client.VoiceServerUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> handler) => client.VoiceServerUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IVoiceServerUpdatedEventHandler handler, DiscordClient sender, VoiceServerUpdateEventArgs args) => handler.OnVoiceServerUpdated(sender, args);
}

internal partial class MetaThreadCreatedHandler : EventHandlerManager<IThreadCreatedEventHandler, ThreadCreateEventArgs>
{    
    public MetaThreadCreatedHandler(ILogger<MetaThreadCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> handler) => client.ThreadCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> handler) => client.ThreadCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadCreatedEventHandler handler, DiscordClient sender, ThreadCreateEventArgs args) => handler.OnThreadCreated(sender, args);
}

internal partial class MetaThreadUpdatedHandler : EventHandlerManager<IThreadUpdatedEventHandler, ThreadUpdateEventArgs>
{    
    public MetaThreadUpdatedHandler(ILogger<MetaThreadUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> handler) => client.ThreadUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> handler) => client.ThreadUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadUpdatedEventHandler handler, DiscordClient sender, ThreadUpdateEventArgs args) => handler.OnThreadUpdated(sender, args);
}

internal partial class MetaThreadDeletedHandler : EventHandlerManager<IThreadDeletedEventHandler, ThreadDeleteEventArgs>
{    
    public MetaThreadDeletedHandler(ILogger<MetaThreadDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> handler) => client.ThreadDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> handler) => client.ThreadDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadDeletedEventHandler handler, DiscordClient sender, ThreadDeleteEventArgs args) => handler.OnThreadDeleted(sender, args);
}

internal partial class MetaThreadListSyncedHandler : EventHandlerManager<IThreadListSyncedEventHandler, ThreadListSyncEventArgs>
{    
    public MetaThreadListSyncedHandler(ILogger<MetaThreadListSyncedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadListSyncedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> handler) => client.ThreadListSynced += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> handler) => client.ThreadListSynced -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadListSyncedEventHandler handler, DiscordClient sender, ThreadListSyncEventArgs args) => handler.OnThreadListSynced(sender, args);
}

internal partial class MetaThreadMemberUpdatedHandler : EventHandlerManager<IThreadMemberUpdatedEventHandler, ThreadMemberUpdateEventArgs>
{    
    public MetaThreadMemberUpdatedHandler(ILogger<MetaThreadMemberUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadMemberUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> handler) => client.ThreadMemberUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> handler) => client.ThreadMemberUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadMemberUpdatedEventHandler handler, DiscordClient sender, ThreadMemberUpdateEventArgs args) => handler.OnThreadMemberUpdated(sender, args);
}

internal partial class MetaThreadMembersUpdatedHandler : EventHandlerManager<IThreadMembersUpdatedEventHandler, ThreadMembersUpdateEventArgs>
{    
    public MetaThreadMembersUpdatedHandler(ILogger<MetaThreadMembersUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IThreadMembersUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> handler) => client.ThreadMembersUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> handler) => client.ThreadMembersUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadMembersUpdatedEventHandler handler, DiscordClient sender, ThreadMembersUpdateEventArgs args) => handler.OnThreadMembersUpdated(sender, args);
}

internal partial class MetaIntegrationCreatedHandler : EventHandlerManager<IIntegrationCreatedEventHandler, IntegrationCreateEventArgs>
{    
    public MetaIntegrationCreatedHandler(ILogger<MetaIntegrationCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IIntegrationCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> handler) => client.IntegrationCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> handler) => client.IntegrationCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationCreatedEventHandler handler, DiscordClient sender, IntegrationCreateEventArgs args) => handler.OnIntegrationCreated(sender, args);
}

internal partial class MetaIntegrationUpdatedHandler : EventHandlerManager<IIntegrationUpdatedEventHandler, IntegrationUpdateEventArgs>
{    
    public MetaIntegrationUpdatedHandler(ILogger<MetaIntegrationUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IIntegrationUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> handler) => client.IntegrationUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> handler) => client.IntegrationUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationUpdatedEventHandler handler, DiscordClient sender, IntegrationUpdateEventArgs args) => handler.OnIntegrationUpdated(sender, args);
}

internal partial class MetaIntegrationDeletedHandler : EventHandlerManager<IIntegrationDeletedEventHandler, IntegrationDeleteEventArgs>
{    
    public MetaIntegrationDeletedHandler(ILogger<MetaIntegrationDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IIntegrationDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> handler) => client.IntegrationDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> handler) => client.IntegrationDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationDeletedEventHandler handler, DiscordClient sender, IntegrationDeleteEventArgs args) => handler.OnIntegrationDeleted(sender, args);
}

internal partial class MetaStageInstanceCreatedHandler : EventHandlerManager<IStageInstanceCreatedEventHandler, StageInstanceCreateEventArgs>
{    
    public MetaStageInstanceCreatedHandler(ILogger<MetaStageInstanceCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IStageInstanceCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> handler) => client.StageInstanceCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> handler) => client.StageInstanceCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceCreatedEventHandler handler, DiscordClient sender, StageInstanceCreateEventArgs args) => handler.OnStageInstanceCreated(sender, args);
}

internal partial class MetaStageInstanceUpdatedHandler : EventHandlerManager<IStageInstanceUpdatedEventHandler, StageInstanceUpdateEventArgs>
{    
    public MetaStageInstanceUpdatedHandler(ILogger<MetaStageInstanceUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IStageInstanceUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> handler) => client.StageInstanceUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> handler) => client.StageInstanceUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceUpdatedEventHandler handler, DiscordClient sender, StageInstanceUpdateEventArgs args) => handler.OnStageInstanceUpdated(sender, args);
}

internal partial class MetaStageInstanceDeletedHandler : EventHandlerManager<IStageInstanceDeletedEventHandler, StageInstanceDeleteEventArgs>
{    
    public MetaStageInstanceDeletedHandler(ILogger<MetaStageInstanceDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IStageInstanceDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> handler) => client.StageInstanceDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> handler) => client.StageInstanceDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceDeletedEventHandler handler, DiscordClient sender, StageInstanceDeleteEventArgs args) => handler.OnStageInstanceDeleted(sender, args);
}

internal partial class MetaInteractionCreatedHandler : EventHandlerManager<IInteractionCreatedEventHandler, InteractionCreateEventArgs>
{    
    public MetaInteractionCreatedHandler(ILogger<MetaInteractionCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> handler) => client.InteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> handler) => client.InteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInteractionCreatedEventHandler handler, DiscordClient sender, InteractionCreateEventArgs args) => handler.OnInteractionCreated(sender, args);
}

internal partial class MetaComponentInteractionCreatedHandler : EventHandlerManager<IComponentInteractionCreatedEventHandler, ComponentInteractionCreateEventArgs>
{    
    public MetaComponentInteractionCreatedHandler(ILogger<MetaComponentInteractionCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IComponentInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> handler) => client.ComponentInteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> handler) => client.ComponentInteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IComponentInteractionCreatedEventHandler handler, DiscordClient sender, ComponentInteractionCreateEventArgs args) => handler.OnComponentInteractionCreated(sender, args);
}

internal partial class MetaModalSubmittedHandler : EventHandlerManager<IModalSubmittedEventHandler, ModalSubmitEventArgs>
{    
    public MetaModalSubmittedHandler(ILogger<MetaModalSubmittedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IModalSubmittedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> handler) => client.ModalSubmitted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> handler) => client.ModalSubmitted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IModalSubmittedEventHandler handler, DiscordClient sender, ModalSubmitEventArgs args) => handler.OnModalSubmitted(sender, args);
}

internal partial class MetaContextMenuInteractionCreatedHandler : EventHandlerManager<IContextMenuInteractionCreatedEventHandler, ContextMenuInteractionCreateEventArgs>
{    
    public MetaContextMenuInteractionCreatedHandler(ILogger<MetaContextMenuInteractionCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IContextMenuInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> handler) => client.ContextMenuInteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> handler) => client.ContextMenuInteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IContextMenuInteractionCreatedEventHandler handler, DiscordClient sender, ContextMenuInteractionCreateEventArgs args) => handler.OnContextMenuInteractionCreated(sender, args);
}

internal partial class MetaTypingStartedHandler : EventHandlerManager<ITypingStartedEventHandler, TypingStartEventArgs>
{    
    public MetaTypingStartedHandler(ILogger<MetaTypingStartedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<ITypingStartedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TypingStartEventArgs> handler) => client.TypingStarted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TypingStartEventArgs> handler) => client.TypingStarted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ITypingStartedEventHandler handler, DiscordClient sender, TypingStartEventArgs args) => handler.OnTypingStarted(sender, args);
}

internal partial class MetaUnknownEventHandler : EventHandlerManager<IUnknownEventEventHandler, UnknownEventArgs>
{    
    public MetaUnknownEventHandler(ILogger<MetaUnknownEventHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IUnknownEventEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UnknownEventArgs> handler) => client.UnknownEvent += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UnknownEventArgs> handler) => client.UnknownEvent -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUnknownEventEventHandler handler, DiscordClient sender, UnknownEventArgs args) => handler.OnUnknownEvent(sender, args);
}

internal partial class MetaWebhooksUpdatedHandler : EventHandlerManager<IWebhooksUpdatedEventHandler, WebhooksUpdateEventArgs>
{    
    public MetaWebhooksUpdatedHandler(ILogger<MetaWebhooksUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IWebhooksUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> handler) => client.WebhooksUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> handler) => client.WebhooksUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IWebhooksUpdatedEventHandler handler, DiscordClient sender, WebhooksUpdateEventArgs args) => handler.OnWebhooksUpdated(sender, args);
}

internal partial class MetaClientErroredHandler : EventHandlerManager<IClientErroredEventHandler, ClientErrorEventArgs>
{    
    public MetaClientErroredHandler(ILogger<MetaClientErroredHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IClientErroredEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ClientErrorEventArgs> handler) => client.ClientErrored += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ClientErrorEventArgs> handler) => client.ClientErrored -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IClientErroredEventHandler handler, DiscordClient sender, ClientErrorEventArgs args) => handler.OnClientErrored(sender, args);
}

internal partial class MetaAutoModerationRuleCreatedHandler : EventHandlerManager<IAutoModerationRuleCreatedEventHandler, AutoModerationRuleCreateEventArgs>
{    
    public MetaAutoModerationRuleCreatedHandler(ILogger<MetaAutoModerationRuleCreatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IAutoModerationRuleCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> handler) => client.AutoModerationRuleCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> handler) => client.AutoModerationRuleCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleCreatedEventHandler handler, DiscordClient sender, AutoModerationRuleCreateEventArgs args) => handler.OnAutoModerationRuleCreated(sender, args);
}

internal partial class MetaAutoModerationRuleUpdatedHandler : EventHandlerManager<IAutoModerationRuleUpdatedEventHandler, AutoModerationRuleUpdateEventArgs>
{    
    public MetaAutoModerationRuleUpdatedHandler(ILogger<MetaAutoModerationRuleUpdatedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IAutoModerationRuleUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> handler) => client.AutoModerationRuleUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> handler) => client.AutoModerationRuleUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleUpdatedEventHandler handler, DiscordClient sender, AutoModerationRuleUpdateEventArgs args) => handler.OnAutoModerationRuleUpdated(sender, args);
}

internal partial class MetaAutoModerationRuleDeletedHandler : EventHandlerManager<IAutoModerationRuleDeletedEventHandler, AutoModerationRuleDeleteEventArgs>
{    
    public MetaAutoModerationRuleDeletedHandler(ILogger<MetaAutoModerationRuleDeletedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IAutoModerationRuleDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> handler) => client.AutoModerationRuleDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> handler) => client.AutoModerationRuleDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleDeletedEventHandler handler, DiscordClient sender, AutoModerationRuleDeleteEventArgs args) => handler.OnAutoModerationRuleDeleted(sender, args);
}

internal partial class MetaAutoModerationRuleExecutedHandler : EventHandlerManager<IAutoModerationRuleExecutedEventHandler, AutoModerationRuleExecuteEventArgs>
{    
    public MetaAutoModerationRuleExecutedHandler(ILogger<MetaAutoModerationRuleExecutedHandler> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<IAutoModerationRuleExecutedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider) : base(logger, discordConfig, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> handler) => client.AutoModerationRuleExecuted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> handler) => client.AutoModerationRuleExecuted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleExecutedEventHandler handler, DiscordClient sender, AutoModerationRuleExecuteEventArgs args) => handler.OnAutoModerationRuleExecuted(sender, args);
}
