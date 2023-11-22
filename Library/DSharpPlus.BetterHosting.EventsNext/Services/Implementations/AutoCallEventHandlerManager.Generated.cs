
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using DSharpPlus.EventArgs;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal partial class AutoCallEventHandlerManager<TInterface, TArgument>
{
    protected override partial void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) 
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            SocketErroredEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            SocketOpenedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            SocketClosedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            SessionCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            SessionResumedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            HeartbeatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            ZombiedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            ApplicationCommandPermissionsUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            ChannelCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            ChannelUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            ChannelDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            DmChannelDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            ChannelPinsUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            GuildCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            GuildAvailableEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            GuildUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            GuildDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            GuildUnavailableEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            GuildDownloadCompletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            GuildEmojisUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            GuildStickersUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            GuildIntegrationsUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            GuildAuditLogCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            ScheduledGuildEventCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            ScheduledGuildEventUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            ScheduledGuildEventDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            ScheduledGuildEventCompletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            ScheduledGuildEventUserAddedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            ScheduledGuildEventUserRemovedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            GuildBanAddedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            GuildBanRemovedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            GuildMemberAddedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            GuildMemberRemovedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            GuildMemberUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            GuildMembersChunkedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            GuildRoleCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            GuildRoleUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            GuildRoleDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            InviteCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            InviteDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            MessageCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            MessageAcknowledgedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            MessageUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            MessageDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            MessagesBulkDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            MessageReactionAddedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            MessageReactionRemovedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            MessageReactionsClearedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            MessageReactionRemovedEmojiEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            PresenceUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            UserSettingsUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            UserUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            VoiceStateUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            VoiceServerUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            ThreadCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            ThreadUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            ThreadDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            ThreadListSyncedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            ThreadMemberUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            ThreadMembersUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            IntegrationCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            IntegrationUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            IntegrationDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            StageInstanceCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            StageInstanceUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            StageInstanceDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            InteractionCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            ComponentInteractionCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            ModalSubmittedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            ContextMenuInteractionCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            TypingStartedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            UnknownEventEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            WebhooksUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            ClientErroredEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            AutoModerationRuleCreatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            AutoModerationRuleUpdatedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            AutoModerationRuleDeletedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            AutoModerationRuleExecutedEventHandlerAdapter.BindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler);
        else
            ThrowInvalid_AlreadyVerified();
    }
    protected override partial void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            SocketErroredEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, SocketErrorEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            SocketOpenedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, SocketEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            SocketClosedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, SocketCloseEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            SessionCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            SessionResumedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, SessionReadyEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            HeartbeatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, HeartbeatEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            ZombiedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ZombiedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            ApplicationCommandPermissionsUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            ChannelCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ChannelCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            ChannelUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            ChannelDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            DmChannelDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            ChannelPinsUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            GuildCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            GuildAvailableEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            GuildUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            GuildDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            GuildUnavailableEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            GuildDownloadCompletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            GuildEmojisUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            GuildStickersUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            GuildIntegrationsUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            GuildAuditLogCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            ScheduledGuildEventCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            ScheduledGuildEventUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            ScheduledGuildEventDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            ScheduledGuildEventCompletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            ScheduledGuildEventUserAddedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            ScheduledGuildEventUserRemovedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            GuildBanAddedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildBanAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            GuildBanRemovedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            GuildMemberAddedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            GuildMemberRemovedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            GuildMemberUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            GuildMembersChunkedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            GuildRoleCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            GuildRoleUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            GuildRoleDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            InviteCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, InviteCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            InviteDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, InviteDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            MessageCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            MessageAcknowledgedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            MessageUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            MessageDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            MessagesBulkDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            MessageReactionAddedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            MessageReactionRemovedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            MessageReactionsClearedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            MessageReactionRemovedEmojiEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            PresenceUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            UserSettingsUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            UserUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, UserUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            VoiceStateUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            VoiceServerUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            ThreadCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            ThreadUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            ThreadDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            ThreadListSyncedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            ThreadMemberUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            ThreadMembersUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            IntegrationCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            IntegrationUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            IntegrationDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            StageInstanceCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            StageInstanceUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            StageInstanceDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            InteractionCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, InteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            ComponentInteractionCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            ModalSubmittedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ModalSubmitEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            ContextMenuInteractionCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            TypingStartedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, TypingStartEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            UnknownEventEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, UnknownEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            WebhooksUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            ClientErroredEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, ClientErrorEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            AutoModerationRuleCreatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            AutoModerationRuleUpdatedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            AutoModerationRuleDeletedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs>)handler);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            AutoModerationRuleExecutedEventHandlerAdapter.UnbindHandler(client, (AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs>)handler);
        else
            ThrowInvalid_AlreadyVerified();
    }
    protected override partial ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument eventArg)
    {
        if (typeof(TInterface) == typeof(ISocketErroredEventHandler))
            return SocketErroredEventHandlerAdapter.Invoke((ISocketErroredEventHandler)handler, sender, (SocketErrorEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            return SocketOpenedEventHandlerAdapter.Invoke((ISocketOpenedEventHandler)handler, sender, (SocketEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISocketClosedEventHandler))
            return SocketClosedEventHandlerAdapter.Invoke((ISocketClosedEventHandler)handler, sender, (SocketCloseEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            return SessionCreatedEventHandlerAdapter.Invoke((ISessionCreatedEventHandler)handler, sender, (SessionReadyEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ISessionResumedEventHandler))
            return SessionResumedEventHandlerAdapter.Invoke((ISessionResumedEventHandler)handler, sender, (SessionReadyEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            return HeartbeatedEventHandlerAdapter.Invoke((IHeartbeatedEventHandler)handler, sender, (HeartbeatEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IZombiedEventHandler))
            return ZombiedEventHandlerAdapter.Invoke((IZombiedEventHandler)handler, sender, (ZombiedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            return ApplicationCommandPermissionsUpdatedEventHandlerAdapter.Invoke((IApplicationCommandPermissionsUpdatedEventHandler)handler, sender, (ApplicationCommandPermissionsUpdatedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            return ChannelCreatedEventHandlerAdapter.Invoke((IChannelCreatedEventHandler)handler, sender, (ChannelCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            return ChannelUpdatedEventHandlerAdapter.Invoke((IChannelUpdatedEventHandler)handler, sender, (ChannelUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            return ChannelDeletedEventHandlerAdapter.Invoke((IChannelDeletedEventHandler)handler, sender, (ChannelDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            return DmChannelDeletedEventHandlerAdapter.Invoke((IDmChannelDeletedEventHandler)handler, sender, (DmChannelDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            return ChannelPinsUpdatedEventHandlerAdapter.Invoke((IChannelPinsUpdatedEventHandler)handler, sender, (ChannelPinsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            return GuildCreatedEventHandlerAdapter.Invoke((IGuildCreatedEventHandler)handler, sender, (GuildCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            return GuildAvailableEventHandlerAdapter.Invoke((IGuildAvailableEventHandler)handler, sender, (GuildCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            return GuildUpdatedEventHandlerAdapter.Invoke((IGuildUpdatedEventHandler)handler, sender, (GuildUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            return GuildDeletedEventHandlerAdapter.Invoke((IGuildDeletedEventHandler)handler, sender, (GuildDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            return GuildUnavailableEventHandlerAdapter.Invoke((IGuildUnavailableEventHandler)handler, sender, (GuildDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            return GuildDownloadCompletedEventHandlerAdapter.Invoke((IGuildDownloadCompletedEventHandler)handler, sender, (GuildDownloadCompletedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            return GuildEmojisUpdatedEventHandlerAdapter.Invoke((IGuildEmojisUpdatedEventHandler)handler, sender, (GuildEmojisUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            return GuildStickersUpdatedEventHandlerAdapter.Invoke((IGuildStickersUpdatedEventHandler)handler, sender, (GuildStickersUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            return GuildIntegrationsUpdatedEventHandlerAdapter.Invoke((IGuildIntegrationsUpdatedEventHandler)handler, sender, (GuildIntegrationsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            return GuildAuditLogCreatedEventHandlerAdapter.Invoke((IGuildAuditLogCreatedEventHandler)handler, sender, (GuildAuditLogCreatedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            return ScheduledGuildEventCreatedEventHandlerAdapter.Invoke((IScheduledGuildEventCreatedEventHandler)handler, sender, (ScheduledGuildEventCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            return ScheduledGuildEventUpdatedEventHandlerAdapter.Invoke((IScheduledGuildEventUpdatedEventHandler)handler, sender, (ScheduledGuildEventUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            return ScheduledGuildEventDeletedEventHandlerAdapter.Invoke((IScheduledGuildEventDeletedEventHandler)handler, sender, (ScheduledGuildEventDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            return ScheduledGuildEventCompletedEventHandlerAdapter.Invoke((IScheduledGuildEventCompletedEventHandler)handler, sender, (ScheduledGuildEventCompletedEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            return ScheduledGuildEventUserAddedEventHandlerAdapter.Invoke((IScheduledGuildEventUserAddedEventHandler)handler, sender, (ScheduledGuildEventUserAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            return ScheduledGuildEventUserRemovedEventHandlerAdapter.Invoke((IScheduledGuildEventUserRemovedEventHandler)handler, sender, (ScheduledGuildEventUserRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            return GuildBanAddedEventHandlerAdapter.Invoke((IGuildBanAddedEventHandler)handler, sender, (GuildBanAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            return GuildBanRemovedEventHandlerAdapter.Invoke((IGuildBanRemovedEventHandler)handler, sender, (GuildBanRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            return GuildMemberAddedEventHandlerAdapter.Invoke((IGuildMemberAddedEventHandler)handler, sender, (GuildMemberAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            return GuildMemberRemovedEventHandlerAdapter.Invoke((IGuildMemberRemovedEventHandler)handler, sender, (GuildMemberRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            return GuildMemberUpdatedEventHandlerAdapter.Invoke((IGuildMemberUpdatedEventHandler)handler, sender, (GuildMemberUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            return GuildMembersChunkedEventHandlerAdapter.Invoke((IGuildMembersChunkedEventHandler)handler, sender, (GuildMembersChunkEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            return GuildRoleCreatedEventHandlerAdapter.Invoke((IGuildRoleCreatedEventHandler)handler, sender, (GuildRoleCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            return GuildRoleUpdatedEventHandlerAdapter.Invoke((IGuildRoleUpdatedEventHandler)handler, sender, (GuildRoleUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            return GuildRoleDeletedEventHandlerAdapter.Invoke((IGuildRoleDeletedEventHandler)handler, sender, (GuildRoleDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            return InviteCreatedEventHandlerAdapter.Invoke((IInviteCreatedEventHandler)handler, sender, (InviteCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            return InviteDeletedEventHandlerAdapter.Invoke((IInviteDeletedEventHandler)handler, sender, (InviteDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            return MessageCreatedEventHandlerAdapter.Invoke((IMessageCreatedEventHandler)handler, sender, (MessageCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            return MessageAcknowledgedEventHandlerAdapter.Invoke((IMessageAcknowledgedEventHandler)handler, sender, (MessageAcknowledgeEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            return MessageUpdatedEventHandlerAdapter.Invoke((IMessageUpdatedEventHandler)handler, sender, (MessageUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            return MessageDeletedEventHandlerAdapter.Invoke((IMessageDeletedEventHandler)handler, sender, (MessageDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            return MessagesBulkDeletedEventHandlerAdapter.Invoke((IMessagesBulkDeletedEventHandler)handler, sender, (MessageBulkDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            return MessageReactionAddedEventHandlerAdapter.Invoke((IMessageReactionAddedEventHandler)handler, sender, (MessageReactionAddEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            return MessageReactionRemovedEventHandlerAdapter.Invoke((IMessageReactionRemovedEventHandler)handler, sender, (MessageReactionRemoveEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            return MessageReactionsClearedEventHandlerAdapter.Invoke((IMessageReactionsClearedEventHandler)handler, sender, (MessageReactionsClearEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            return MessageReactionRemovedEmojiEventHandlerAdapter.Invoke((IMessageReactionRemovedEmojiEventHandler)handler, sender, (MessageReactionRemoveEmojiEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            return PresenceUpdatedEventHandlerAdapter.Invoke((IPresenceUpdatedEventHandler)handler, sender, (PresenceUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            return UserSettingsUpdatedEventHandlerAdapter.Invoke((IUserSettingsUpdatedEventHandler)handler, sender, (UserSettingsUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            return UserUpdatedEventHandlerAdapter.Invoke((IUserUpdatedEventHandler)handler, sender, (UserUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            return VoiceStateUpdatedEventHandlerAdapter.Invoke((IVoiceStateUpdatedEventHandler)handler, sender, (VoiceStateUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            return VoiceServerUpdatedEventHandlerAdapter.Invoke((IVoiceServerUpdatedEventHandler)handler, sender, (VoiceServerUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            return ThreadCreatedEventHandlerAdapter.Invoke((IThreadCreatedEventHandler)handler, sender, (ThreadCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            return ThreadUpdatedEventHandlerAdapter.Invoke((IThreadUpdatedEventHandler)handler, sender, (ThreadUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            return ThreadDeletedEventHandlerAdapter.Invoke((IThreadDeletedEventHandler)handler, sender, (ThreadDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            return ThreadListSyncedEventHandlerAdapter.Invoke((IThreadListSyncedEventHandler)handler, sender, (ThreadListSyncEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            return ThreadMemberUpdatedEventHandlerAdapter.Invoke((IThreadMemberUpdatedEventHandler)handler, sender, (ThreadMemberUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            return ThreadMembersUpdatedEventHandlerAdapter.Invoke((IThreadMembersUpdatedEventHandler)handler, sender, (ThreadMembersUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            return IntegrationCreatedEventHandlerAdapter.Invoke((IIntegrationCreatedEventHandler)handler, sender, (IntegrationCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            return IntegrationUpdatedEventHandlerAdapter.Invoke((IIntegrationUpdatedEventHandler)handler, sender, (IntegrationUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            return IntegrationDeletedEventHandlerAdapter.Invoke((IIntegrationDeletedEventHandler)handler, sender, (IntegrationDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            return StageInstanceCreatedEventHandlerAdapter.Invoke((IStageInstanceCreatedEventHandler)handler, sender, (StageInstanceCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            return StageInstanceUpdatedEventHandlerAdapter.Invoke((IStageInstanceUpdatedEventHandler)handler, sender, (StageInstanceUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            return StageInstanceDeletedEventHandlerAdapter.Invoke((IStageInstanceDeletedEventHandler)handler, sender, (StageInstanceDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            return InteractionCreatedEventHandlerAdapter.Invoke((IInteractionCreatedEventHandler)handler, sender, (InteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            return ComponentInteractionCreatedEventHandlerAdapter.Invoke((IComponentInteractionCreatedEventHandler)handler, sender, (ComponentInteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            return ModalSubmittedEventHandlerAdapter.Invoke((IModalSubmittedEventHandler)handler, sender, (ModalSubmitEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            return ContextMenuInteractionCreatedEventHandlerAdapter.Invoke((IContextMenuInteractionCreatedEventHandler)handler, sender, (ContextMenuInteractionCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(ITypingStartedEventHandler))
            return TypingStartedEventHandlerAdapter.Invoke((ITypingStartedEventHandler)handler, sender, (TypingStartEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IUnknownEventEventHandler))
            return UnknownEventEventHandlerAdapter.Invoke((IUnknownEventEventHandler)handler, sender, (UnknownEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            return WebhooksUpdatedEventHandlerAdapter.Invoke((IWebhooksUpdatedEventHandler)handler, sender, (WebhooksUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IClientErroredEventHandler))
            return ClientErroredEventHandlerAdapter.Invoke((IClientErroredEventHandler)handler, sender, (ClientErrorEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            return AutoModerationRuleCreatedEventHandlerAdapter.Invoke((IAutoModerationRuleCreatedEventHandler)handler, sender, (AutoModerationRuleCreateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            return AutoModerationRuleUpdatedEventHandlerAdapter.Invoke((IAutoModerationRuleUpdatedEventHandler)handler, sender, (AutoModerationRuleUpdateEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            return AutoModerationRuleDeletedEventHandlerAdapter.Invoke((IAutoModerationRuleDeletedEventHandler)handler, sender, (AutoModerationRuleDeleteEventArgs)(DiscordEventArgs)eventArg);
        else if (typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            return AutoModerationRuleExecutedEventHandlerAdapter.Invoke((IAutoModerationRuleExecutedEventHandler)handler, sender, (AutoModerationRuleExecuteEventArgs)(DiscordEventArgs)eventArg);
        ThrowInvalid_AlreadyVerified();
        return default!;
    }
}

