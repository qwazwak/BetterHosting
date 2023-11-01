
using DSharpPlus.EventArgs;
using System.Diagnostics;
using DSharpPlus.EventsNext.Entities;
using System;
using DSharpPlus.AsyncEvents;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DSharpPlus.EventsNext.Tools.Internal;

internal static partial class EventHandlerReflector
{
    public static partial IEnumerable<Type> GetInterfaces<THandlerImplementation>() where THandlerImplementation : IDiscordEventHandler
    {
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ISocketErroredEventHandler)))
            yield return typeof(ISocketErroredEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ISocketOpenedEventHandler)))
            yield return typeof(ISocketOpenedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ISocketClosedEventHandler)))
            yield return typeof(ISocketClosedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ISessionCreatedEventHandler)))
            yield return typeof(ISessionCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ISessionResumedEventHandler)))
            yield return typeof(ISessionResumedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IHeartbeatedEventHandler)))
            yield return typeof(IHeartbeatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IZombiedEventHandler)))
            yield return typeof(IZombiedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)))
            yield return typeof(IApplicationCommandPermissionsUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IChannelCreatedEventHandler)))
            yield return typeof(IChannelCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IChannelUpdatedEventHandler)))
            yield return typeof(IChannelUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IChannelDeletedEventHandler)))
            yield return typeof(IChannelDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IDmChannelDeletedEventHandler)))
            yield return typeof(IDmChannelDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)))
            yield return typeof(IChannelPinsUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildCreatedEventHandler)))
            yield return typeof(IGuildCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildAvailableEventHandler)))
            yield return typeof(IGuildAvailableEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildUpdatedEventHandler)))
            yield return typeof(IGuildUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildDeletedEventHandler)))
            yield return typeof(IGuildDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildUnavailableEventHandler)))
            yield return typeof(IGuildUnavailableEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)))
            yield return typeof(IGuildDownloadCompletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)))
            yield return typeof(IGuildEmojisUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)))
            yield return typeof(IGuildStickersUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)))
            yield return typeof(IGuildIntegrationsUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)))
            yield return typeof(IGuildAuditLogCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)))
            yield return typeof(IScheduledGuildEventCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)))
            yield return typeof(IScheduledGuildEventUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)))
            yield return typeof(IScheduledGuildEventDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)))
            yield return typeof(IScheduledGuildEventCompletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)))
            yield return typeof(IScheduledGuildEventUserAddedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)))
            yield return typeof(IScheduledGuildEventUserRemovedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildBanAddedEventHandler)))
            yield return typeof(IGuildBanAddedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildBanRemovedEventHandler)))
            yield return typeof(IGuildBanRemovedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildMemberAddedEventHandler)))
            yield return typeof(IGuildMemberAddedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)))
            yield return typeof(IGuildMemberRemovedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)))
            yield return typeof(IGuildMemberUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)))
            yield return typeof(IGuildMembersChunkedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)))
            yield return typeof(IGuildRoleCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)))
            yield return typeof(IGuildRoleUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)))
            yield return typeof(IGuildRoleDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IInviteCreatedEventHandler)))
            yield return typeof(IInviteCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IInviteDeletedEventHandler)))
            yield return typeof(IInviteDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageCreatedEventHandler)))
            yield return typeof(IMessageCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)))
            yield return typeof(IMessageAcknowledgedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageUpdatedEventHandler)))
            yield return typeof(IMessageUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageDeletedEventHandler)))
            yield return typeof(IMessageDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)))
            yield return typeof(IMessagesBulkDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageReactionAddedEventHandler)))
            yield return typeof(IMessageReactionAddedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)))
            yield return typeof(IMessageReactionRemovedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)))
            yield return typeof(IMessageReactionsClearedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)))
            yield return typeof(IMessageReactionRemovedEmojiEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IPresenceUpdatedEventHandler)))
            yield return typeof(IPresenceUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)))
            yield return typeof(IUserSettingsUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IUserUpdatedEventHandler)))
            yield return typeof(IUserUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)))
            yield return typeof(IVoiceStateUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)))
            yield return typeof(IVoiceServerUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadCreatedEventHandler)))
            yield return typeof(IThreadCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadUpdatedEventHandler)))
            yield return typeof(IThreadUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadDeletedEventHandler)))
            yield return typeof(IThreadDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadListSyncedEventHandler)))
            yield return typeof(IThreadListSyncedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)))
            yield return typeof(IThreadMemberUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)))
            yield return typeof(IThreadMembersUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IIntegrationCreatedEventHandler)))
            yield return typeof(IIntegrationCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)))
            yield return typeof(IIntegrationUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IIntegrationDeletedEventHandler)))
            yield return typeof(IIntegrationDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)))
            yield return typeof(IStageInstanceCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)))
            yield return typeof(IStageInstanceUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)))
            yield return typeof(IStageInstanceDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IInteractionCreatedEventHandler)))
            yield return typeof(IInteractionCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)))
            yield return typeof(IComponentInteractionCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IModalSubmittedEventHandler)))
            yield return typeof(IModalSubmittedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)))
            yield return typeof(IContextMenuInteractionCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(ITypingStartedEventHandler)))
            yield return typeof(ITypingStartedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IUnknownEventEventHandler)))
            yield return typeof(IUnknownEventEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)))
            yield return typeof(IWebhooksUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IClientErroredEventHandler)))
            yield return typeof(IClientErroredEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)))
            yield return typeof(IAutoModerationRuleCreatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)))
            yield return typeof(IAutoModerationRuleUpdatedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)))
            yield return typeof(IAutoModerationRuleDeletedEventHandler);
        if(typeof(THandlerImplementation).IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler)))
            yield return typeof(IAutoModerationRuleExecutedEventHandler);
    }

    public static partial ValueTask AutoCallEventHandler<THandler, TArgument>(IDiscordEventHandler<TArgument> handler, DiscordClient sender, TArgument args) where THandler : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs
    {
        if(typeof(THandler) == typeof(ISocketErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketErrorEventArgs));
            ISocketErroredEventHandler castHandler = (ISocketErroredEventHandler)handler;
            SocketErrorEventArgs castArgs = (SocketErrorEventArgs)(DiscordEventArgs)args;
            return castHandler.OnSocketErrored(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(ISocketOpenedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketEventArgs));
            ISocketOpenedEventHandler castHandler = (ISocketOpenedEventHandler)handler;
            SocketEventArgs castArgs = (SocketEventArgs)(DiscordEventArgs)args;
            return castHandler.OnSocketOpened(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(ISocketClosedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketCloseEventArgs));
            ISocketClosedEventHandler castHandler = (ISocketClosedEventHandler)handler;
            SocketCloseEventArgs castArgs = (SocketCloseEventArgs)(DiscordEventArgs)args;
            return castHandler.OnSocketClosed(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(ISessionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            ISessionCreatedEventHandler castHandler = (ISessionCreatedEventHandler)handler;
            SessionReadyEventArgs castArgs = (SessionReadyEventArgs)(DiscordEventArgs)args;
            return castHandler.OnSessionCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(ISessionResumedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            ISessionResumedEventHandler castHandler = (ISessionResumedEventHandler)handler;
            SessionReadyEventArgs castArgs = (SessionReadyEventArgs)(DiscordEventArgs)args;
            return castHandler.OnSessionResumed(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IHeartbeatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(HeartbeatEventArgs));
            IHeartbeatedEventHandler castHandler = (IHeartbeatedEventHandler)handler;
            HeartbeatEventArgs castArgs = (HeartbeatEventArgs)(DiscordEventArgs)args;
            return castHandler.OnHeartbeated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IZombiedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ZombiedEventArgs));
            IZombiedEventHandler castHandler = (IZombiedEventHandler)handler;
            ZombiedEventArgs castArgs = (ZombiedEventArgs)(DiscordEventArgs)args;
            return castHandler.OnZombied(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ApplicationCommandPermissionsUpdatedEventArgs));
            IApplicationCommandPermissionsUpdatedEventHandler castHandler = (IApplicationCommandPermissionsUpdatedEventHandler)handler;
            ApplicationCommandPermissionsUpdatedEventArgs castArgs = (ApplicationCommandPermissionsUpdatedEventArgs)(DiscordEventArgs)args;
            return castHandler.OnApplicationCommandPermissionsUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IChannelCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelCreateEventArgs));
            IChannelCreatedEventHandler castHandler = (IChannelCreatedEventHandler)handler;
            ChannelCreateEventArgs castArgs = (ChannelCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnChannelCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IChannelUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelUpdateEventArgs));
            IChannelUpdatedEventHandler castHandler = (IChannelUpdatedEventHandler)handler;
            ChannelUpdateEventArgs castArgs = (ChannelUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnChannelUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelDeleteEventArgs));
            IChannelDeletedEventHandler castHandler = (IChannelDeletedEventHandler)handler;
            ChannelDeleteEventArgs castArgs = (ChannelDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnChannelDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IDmChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(DmChannelDeleteEventArgs));
            IDmChannelDeletedEventHandler castHandler = (IDmChannelDeletedEventHandler)handler;
            DmChannelDeleteEventArgs castArgs = (DmChannelDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnDmChannelDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IChannelPinsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelPinsUpdateEventArgs));
            IChannelPinsUpdatedEventHandler castHandler = (IChannelPinsUpdatedEventHandler)handler;
            ChannelPinsUpdateEventArgs castArgs = (ChannelPinsUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnChannelPinsUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            IGuildCreatedEventHandler castHandler = (IGuildCreatedEventHandler)handler;
            GuildCreateEventArgs castArgs = (GuildCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildAvailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            IGuildAvailableEventHandler castHandler = (IGuildAvailableEventHandler)handler;
            GuildCreateEventArgs castArgs = (GuildCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildAvailable(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildUpdateEventArgs));
            IGuildUpdatedEventHandler castHandler = (IGuildUpdatedEventHandler)handler;
            GuildUpdateEventArgs castArgs = (GuildUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            IGuildDeletedEventHandler castHandler = (IGuildDeletedEventHandler)handler;
            GuildDeleteEventArgs castArgs = (GuildDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildUnavailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            IGuildUnavailableEventHandler castHandler = (IGuildUnavailableEventHandler)handler;
            GuildDeleteEventArgs castArgs = (GuildDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildUnavailable(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildDownloadCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDownloadCompletedEventArgs));
            IGuildDownloadCompletedEventHandler castHandler = (IGuildDownloadCompletedEventHandler)handler;
            GuildDownloadCompletedEventArgs castArgs = (GuildDownloadCompletedEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildDownloadCompleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildEmojisUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildEmojisUpdateEventArgs));
            IGuildEmojisUpdatedEventHandler castHandler = (IGuildEmojisUpdatedEventHandler)handler;
            GuildEmojisUpdateEventArgs castArgs = (GuildEmojisUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildEmojisUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildStickersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildStickersUpdateEventArgs));
            IGuildStickersUpdatedEventHandler castHandler = (IGuildStickersUpdatedEventHandler)handler;
            GuildStickersUpdateEventArgs castArgs = (GuildStickersUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildStickersUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildIntegrationsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildIntegrationsUpdateEventArgs));
            IGuildIntegrationsUpdatedEventHandler castHandler = (IGuildIntegrationsUpdatedEventHandler)handler;
            GuildIntegrationsUpdateEventArgs castArgs = (GuildIntegrationsUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildIntegrationsUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildAuditLogCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildAuditLogCreatedEventArgs));
            IGuildAuditLogCreatedEventHandler castHandler = (IGuildAuditLogCreatedEventHandler)handler;
            GuildAuditLogCreatedEventArgs castArgs = (GuildAuditLogCreatedEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildAuditLogCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCreateEventArgs));
            IScheduledGuildEventCreatedEventHandler castHandler = (IScheduledGuildEventCreatedEventHandler)handler;
            ScheduledGuildEventCreateEventArgs castArgs = (ScheduledGuildEventCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUpdateEventArgs));
            IScheduledGuildEventUpdatedEventHandler castHandler = (IScheduledGuildEventUpdatedEventHandler)handler;
            ScheduledGuildEventUpdateEventArgs castArgs = (ScheduledGuildEventUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventDeleteEventArgs));
            IScheduledGuildEventDeletedEventHandler castHandler = (IScheduledGuildEventDeletedEventHandler)handler;
            ScheduledGuildEventDeleteEventArgs castArgs = (ScheduledGuildEventDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCompletedEventArgs));
            IScheduledGuildEventCompletedEventHandler castHandler = (IScheduledGuildEventCompletedEventHandler)handler;
            ScheduledGuildEventCompletedEventArgs castArgs = (ScheduledGuildEventCompletedEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventCompleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventUserAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserAddEventArgs));
            IScheduledGuildEventUserAddedEventHandler castHandler = (IScheduledGuildEventUserAddedEventHandler)handler;
            ScheduledGuildEventUserAddEventArgs castArgs = (ScheduledGuildEventUserAddEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventUserAdded(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IScheduledGuildEventUserRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserRemoveEventArgs));
            IScheduledGuildEventUserRemovedEventHandler castHandler = (IScheduledGuildEventUserRemovedEventHandler)handler;
            ScheduledGuildEventUserRemoveEventArgs castArgs = (ScheduledGuildEventUserRemoveEventArgs)(DiscordEventArgs)args;
            return castHandler.OnScheduledGuildEventUserRemoved(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildBanAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanAddEventArgs));
            IGuildBanAddedEventHandler castHandler = (IGuildBanAddedEventHandler)handler;
            GuildBanAddEventArgs castArgs = (GuildBanAddEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildBanAdded(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildBanRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanRemoveEventArgs));
            IGuildBanRemovedEventHandler castHandler = (IGuildBanRemovedEventHandler)handler;
            GuildBanRemoveEventArgs castArgs = (GuildBanRemoveEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildBanRemoved(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildMemberAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberAddEventArgs));
            IGuildMemberAddedEventHandler castHandler = (IGuildMemberAddedEventHandler)handler;
            GuildMemberAddEventArgs castArgs = (GuildMemberAddEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildMemberAdded(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildMemberRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberRemoveEventArgs));
            IGuildMemberRemovedEventHandler castHandler = (IGuildMemberRemovedEventHandler)handler;
            GuildMemberRemoveEventArgs castArgs = (GuildMemberRemoveEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildMemberRemoved(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberUpdateEventArgs));
            IGuildMemberUpdatedEventHandler castHandler = (IGuildMemberUpdatedEventHandler)handler;
            GuildMemberUpdateEventArgs castArgs = (GuildMemberUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildMemberUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildMembersChunkedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMembersChunkEventArgs));
            IGuildMembersChunkedEventHandler castHandler = (IGuildMembersChunkedEventHandler)handler;
            GuildMembersChunkEventArgs castArgs = (GuildMembersChunkEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildMembersChunked(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildRoleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleCreateEventArgs));
            IGuildRoleCreatedEventHandler castHandler = (IGuildRoleCreatedEventHandler)handler;
            GuildRoleCreateEventArgs castArgs = (GuildRoleCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildRoleCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildRoleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleUpdateEventArgs));
            IGuildRoleUpdatedEventHandler castHandler = (IGuildRoleUpdatedEventHandler)handler;
            GuildRoleUpdateEventArgs castArgs = (GuildRoleUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildRoleUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IGuildRoleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleDeleteEventArgs));
            IGuildRoleDeletedEventHandler castHandler = (IGuildRoleDeletedEventHandler)handler;
            GuildRoleDeleteEventArgs castArgs = (GuildRoleDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnGuildRoleDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IInviteCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteCreateEventArgs));
            IInviteCreatedEventHandler castHandler = (IInviteCreatedEventHandler)handler;
            InviteCreateEventArgs castArgs = (InviteCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnInviteCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IInviteDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteDeleteEventArgs));
            IInviteDeletedEventHandler castHandler = (IInviteDeletedEventHandler)handler;
            InviteDeleteEventArgs castArgs = (InviteDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnInviteDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageCreateEventArgs));
            IMessageCreatedEventHandler castHandler = (IMessageCreatedEventHandler)handler;
            MessageCreateEventArgs castArgs = (MessageCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageAcknowledgedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageAcknowledgeEventArgs));
            IMessageAcknowledgedEventHandler castHandler = (IMessageAcknowledgedEventHandler)handler;
            MessageAcknowledgeEventArgs castArgs = (MessageAcknowledgeEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageAcknowledged(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageUpdateEventArgs));
            IMessageUpdatedEventHandler castHandler = (IMessageUpdatedEventHandler)handler;
            MessageUpdateEventArgs castArgs = (MessageUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageDeleteEventArgs));
            IMessageDeletedEventHandler castHandler = (IMessageDeletedEventHandler)handler;
            MessageDeleteEventArgs castArgs = (MessageDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessagesBulkDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageBulkDeleteEventArgs));
            IMessagesBulkDeletedEventHandler castHandler = (IMessagesBulkDeletedEventHandler)handler;
            MessageBulkDeleteEventArgs castArgs = (MessageBulkDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessagesBulkDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageReactionAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionAddEventArgs));
            IMessageReactionAddedEventHandler castHandler = (IMessageReactionAddedEventHandler)handler;
            MessageReactionAddEventArgs castArgs = (MessageReactionAddEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageReactionAdded(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageReactionRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEventArgs));
            IMessageReactionRemovedEventHandler castHandler = (IMessageReactionRemovedEventHandler)handler;
            MessageReactionRemoveEventArgs castArgs = (MessageReactionRemoveEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageReactionRemoved(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageReactionsClearedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionsClearEventArgs));
            IMessageReactionsClearedEventHandler castHandler = (IMessageReactionsClearedEventHandler)handler;
            MessageReactionsClearEventArgs castArgs = (MessageReactionsClearEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageReactionsCleared(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IMessageReactionRemovedEmojiEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEmojiEventArgs));
            IMessageReactionRemovedEmojiEventHandler castHandler = (IMessageReactionRemovedEmojiEventHandler)handler;
            MessageReactionRemoveEmojiEventArgs castArgs = (MessageReactionRemoveEmojiEventArgs)(DiscordEventArgs)args;
            return castHandler.OnMessageReactionRemovedEmoji(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IPresenceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(PresenceUpdateEventArgs));
            IPresenceUpdatedEventHandler castHandler = (IPresenceUpdatedEventHandler)handler;
            PresenceUpdateEventArgs castArgs = (PresenceUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnPresenceUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IUserSettingsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserSettingsUpdateEventArgs));
            IUserSettingsUpdatedEventHandler castHandler = (IUserSettingsUpdatedEventHandler)handler;
            UserSettingsUpdateEventArgs castArgs = (UserSettingsUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnUserSettingsUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IUserUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserUpdateEventArgs));
            IUserUpdatedEventHandler castHandler = (IUserUpdatedEventHandler)handler;
            UserUpdateEventArgs castArgs = (UserUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnUserUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IVoiceStateUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceStateUpdateEventArgs));
            IVoiceStateUpdatedEventHandler castHandler = (IVoiceStateUpdatedEventHandler)handler;
            VoiceStateUpdateEventArgs castArgs = (VoiceStateUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnVoiceStateUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IVoiceServerUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceServerUpdateEventArgs));
            IVoiceServerUpdatedEventHandler castHandler = (IVoiceServerUpdatedEventHandler)handler;
            VoiceServerUpdateEventArgs castArgs = (VoiceServerUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnVoiceServerUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadCreateEventArgs));
            IThreadCreatedEventHandler castHandler = (IThreadCreatedEventHandler)handler;
            ThreadCreateEventArgs castArgs = (ThreadCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadUpdateEventArgs));
            IThreadUpdatedEventHandler castHandler = (IThreadUpdatedEventHandler)handler;
            ThreadUpdateEventArgs castArgs = (ThreadUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadDeleteEventArgs));
            IThreadDeletedEventHandler castHandler = (IThreadDeletedEventHandler)handler;
            ThreadDeleteEventArgs castArgs = (ThreadDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadListSyncedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadListSyncEventArgs));
            IThreadListSyncedEventHandler castHandler = (IThreadListSyncedEventHandler)handler;
            ThreadListSyncEventArgs castArgs = (ThreadListSyncEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadListSynced(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMemberUpdateEventArgs));
            IThreadMemberUpdatedEventHandler castHandler = (IThreadMemberUpdatedEventHandler)handler;
            ThreadMemberUpdateEventArgs castArgs = (ThreadMemberUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadMemberUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IThreadMembersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMembersUpdateEventArgs));
            IThreadMembersUpdatedEventHandler castHandler = (IThreadMembersUpdatedEventHandler)handler;
            ThreadMembersUpdateEventArgs castArgs = (ThreadMembersUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnThreadMembersUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IIntegrationCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationCreateEventArgs));
            IIntegrationCreatedEventHandler castHandler = (IIntegrationCreatedEventHandler)handler;
            IntegrationCreateEventArgs castArgs = (IntegrationCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnIntegrationCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IIntegrationUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationUpdateEventArgs));
            IIntegrationUpdatedEventHandler castHandler = (IIntegrationUpdatedEventHandler)handler;
            IntegrationUpdateEventArgs castArgs = (IntegrationUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnIntegrationUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IIntegrationDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationDeleteEventArgs));
            IIntegrationDeletedEventHandler castHandler = (IIntegrationDeletedEventHandler)handler;
            IntegrationDeleteEventArgs castArgs = (IntegrationDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnIntegrationDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IStageInstanceCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceCreateEventArgs));
            IStageInstanceCreatedEventHandler castHandler = (IStageInstanceCreatedEventHandler)handler;
            StageInstanceCreateEventArgs castArgs = (StageInstanceCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnStageInstanceCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IStageInstanceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceUpdateEventArgs));
            IStageInstanceUpdatedEventHandler castHandler = (IStageInstanceUpdatedEventHandler)handler;
            StageInstanceUpdateEventArgs castArgs = (StageInstanceUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnStageInstanceUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IStageInstanceDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceDeleteEventArgs));
            IStageInstanceDeletedEventHandler castHandler = (IStageInstanceDeletedEventHandler)handler;
            StageInstanceDeleteEventArgs castArgs = (StageInstanceDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnStageInstanceDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InteractionCreateEventArgs));
            IInteractionCreatedEventHandler castHandler = (IInteractionCreatedEventHandler)handler;
            InteractionCreateEventArgs castArgs = (InteractionCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IComponentInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ComponentInteractionCreateEventArgs));
            IComponentInteractionCreatedEventHandler castHandler = (IComponentInteractionCreatedEventHandler)handler;
            ComponentInteractionCreateEventArgs castArgs = (ComponentInteractionCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnComponentInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IModalSubmittedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ModalSubmitEventArgs));
            IModalSubmittedEventHandler castHandler = (IModalSubmittedEventHandler)handler;
            ModalSubmitEventArgs castArgs = (ModalSubmitEventArgs)(DiscordEventArgs)args;
            return castHandler.OnModalSubmitted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IContextMenuInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ContextMenuInteractionCreateEventArgs));
            IContextMenuInteractionCreatedEventHandler castHandler = (IContextMenuInteractionCreatedEventHandler)handler;
            ContextMenuInteractionCreateEventArgs castArgs = (ContextMenuInteractionCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnContextMenuInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(ITypingStartedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(TypingStartEventArgs));
            ITypingStartedEventHandler castHandler = (ITypingStartedEventHandler)handler;
            TypingStartEventArgs castArgs = (TypingStartEventArgs)(DiscordEventArgs)args;
            return castHandler.OnTypingStarted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IUnknownEventEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UnknownEventArgs));
            IUnknownEventEventHandler castHandler = (IUnknownEventEventHandler)handler;
            UnknownEventArgs castArgs = (UnknownEventArgs)(DiscordEventArgs)args;
            return castHandler.OnUnknownEvent(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IWebhooksUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(WebhooksUpdateEventArgs));
            IWebhooksUpdatedEventHandler castHandler = (IWebhooksUpdatedEventHandler)handler;
            WebhooksUpdateEventArgs castArgs = (WebhooksUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnWebhooksUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IClientErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ClientErrorEventArgs));
            IClientErroredEventHandler castHandler = (IClientErroredEventHandler)handler;
            ClientErrorEventArgs castArgs = (ClientErrorEventArgs)(DiscordEventArgs)args;
            return castHandler.OnClientErrored(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IAutoModerationRuleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleCreateEventArgs));
            IAutoModerationRuleCreatedEventHandler castHandler = (IAutoModerationRuleCreatedEventHandler)handler;
            AutoModerationRuleCreateEventArgs castArgs = (AutoModerationRuleCreateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnAutoModerationRuleCreated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IAutoModerationRuleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleUpdateEventArgs));
            IAutoModerationRuleUpdatedEventHandler castHandler = (IAutoModerationRuleUpdatedEventHandler)handler;
            AutoModerationRuleUpdateEventArgs castArgs = (AutoModerationRuleUpdateEventArgs)(DiscordEventArgs)args;
            return castHandler.OnAutoModerationRuleUpdated(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IAutoModerationRuleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleDeleteEventArgs));
            IAutoModerationRuleDeletedEventHandler castHandler = (IAutoModerationRuleDeletedEventHandler)handler;
            AutoModerationRuleDeleteEventArgs castArgs = (AutoModerationRuleDeleteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnAutoModerationRuleDeleted(sender, castArgs);
        }
        else
        if(typeof(THandler) == typeof(IAutoModerationRuleExecutedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleExecuteEventArgs));
            IAutoModerationRuleExecutedEventHandler castHandler = (IAutoModerationRuleExecutedEventHandler)handler;
            AutoModerationRuleExecuteEventArgs castArgs = (AutoModerationRuleExecuteEventArgs)(DiscordEventArgs)args;
            return castHandler.OnAutoModerationRuleExecuted(sender, castArgs);
        }
        else
        {
            Debug.Fail($"Not a supported type: {typeof(THandler).Name}");
            return ValueTask.FromException(new InvalidOperationException($"Handler of type {typeof(THandler).Name} not supported"));
        }
    }

    public static partial void BindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs
    {
        if(typeof(THandlerInterface) == typeof(ISocketErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketErrorEventArgs));
            client.SocketErrored += (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISocketOpenedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketEventArgs));
            client.SocketOpened += (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISocketClosedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketCloseEventArgs));
            client.SocketClosed += (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISessionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            client.SessionCreated += (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISessionResumedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            client.SessionResumed += (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IHeartbeatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(HeartbeatEventArgs));
            client.Heartbeated += (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IZombiedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ZombiedEventArgs));
            client.Zombied += (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ApplicationCommandPermissionsUpdatedEventArgs));
            client.ApplicationCommandPermissionsUpdated += (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelCreateEventArgs));
            client.ChannelCreated += (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelUpdateEventArgs));
            client.ChannelUpdated += (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelDeleteEventArgs));
            client.ChannelDeleted += (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IDmChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(DmChannelDeleteEventArgs));
            client.DmChannelDeleted += (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelPinsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelPinsUpdateEventArgs));
            client.ChannelPinsUpdated += (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            client.GuildCreated += (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildAvailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            client.GuildAvailable += (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildUpdateEventArgs));
            client.GuildUpdated += (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            client.GuildDeleted += (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildUnavailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            client.GuildUnavailable += (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildDownloadCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDownloadCompletedEventArgs));
            client.GuildDownloadCompleted += (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildEmojisUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildEmojisUpdateEventArgs));
            client.GuildEmojisUpdated += (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildStickersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildStickersUpdateEventArgs));
            client.GuildStickersUpdated += (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildIntegrationsUpdateEventArgs));
            client.GuildIntegrationsUpdated += (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildAuditLogCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildAuditLogCreatedEventArgs));
            client.GuildAuditLogCreated += (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCreateEventArgs));
            client.ScheduledGuildEventCreated += (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUpdateEventArgs));
            client.ScheduledGuildEventUpdated += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventDeleteEventArgs));
            client.ScheduledGuildEventDeleted += (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCompletedEventArgs));
            client.ScheduledGuildEventCompleted += (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserAddEventArgs));
            client.ScheduledGuildEventUserAdded += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserRemoveEventArgs));
            client.ScheduledGuildEventUserRemoved += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildBanAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanAddEventArgs));
            client.GuildBanAdded += (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildBanRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanRemoveEventArgs));
            client.GuildBanRemoved += (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberAddEventArgs));
            client.GuildMemberAdded += (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberRemoveEventArgs));
            client.GuildMemberRemoved += (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberUpdateEventArgs));
            client.GuildMemberUpdated += (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMembersChunkedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMembersChunkEventArgs));
            client.GuildMembersChunked += (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleCreateEventArgs));
            client.GuildRoleCreated += (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleUpdateEventArgs));
            client.GuildRoleUpdated += (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleDeleteEventArgs));
            client.GuildRoleDeleted += (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInviteCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteCreateEventArgs));
            client.InviteCreated += (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInviteDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteDeleteEventArgs));
            client.InviteDeleted += (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageCreateEventArgs));
            client.MessageCreated += (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageAcknowledgedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageAcknowledgeEventArgs));
            client.MessageAcknowledged += (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageUpdateEventArgs));
            client.MessageUpdated += (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageDeleteEventArgs));
            client.MessageDeleted += (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessagesBulkDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageBulkDeleteEventArgs));
            client.MessagesBulkDeleted += (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionAddEventArgs));
            client.MessageReactionAdded += (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEventArgs));
            client.MessageReactionRemoved += (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionsClearedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionsClearEventArgs));
            client.MessageReactionsCleared += (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEmojiEventArgs));
            client.MessageReactionRemovedEmoji += (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IPresenceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(PresenceUpdateEventArgs));
            client.PresenceUpdated += (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUserSettingsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserSettingsUpdateEventArgs));
            client.UserSettingsUpdated += (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUserUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserUpdateEventArgs));
            client.UserUpdated += (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IVoiceStateUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceStateUpdateEventArgs));
            client.VoiceStateUpdated += (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IVoiceServerUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceServerUpdateEventArgs));
            client.VoiceServerUpdated += (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadCreateEventArgs));
            client.ThreadCreated += (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadUpdateEventArgs));
            client.ThreadUpdated += (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadDeleteEventArgs));
            client.ThreadDeleted += (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadListSyncedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadListSyncEventArgs));
            client.ThreadListSynced += (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMemberUpdateEventArgs));
            client.ThreadMemberUpdated += (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadMembersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMembersUpdateEventArgs));
            client.ThreadMembersUpdated += (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationCreateEventArgs));
            client.IntegrationCreated += (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationUpdateEventArgs));
            client.IntegrationUpdated += (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationDeleteEventArgs));
            client.IntegrationDeleted += (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceCreateEventArgs));
            client.StageInstanceCreated += (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceUpdateEventArgs));
            client.StageInstanceUpdated += (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceDeleteEventArgs));
            client.StageInstanceDeleted += (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InteractionCreateEventArgs));
            client.InteractionCreated += (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IComponentInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ComponentInteractionCreateEventArgs));
            client.ComponentInteractionCreated += (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IModalSubmittedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ModalSubmitEventArgs));
            client.ModalSubmitted += (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ContextMenuInteractionCreateEventArgs));
            client.ContextMenuInteractionCreated += (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ITypingStartedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(TypingStartEventArgs));
            client.TypingStarted += (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUnknownEventEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UnknownEventArgs));
            client.UnknownEvent += (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IWebhooksUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(WebhooksUpdateEventArgs));
            client.WebhooksUpdated += (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IClientErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ClientErrorEventArgs));
            client.ClientErrored += (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleCreateEventArgs));
            client.AutoModerationRuleCreated += (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleUpdateEventArgs));
            client.AutoModerationRuleUpdated += (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleDeleteEventArgs));
            client.AutoModerationRuleDeleted += (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleExecuteEventArgs));
            client.AutoModerationRuleExecuted += (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler;
            return;
        }
        else
        {
            Debug.Fail($"Not a supported type: {typeof(THandlerInterface).Name}");
            throw new InvalidOperationException($"Handler of type {typeof(THandlerInterface).Name} not supported");
        }
    }

    public static partial void UnbindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs
    {
        if(typeof(THandlerInterface) == typeof(ISocketErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketErrorEventArgs));
            client.SocketErrored -= (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISocketOpenedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketEventArgs));
            client.SocketOpened -= (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISocketClosedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SocketCloseEventArgs));
            client.SocketClosed -= (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISessionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            client.SessionCreated -= (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ISessionResumedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(SessionReadyEventArgs));
            client.SessionResumed -= (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IHeartbeatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(HeartbeatEventArgs));
            client.Heartbeated -= (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IZombiedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ZombiedEventArgs));
            client.Zombied -= (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ApplicationCommandPermissionsUpdatedEventArgs));
            client.ApplicationCommandPermissionsUpdated -= (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelCreateEventArgs));
            client.ChannelCreated -= (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelUpdateEventArgs));
            client.ChannelUpdated -= (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelDeleteEventArgs));
            client.ChannelDeleted -= (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IDmChannelDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(DmChannelDeleteEventArgs));
            client.DmChannelDeleted -= (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IChannelPinsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ChannelPinsUpdateEventArgs));
            client.ChannelPinsUpdated -= (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            client.GuildCreated -= (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildAvailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildCreateEventArgs));
            client.GuildAvailable -= (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildUpdateEventArgs));
            client.GuildUpdated -= (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            client.GuildDeleted -= (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildUnavailableEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDeleteEventArgs));
            client.GuildUnavailable -= (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildDownloadCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildDownloadCompletedEventArgs));
            client.GuildDownloadCompleted -= (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildEmojisUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildEmojisUpdateEventArgs));
            client.GuildEmojisUpdated -= (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildStickersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildStickersUpdateEventArgs));
            client.GuildStickersUpdated -= (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildIntegrationsUpdateEventArgs));
            client.GuildIntegrationsUpdated -= (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildAuditLogCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildAuditLogCreatedEventArgs));
            client.GuildAuditLogCreated -= (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCreateEventArgs));
            client.ScheduledGuildEventCreated -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUpdateEventArgs));
            client.ScheduledGuildEventUpdated -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventDeleteEventArgs));
            client.ScheduledGuildEventDeleted -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventCompletedEventArgs));
            client.ScheduledGuildEventCompleted -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserAddEventArgs));
            client.ScheduledGuildEventUserAdded -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ScheduledGuildEventUserRemoveEventArgs));
            client.ScheduledGuildEventUserRemoved -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildBanAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanAddEventArgs));
            client.GuildBanAdded -= (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildBanRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildBanRemoveEventArgs));
            client.GuildBanRemoved -= (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberAddEventArgs));
            client.GuildMemberAdded -= (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberRemoveEventArgs));
            client.GuildMemberRemoved -= (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMemberUpdateEventArgs));
            client.GuildMemberUpdated -= (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildMembersChunkedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildMembersChunkEventArgs));
            client.GuildMembersChunked -= (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleCreateEventArgs));
            client.GuildRoleCreated -= (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleUpdateEventArgs));
            client.GuildRoleUpdated -= (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IGuildRoleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(GuildRoleDeleteEventArgs));
            client.GuildRoleDeleted -= (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInviteCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteCreateEventArgs));
            client.InviteCreated -= (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInviteDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InviteDeleteEventArgs));
            client.InviteDeleted -= (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageCreateEventArgs));
            client.MessageCreated -= (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageAcknowledgedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageAcknowledgeEventArgs));
            client.MessageAcknowledged -= (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageUpdateEventArgs));
            client.MessageUpdated -= (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageDeleteEventArgs));
            client.MessageDeleted -= (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessagesBulkDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageBulkDeleteEventArgs));
            client.MessagesBulkDeleted -= (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionAddedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionAddEventArgs));
            client.MessageReactionAdded -= (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionRemovedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEventArgs));
            client.MessageReactionRemoved -= (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionsClearedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionsClearEventArgs));
            client.MessageReactionsCleared -= (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(MessageReactionRemoveEmojiEventArgs));
            client.MessageReactionRemovedEmoji -= (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IPresenceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(PresenceUpdateEventArgs));
            client.PresenceUpdated -= (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUserSettingsUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserSettingsUpdateEventArgs));
            client.UserSettingsUpdated -= (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUserUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UserUpdateEventArgs));
            client.UserUpdated -= (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IVoiceStateUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceStateUpdateEventArgs));
            client.VoiceStateUpdated -= (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IVoiceServerUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(VoiceServerUpdateEventArgs));
            client.VoiceServerUpdated -= (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadCreateEventArgs));
            client.ThreadCreated -= (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadUpdateEventArgs));
            client.ThreadUpdated -= (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadDeleteEventArgs));
            client.ThreadDeleted -= (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadListSyncedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadListSyncEventArgs));
            client.ThreadListSynced -= (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadMemberUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMemberUpdateEventArgs));
            client.ThreadMemberUpdated -= (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IThreadMembersUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ThreadMembersUpdateEventArgs));
            client.ThreadMembersUpdated -= (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationCreateEventArgs));
            client.IntegrationCreated -= (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationUpdateEventArgs));
            client.IntegrationUpdated -= (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IIntegrationDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(IntegrationDeleteEventArgs));
            client.IntegrationDeleted -= (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceCreateEventArgs));
            client.StageInstanceCreated -= (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceUpdateEventArgs));
            client.StageInstanceUpdated -= (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IStageInstanceDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(StageInstanceDeleteEventArgs));
            client.StageInstanceDeleted -= (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(InteractionCreateEventArgs));
            client.InteractionCreated -= (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IComponentInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ComponentInteractionCreateEventArgs));
            client.ComponentInteractionCreated -= (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IModalSubmittedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ModalSubmitEventArgs));
            client.ModalSubmitted -= (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ContextMenuInteractionCreateEventArgs));
            client.ContextMenuInteractionCreated -= (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(ITypingStartedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(TypingStartEventArgs));
            client.TypingStarted -= (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IUnknownEventEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(UnknownEventArgs));
            client.UnknownEvent -= (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IWebhooksUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(WebhooksUpdateEventArgs));
            client.WebhooksUpdated -= (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IClientErroredEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(ClientErrorEventArgs));
            client.ClientErrored -= (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleCreateEventArgs));
            client.AutoModerationRuleCreated -= (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleUpdateEventArgs));
            client.AutoModerationRuleUpdated -= (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleDeleteEventArgs));
            client.AutoModerationRuleDeleted -= (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler;
            return;
        }
        else
        if(typeof(THandlerInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
        {
            Debug.Assert(typeof(TArgument) == typeof(AutoModerationRuleExecuteEventArgs));
            client.AutoModerationRuleExecuted -= (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler;
            return;
        }
        else
        {
            Debug.Fail($"Not a supported type: {typeof(THandlerInterface).Name}");
            throw new InvalidOperationException($"Handler of type {typeof(THandlerInterface).Name} not supported");
        }
    }
}