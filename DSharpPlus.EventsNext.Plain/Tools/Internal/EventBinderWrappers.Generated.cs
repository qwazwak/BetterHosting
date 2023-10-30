
using System;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsNext.Plain.Tools.Internal;

internal static partial class EventBinderWrappers
{
    public static AsyncEventHandler<DiscordClient, SocketErrorEventArgs> WrapSocketErrored<THandler>() where THandler : class, ISocketErroredEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketErroredEventHandler instance = scope.ServiceProvider.GetRequiredService<ISocketErroredEventHandler>();
            await instance.OnSocketErrored(client, args);
        };

    public static AsyncEventHandler<DiscordClient, SocketErrorEventArgs> WrapSocketErrored(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ISocketErroredEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ISocketErroredEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketErroredEventHandler instance = (ISocketErroredEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSocketErrored(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, SocketEventArgs> WrapSocketOpened<THandler>() where THandler : class, ISocketOpenedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketOpenedEventHandler instance = scope.ServiceProvider.GetRequiredService<ISocketOpenedEventHandler>();
            await instance.OnSocketOpened(client, args);
        };

    public static AsyncEventHandler<DiscordClient, SocketEventArgs> WrapSocketOpened(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ISocketOpenedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ISocketOpenedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketOpenedEventHandler instance = (ISocketOpenedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSocketOpened(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, SocketCloseEventArgs> WrapSocketClosed<THandler>() where THandler : class, ISocketClosedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketClosedEventHandler instance = scope.ServiceProvider.GetRequiredService<ISocketClosedEventHandler>();
            await instance.OnSocketClosed(client, args);
        };

    public static AsyncEventHandler<DiscordClient, SocketCloseEventArgs> WrapSocketClosed(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ISocketClosedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ISocketClosedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketClosedEventHandler instance = (ISocketClosedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSocketClosed(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, SessionReadyEventArgs> WrapSessionCreated<THandler>() where THandler : class, ISessionCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISessionCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<ISessionCreatedEventHandler>();
            await instance.OnSessionCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, SessionReadyEventArgs> WrapSessionCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ISessionCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ISessionCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISessionCreatedEventHandler instance = (ISessionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSessionCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, SessionReadyEventArgs> WrapSessionResumed<THandler>() where THandler : class, ISessionResumedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISessionResumedEventHandler instance = scope.ServiceProvider.GetRequiredService<ISessionResumedEventHandler>();
            await instance.OnSessionResumed(client, args);
        };

    public static AsyncEventHandler<DiscordClient, SessionReadyEventArgs> WrapSessionResumed(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ISessionResumedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ISessionResumedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISessionResumedEventHandler instance = (ISessionResumedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSessionResumed(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, HeartbeatEventArgs> WrapHeartbeated<THandler>() where THandler : class, IHeartbeatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IHeartbeatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IHeartbeatedEventHandler>();
            await instance.OnHeartbeated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, HeartbeatEventArgs> WrapHeartbeated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IHeartbeatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IHeartbeatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IHeartbeatedEventHandler instance = (IHeartbeatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnHeartbeated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ZombiedEventArgs> WrapZombied<THandler>() where THandler : class, IZombiedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IZombiedEventHandler instance = scope.ServiceProvider.GetRequiredService<IZombiedEventHandler>();
            await instance.OnZombied(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ZombiedEventArgs> WrapZombied(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IZombiedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IZombiedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IZombiedEventHandler instance = (IZombiedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnZombied(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> WrapApplicationCommandPermissionsUpdated<THandler>() where THandler : class, IApplicationCommandPermissionsUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IApplicationCommandPermissionsUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IApplicationCommandPermissionsUpdatedEventHandler>();
            await instance.OnApplicationCommandPermissionsUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> WrapApplicationCommandPermissionsUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IApplicationCommandPermissionsUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IApplicationCommandPermissionsUpdatedEventHandler instance = (IApplicationCommandPermissionsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnApplicationCommandPermissionsUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> WrapChannelCreated<THandler>() where THandler : class, IChannelCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IChannelCreatedEventHandler>();
            await instance.OnChannelCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> WrapChannelCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IChannelCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IChannelCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelCreatedEventHandler instance = (IChannelCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> WrapChannelUpdated<THandler>() where THandler : class, IChannelUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IChannelUpdatedEventHandler>();
            await instance.OnChannelUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> WrapChannelUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IChannelUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IChannelUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelUpdatedEventHandler instance = (IChannelUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> WrapChannelDeleted<THandler>() where THandler : class, IChannelDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IChannelDeletedEventHandler>();
            await instance.OnChannelDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> WrapChannelDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IChannelDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IChannelDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelDeletedEventHandler instance = (IChannelDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> WrapDmChannelDeleted<THandler>() where THandler : class, IDmChannelDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IDmChannelDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IDmChannelDeletedEventHandler>();
            await instance.OnDmChannelDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> WrapDmChannelDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IDmChannelDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IDmChannelDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IDmChannelDeletedEventHandler instance = (IDmChannelDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnDmChannelDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> WrapChannelPinsUpdated<THandler>() where THandler : class, IChannelPinsUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelPinsUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IChannelPinsUpdatedEventHandler>();
            await instance.OnChannelPinsUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> WrapChannelPinsUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IChannelPinsUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelPinsUpdatedEventHandler instance = (IChannelPinsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelPinsUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildCreated<THandler>() where THandler : class, IGuildCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildCreatedEventHandler>();
            await instance.OnGuildCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildCreatedEventHandler instance = (IGuildCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildAvailable<THandler>() where THandler : class, IGuildAvailableEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildAvailableEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildAvailableEventHandler>();
            await instance.OnGuildAvailable(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildAvailable(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildAvailableEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildAvailableEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildAvailableEventHandler instance = (IGuildAvailableEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildAvailable(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> WrapGuildUpdated<THandler>() where THandler : class, IGuildUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildUpdatedEventHandler>();
            await instance.OnGuildUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> WrapGuildUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildUpdatedEventHandler instance = (IGuildUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildDeleted<THandler>() where THandler : class, IGuildDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildDeletedEventHandler>();
            await instance.OnGuildDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDeletedEventHandler instance = (IGuildDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildUnavailable<THandler>() where THandler : class, IGuildUnavailableEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildUnavailableEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildUnavailableEventHandler>();
            await instance.OnGuildUnavailable(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildUnavailable(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildUnavailableEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildUnavailableEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildUnavailableEventHandler instance = (IGuildUnavailableEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildUnavailable(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> WrapGuildDownloadCompleted<THandler>() where THandler : class, IGuildDownloadCompletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDownloadCompletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildDownloadCompletedEventHandler>();
            await instance.OnGuildDownloadCompleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> WrapGuildDownloadCompleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildDownloadCompletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDownloadCompletedEventHandler instance = (IGuildDownloadCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildDownloadCompleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> WrapGuildEmojisUpdated<THandler>() where THandler : class, IGuildEmojisUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildEmojisUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildEmojisUpdatedEventHandler>();
            await instance.OnGuildEmojisUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> WrapGuildEmojisUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildEmojisUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildEmojisUpdatedEventHandler instance = (IGuildEmojisUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildEmojisUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> WrapGuildStickersUpdated<THandler>() where THandler : class, IGuildStickersUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildStickersUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildStickersUpdatedEventHandler>();
            await instance.OnGuildStickersUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> WrapGuildStickersUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildStickersUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildStickersUpdatedEventHandler instance = (IGuildStickersUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildStickersUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> WrapGuildIntegrationsUpdated<THandler>() where THandler : class, IGuildIntegrationsUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildIntegrationsUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildIntegrationsUpdatedEventHandler>();
            await instance.OnGuildIntegrationsUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> WrapGuildIntegrationsUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildIntegrationsUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildIntegrationsUpdatedEventHandler instance = (IGuildIntegrationsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildIntegrationsUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> WrapGuildAuditLogCreated<THandler>() where THandler : class, IGuildAuditLogCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildAuditLogCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildAuditLogCreatedEventHandler>();
            await instance.OnGuildAuditLogCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> WrapGuildAuditLogCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildAuditLogCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildAuditLogCreatedEventHandler instance = (IGuildAuditLogCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildAuditLogCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> WrapScheduledGuildEventCreated<THandler>() where THandler : class, IScheduledGuildEventCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventCreatedEventHandler>();
            await instance.OnScheduledGuildEventCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> WrapScheduledGuildEventCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCreatedEventHandler instance = (IScheduledGuildEventCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> WrapScheduledGuildEventUpdated<THandler>() where THandler : class, IScheduledGuildEventUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventUpdatedEventHandler>();
            await instance.OnScheduledGuildEventUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> WrapScheduledGuildEventUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUpdatedEventHandler instance = (IScheduledGuildEventUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> WrapScheduledGuildEventDeleted<THandler>() where THandler : class, IScheduledGuildEventDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventDeletedEventHandler>();
            await instance.OnScheduledGuildEventDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> WrapScheduledGuildEventDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventDeletedEventHandler instance = (IScheduledGuildEventDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> WrapScheduledGuildEventCompleted<THandler>() where THandler : class, IScheduledGuildEventCompletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCompletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventCompletedEventHandler>();
            await instance.OnScheduledGuildEventCompleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> WrapScheduledGuildEventCompleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventCompletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCompletedEventHandler instance = (IScheduledGuildEventCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventCompleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> WrapScheduledGuildEventUserAdded<THandler>() where THandler : class, IScheduledGuildEventUserAddedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserAddedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventUserAddedEventHandler>();
            await instance.OnScheduledGuildEventUserAdded(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> WrapScheduledGuildEventUserAdded(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventUserAddedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserAddedEventHandler instance = (IScheduledGuildEventUserAddedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUserAdded(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> WrapScheduledGuildEventUserRemoved<THandler>() where THandler : class, IScheduledGuildEventUserRemovedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserRemovedEventHandler instance = scope.ServiceProvider.GetRequiredService<IScheduledGuildEventUserRemovedEventHandler>();
            await instance.OnScheduledGuildEventUserRemoved(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> WrapScheduledGuildEventUserRemoved(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IScheduledGuildEventUserRemovedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserRemovedEventHandler instance = (IScheduledGuildEventUserRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUserRemoved(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> WrapGuildBanAdded<THandler>() where THandler : class, IGuildBanAddedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanAddedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildBanAddedEventHandler>();
            await instance.OnGuildBanAdded(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> WrapGuildBanAdded(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildBanAddedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildBanAddedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanAddedEventHandler instance = (IGuildBanAddedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildBanAdded(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> WrapGuildBanRemoved<THandler>() where THandler : class, IGuildBanRemovedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanRemovedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildBanRemovedEventHandler>();
            await instance.OnGuildBanRemoved(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> WrapGuildBanRemoved(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildBanRemovedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildBanRemovedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanRemovedEventHandler instance = (IGuildBanRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildBanRemoved(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> WrapGuildMemberAdded<THandler>() where THandler : class, IGuildMemberAddedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberAddedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildMemberAddedEventHandler>();
            await instance.OnGuildMemberAdded(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> WrapGuildMemberAdded(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildMemberAddedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildMemberAddedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberAddedEventHandler instance = (IGuildMemberAddedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberAdded(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> WrapGuildMemberRemoved<THandler>() where THandler : class, IGuildMemberRemovedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberRemovedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildMemberRemovedEventHandler>();
            await instance.OnGuildMemberRemoved(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> WrapGuildMemberRemoved(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildMemberRemovedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberRemovedEventHandler instance = (IGuildMemberRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberRemoved(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> WrapGuildMemberUpdated<THandler>() where THandler : class, IGuildMemberUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildMemberUpdatedEventHandler>();
            await instance.OnGuildMemberUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> WrapGuildMemberUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildMemberUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberUpdatedEventHandler instance = (IGuildMemberUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> WrapGuildMembersChunked<THandler>() where THandler : class, IGuildMembersChunkedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMembersChunkedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildMembersChunkedEventHandler>();
            await instance.OnGuildMembersChunked(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> WrapGuildMembersChunked(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildMembersChunkedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMembersChunkedEventHandler instance = (IGuildMembersChunkedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMembersChunked(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> WrapGuildRoleCreated<THandler>() where THandler : class, IGuildRoleCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildRoleCreatedEventHandler>();
            await instance.OnGuildRoleCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> WrapGuildRoleCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildRoleCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleCreatedEventHandler instance = (IGuildRoleCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> WrapGuildRoleUpdated<THandler>() where THandler : class, IGuildRoleUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildRoleUpdatedEventHandler>();
            await instance.OnGuildRoleUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> WrapGuildRoleUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildRoleUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleUpdatedEventHandler instance = (IGuildRoleUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> WrapGuildRoleDeleted<THandler>() where THandler : class, IGuildRoleDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IGuildRoleDeletedEventHandler>();
            await instance.OnGuildRoleDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> WrapGuildRoleDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IGuildRoleDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleDeletedEventHandler instance = (IGuildRoleDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, InviteCreateEventArgs> WrapInviteCreated<THandler>() where THandler : class, IInviteCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IInviteCreatedEventHandler>();
            await instance.OnInviteCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, InviteCreateEventArgs> WrapInviteCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IInviteCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IInviteCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteCreatedEventHandler instance = (IInviteCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInviteCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> WrapInviteDeleted<THandler>() where THandler : class, IInviteDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IInviteDeletedEventHandler>();
            await instance.OnInviteDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> WrapInviteDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IInviteDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IInviteDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteDeletedEventHandler instance = (IInviteDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInviteDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageCreateEventArgs> WrapMessageCreated<THandler>() where THandler : class, IMessageCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageCreatedEventHandler>();
            await instance.OnMessageCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageCreateEventArgs> WrapMessageCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageCreatedEventHandler instance = (IMessageCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> WrapMessageAcknowledged<THandler>() where THandler : class, IMessageAcknowledgedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageAcknowledgedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageAcknowledgedEventHandler>();
            await instance.OnMessageAcknowledged(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> WrapMessageAcknowledged(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageAcknowledgedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageAcknowledgedEventHandler instance = (IMessageAcknowledgedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageAcknowledged(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> WrapMessageUpdated<THandler>() where THandler : class, IMessageUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageUpdatedEventHandler>();
            await instance.OnMessageUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> WrapMessageUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageUpdatedEventHandler instance = (IMessageUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> WrapMessageDeleted<THandler>() where THandler : class, IMessageDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageDeletedEventHandler>();
            await instance.OnMessageDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> WrapMessageDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageDeletedEventHandler instance = (IMessageDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> WrapMessagesBulkDeleted<THandler>() where THandler : class, IMessagesBulkDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessagesBulkDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessagesBulkDeletedEventHandler>();
            await instance.OnMessagesBulkDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> WrapMessagesBulkDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessagesBulkDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessagesBulkDeletedEventHandler instance = (IMessagesBulkDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessagesBulkDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> WrapMessageReactionAdded<THandler>() where THandler : class, IMessageReactionAddedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionAddedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageReactionAddedEventHandler>();
            await instance.OnMessageReactionAdded(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> WrapMessageReactionAdded(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageReactionAddedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageReactionAddedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionAddedEventHandler instance = (IMessageReactionAddedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionAdded(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> WrapMessageReactionRemoved<THandler>() where THandler : class, IMessageReactionRemovedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemovedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageReactionRemovedEventHandler>();
            await instance.OnMessageReactionRemoved(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> WrapMessageReactionRemoved(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageReactionRemovedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemovedEventHandler instance = (IMessageReactionRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionRemoved(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> WrapMessageReactionsCleared<THandler>() where THandler : class, IMessageReactionsClearedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionsClearedEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageReactionsClearedEventHandler>();
            await instance.OnMessageReactionsCleared(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> WrapMessageReactionsCleared(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageReactionsClearedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionsClearedEventHandler instance = (IMessageReactionsClearedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionsCleared(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> WrapMessageReactionRemovedEmoji<THandler>() where THandler : class, IMessageReactionRemovedEmojiEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemovedEmojiEventHandler instance = scope.ServiceProvider.GetRequiredService<IMessageReactionRemovedEmojiEventHandler>();
            await instance.OnMessageReactionRemovedEmoji(client, args);
        };

    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> WrapMessageReactionRemovedEmoji(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IMessageReactionRemovedEmojiEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemovedEmojiEventHandler instance = (IMessageReactionRemovedEmojiEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionRemovedEmoji(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> WrapPresenceUpdated<THandler>() where THandler : class, IPresenceUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IPresenceUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IPresenceUpdatedEventHandler>();
            await instance.OnPresenceUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> WrapPresenceUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IPresenceUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IPresenceUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IPresenceUpdatedEventHandler instance = (IPresenceUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnPresenceUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> WrapUserSettingsUpdated<THandler>() where THandler : class, IUserSettingsUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserSettingsUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IUserSettingsUpdatedEventHandler>();
            await instance.OnUserSettingsUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> WrapUserSettingsUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IUserSettingsUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserSettingsUpdatedEventHandler instance = (IUserSettingsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnUserSettingsUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, UserUpdateEventArgs> WrapUserUpdated<THandler>() where THandler : class, IUserUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IUserUpdatedEventHandler>();
            await instance.OnUserUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, UserUpdateEventArgs> WrapUserUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IUserUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IUserUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserUpdatedEventHandler instance = (IUserUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnUserUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> WrapVoiceStateUpdated<THandler>() where THandler : class, IVoiceStateUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceStateUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IVoiceStateUpdatedEventHandler>();
            await instance.OnVoiceStateUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> WrapVoiceStateUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IVoiceStateUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceStateUpdatedEventHandler instance = (IVoiceStateUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnVoiceStateUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> WrapVoiceServerUpdated<THandler>() where THandler : class, IVoiceServerUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceServerUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IVoiceServerUpdatedEventHandler>();
            await instance.OnVoiceServerUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> WrapVoiceServerUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IVoiceServerUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceServerUpdatedEventHandler instance = (IVoiceServerUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnVoiceServerUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> WrapThreadCreated<THandler>() where THandler : class, IThreadCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadCreatedEventHandler>();
            await instance.OnThreadCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> WrapThreadCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadCreatedEventHandler instance = (IThreadCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> WrapThreadUpdated<THandler>() where THandler : class, IThreadUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadUpdatedEventHandler>();
            await instance.OnThreadUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> WrapThreadUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadUpdatedEventHandler instance = (IThreadUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> WrapThreadDeleted<THandler>() where THandler : class, IThreadDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadDeletedEventHandler>();
            await instance.OnThreadDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> WrapThreadDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadDeletedEventHandler instance = (IThreadDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> WrapThreadListSynced<THandler>() where THandler : class, IThreadListSyncedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadListSyncedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadListSyncedEventHandler>();
            await instance.OnThreadListSynced(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> WrapThreadListSynced(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadListSyncedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadListSyncedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadListSyncedEventHandler instance = (IThreadListSyncedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadListSynced(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> WrapThreadMemberUpdated<THandler>() where THandler : class, IThreadMemberUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMemberUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadMemberUpdatedEventHandler>();
            await instance.OnThreadMemberUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> WrapThreadMemberUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadMemberUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMemberUpdatedEventHandler instance = (IThreadMemberUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadMemberUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> WrapThreadMembersUpdated<THandler>() where THandler : class, IThreadMembersUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMembersUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IThreadMembersUpdatedEventHandler>();
            await instance.OnThreadMembersUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> WrapThreadMembersUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IThreadMembersUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMembersUpdatedEventHandler instance = (IThreadMembersUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadMembersUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> WrapIntegrationCreated<THandler>() where THandler : class, IIntegrationCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IIntegrationCreatedEventHandler>();
            await instance.OnIntegrationCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> WrapIntegrationCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IIntegrationCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IIntegrationCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationCreatedEventHandler instance = (IIntegrationCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> WrapIntegrationUpdated<THandler>() where THandler : class, IIntegrationUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IIntegrationUpdatedEventHandler>();
            await instance.OnIntegrationUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> WrapIntegrationUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IIntegrationUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationUpdatedEventHandler instance = (IIntegrationUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> WrapIntegrationDeleted<THandler>() where THandler : class, IIntegrationDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IIntegrationDeletedEventHandler>();
            await instance.OnIntegrationDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> WrapIntegrationDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IIntegrationDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IIntegrationDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationDeletedEventHandler instance = (IIntegrationDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> WrapStageInstanceCreated<THandler>() where THandler : class, IStageInstanceCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IStageInstanceCreatedEventHandler>();
            await instance.OnStageInstanceCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> WrapStageInstanceCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IStageInstanceCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceCreatedEventHandler instance = (IStageInstanceCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> WrapStageInstanceUpdated<THandler>() where THandler : class, IStageInstanceUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IStageInstanceUpdatedEventHandler>();
            await instance.OnStageInstanceUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> WrapStageInstanceUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IStageInstanceUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceUpdatedEventHandler instance = (IStageInstanceUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> WrapStageInstanceDeleted<THandler>() where THandler : class, IStageInstanceDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IStageInstanceDeletedEventHandler>();
            await instance.OnStageInstanceDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> WrapStageInstanceDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IStageInstanceDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceDeletedEventHandler instance = (IStageInstanceDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> WrapInteractionCreated<THandler>() where THandler : class, IInteractionCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInteractionCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IInteractionCreatedEventHandler>();
            await instance.OnInteractionCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> WrapInteractionCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IInteractionCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IInteractionCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInteractionCreatedEventHandler instance = (IInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInteractionCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> WrapComponentInteractionCreated<THandler>() where THandler : class, IComponentInteractionCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IComponentInteractionCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IComponentInteractionCreatedEventHandler>();
            await instance.OnComponentInteractionCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> WrapComponentInteractionCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IComponentInteractionCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IComponentInteractionCreatedEventHandler instance = (IComponentInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnComponentInteractionCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> WrapModalSubmitted<THandler>() where THandler : class, IModalSubmittedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IModalSubmittedEventHandler instance = scope.ServiceProvider.GetRequiredService<IModalSubmittedEventHandler>();
            await instance.OnModalSubmitted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> WrapModalSubmitted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IModalSubmittedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IModalSubmittedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IModalSubmittedEventHandler instance = (IModalSubmittedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnModalSubmitted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> WrapContextMenuInteractionCreated<THandler>() where THandler : class, IContextMenuInteractionCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IContextMenuInteractionCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IContextMenuInteractionCreatedEventHandler>();
            await instance.OnContextMenuInteractionCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> WrapContextMenuInteractionCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IContextMenuInteractionCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IContextMenuInteractionCreatedEventHandler instance = (IContextMenuInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnContextMenuInteractionCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, TypingStartEventArgs> WrapTypingStarted<THandler>() where THandler : class, ITypingStartedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ITypingStartedEventHandler instance = scope.ServiceProvider.GetRequiredService<ITypingStartedEventHandler>();
            await instance.OnTypingStarted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, TypingStartEventArgs> WrapTypingStarted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(ITypingStartedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface ITypingStartedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ITypingStartedEventHandler instance = (ITypingStartedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnTypingStarted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, UnknownEventArgs> WrapUnknownEvent<THandler>() where THandler : class, IUnknownEventEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUnknownEventEventHandler instance = scope.ServiceProvider.GetRequiredService<IUnknownEventEventHandler>();
            await instance.OnUnknownEvent(client, args);
        };

    public static AsyncEventHandler<DiscordClient, UnknownEventArgs> WrapUnknownEvent(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IUnknownEventEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IUnknownEventEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUnknownEventEventHandler instance = (IUnknownEventEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnUnknownEvent(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> WrapWebhooksUpdated<THandler>() where THandler : class, IWebhooksUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IWebhooksUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IWebhooksUpdatedEventHandler>();
            await instance.OnWebhooksUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> WrapWebhooksUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IWebhooksUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IWebhooksUpdatedEventHandler instance = (IWebhooksUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnWebhooksUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, ClientErrorEventArgs> WrapClientErrored<THandler>() where THandler : class, IClientErroredEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IClientErroredEventHandler instance = scope.ServiceProvider.GetRequiredService<IClientErroredEventHandler>();
            await instance.OnClientErrored(client, args);
        };

    public static AsyncEventHandler<DiscordClient, ClientErrorEventArgs> WrapClientErrored(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IClientErroredEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IClientErroredEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IClientErroredEventHandler instance = (IClientErroredEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnClientErrored(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> WrapAutoModerationRuleCreated<THandler>() where THandler : class, IAutoModerationRuleCreatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleCreatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IAutoModerationRuleCreatedEventHandler>();
            await instance.OnAutoModerationRuleCreated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> WrapAutoModerationRuleCreated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IAutoModerationRuleCreatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleCreatedEventHandler instance = (IAutoModerationRuleCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnAutoModerationRuleCreated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> WrapAutoModerationRuleUpdated<THandler>() where THandler : class, IAutoModerationRuleUpdatedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleUpdatedEventHandler instance = scope.ServiceProvider.GetRequiredService<IAutoModerationRuleUpdatedEventHandler>();
            await instance.OnAutoModerationRuleUpdated(client, args);
        };

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> WrapAutoModerationRuleUpdated(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IAutoModerationRuleUpdatedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleUpdatedEventHandler instance = (IAutoModerationRuleUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnAutoModerationRuleUpdated(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> WrapAutoModerationRuleDeleted<THandler>() where THandler : class, IAutoModerationRuleDeletedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleDeletedEventHandler instance = scope.ServiceProvider.GetRequiredService<IAutoModerationRuleDeletedEventHandler>();
            await instance.OnAutoModerationRuleDeleted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> WrapAutoModerationRuleDeleted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IAutoModerationRuleDeletedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleDeletedEventHandler instance = (IAutoModerationRuleDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnAutoModerationRuleDeleted(client, args);
        };
    }

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> WrapAutoModerationRuleExecuted<THandler>() where THandler : class, IAutoModerationRuleExecutedEventHandler => async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleExecutedEventHandler instance = scope.ServiceProvider.GetRequiredService<IAutoModerationRuleExecutedEventHandler>();
            await instance.OnAutoModerationRuleExecuted(client, args);
        };

    public static AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> WrapAutoModerationRuleExecuted(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if(!handler.IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler)))
            throw new ArgumentException($"{handler.Name} does not implement the required interface IAutoModerationRuleExecutedEventHandler");

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetEventsNext();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IAutoModerationRuleExecutedEventHandler instance = (IAutoModerationRuleExecutedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnAutoModerationRuleExecuted(client, args);
        };
    }

}
