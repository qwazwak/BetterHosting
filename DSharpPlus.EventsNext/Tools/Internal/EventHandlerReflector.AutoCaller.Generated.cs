
using DSharpPlus.EventArgs;
using System.Diagnostics;
using System.Threading.Tasks;
using DSharpPlus.EventsNext.Entities;
using System;

namespace DSharpPlus.EventsNext.Tools.Internal;

internal partial class EventHandlerReflector
{
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
}