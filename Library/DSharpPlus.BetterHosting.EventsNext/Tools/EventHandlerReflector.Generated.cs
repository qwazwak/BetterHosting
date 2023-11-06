
#if false
using DSharpPlus.EventArgs;
using System.Diagnostics;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using DSharpPlus.AsyncEvents;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventHandlerReflector
{
    public static partial ValueTask AutoCallEventHandler<TInterface>(IDiscordEventHandler handler, DiscordClient sender, DiscordEventArgs args) where TInterface : IDiscordEventHandler
    {
        if(typeof(TInterface) == typeof(ISocketErroredEventHandler))
        {
            ISocketErroredEventHandler castHandler = (ISocketErroredEventHandler)handler;
            SocketErrorEventArgs castArgs = (SocketErrorEventArgs)args;
            return castHandler.OnSocketErrored(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(ISocketOpenedEventHandler))
        {
            ISocketOpenedEventHandler castHandler = (ISocketOpenedEventHandler)handler;
            SocketEventArgs castArgs = (SocketEventArgs)args;
            return castHandler.OnSocketOpened(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(ISocketClosedEventHandler))
        {
            ISocketClosedEventHandler castHandler = (ISocketClosedEventHandler)handler;
            SocketCloseEventArgs castArgs = (SocketCloseEventArgs)args;
            return castHandler.OnSocketClosed(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(ISessionCreatedEventHandler))
        {
            ISessionCreatedEventHandler castHandler = (ISessionCreatedEventHandler)handler;
            SessionReadyEventArgs castArgs = (SessionReadyEventArgs)args;
            return castHandler.OnSessionCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(ISessionResumedEventHandler))
        {
            ISessionResumedEventHandler castHandler = (ISessionResumedEventHandler)handler;
            SessionReadyEventArgs castArgs = (SessionReadyEventArgs)args;
            return castHandler.OnSessionResumed(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IHeartbeatedEventHandler))
        {
            IHeartbeatedEventHandler castHandler = (IHeartbeatedEventHandler)handler;
            HeartbeatEventArgs castArgs = (HeartbeatEventArgs)args;
            return castHandler.OnHeartbeated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IZombiedEventHandler))
        {
            IZombiedEventHandler castHandler = (IZombiedEventHandler)handler;
            ZombiedEventArgs castArgs = (ZombiedEventArgs)args;
            return castHandler.OnZombied(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
        {
            IApplicationCommandPermissionsUpdatedEventHandler castHandler = (IApplicationCommandPermissionsUpdatedEventHandler)handler;
            ApplicationCommandPermissionsUpdatedEventArgs castArgs = (ApplicationCommandPermissionsUpdatedEventArgs)args;
            return castHandler.OnApplicationCommandPermissionsUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IChannelCreatedEventHandler))
        {
            IChannelCreatedEventHandler castHandler = (IChannelCreatedEventHandler)handler;
            ChannelCreateEventArgs castArgs = (ChannelCreateEventArgs)args;
            return castHandler.OnChannelCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
        {
            IChannelUpdatedEventHandler castHandler = (IChannelUpdatedEventHandler)handler;
            ChannelUpdateEventArgs castArgs = (ChannelUpdateEventArgs)args;
            return castHandler.OnChannelUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IChannelDeletedEventHandler))
        {
            IChannelDeletedEventHandler castHandler = (IChannelDeletedEventHandler)handler;
            ChannelDeleteEventArgs castArgs = (ChannelDeleteEventArgs)args;
            return castHandler.OnChannelDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
        {
            IDmChannelDeletedEventHandler castHandler = (IDmChannelDeletedEventHandler)handler;
            DmChannelDeleteEventArgs castArgs = (DmChannelDeleteEventArgs)args;
            return castHandler.OnDmChannelDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
        {
            IChannelPinsUpdatedEventHandler castHandler = (IChannelPinsUpdatedEventHandler)handler;
            ChannelPinsUpdateEventArgs castArgs = (ChannelPinsUpdateEventArgs)args;
            return castHandler.OnChannelPinsUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildCreatedEventHandler))
        {
            IGuildCreatedEventHandler castHandler = (IGuildCreatedEventHandler)handler;
            GuildCreateEventArgs castArgs = (GuildCreateEventArgs)args;
            return castHandler.OnGuildCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildAvailableEventHandler))
        {
            IGuildAvailableEventHandler castHandler = (IGuildAvailableEventHandler)handler;
            GuildCreateEventArgs castArgs = (GuildCreateEventArgs)args;
            return castHandler.OnGuildAvailable(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
        {
            IGuildUpdatedEventHandler castHandler = (IGuildUpdatedEventHandler)handler;
            GuildUpdateEventArgs castArgs = (GuildUpdateEventArgs)args;
            return castHandler.OnGuildUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildDeletedEventHandler))
        {
            IGuildDeletedEventHandler castHandler = (IGuildDeletedEventHandler)handler;
            GuildDeleteEventArgs castArgs = (GuildDeleteEventArgs)args;
            return castHandler.OnGuildDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
        {
            IGuildUnavailableEventHandler castHandler = (IGuildUnavailableEventHandler)handler;
            GuildDeleteEventArgs castArgs = (GuildDeleteEventArgs)args;
            return castHandler.OnGuildUnavailable(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
        {
            IGuildDownloadCompletedEventHandler castHandler = (IGuildDownloadCompletedEventHandler)handler;
            GuildDownloadCompletedEventArgs castArgs = (GuildDownloadCompletedEventArgs)args;
            return castHandler.OnGuildDownloadCompleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
        {
            IGuildEmojisUpdatedEventHandler castHandler = (IGuildEmojisUpdatedEventHandler)handler;
            GuildEmojisUpdateEventArgs castArgs = (GuildEmojisUpdateEventArgs)args;
            return castHandler.OnGuildEmojisUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
        {
            IGuildStickersUpdatedEventHandler castHandler = (IGuildStickersUpdatedEventHandler)handler;
            GuildStickersUpdateEventArgs castArgs = (GuildStickersUpdateEventArgs)args;
            return castHandler.OnGuildStickersUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
        {
            IGuildIntegrationsUpdatedEventHandler castHandler = (IGuildIntegrationsUpdatedEventHandler)handler;
            GuildIntegrationsUpdateEventArgs castArgs = (GuildIntegrationsUpdateEventArgs)args;
            return castHandler.OnGuildIntegrationsUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
        {
            IGuildAuditLogCreatedEventHandler castHandler = (IGuildAuditLogCreatedEventHandler)handler;
            GuildAuditLogCreatedEventArgs castArgs = (GuildAuditLogCreatedEventArgs)args;
            return castHandler.OnGuildAuditLogCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
        {
            IScheduledGuildEventCreatedEventHandler castHandler = (IScheduledGuildEventCreatedEventHandler)handler;
            ScheduledGuildEventCreateEventArgs castArgs = (ScheduledGuildEventCreateEventArgs)args;
            return castHandler.OnScheduledGuildEventCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
        {
            IScheduledGuildEventUpdatedEventHandler castHandler = (IScheduledGuildEventUpdatedEventHandler)handler;
            ScheduledGuildEventUpdateEventArgs castArgs = (ScheduledGuildEventUpdateEventArgs)args;
            return castHandler.OnScheduledGuildEventUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
        {
            IScheduledGuildEventDeletedEventHandler castHandler = (IScheduledGuildEventDeletedEventHandler)handler;
            ScheduledGuildEventDeleteEventArgs castArgs = (ScheduledGuildEventDeleteEventArgs)args;
            return castHandler.OnScheduledGuildEventDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
        {
            IScheduledGuildEventCompletedEventHandler castHandler = (IScheduledGuildEventCompletedEventHandler)handler;
            ScheduledGuildEventCompletedEventArgs castArgs = (ScheduledGuildEventCompletedEventArgs)args;
            return castHandler.OnScheduledGuildEventCompleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
        {
            IScheduledGuildEventUserAddedEventHandler castHandler = (IScheduledGuildEventUserAddedEventHandler)handler;
            ScheduledGuildEventUserAddEventArgs castArgs = (ScheduledGuildEventUserAddEventArgs)args;
            return castHandler.OnScheduledGuildEventUserAdded(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
        {
            IScheduledGuildEventUserRemovedEventHandler castHandler = (IScheduledGuildEventUserRemovedEventHandler)handler;
            ScheduledGuildEventUserRemoveEventArgs castArgs = (ScheduledGuildEventUserRemoveEventArgs)args;
            return castHandler.OnScheduledGuildEventUserRemoved(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
        {
            IGuildBanAddedEventHandler castHandler = (IGuildBanAddedEventHandler)handler;
            GuildBanAddEventArgs castArgs = (GuildBanAddEventArgs)args;
            return castHandler.OnGuildBanAdded(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
        {
            IGuildBanRemovedEventHandler castHandler = (IGuildBanRemovedEventHandler)handler;
            GuildBanRemoveEventArgs castArgs = (GuildBanRemoveEventArgs)args;
            return castHandler.OnGuildBanRemoved(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
        {
            IGuildMemberAddedEventHandler castHandler = (IGuildMemberAddedEventHandler)handler;
            GuildMemberAddEventArgs castArgs = (GuildMemberAddEventArgs)args;
            return castHandler.OnGuildMemberAdded(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
        {
            IGuildMemberRemovedEventHandler castHandler = (IGuildMemberRemovedEventHandler)handler;
            GuildMemberRemoveEventArgs castArgs = (GuildMemberRemoveEventArgs)args;
            return castHandler.OnGuildMemberRemoved(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
        {
            IGuildMemberUpdatedEventHandler castHandler = (IGuildMemberUpdatedEventHandler)handler;
            GuildMemberUpdateEventArgs castArgs = (GuildMemberUpdateEventArgs)args;
            return castHandler.OnGuildMemberUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
        {
            IGuildMembersChunkedEventHandler castHandler = (IGuildMembersChunkedEventHandler)handler;
            GuildMembersChunkEventArgs castArgs = (GuildMembersChunkEventArgs)args;
            return castHandler.OnGuildMembersChunked(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
        {
            IGuildRoleCreatedEventHandler castHandler = (IGuildRoleCreatedEventHandler)handler;
            GuildRoleCreateEventArgs castArgs = (GuildRoleCreateEventArgs)args;
            return castHandler.OnGuildRoleCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
        {
            IGuildRoleUpdatedEventHandler castHandler = (IGuildRoleUpdatedEventHandler)handler;
            GuildRoleUpdateEventArgs castArgs = (GuildRoleUpdateEventArgs)args;
            return castHandler.OnGuildRoleUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
        {
            IGuildRoleDeletedEventHandler castHandler = (IGuildRoleDeletedEventHandler)handler;
            GuildRoleDeleteEventArgs castArgs = (GuildRoleDeleteEventArgs)args;
            return castHandler.OnGuildRoleDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IInviteCreatedEventHandler))
        {
            IInviteCreatedEventHandler castHandler = (IInviteCreatedEventHandler)handler;
            InviteCreateEventArgs castArgs = (InviteCreateEventArgs)args;
            return castHandler.OnInviteCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IInviteDeletedEventHandler))
        {
            IInviteDeletedEventHandler castHandler = (IInviteDeletedEventHandler)handler;
            InviteDeleteEventArgs castArgs = (InviteDeleteEventArgs)args;
            return castHandler.OnInviteDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageCreatedEventHandler))
        {
            IMessageCreatedEventHandler castHandler = (IMessageCreatedEventHandler)handler;
            MessageCreateEventArgs castArgs = (MessageCreateEventArgs)args;
            return castHandler.OnMessageCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
        {
            IMessageAcknowledgedEventHandler castHandler = (IMessageAcknowledgedEventHandler)handler;
            MessageAcknowledgeEventArgs castArgs = (MessageAcknowledgeEventArgs)args;
            return castHandler.OnMessageAcknowledged(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
        {
            IMessageUpdatedEventHandler castHandler = (IMessageUpdatedEventHandler)handler;
            MessageUpdateEventArgs castArgs = (MessageUpdateEventArgs)args;
            return castHandler.OnMessageUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageDeletedEventHandler))
        {
            IMessageDeletedEventHandler castHandler = (IMessageDeletedEventHandler)handler;
            MessageDeleteEventArgs castArgs = (MessageDeleteEventArgs)args;
            return castHandler.OnMessageDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
        {
            IMessagesBulkDeletedEventHandler castHandler = (IMessagesBulkDeletedEventHandler)handler;
            MessageBulkDeleteEventArgs castArgs = (MessageBulkDeleteEventArgs)args;
            return castHandler.OnMessagesBulkDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
        {
            IMessageReactionAddedEventHandler castHandler = (IMessageReactionAddedEventHandler)handler;
            MessageReactionAddEventArgs castArgs = (MessageReactionAddEventArgs)args;
            return castHandler.OnMessageReactionAdded(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
        {
            IMessageReactionRemovedEventHandler castHandler = (IMessageReactionRemovedEventHandler)handler;
            MessageReactionRemoveEventArgs castArgs = (MessageReactionRemoveEventArgs)args;
            return castHandler.OnMessageReactionRemoved(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
        {
            IMessageReactionsClearedEventHandler castHandler = (IMessageReactionsClearedEventHandler)handler;
            MessageReactionsClearEventArgs castArgs = (MessageReactionsClearEventArgs)args;
            return castHandler.OnMessageReactionsCleared(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
        {
            IMessageReactionRemovedEmojiEventHandler castHandler = (IMessageReactionRemovedEmojiEventHandler)handler;
            MessageReactionRemoveEmojiEventArgs castArgs = (MessageReactionRemoveEmojiEventArgs)args;
            return castHandler.OnMessageReactionRemovedEmoji(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
        {
            IPresenceUpdatedEventHandler castHandler = (IPresenceUpdatedEventHandler)handler;
            PresenceUpdateEventArgs castArgs = (PresenceUpdateEventArgs)args;
            return castHandler.OnPresenceUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
        {
            IUserSettingsUpdatedEventHandler castHandler = (IUserSettingsUpdatedEventHandler)handler;
            UserSettingsUpdateEventArgs castArgs = (UserSettingsUpdateEventArgs)args;
            return castHandler.OnUserSettingsUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IUserUpdatedEventHandler))
        {
            IUserUpdatedEventHandler castHandler = (IUserUpdatedEventHandler)handler;
            UserUpdateEventArgs castArgs = (UserUpdateEventArgs)args;
            return castHandler.OnUserUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
        {
            IVoiceStateUpdatedEventHandler castHandler = (IVoiceStateUpdatedEventHandler)handler;
            VoiceStateUpdateEventArgs castArgs = (VoiceStateUpdateEventArgs)args;
            return castHandler.OnVoiceStateUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
        {
            IVoiceServerUpdatedEventHandler castHandler = (IVoiceServerUpdatedEventHandler)handler;
            VoiceServerUpdateEventArgs castArgs = (VoiceServerUpdateEventArgs)args;
            return castHandler.OnVoiceServerUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadCreatedEventHandler))
        {
            IThreadCreatedEventHandler castHandler = (IThreadCreatedEventHandler)handler;
            ThreadCreateEventArgs castArgs = (ThreadCreateEventArgs)args;
            return castHandler.OnThreadCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
        {
            IThreadUpdatedEventHandler castHandler = (IThreadUpdatedEventHandler)handler;
            ThreadUpdateEventArgs castArgs = (ThreadUpdateEventArgs)args;
            return castHandler.OnThreadUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadDeletedEventHandler))
        {
            IThreadDeletedEventHandler castHandler = (IThreadDeletedEventHandler)handler;
            ThreadDeleteEventArgs castArgs = (ThreadDeleteEventArgs)args;
            return castHandler.OnThreadDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
        {
            IThreadListSyncedEventHandler castHandler = (IThreadListSyncedEventHandler)handler;
            ThreadListSyncEventArgs castArgs = (ThreadListSyncEventArgs)args;
            return castHandler.OnThreadListSynced(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
        {
            IThreadMemberUpdatedEventHandler castHandler = (IThreadMemberUpdatedEventHandler)handler;
            ThreadMemberUpdateEventArgs castArgs = (ThreadMemberUpdateEventArgs)args;
            return castHandler.OnThreadMemberUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
        {
            IThreadMembersUpdatedEventHandler castHandler = (IThreadMembersUpdatedEventHandler)handler;
            ThreadMembersUpdateEventArgs castArgs = (ThreadMembersUpdateEventArgs)args;
            return castHandler.OnThreadMembersUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
        {
            IIntegrationCreatedEventHandler castHandler = (IIntegrationCreatedEventHandler)handler;
            IntegrationCreateEventArgs castArgs = (IntegrationCreateEventArgs)args;
            return castHandler.OnIntegrationCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
        {
            IIntegrationUpdatedEventHandler castHandler = (IIntegrationUpdatedEventHandler)handler;
            IntegrationUpdateEventArgs castArgs = (IntegrationUpdateEventArgs)args;
            return castHandler.OnIntegrationUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
        {
            IIntegrationDeletedEventHandler castHandler = (IIntegrationDeletedEventHandler)handler;
            IntegrationDeleteEventArgs castArgs = (IntegrationDeleteEventArgs)args;
            return castHandler.OnIntegrationDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
        {
            IStageInstanceCreatedEventHandler castHandler = (IStageInstanceCreatedEventHandler)handler;
            StageInstanceCreateEventArgs castArgs = (StageInstanceCreateEventArgs)args;
            return castHandler.OnStageInstanceCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
        {
            IStageInstanceUpdatedEventHandler castHandler = (IStageInstanceUpdatedEventHandler)handler;
            StageInstanceUpdateEventArgs castArgs = (StageInstanceUpdateEventArgs)args;
            return castHandler.OnStageInstanceUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
        {
            IStageInstanceDeletedEventHandler castHandler = (IStageInstanceDeletedEventHandler)handler;
            StageInstanceDeleteEventArgs castArgs = (StageInstanceDeleteEventArgs)args;
            return castHandler.OnStageInstanceDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
        {
            IInteractionCreatedEventHandler castHandler = (IInteractionCreatedEventHandler)handler;
            InteractionCreateEventArgs castArgs = (InteractionCreateEventArgs)args;
            return castHandler.OnInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
        {
            IComponentInteractionCreatedEventHandler castHandler = (IComponentInteractionCreatedEventHandler)handler;
            ComponentInteractionCreateEventArgs castArgs = (ComponentInteractionCreateEventArgs)args;
            return castHandler.OnComponentInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IModalSubmittedEventHandler))
        {
            IModalSubmittedEventHandler castHandler = (IModalSubmittedEventHandler)handler;
            ModalSubmitEventArgs castArgs = (ModalSubmitEventArgs)args;
            return castHandler.OnModalSubmitted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
        {
            IContextMenuInteractionCreatedEventHandler castHandler = (IContextMenuInteractionCreatedEventHandler)handler;
            ContextMenuInteractionCreateEventArgs castArgs = (ContextMenuInteractionCreateEventArgs)args;
            return castHandler.OnContextMenuInteractionCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(ITypingStartedEventHandler))
        {
            ITypingStartedEventHandler castHandler = (ITypingStartedEventHandler)handler;
            TypingStartEventArgs castArgs = (TypingStartEventArgs)args;
            return castHandler.OnTypingStarted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IUnknownEventEventHandler))
        {
            IUnknownEventEventHandler castHandler = (IUnknownEventEventHandler)handler;
            UnknownEventArgs castArgs = (UnknownEventArgs)args;
            return castHandler.OnUnknownEvent(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
        {
            IWebhooksUpdatedEventHandler castHandler = (IWebhooksUpdatedEventHandler)handler;
            WebhooksUpdateEventArgs castArgs = (WebhooksUpdateEventArgs)args;
            return castHandler.OnWebhooksUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IClientErroredEventHandler))
        {
            IClientErroredEventHandler castHandler = (IClientErroredEventHandler)handler;
            ClientErrorEventArgs castArgs = (ClientErrorEventArgs)args;
            return castHandler.OnClientErrored(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
        {
            IAutoModerationRuleCreatedEventHandler castHandler = (IAutoModerationRuleCreatedEventHandler)handler;
            AutoModerationRuleCreateEventArgs castArgs = (AutoModerationRuleCreateEventArgs)args;
            return castHandler.OnAutoModerationRuleCreated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
        {
            IAutoModerationRuleUpdatedEventHandler castHandler = (IAutoModerationRuleUpdatedEventHandler)handler;
            AutoModerationRuleUpdateEventArgs castArgs = (AutoModerationRuleUpdateEventArgs)args;
            return castHandler.OnAutoModerationRuleUpdated(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
        {
            IAutoModerationRuleDeletedEventHandler castHandler = (IAutoModerationRuleDeletedEventHandler)handler;
            AutoModerationRuleDeleteEventArgs castArgs = (AutoModerationRuleDeleteEventArgs)args;
            return castHandler.OnAutoModerationRuleDeleted(sender, castArgs);
        }
        else
        if(typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
        {
            IAutoModerationRuleExecutedEventHandler castHandler = (IAutoModerationRuleExecutedEventHandler)handler;
            AutoModerationRuleExecuteEventArgs castArgs = (AutoModerationRuleExecuteEventArgs)args;
            return castHandler.OnAutoModerationRuleExecuted(sender, castArgs);
        }
        else
        {
            Debug.Fail($"Not a supported type: {typeof(TInterface).Name}");
            return ValueTask.FromException(new InvalidOperationException($"Handler of type {typeof(TInterface).Name} not supported"));
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
#endif