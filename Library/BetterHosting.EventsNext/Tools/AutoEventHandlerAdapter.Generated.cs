
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;
using DSharpPlus;


namespace BetterHosting.EventsNext.Tools;

internal partial class AutoEventHandlerAdapter<TInterface, TArgument>
{
    public static partial void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            client.SocketErrored += (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            client.SocketOpened += (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            client.SocketClosed += (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            client.SessionCreated += (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            client.SessionResumed += (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            client.Heartbeated += (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            client.Zombied += (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            client.ApplicationCommandPermissionsUpdated += (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            client.ChannelCreated += (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            client.ChannelUpdated += (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            client.ChannelDeleted += (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            client.DmChannelDeleted += (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            client.ChannelPinsUpdated += (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            client.GuildCreated += (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            client.GuildAvailable += (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            client.GuildUpdated += (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            client.GuildDeleted += (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            client.GuildUnavailable += (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            client.GuildDownloadCompleted += (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            client.GuildEmojisUpdated += (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            client.GuildStickersUpdated += (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            client.GuildIntegrationsUpdated += (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            client.GuildAuditLogCreated += (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            client.ScheduledGuildEventCreated += (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            client.ScheduledGuildEventUpdated += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            client.ScheduledGuildEventDeleted += (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            client.ScheduledGuildEventCompleted += (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            client.ScheduledGuildEventUserAdded += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            client.ScheduledGuildEventUserRemoved += (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            client.GuildBanAdded += (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            client.GuildBanRemoved += (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            client.GuildMemberAdded += (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            client.GuildMemberRemoved += (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            client.GuildMemberUpdated += (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            client.GuildMembersChunked += (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            client.GuildRoleCreated += (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            client.GuildRoleUpdated += (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            client.GuildRoleDeleted += (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            client.InviteCreated += (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            client.InviteDeleted += (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            client.MessageCreated += (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            client.MessageAcknowledged += (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            client.MessageUpdated += (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            client.MessageDeleted += (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            client.MessagesBulkDeleted += (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            client.MessageReactionAdded += (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            client.MessageReactionRemoved += (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            client.MessageReactionsCleared += (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            client.MessageReactionRemovedEmoji += (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            client.PresenceUpdated += (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            client.UserSettingsUpdated += (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            client.UserUpdated += (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            client.VoiceStateUpdated += (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            client.VoiceServerUpdated += (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            client.ThreadCreated += (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            client.ThreadUpdated += (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            client.ThreadDeleted += (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            client.ThreadListSynced += (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            client.ThreadMemberUpdated += (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            client.ThreadMembersUpdated += (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            client.IntegrationCreated += (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            client.IntegrationUpdated += (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            client.IntegrationDeleted += (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            client.StageInstanceCreated += (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            client.StageInstanceUpdated += (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            client.StageInstanceDeleted += (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            client.InteractionCreated += (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            client.ComponentInteractionCreated += (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            client.ModalSubmitted += (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            client.ContextMenuInteractionCreated += (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            client.TypingStarted += (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            client.UnknownEvent += (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            client.WebhooksUpdated += (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            client.ClientErrored += (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            client.AutoModerationRuleCreated += (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            client.AutoModerationRuleUpdated += (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            client.AutoModerationRuleDeleted += (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            client.AutoModerationRuleExecuted += (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler;
        else
            ThrowInvalid_AlreadyVerified();
    }

    public static partial void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            client.SocketErrored -= (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            client.SocketOpened -= (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            client.SocketClosed -= (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            client.SessionCreated -= (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            client.SessionResumed -= (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            client.Heartbeated -= (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            client.Zombied -= (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            client.ApplicationCommandPermissionsUpdated -= (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            client.ChannelCreated -= (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            client.ChannelUpdated -= (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            client.ChannelDeleted -= (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            client.DmChannelDeleted -= (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            client.ChannelPinsUpdated -= (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            client.GuildCreated -= (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            client.GuildAvailable -= (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            client.GuildUpdated -= (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            client.GuildDeleted -= (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            client.GuildUnavailable -= (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            client.GuildDownloadCompleted -= (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            client.GuildEmojisUpdated -= (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            client.GuildStickersUpdated -= (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            client.GuildIntegrationsUpdated -= (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            client.GuildAuditLogCreated -= (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            client.ScheduledGuildEventCreated -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            client.ScheduledGuildEventUpdated -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            client.ScheduledGuildEventDeleted -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            client.ScheduledGuildEventCompleted -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            client.ScheduledGuildEventUserAdded -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            client.ScheduledGuildEventUserRemoved -= (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            client.GuildBanAdded -= (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            client.GuildBanRemoved -= (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            client.GuildMemberAdded -= (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            client.GuildMemberRemoved -= (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            client.GuildMemberUpdated -= (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            client.GuildMembersChunked -= (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            client.GuildRoleCreated -= (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            client.GuildRoleUpdated -= (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            client.GuildRoleDeleted -= (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            client.InviteCreated -= (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            client.InviteDeleted -= (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            client.MessageCreated -= (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            client.MessageAcknowledged -= (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            client.MessageUpdated -= (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            client.MessageDeleted -= (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            client.MessagesBulkDeleted -= (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            client.MessageReactionAdded -= (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            client.MessageReactionRemoved -= (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            client.MessageReactionsCleared -= (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            client.MessageReactionRemovedEmoji -= (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            client.PresenceUpdated -= (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            client.UserSettingsUpdated -= (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            client.UserUpdated -= (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            client.VoiceStateUpdated -= (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            client.VoiceServerUpdated -= (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            client.ThreadCreated -= (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            client.ThreadUpdated -= (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            client.ThreadDeleted -= (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            client.ThreadListSynced -= (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            client.ThreadMemberUpdated -= (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            client.ThreadMembersUpdated -= (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            client.IntegrationCreated -= (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            client.IntegrationUpdated -= (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            client.IntegrationDeleted -= (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            client.StageInstanceCreated -= (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            client.StageInstanceUpdated -= (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            client.StageInstanceDeleted -= (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            client.InteractionCreated -= (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            client.ComponentInteractionCreated -= (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            client.ModalSubmitted -= (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            client.ContextMenuInteractionCreated -= (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            client.TypingStarted -= (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            client.UnknownEvent -= (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            client.WebhooksUpdated -= (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            client.ClientErrored -= (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            client.AutoModerationRuleCreated -= (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            client.AutoModerationRuleUpdated -= (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            client.AutoModerationRuleDeleted -= (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler;
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            client.AutoModerationRuleExecuted -= (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler;
        else
            ThrowInvalid_AlreadyVerified();
    }


    public static partial ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument eventArg)
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            return ((ISocketErroredEventHandler)handler).OnSocketErrored(sender, (SocketErrorEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            return ((ISocketOpenedEventHandler)handler).OnSocketOpened(sender, (SocketEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            return ((ISocketClosedEventHandler)handler).OnSocketClosed(sender, (SocketCloseEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            return ((ISessionCreatedEventHandler)handler).OnSessionCreated(sender, (SessionReadyEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            return ((ISessionResumedEventHandler)handler).OnSessionResumed(sender, (SessionReadyEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            return ((IHeartbeatedEventHandler)handler).OnHeartbeated(sender, (HeartbeatEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            return ((IZombiedEventHandler)handler).OnZombied(sender, (ZombiedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            return ((IApplicationCommandPermissionsUpdatedEventHandler)handler).OnApplicationCommandPermissionsUpdated(sender, (ApplicationCommandPermissionsUpdatedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            return ((IChannelCreatedEventHandler)handler).OnChannelCreated(sender, (ChannelCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            return ((IChannelUpdatedEventHandler)handler).OnChannelUpdated(sender, (ChannelUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            return ((IChannelDeletedEventHandler)handler).OnChannelDeleted(sender, (ChannelDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            return ((IDmChannelDeletedEventHandler)handler).OnDmChannelDeleted(sender, (DmChannelDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            return ((IChannelPinsUpdatedEventHandler)handler).OnChannelPinsUpdated(sender, (ChannelPinsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            return ((IGuildCreatedEventHandler)handler).OnGuildCreated(sender, (GuildCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            return ((IGuildAvailableEventHandler)handler).OnGuildAvailable(sender, (GuildCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            return ((IGuildUpdatedEventHandler)handler).OnGuildUpdated(sender, (GuildUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            return ((IGuildDeletedEventHandler)handler).OnGuildDeleted(sender, (GuildDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            return ((IGuildUnavailableEventHandler)handler).OnGuildUnavailable(sender, (GuildDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            return ((IGuildDownloadCompletedEventHandler)handler).OnGuildDownloadCompleted(sender, (GuildDownloadCompletedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            return ((IGuildEmojisUpdatedEventHandler)handler).OnGuildEmojisUpdated(sender, (GuildEmojisUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            return ((IGuildStickersUpdatedEventHandler)handler).OnGuildStickersUpdated(sender, (GuildStickersUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            return ((IGuildIntegrationsUpdatedEventHandler)handler).OnGuildIntegrationsUpdated(sender, (GuildIntegrationsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            return ((IGuildAuditLogCreatedEventHandler)handler).OnGuildAuditLogCreated(sender, (GuildAuditLogCreatedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            return ((IScheduledGuildEventCreatedEventHandler)handler).OnScheduledGuildEventCreated(sender, (ScheduledGuildEventCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            return ((IScheduledGuildEventUpdatedEventHandler)handler).OnScheduledGuildEventUpdated(sender, (ScheduledGuildEventUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            return ((IScheduledGuildEventDeletedEventHandler)handler).OnScheduledGuildEventDeleted(sender, (ScheduledGuildEventDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            return ((IScheduledGuildEventCompletedEventHandler)handler).OnScheduledGuildEventCompleted(sender, (ScheduledGuildEventCompletedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            return ((IScheduledGuildEventUserAddedEventHandler)handler).OnScheduledGuildEventUserAdded(sender, (ScheduledGuildEventUserAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            return ((IScheduledGuildEventUserRemovedEventHandler)handler).OnScheduledGuildEventUserRemoved(sender, (ScheduledGuildEventUserRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            return ((IGuildBanAddedEventHandler)handler).OnGuildBanAdded(sender, (GuildBanAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            return ((IGuildBanRemovedEventHandler)handler).OnGuildBanRemoved(sender, (GuildBanRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            return ((IGuildMemberAddedEventHandler)handler).OnGuildMemberAdded(sender, (GuildMemberAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            return ((IGuildMemberRemovedEventHandler)handler).OnGuildMemberRemoved(sender, (GuildMemberRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            return ((IGuildMemberUpdatedEventHandler)handler).OnGuildMemberUpdated(sender, (GuildMemberUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            return ((IGuildMembersChunkedEventHandler)handler).OnGuildMembersChunked(sender, (GuildMembersChunkEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            return ((IGuildRoleCreatedEventHandler)handler).OnGuildRoleCreated(sender, (GuildRoleCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            return ((IGuildRoleUpdatedEventHandler)handler).OnGuildRoleUpdated(sender, (GuildRoleUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            return ((IGuildRoleDeletedEventHandler)handler).OnGuildRoleDeleted(sender, (GuildRoleDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            return ((IInviteCreatedEventHandler)handler).OnInviteCreated(sender, (InviteCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            return ((IInviteDeletedEventHandler)handler).OnInviteDeleted(sender, (InviteDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            return ((IMessageCreatedEventHandler)handler).OnMessageCreated(sender, (MessageCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            return ((IMessageAcknowledgedEventHandler)handler).OnMessageAcknowledged(sender, (MessageAcknowledgeEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            return ((IMessageUpdatedEventHandler)handler).OnMessageUpdated(sender, (MessageUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            return ((IMessageDeletedEventHandler)handler).OnMessageDeleted(sender, (MessageDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            return ((IMessagesBulkDeletedEventHandler)handler).OnMessagesBulkDeleted(sender, (MessageBulkDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            return ((IMessageReactionAddedEventHandler)handler).OnMessageReactionAdded(sender, (MessageReactionAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            return ((IMessageReactionRemovedEventHandler)handler).OnMessageReactionRemoved(sender, (MessageReactionRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            return ((IMessageReactionsClearedEventHandler)handler).OnMessageReactionsCleared(sender, (MessageReactionsClearEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            return ((IMessageReactionRemovedEmojiEventHandler)handler).OnMessageReactionRemovedEmoji(sender, (MessageReactionRemoveEmojiEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            return ((IPresenceUpdatedEventHandler)handler).OnPresenceUpdated(sender, (PresenceUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            return ((IUserSettingsUpdatedEventHandler)handler).OnUserSettingsUpdated(sender, (UserSettingsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            return ((IUserUpdatedEventHandler)handler).OnUserUpdated(sender, (UserUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            return ((IVoiceStateUpdatedEventHandler)handler).OnVoiceStateUpdated(sender, (VoiceStateUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            return ((IVoiceServerUpdatedEventHandler)handler).OnVoiceServerUpdated(sender, (VoiceServerUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            return ((IThreadCreatedEventHandler)handler).OnThreadCreated(sender, (ThreadCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            return ((IThreadUpdatedEventHandler)handler).OnThreadUpdated(sender, (ThreadUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            return ((IThreadDeletedEventHandler)handler).OnThreadDeleted(sender, (ThreadDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            return ((IThreadListSyncedEventHandler)handler).OnThreadListSynced(sender, (ThreadListSyncEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            return ((IThreadMemberUpdatedEventHandler)handler).OnThreadMemberUpdated(sender, (ThreadMemberUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            return ((IThreadMembersUpdatedEventHandler)handler).OnThreadMembersUpdated(sender, (ThreadMembersUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            return ((IIntegrationCreatedEventHandler)handler).OnIntegrationCreated(sender, (IntegrationCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            return ((IIntegrationUpdatedEventHandler)handler).OnIntegrationUpdated(sender, (IntegrationUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            return ((IIntegrationDeletedEventHandler)handler).OnIntegrationDeleted(sender, (IntegrationDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            return ((IStageInstanceCreatedEventHandler)handler).OnStageInstanceCreated(sender, (StageInstanceCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            return ((IStageInstanceUpdatedEventHandler)handler).OnStageInstanceUpdated(sender, (StageInstanceUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            return ((IStageInstanceDeletedEventHandler)handler).OnStageInstanceDeleted(sender, (StageInstanceDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            return ((IInteractionCreatedEventHandler)handler).OnInteractionCreated(sender, (InteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            return ((IComponentInteractionCreatedEventHandler)handler).OnComponentInteractionCreated(sender, (ComponentInteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            return ((IModalSubmittedEventHandler)handler).OnModalSubmitted(sender, (ModalSubmitEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            return ((IContextMenuInteractionCreatedEventHandler)handler).OnContextMenuInteractionCreated(sender, (ContextMenuInteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            return ((ITypingStartedEventHandler)handler).OnTypingStarted(sender, (TypingStartEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            return ((IUnknownEventEventHandler)handler).OnUnknownEvent(sender, (UnknownEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            return ((IWebhooksUpdatedEventHandler)handler).OnWebhooksUpdated(sender, (WebhooksUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            return ((IClientErroredEventHandler)handler).OnClientErrored(sender, (ClientErrorEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            return ((IAutoModerationRuleCreatedEventHandler)handler).OnAutoModerationRuleCreated(sender, (AutoModerationRuleCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            return ((IAutoModerationRuleUpdatedEventHandler)handler).OnAutoModerationRuleUpdated(sender, (AutoModerationRuleUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            return ((IAutoModerationRuleDeletedEventHandler)handler).OnAutoModerationRuleDeleted(sender, (AutoModerationRuleDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            return ((IAutoModerationRuleExecutedEventHandler)handler).OnAutoModerationRuleExecuted(sender, (AutoModerationRuleExecuteEventArgs)(DiscordEventArgs)eventArg);
        ThrowInvalid_AlreadyVerified();
        return default!;
    }
}
