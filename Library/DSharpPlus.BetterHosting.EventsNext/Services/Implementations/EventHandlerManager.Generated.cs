﻿
using DSharpPlus.EventArgs;
using DSharpPlus.AsyncEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;


[ExcludeFromCodeCoverage]
internal partial class SocketErroredHandlerManager : EventHandlerManager<ISocketErroredEventHandler, SocketErrorEventArgs>
{    
    public SocketErroredHandlerManager(ILogger<SocketErroredHandlerManager> logger, HandlerRegistry<ISocketErroredEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketErrorEventArgs> handler) => client.SocketErrored += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketErrorEventArgs> handler) => client.SocketErrored -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketErroredEventHandler handler, DiscordClient sender, SocketErrorEventArgs args) => handler.OnSocketErrored(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class SocketOpenedHandlerManager : EventHandlerManager<ISocketOpenedEventHandler, SocketEventArgs>
{    
    public SocketOpenedHandlerManager(ILogger<SocketOpenedHandlerManager> logger, HandlerRegistry<ISocketOpenedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketEventArgs> handler) => client.SocketOpened += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketEventArgs> handler) => client.SocketOpened -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketOpenedEventHandler handler, DiscordClient sender, SocketEventArgs args) => handler.OnSocketOpened(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class SocketClosedHandlerManager : EventHandlerManager<ISocketClosedEventHandler, SocketCloseEventArgs>
{    
    public SocketClosedHandlerManager(ILogger<SocketClosedHandlerManager> logger, HandlerRegistry<ISocketClosedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketCloseEventArgs> handler) => client.SocketClosed += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SocketCloseEventArgs> handler) => client.SocketClosed -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISocketClosedEventHandler handler, DiscordClient sender, SocketCloseEventArgs args) => handler.OnSocketClosed(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class SessionCreatedHandlerManager : EventHandlerManager<ISessionCreatedEventHandler, SessionReadyEventArgs>
{    
    public SessionCreatedHandlerManager(ILogger<SessionCreatedHandlerManager> logger, HandlerRegistry<ISessionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISessionCreatedEventHandler handler, DiscordClient sender, SessionReadyEventArgs args) => handler.OnSessionCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class SessionResumedHandlerManager : EventHandlerManager<ISessionResumedEventHandler, SessionReadyEventArgs>
{    
    public SessionResumedHandlerManager(ILogger<SessionResumedHandlerManager> logger, HandlerRegistry<ISessionResumedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionResumed += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, SessionReadyEventArgs> handler) => client.SessionResumed -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ISessionResumedEventHandler handler, DiscordClient sender, SessionReadyEventArgs args) => handler.OnSessionResumed(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class HeartbeatedHandlerManager : EventHandlerManager<IHeartbeatedEventHandler, HeartbeatEventArgs>
{    
    public HeartbeatedHandlerManager(ILogger<HeartbeatedHandlerManager> logger, HandlerRegistry<IHeartbeatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, HeartbeatEventArgs> handler) => client.Heartbeated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, HeartbeatEventArgs> handler) => client.Heartbeated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IHeartbeatedEventHandler handler, DiscordClient sender, HeartbeatEventArgs args) => handler.OnHeartbeated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ZombiedHandlerManager : EventHandlerManager<IZombiedEventHandler, ZombiedEventArgs>
{    
    public ZombiedHandlerManager(ILogger<ZombiedHandlerManager> logger, HandlerRegistry<IZombiedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ZombiedEventArgs> handler) => client.Zombied += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ZombiedEventArgs> handler) => client.Zombied -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IZombiedEventHandler handler, DiscordClient sender, ZombiedEventArgs args) => handler.OnZombied(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ApplicationCommandPermissionsUpdatedHandlerManager : EventHandlerManager<IApplicationCommandPermissionsUpdatedEventHandler, ApplicationCommandPermissionsUpdatedEventArgs>
{    
    public ApplicationCommandPermissionsUpdatedHandlerManager(ILogger<ApplicationCommandPermissionsUpdatedHandlerManager> logger, HandlerRegistry<IApplicationCommandPermissionsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> handler) => client.ApplicationCommandPermissionsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> handler) => client.ApplicationCommandPermissionsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IApplicationCommandPermissionsUpdatedEventHandler handler, DiscordClient sender, ApplicationCommandPermissionsUpdatedEventArgs args) => handler.OnApplicationCommandPermissionsUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ChannelCreatedHandlerManager : EventHandlerManager<IChannelCreatedEventHandler, ChannelCreateEventArgs>
{    
    public ChannelCreatedHandlerManager(ILogger<ChannelCreatedHandlerManager> logger, HandlerRegistry<IChannelCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> handler) => client.ChannelCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> handler) => client.ChannelCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelCreatedEventHandler handler, DiscordClient sender, ChannelCreateEventArgs args) => handler.OnChannelCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ChannelUpdatedHandlerManager : EventHandlerManager<IChannelUpdatedEventHandler, ChannelUpdateEventArgs>
{    
    public ChannelUpdatedHandlerManager(ILogger<ChannelUpdatedHandlerManager> logger, HandlerRegistry<IChannelUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> handler) => client.ChannelUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> handler) => client.ChannelUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelUpdatedEventHandler handler, DiscordClient sender, ChannelUpdateEventArgs args) => handler.OnChannelUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ChannelDeletedHandlerManager : EventHandlerManager<IChannelDeletedEventHandler, ChannelDeleteEventArgs>
{    
    public ChannelDeletedHandlerManager(ILogger<ChannelDeletedHandlerManager> logger, HandlerRegistry<IChannelDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> handler) => client.ChannelDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> handler) => client.ChannelDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelDeletedEventHandler handler, DiscordClient sender, ChannelDeleteEventArgs args) => handler.OnChannelDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class DmChannelDeletedHandlerManager : EventHandlerManager<IDmChannelDeletedEventHandler, DmChannelDeleteEventArgs>
{    
    public DmChannelDeletedHandlerManager(ILogger<DmChannelDeletedHandlerManager> logger, HandlerRegistry<IDmChannelDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> handler) => client.DmChannelDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> handler) => client.DmChannelDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IDmChannelDeletedEventHandler handler, DiscordClient sender, DmChannelDeleteEventArgs args) => handler.OnDmChannelDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ChannelPinsUpdatedHandlerManager : EventHandlerManager<IChannelPinsUpdatedEventHandler, ChannelPinsUpdateEventArgs>
{    
    public ChannelPinsUpdatedHandlerManager(ILogger<ChannelPinsUpdatedHandlerManager> logger, HandlerRegistry<IChannelPinsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> handler) => client.ChannelPinsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> handler) => client.ChannelPinsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IChannelPinsUpdatedEventHandler handler, DiscordClient sender, ChannelPinsUpdateEventArgs args) => handler.OnChannelPinsUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildCreatedHandlerManager : EventHandlerManager<IGuildCreatedEventHandler, GuildCreateEventArgs>
{    
    public GuildCreatedHandlerManager(ILogger<GuildCreatedHandlerManager> logger, HandlerRegistry<IGuildCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildCreatedEventHandler handler, DiscordClient sender, GuildCreateEventArgs args) => handler.OnGuildCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildAvailableHandlerManager : EventHandlerManager<IGuildAvailableEventHandler, GuildCreateEventArgs>
{    
    public GuildAvailableHandlerManager(ILogger<GuildAvailableHandlerManager> logger, HandlerRegistry<IGuildAvailableEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildAvailable += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildCreateEventArgs> handler) => client.GuildAvailable -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildAvailableEventHandler handler, DiscordClient sender, GuildCreateEventArgs args) => handler.OnGuildAvailable(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildUpdatedHandlerManager : EventHandlerManager<IGuildUpdatedEventHandler, GuildUpdateEventArgs>
{    
    public GuildUpdatedHandlerManager(ILogger<GuildUpdatedHandlerManager> logger, HandlerRegistry<IGuildUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> handler) => client.GuildUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> handler) => client.GuildUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildUpdatedEventHandler handler, DiscordClient sender, GuildUpdateEventArgs args) => handler.OnGuildUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildDeletedHandlerManager : EventHandlerManager<IGuildDeletedEventHandler, GuildDeleteEventArgs>
{    
    public GuildDeletedHandlerManager(ILogger<GuildDeletedHandlerManager> logger, HandlerRegistry<IGuildDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildDeletedEventHandler handler, DiscordClient sender, GuildDeleteEventArgs args) => handler.OnGuildDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildUnavailableHandlerManager : EventHandlerManager<IGuildUnavailableEventHandler, GuildDeleteEventArgs>
{    
    public GuildUnavailableHandlerManager(ILogger<GuildUnavailableHandlerManager> logger, HandlerRegistry<IGuildUnavailableEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildUnavailable += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> handler) => client.GuildUnavailable -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildUnavailableEventHandler handler, DiscordClient sender, GuildDeleteEventArgs args) => handler.OnGuildUnavailable(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildDownloadCompletedHandlerManager : EventHandlerManager<IGuildDownloadCompletedEventHandler, GuildDownloadCompletedEventArgs>
{    
    public GuildDownloadCompletedHandlerManager(ILogger<GuildDownloadCompletedHandlerManager> logger, HandlerRegistry<IGuildDownloadCompletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> handler) => client.GuildDownloadCompleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> handler) => client.GuildDownloadCompleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildDownloadCompletedEventHandler handler, DiscordClient sender, GuildDownloadCompletedEventArgs args) => handler.OnGuildDownloadCompleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildEmojisUpdatedHandlerManager : EventHandlerManager<IGuildEmojisUpdatedEventHandler, GuildEmojisUpdateEventArgs>
{    
    public GuildEmojisUpdatedHandlerManager(ILogger<GuildEmojisUpdatedHandlerManager> logger, HandlerRegistry<IGuildEmojisUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> handler) => client.GuildEmojisUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> handler) => client.GuildEmojisUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildEmojisUpdatedEventHandler handler, DiscordClient sender, GuildEmojisUpdateEventArgs args) => handler.OnGuildEmojisUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildStickersUpdatedHandlerManager : EventHandlerManager<IGuildStickersUpdatedEventHandler, GuildStickersUpdateEventArgs>
{    
    public GuildStickersUpdatedHandlerManager(ILogger<GuildStickersUpdatedHandlerManager> logger, HandlerRegistry<IGuildStickersUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> handler) => client.GuildStickersUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> handler) => client.GuildStickersUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildStickersUpdatedEventHandler handler, DiscordClient sender, GuildStickersUpdateEventArgs args) => handler.OnGuildStickersUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildIntegrationsUpdatedHandlerManager : EventHandlerManager<IGuildIntegrationsUpdatedEventHandler, GuildIntegrationsUpdateEventArgs>
{    
    public GuildIntegrationsUpdatedHandlerManager(ILogger<GuildIntegrationsUpdatedHandlerManager> logger, HandlerRegistry<IGuildIntegrationsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> handler) => client.GuildIntegrationsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> handler) => client.GuildIntegrationsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildIntegrationsUpdatedEventHandler handler, DiscordClient sender, GuildIntegrationsUpdateEventArgs args) => handler.OnGuildIntegrationsUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildAuditLogCreatedHandlerManager : EventHandlerManager<IGuildAuditLogCreatedEventHandler, GuildAuditLogCreatedEventArgs>
{    
    public GuildAuditLogCreatedHandlerManager(ILogger<GuildAuditLogCreatedHandlerManager> logger, HandlerRegistry<IGuildAuditLogCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> handler) => client.GuildAuditLogCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> handler) => client.GuildAuditLogCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildAuditLogCreatedEventHandler handler, DiscordClient sender, GuildAuditLogCreatedEventArgs args) => handler.OnGuildAuditLogCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventCreatedHandlerManager : EventHandlerManager<IScheduledGuildEventCreatedEventHandler, ScheduledGuildEventCreateEventArgs>
{    
    public ScheduledGuildEventCreatedHandlerManager(ILogger<ScheduledGuildEventCreatedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> handler) => client.ScheduledGuildEventCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> handler) => client.ScheduledGuildEventCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventCreatedEventHandler handler, DiscordClient sender, ScheduledGuildEventCreateEventArgs args) => handler.OnScheduledGuildEventCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventUpdatedHandlerManager : EventHandlerManager<IScheduledGuildEventUpdatedEventHandler, ScheduledGuildEventUpdateEventArgs>
{    
    public ScheduledGuildEventUpdatedHandlerManager(ILogger<ScheduledGuildEventUpdatedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> handler) => client.ScheduledGuildEventUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> handler) => client.ScheduledGuildEventUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUpdatedEventHandler handler, DiscordClient sender, ScheduledGuildEventUpdateEventArgs args) => handler.OnScheduledGuildEventUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventDeletedHandlerManager : EventHandlerManager<IScheduledGuildEventDeletedEventHandler, ScheduledGuildEventDeleteEventArgs>
{    
    public ScheduledGuildEventDeletedHandlerManager(ILogger<ScheduledGuildEventDeletedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> handler) => client.ScheduledGuildEventDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> handler) => client.ScheduledGuildEventDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventDeletedEventHandler handler, DiscordClient sender, ScheduledGuildEventDeleteEventArgs args) => handler.OnScheduledGuildEventDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventCompletedHandlerManager : EventHandlerManager<IScheduledGuildEventCompletedEventHandler, ScheduledGuildEventCompletedEventArgs>
{    
    public ScheduledGuildEventCompletedHandlerManager(ILogger<ScheduledGuildEventCompletedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventCompletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> handler) => client.ScheduledGuildEventCompleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> handler) => client.ScheduledGuildEventCompleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventCompletedEventHandler handler, DiscordClient sender, ScheduledGuildEventCompletedEventArgs args) => handler.OnScheduledGuildEventCompleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventUserAddedHandlerManager : EventHandlerManager<IScheduledGuildEventUserAddedEventHandler, ScheduledGuildEventUserAddEventArgs>
{    
    public ScheduledGuildEventUserAddedHandlerManager(ILogger<ScheduledGuildEventUserAddedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventUserAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> handler) => client.ScheduledGuildEventUserAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> handler) => client.ScheduledGuildEventUserAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUserAddedEventHandler handler, DiscordClient sender, ScheduledGuildEventUserAddEventArgs args) => handler.OnScheduledGuildEventUserAdded(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ScheduledGuildEventUserRemovedHandlerManager : EventHandlerManager<IScheduledGuildEventUserRemovedEventHandler, ScheduledGuildEventUserRemoveEventArgs>
{    
    public ScheduledGuildEventUserRemovedHandlerManager(ILogger<ScheduledGuildEventUserRemovedHandlerManager> logger, HandlerRegistry<IScheduledGuildEventUserRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> handler) => client.ScheduledGuildEventUserRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> handler) => client.ScheduledGuildEventUserRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IScheduledGuildEventUserRemovedEventHandler handler, DiscordClient sender, ScheduledGuildEventUserRemoveEventArgs args) => handler.OnScheduledGuildEventUserRemoved(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildBanAddedHandlerManager : EventHandlerManager<IGuildBanAddedEventHandler, GuildBanAddEventArgs>
{    
    public GuildBanAddedHandlerManager(ILogger<GuildBanAddedHandlerManager> logger, HandlerRegistry<IGuildBanAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> handler) => client.GuildBanAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> handler) => client.GuildBanAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildBanAddedEventHandler handler, DiscordClient sender, GuildBanAddEventArgs args) => handler.OnGuildBanAdded(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildBanRemovedHandlerManager : EventHandlerManager<IGuildBanRemovedEventHandler, GuildBanRemoveEventArgs>
{    
    public GuildBanRemovedHandlerManager(ILogger<GuildBanRemovedHandlerManager> logger, HandlerRegistry<IGuildBanRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> handler) => client.GuildBanRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> handler) => client.GuildBanRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildBanRemovedEventHandler handler, DiscordClient sender, GuildBanRemoveEventArgs args) => handler.OnGuildBanRemoved(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildMemberAddedHandlerManager : EventHandlerManager<IGuildMemberAddedEventHandler, GuildMemberAddEventArgs>
{    
    public GuildMemberAddedHandlerManager(ILogger<GuildMemberAddedHandlerManager> logger, HandlerRegistry<IGuildMemberAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> handler) => client.GuildMemberAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> handler) => client.GuildMemberAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberAddedEventHandler handler, DiscordClient sender, GuildMemberAddEventArgs args) => handler.OnGuildMemberAdded(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildMemberRemovedHandlerManager : EventHandlerManager<IGuildMemberRemovedEventHandler, GuildMemberRemoveEventArgs>
{    
    public GuildMemberRemovedHandlerManager(ILogger<GuildMemberRemovedHandlerManager> logger, HandlerRegistry<IGuildMemberRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> handler) => client.GuildMemberRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> handler) => client.GuildMemberRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberRemovedEventHandler handler, DiscordClient sender, GuildMemberRemoveEventArgs args) => handler.OnGuildMemberRemoved(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildMemberUpdatedHandlerManager : EventHandlerManager<IGuildMemberUpdatedEventHandler, GuildMemberUpdateEventArgs>
{    
    public GuildMemberUpdatedHandlerManager(ILogger<GuildMemberUpdatedHandlerManager> logger, HandlerRegistry<IGuildMemberUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> handler) => client.GuildMemberUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> handler) => client.GuildMemberUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMemberUpdatedEventHandler handler, DiscordClient sender, GuildMemberUpdateEventArgs args) => handler.OnGuildMemberUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildMembersChunkedHandlerManager : EventHandlerManager<IGuildMembersChunkedEventHandler, GuildMembersChunkEventArgs>
{    
    public GuildMembersChunkedHandlerManager(ILogger<GuildMembersChunkedHandlerManager> logger, HandlerRegistry<IGuildMembersChunkedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> handler) => client.GuildMembersChunked += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> handler) => client.GuildMembersChunked -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildMembersChunkedEventHandler handler, DiscordClient sender, GuildMembersChunkEventArgs args) => handler.OnGuildMembersChunked(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildRoleCreatedHandlerManager : EventHandlerManager<IGuildRoleCreatedEventHandler, GuildRoleCreateEventArgs>
{    
    public GuildRoleCreatedHandlerManager(ILogger<GuildRoleCreatedHandlerManager> logger, HandlerRegistry<IGuildRoleCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> handler) => client.GuildRoleCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> handler) => client.GuildRoleCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleCreatedEventHandler handler, DiscordClient sender, GuildRoleCreateEventArgs args) => handler.OnGuildRoleCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildRoleUpdatedHandlerManager : EventHandlerManager<IGuildRoleUpdatedEventHandler, GuildRoleUpdateEventArgs>
{    
    public GuildRoleUpdatedHandlerManager(ILogger<GuildRoleUpdatedHandlerManager> logger, HandlerRegistry<IGuildRoleUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> handler) => client.GuildRoleUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> handler) => client.GuildRoleUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleUpdatedEventHandler handler, DiscordClient sender, GuildRoleUpdateEventArgs args) => handler.OnGuildRoleUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class GuildRoleDeletedHandlerManager : EventHandlerManager<IGuildRoleDeletedEventHandler, GuildRoleDeleteEventArgs>
{    
    public GuildRoleDeletedHandlerManager(ILogger<GuildRoleDeletedHandlerManager> logger, HandlerRegistry<IGuildRoleDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> handler) => client.GuildRoleDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> handler) => client.GuildRoleDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IGuildRoleDeletedEventHandler handler, DiscordClient sender, GuildRoleDeleteEventArgs args) => handler.OnGuildRoleDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class InviteCreatedHandlerManager : EventHandlerManager<IInviteCreatedEventHandler, InviteCreateEventArgs>
{    
    public InviteCreatedHandlerManager(ILogger<InviteCreatedHandlerManager> logger, HandlerRegistry<IInviteCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteCreateEventArgs> handler) => client.InviteCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteCreateEventArgs> handler) => client.InviteCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInviteCreatedEventHandler handler, DiscordClient sender, InviteCreateEventArgs args) => handler.OnInviteCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class InviteDeletedHandlerManager : EventHandlerManager<IInviteDeletedEventHandler, InviteDeleteEventArgs>
{    
    public InviteDeletedHandlerManager(ILogger<InviteDeletedHandlerManager> logger, HandlerRegistry<IInviteDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> handler) => client.InviteDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> handler) => client.InviteDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInviteDeletedEventHandler handler, DiscordClient sender, InviteDeleteEventArgs args) => handler.OnInviteDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageCreatedHandlerManager : EventHandlerManager<IMessageCreatedEventHandler, MessageCreateEventArgs>
{    
    public MessageCreatedHandlerManager(ILogger<MessageCreatedHandlerManager> logger, HandlerRegistry<IMessageCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageCreateEventArgs> handler) => client.MessageCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageCreateEventArgs> handler) => client.MessageCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageCreatedEventHandler handler, DiscordClient sender, MessageCreateEventArgs args) => handler.OnMessageCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageAcknowledgedHandlerManager : EventHandlerManager<IMessageAcknowledgedEventHandler, MessageAcknowledgeEventArgs>
{    
    public MessageAcknowledgedHandlerManager(ILogger<MessageAcknowledgedHandlerManager> logger, HandlerRegistry<IMessageAcknowledgedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> handler) => client.MessageAcknowledged += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> handler) => client.MessageAcknowledged -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageAcknowledgedEventHandler handler, DiscordClient sender, MessageAcknowledgeEventArgs args) => handler.OnMessageAcknowledged(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageUpdatedHandlerManager : EventHandlerManager<IMessageUpdatedEventHandler, MessageUpdateEventArgs>
{    
    public MessageUpdatedHandlerManager(ILogger<MessageUpdatedHandlerManager> logger, HandlerRegistry<IMessageUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> handler) => client.MessageUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> handler) => client.MessageUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageUpdatedEventHandler handler, DiscordClient sender, MessageUpdateEventArgs args) => handler.OnMessageUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageDeletedHandlerManager : EventHandlerManager<IMessageDeletedEventHandler, MessageDeleteEventArgs>
{    
    public MessageDeletedHandlerManager(ILogger<MessageDeletedHandlerManager> logger, HandlerRegistry<IMessageDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> handler) => client.MessageDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> handler) => client.MessageDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageDeletedEventHandler handler, DiscordClient sender, MessageDeleteEventArgs args) => handler.OnMessageDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessagesBulkDeletedHandlerManager : EventHandlerManager<IMessagesBulkDeletedEventHandler, MessageBulkDeleteEventArgs>
{    
    public MessagesBulkDeletedHandlerManager(ILogger<MessagesBulkDeletedHandlerManager> logger, HandlerRegistry<IMessagesBulkDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> handler) => client.MessagesBulkDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> handler) => client.MessagesBulkDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessagesBulkDeletedEventHandler handler, DiscordClient sender, MessageBulkDeleteEventArgs args) => handler.OnMessagesBulkDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageReactionAddedHandlerManager : EventHandlerManager<IMessageReactionAddedEventHandler, MessageReactionAddEventArgs>
{    
    public MessageReactionAddedHandlerManager(ILogger<MessageReactionAddedHandlerManager> logger, HandlerRegistry<IMessageReactionAddedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> handler) => client.MessageReactionAdded += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> handler) => client.MessageReactionAdded -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionAddedEventHandler handler, DiscordClient sender, MessageReactionAddEventArgs args) => handler.OnMessageReactionAdded(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageReactionRemovedHandlerManager : EventHandlerManager<IMessageReactionRemovedEventHandler, MessageReactionRemoveEventArgs>
{    
    public MessageReactionRemovedHandlerManager(ILogger<MessageReactionRemovedHandlerManager> logger, HandlerRegistry<IMessageReactionRemovedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> handler) => client.MessageReactionRemoved += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> handler) => client.MessageReactionRemoved -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionRemovedEventHandler handler, DiscordClient sender, MessageReactionRemoveEventArgs args) => handler.OnMessageReactionRemoved(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageReactionsClearedHandlerManager : EventHandlerManager<IMessageReactionsClearedEventHandler, MessageReactionsClearEventArgs>
{    
    public MessageReactionsClearedHandlerManager(ILogger<MessageReactionsClearedHandlerManager> logger, HandlerRegistry<IMessageReactionsClearedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> handler) => client.MessageReactionsCleared += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> handler) => client.MessageReactionsCleared -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionsClearedEventHandler handler, DiscordClient sender, MessageReactionsClearEventArgs args) => handler.OnMessageReactionsCleared(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class MessageReactionRemovedEmojiHandlerManager : EventHandlerManager<IMessageReactionRemovedEmojiEventHandler, MessageReactionRemoveEmojiEventArgs>
{    
    public MessageReactionRemovedEmojiHandlerManager(ILogger<MessageReactionRemovedEmojiHandlerManager> logger, HandlerRegistry<IMessageReactionRemovedEmojiEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> handler) => client.MessageReactionRemovedEmoji += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> handler) => client.MessageReactionRemovedEmoji -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IMessageReactionRemovedEmojiEventHandler handler, DiscordClient sender, MessageReactionRemoveEmojiEventArgs args) => handler.OnMessageReactionRemovedEmoji(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class PresenceUpdatedHandlerManager : EventHandlerManager<IPresenceUpdatedEventHandler, PresenceUpdateEventArgs>
{    
    public PresenceUpdatedHandlerManager(ILogger<PresenceUpdatedHandlerManager> logger, HandlerRegistry<IPresenceUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> handler) => client.PresenceUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> handler) => client.PresenceUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IPresenceUpdatedEventHandler handler, DiscordClient sender, PresenceUpdateEventArgs args) => handler.OnPresenceUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class UserSettingsUpdatedHandlerManager : EventHandlerManager<IUserSettingsUpdatedEventHandler, UserSettingsUpdateEventArgs>
{    
    public UserSettingsUpdatedHandlerManager(ILogger<UserSettingsUpdatedHandlerManager> logger, HandlerRegistry<IUserSettingsUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> handler) => client.UserSettingsUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> handler) => client.UserSettingsUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUserSettingsUpdatedEventHandler handler, DiscordClient sender, UserSettingsUpdateEventArgs args) => handler.OnUserSettingsUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class UserUpdatedHandlerManager : EventHandlerManager<IUserUpdatedEventHandler, UserUpdateEventArgs>
{    
    public UserUpdatedHandlerManager(ILogger<UserUpdatedHandlerManager> logger, HandlerRegistry<IUserUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserUpdateEventArgs> handler) => client.UserUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UserUpdateEventArgs> handler) => client.UserUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUserUpdatedEventHandler handler, DiscordClient sender, UserUpdateEventArgs args) => handler.OnUserUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class VoiceStateUpdatedHandlerManager : EventHandlerManager<IVoiceStateUpdatedEventHandler, VoiceStateUpdateEventArgs>
{    
    public VoiceStateUpdatedHandlerManager(ILogger<VoiceStateUpdatedHandlerManager> logger, HandlerRegistry<IVoiceStateUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> handler) => client.VoiceStateUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> handler) => client.VoiceStateUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IVoiceStateUpdatedEventHandler handler, DiscordClient sender, VoiceStateUpdateEventArgs args) => handler.OnVoiceStateUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class VoiceServerUpdatedHandlerManager : EventHandlerManager<IVoiceServerUpdatedEventHandler, VoiceServerUpdateEventArgs>
{    
    public VoiceServerUpdatedHandlerManager(ILogger<VoiceServerUpdatedHandlerManager> logger, HandlerRegistry<IVoiceServerUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> handler) => client.VoiceServerUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> handler) => client.VoiceServerUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IVoiceServerUpdatedEventHandler handler, DiscordClient sender, VoiceServerUpdateEventArgs args) => handler.OnVoiceServerUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadCreatedHandlerManager : EventHandlerManager<IThreadCreatedEventHandler, ThreadCreateEventArgs>
{    
    public ThreadCreatedHandlerManager(ILogger<ThreadCreatedHandlerManager> logger, HandlerRegistry<IThreadCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> handler) => client.ThreadCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> handler) => client.ThreadCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadCreatedEventHandler handler, DiscordClient sender, ThreadCreateEventArgs args) => handler.OnThreadCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadUpdatedHandlerManager : EventHandlerManager<IThreadUpdatedEventHandler, ThreadUpdateEventArgs>
{    
    public ThreadUpdatedHandlerManager(ILogger<ThreadUpdatedHandlerManager> logger, HandlerRegistry<IThreadUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> handler) => client.ThreadUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> handler) => client.ThreadUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadUpdatedEventHandler handler, DiscordClient sender, ThreadUpdateEventArgs args) => handler.OnThreadUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadDeletedHandlerManager : EventHandlerManager<IThreadDeletedEventHandler, ThreadDeleteEventArgs>
{    
    public ThreadDeletedHandlerManager(ILogger<ThreadDeletedHandlerManager> logger, HandlerRegistry<IThreadDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> handler) => client.ThreadDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> handler) => client.ThreadDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadDeletedEventHandler handler, DiscordClient sender, ThreadDeleteEventArgs args) => handler.OnThreadDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadListSyncedHandlerManager : EventHandlerManager<IThreadListSyncedEventHandler, ThreadListSyncEventArgs>
{    
    public ThreadListSyncedHandlerManager(ILogger<ThreadListSyncedHandlerManager> logger, HandlerRegistry<IThreadListSyncedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> handler) => client.ThreadListSynced += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> handler) => client.ThreadListSynced -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadListSyncedEventHandler handler, DiscordClient sender, ThreadListSyncEventArgs args) => handler.OnThreadListSynced(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadMemberUpdatedHandlerManager : EventHandlerManager<IThreadMemberUpdatedEventHandler, ThreadMemberUpdateEventArgs>
{    
    public ThreadMemberUpdatedHandlerManager(ILogger<ThreadMemberUpdatedHandlerManager> logger, HandlerRegistry<IThreadMemberUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> handler) => client.ThreadMemberUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> handler) => client.ThreadMemberUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadMemberUpdatedEventHandler handler, DiscordClient sender, ThreadMemberUpdateEventArgs args) => handler.OnThreadMemberUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ThreadMembersUpdatedHandlerManager : EventHandlerManager<IThreadMembersUpdatedEventHandler, ThreadMembersUpdateEventArgs>
{    
    public ThreadMembersUpdatedHandlerManager(ILogger<ThreadMembersUpdatedHandlerManager> logger, HandlerRegistry<IThreadMembersUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> handler) => client.ThreadMembersUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> handler) => client.ThreadMembersUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IThreadMembersUpdatedEventHandler handler, DiscordClient sender, ThreadMembersUpdateEventArgs args) => handler.OnThreadMembersUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class IntegrationCreatedHandlerManager : EventHandlerManager<IIntegrationCreatedEventHandler, IntegrationCreateEventArgs>
{    
    public IntegrationCreatedHandlerManager(ILogger<IntegrationCreatedHandlerManager> logger, HandlerRegistry<IIntegrationCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> handler) => client.IntegrationCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> handler) => client.IntegrationCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationCreatedEventHandler handler, DiscordClient sender, IntegrationCreateEventArgs args) => handler.OnIntegrationCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class IntegrationUpdatedHandlerManager : EventHandlerManager<IIntegrationUpdatedEventHandler, IntegrationUpdateEventArgs>
{    
    public IntegrationUpdatedHandlerManager(ILogger<IntegrationUpdatedHandlerManager> logger, HandlerRegistry<IIntegrationUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> handler) => client.IntegrationUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> handler) => client.IntegrationUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationUpdatedEventHandler handler, DiscordClient sender, IntegrationUpdateEventArgs args) => handler.OnIntegrationUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class IntegrationDeletedHandlerManager : EventHandlerManager<IIntegrationDeletedEventHandler, IntegrationDeleteEventArgs>
{    
    public IntegrationDeletedHandlerManager(ILogger<IntegrationDeletedHandlerManager> logger, HandlerRegistry<IIntegrationDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> handler) => client.IntegrationDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> handler) => client.IntegrationDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IIntegrationDeletedEventHandler handler, DiscordClient sender, IntegrationDeleteEventArgs args) => handler.OnIntegrationDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class StageInstanceCreatedHandlerManager : EventHandlerManager<IStageInstanceCreatedEventHandler, StageInstanceCreateEventArgs>
{    
    public StageInstanceCreatedHandlerManager(ILogger<StageInstanceCreatedHandlerManager> logger, HandlerRegistry<IStageInstanceCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> handler) => client.StageInstanceCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> handler) => client.StageInstanceCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceCreatedEventHandler handler, DiscordClient sender, StageInstanceCreateEventArgs args) => handler.OnStageInstanceCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class StageInstanceUpdatedHandlerManager : EventHandlerManager<IStageInstanceUpdatedEventHandler, StageInstanceUpdateEventArgs>
{    
    public StageInstanceUpdatedHandlerManager(ILogger<StageInstanceUpdatedHandlerManager> logger, HandlerRegistry<IStageInstanceUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> handler) => client.StageInstanceUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> handler) => client.StageInstanceUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceUpdatedEventHandler handler, DiscordClient sender, StageInstanceUpdateEventArgs args) => handler.OnStageInstanceUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class StageInstanceDeletedHandlerManager : EventHandlerManager<IStageInstanceDeletedEventHandler, StageInstanceDeleteEventArgs>
{    
    public StageInstanceDeletedHandlerManager(ILogger<StageInstanceDeletedHandlerManager> logger, HandlerRegistry<IStageInstanceDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> handler) => client.StageInstanceDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> handler) => client.StageInstanceDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IStageInstanceDeletedEventHandler handler, DiscordClient sender, StageInstanceDeleteEventArgs args) => handler.OnStageInstanceDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class InteractionCreatedHandlerManager : EventHandlerManager<IInteractionCreatedEventHandler, InteractionCreateEventArgs>
{    
    public InteractionCreatedHandlerManager(ILogger<InteractionCreatedHandlerManager> logger, HandlerRegistry<IInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> handler) => client.InteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> handler) => client.InteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IInteractionCreatedEventHandler handler, DiscordClient sender, InteractionCreateEventArgs args) => handler.OnInteractionCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ComponentInteractionCreatedHandlerManager : EventHandlerManager<IComponentInteractionCreatedEventHandler, ComponentInteractionCreateEventArgs>
{    
    public ComponentInteractionCreatedHandlerManager(ILogger<ComponentInteractionCreatedHandlerManager> logger, HandlerRegistry<IComponentInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> handler) => client.ComponentInteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> handler) => client.ComponentInteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IComponentInteractionCreatedEventHandler handler, DiscordClient sender, ComponentInteractionCreateEventArgs args) => handler.OnComponentInteractionCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ModalSubmittedHandlerManager : EventHandlerManager<IModalSubmittedEventHandler, ModalSubmitEventArgs>
{    
    public ModalSubmittedHandlerManager(ILogger<ModalSubmittedHandlerManager> logger, HandlerRegistry<IModalSubmittedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> handler) => client.ModalSubmitted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> handler) => client.ModalSubmitted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IModalSubmittedEventHandler handler, DiscordClient sender, ModalSubmitEventArgs args) => handler.OnModalSubmitted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ContextMenuInteractionCreatedHandlerManager : EventHandlerManager<IContextMenuInteractionCreatedEventHandler, ContextMenuInteractionCreateEventArgs>
{    
    public ContextMenuInteractionCreatedHandlerManager(ILogger<ContextMenuInteractionCreatedHandlerManager> logger, HandlerRegistry<IContextMenuInteractionCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> handler) => client.ContextMenuInteractionCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> handler) => client.ContextMenuInteractionCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IContextMenuInteractionCreatedEventHandler handler, DiscordClient sender, ContextMenuInteractionCreateEventArgs args) => handler.OnContextMenuInteractionCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class TypingStartedHandlerManager : EventHandlerManager<ITypingStartedEventHandler, TypingStartEventArgs>
{    
    public TypingStartedHandlerManager(ILogger<TypingStartedHandlerManager> logger, HandlerRegistry<ITypingStartedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TypingStartEventArgs> handler) => client.TypingStarted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TypingStartEventArgs> handler) => client.TypingStarted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(ITypingStartedEventHandler handler, DiscordClient sender, TypingStartEventArgs args) => handler.OnTypingStarted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class UnknownEventHandlerManager : EventHandlerManager<IUnknownEventEventHandler, UnknownEventArgs>
{    
    public UnknownEventHandlerManager(ILogger<UnknownEventHandlerManager> logger, HandlerRegistry<IUnknownEventEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UnknownEventArgs> handler) => client.UnknownEvent += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, UnknownEventArgs> handler) => client.UnknownEvent -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IUnknownEventEventHandler handler, DiscordClient sender, UnknownEventArgs args) => handler.OnUnknownEvent(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class WebhooksUpdatedHandlerManager : EventHandlerManager<IWebhooksUpdatedEventHandler, WebhooksUpdateEventArgs>
{    
    public WebhooksUpdatedHandlerManager(ILogger<WebhooksUpdatedHandlerManager> logger, HandlerRegistry<IWebhooksUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> handler) => client.WebhooksUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> handler) => client.WebhooksUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IWebhooksUpdatedEventHandler handler, DiscordClient sender, WebhooksUpdateEventArgs args) => handler.OnWebhooksUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class ClientErroredHandlerManager : EventHandlerManager<IClientErroredEventHandler, ClientErrorEventArgs>
{    
    public ClientErroredHandlerManager(ILogger<ClientErroredHandlerManager> logger, HandlerRegistry<IClientErroredEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ClientErrorEventArgs> handler) => client.ClientErrored += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, ClientErrorEventArgs> handler) => client.ClientErrored -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IClientErroredEventHandler handler, DiscordClient sender, ClientErrorEventArgs args) => handler.OnClientErrored(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class AutoModerationRuleCreatedHandlerManager : EventHandlerManager<IAutoModerationRuleCreatedEventHandler, AutoModerationRuleCreateEventArgs>
{    
    public AutoModerationRuleCreatedHandlerManager(ILogger<AutoModerationRuleCreatedHandlerManager> logger, HandlerRegistry<IAutoModerationRuleCreatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> handler) => client.AutoModerationRuleCreated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> handler) => client.AutoModerationRuleCreated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleCreatedEventHandler handler, DiscordClient sender, AutoModerationRuleCreateEventArgs args) => handler.OnAutoModerationRuleCreated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class AutoModerationRuleUpdatedHandlerManager : EventHandlerManager<IAutoModerationRuleUpdatedEventHandler, AutoModerationRuleUpdateEventArgs>
{    
    public AutoModerationRuleUpdatedHandlerManager(ILogger<AutoModerationRuleUpdatedHandlerManager> logger, HandlerRegistry<IAutoModerationRuleUpdatedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> handler) => client.AutoModerationRuleUpdated += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> handler) => client.AutoModerationRuleUpdated -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleUpdatedEventHandler handler, DiscordClient sender, AutoModerationRuleUpdateEventArgs args) => handler.OnAutoModerationRuleUpdated(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class AutoModerationRuleDeletedHandlerManager : EventHandlerManager<IAutoModerationRuleDeletedEventHandler, AutoModerationRuleDeleteEventArgs>
{    
    public AutoModerationRuleDeletedHandlerManager(ILogger<AutoModerationRuleDeletedHandlerManager> logger, HandlerRegistry<IAutoModerationRuleDeletedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> handler) => client.AutoModerationRuleDeleted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> handler) => client.AutoModerationRuleDeleted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleDeletedEventHandler handler, DiscordClient sender, AutoModerationRuleDeleteEventArgs args) => handler.OnAutoModerationRuleDeleted(sender, args);
}

[ExcludeFromCodeCoverage]
internal partial class AutoModerationRuleExecutedHandlerManager : EventHandlerManager<IAutoModerationRuleExecutedEventHandler, AutoModerationRuleExecuteEventArgs>
{    
    public AutoModerationRuleExecutedHandlerManager(ILogger<AutoModerationRuleExecutedHandlerManager> logger, HandlerRegistry<IAutoModerationRuleExecutedEventHandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider) : base(logger, registry, provider) { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> handler) => client.AutoModerationRuleExecuted += handler;
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected sealed override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> handler) => client.AutoModerationRuleExecuted -= handler;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected sealed override ValueTask Invoke(IAutoModerationRuleExecutedEventHandler handler, DiscordClient sender, AutoModerationRuleExecuteEventArgs args) => handler.OnAutoModerationRuleExecuted(sender, args);
}
