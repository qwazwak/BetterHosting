
using DSharpPlus.EventArgs;
using System.Diagnostics;
using DSharpPlus.EventsNext.Entities;
using System;
using DSharpPlus.AsyncEvents;

namespace DSharpPlus.EventsNext.Tools.Internal;

internal partial class EventHandlerReflector
{
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