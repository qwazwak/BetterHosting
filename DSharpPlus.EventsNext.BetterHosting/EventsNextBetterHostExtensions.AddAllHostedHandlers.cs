
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.BetterHosting.Services.Hosted;
using DSharpPlus.EventsNext.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsNext.BetterHosting;

public static partial class EventsNextBetterHostExtensions
{
    private static partial void AddAllHostedHandlers(IServiceCollection services)
    {
        services.AddHostedHandler<ISocketErroredEventHandler, SocketErrorEventArgs, MetaSocketErroredHandler>();
        services.AddHostedHandler<ISocketOpenedEventHandler, SocketEventArgs, MetaSocketOpenedHandler>();
        services.AddHostedHandler<ISocketClosedEventHandler, SocketCloseEventArgs, MetaSocketClosedHandler>();
        services.AddHostedHandler<ISessionCreatedEventHandler, SessionReadyEventArgs, MetaSessionCreatedHandler>();
        services.AddHostedHandler<ISessionResumedEventHandler, SessionReadyEventArgs, MetaSessionResumedHandler>();
        services.AddHostedHandler<IHeartbeatedEventHandler, HeartbeatEventArgs, MetaHeartbeatedHandler>();
        services.AddHostedHandler<IZombiedEventHandler, ZombiedEventArgs, MetaZombiedHandler>();
        services.AddHostedHandler<IApplicationCommandPermissionsUpdatedEventHandler, ApplicationCommandPermissionsUpdatedEventArgs, MetaApplicationCommandPermissionsUpdatedHandler>();
        services.AddHostedHandler<IChannelCreatedEventHandler, ChannelCreateEventArgs, MetaChannelCreatedHandler>();
        services.AddHostedHandler<IChannelUpdatedEventHandler, ChannelUpdateEventArgs, MetaChannelUpdatedHandler>();
        services.AddHostedHandler<IChannelDeletedEventHandler, ChannelDeleteEventArgs, MetaChannelDeletedHandler>();
        services.AddHostedHandler<IDmChannelDeletedEventHandler, DmChannelDeleteEventArgs, MetaDmChannelDeletedHandler>();
        services.AddHostedHandler<IChannelPinsUpdatedEventHandler, ChannelPinsUpdateEventArgs, MetaChannelPinsUpdatedHandler>();
        services.AddHostedHandler<IGuildCreatedEventHandler, GuildCreateEventArgs, MetaGuildCreatedHandler>();
        services.AddHostedHandler<IGuildAvailableEventHandler, GuildCreateEventArgs, MetaGuildAvailableHandler>();
        services.AddHostedHandler<IGuildUpdatedEventHandler, GuildUpdateEventArgs, MetaGuildUpdatedHandler>();
        services.AddHostedHandler<IGuildDeletedEventHandler, GuildDeleteEventArgs, MetaGuildDeletedHandler>();
        services.AddHostedHandler<IGuildUnavailableEventHandler, GuildDeleteEventArgs, MetaGuildUnavailableHandler>();
        services.AddHostedHandler<IGuildDownloadCompletedEventHandler, GuildDownloadCompletedEventArgs, MetaGuildDownloadCompletedHandler>();
        services.AddHostedHandler<IGuildEmojisUpdatedEventHandler, GuildEmojisUpdateEventArgs, MetaGuildEmojisUpdatedHandler>();
        services.AddHostedHandler<IGuildStickersUpdatedEventHandler, GuildStickersUpdateEventArgs, MetaGuildStickersUpdatedHandler>();
        services.AddHostedHandler<IGuildIntegrationsUpdatedEventHandler, GuildIntegrationsUpdateEventArgs, MetaGuildIntegrationsUpdatedHandler>();
        services.AddHostedHandler<IGuildAuditLogCreatedEventHandler, GuildAuditLogCreatedEventArgs, MetaGuildAuditLogCreatedHandler>();
        services.AddHostedHandler<IScheduledGuildEventCreatedEventHandler, ScheduledGuildEventCreateEventArgs, MetaScheduledGuildEventCreatedHandler>();
        services.AddHostedHandler<IScheduledGuildEventUpdatedEventHandler, ScheduledGuildEventUpdateEventArgs, MetaScheduledGuildEventUpdatedHandler>();
        services.AddHostedHandler<IScheduledGuildEventDeletedEventHandler, ScheduledGuildEventDeleteEventArgs, MetaScheduledGuildEventDeletedHandler>();
        services.AddHostedHandler<IScheduledGuildEventCompletedEventHandler, ScheduledGuildEventCompletedEventArgs, MetaScheduledGuildEventCompletedHandler>();
        services.AddHostedHandler<IScheduledGuildEventUserAddedEventHandler, ScheduledGuildEventUserAddEventArgs, MetaScheduledGuildEventUserAddedHandler>();
        services.AddHostedHandler<IScheduledGuildEventUserRemovedEventHandler, ScheduledGuildEventUserRemoveEventArgs, MetaScheduledGuildEventUserRemovedHandler>();
        services.AddHostedHandler<IGuildBanAddedEventHandler, GuildBanAddEventArgs, MetaGuildBanAddedHandler>();
        services.AddHostedHandler<IGuildBanRemovedEventHandler, GuildBanRemoveEventArgs, MetaGuildBanRemovedHandler>();
        services.AddHostedHandler<IGuildMemberAddedEventHandler, GuildMemberAddEventArgs, MetaGuildMemberAddedHandler>();
        services.AddHostedHandler<IGuildMemberRemovedEventHandler, GuildMemberRemoveEventArgs, MetaGuildMemberRemovedHandler>();
        services.AddHostedHandler<IGuildMemberUpdatedEventHandler, GuildMemberUpdateEventArgs, MetaGuildMemberUpdatedHandler>();
        services.AddHostedHandler<IGuildMembersChunkedEventHandler, GuildMembersChunkEventArgs, MetaGuildMembersChunkedHandler>();
        services.AddHostedHandler<IGuildRoleCreatedEventHandler, GuildRoleCreateEventArgs, MetaGuildRoleCreatedHandler>();
        services.AddHostedHandler<IGuildRoleUpdatedEventHandler, GuildRoleUpdateEventArgs, MetaGuildRoleUpdatedHandler>();
        services.AddHostedHandler<IGuildRoleDeletedEventHandler, GuildRoleDeleteEventArgs, MetaGuildRoleDeletedHandler>();
        services.AddHostedHandler<IInviteCreatedEventHandler, InviteCreateEventArgs, MetaInviteCreatedHandler>();
        services.AddHostedHandler<IInviteDeletedEventHandler, InviteDeleteEventArgs, MetaInviteDeletedHandler>();
        services.AddHostedHandler<IMessageCreatedEventHandler, MessageCreateEventArgs, MetaMessageCreatedHandler>();
        services.AddHostedHandler<IMessageAcknowledgedEventHandler, MessageAcknowledgeEventArgs, MetaMessageAcknowledgedHandler>();
        services.AddHostedHandler<IMessageUpdatedEventHandler, MessageUpdateEventArgs, MetaMessageUpdatedHandler>();
        services.AddHostedHandler<IMessageDeletedEventHandler, MessageDeleteEventArgs, MetaMessageDeletedHandler>();
        services.AddHostedHandler<IMessagesBulkDeletedEventHandler, MessageBulkDeleteEventArgs, MetaMessagesBulkDeletedHandler>();
        services.AddHostedHandler<IMessageReactionAddedEventHandler, MessageReactionAddEventArgs, MetaMessageReactionAddedHandler>();
        services.AddHostedHandler<IMessageReactionRemovedEventHandler, MessageReactionRemoveEventArgs, MetaMessageReactionRemovedHandler>();
        services.AddHostedHandler<IMessageReactionsClearedEventHandler, MessageReactionsClearEventArgs, MetaMessageReactionsClearedHandler>();
        services.AddHostedHandler<IMessageReactionRemovedEmojiEventHandler, MessageReactionRemoveEmojiEventArgs, MetaMessageReactionRemovedEmojiHandler>();
        services.AddHostedHandler<IPresenceUpdatedEventHandler, PresenceUpdateEventArgs, MetaPresenceUpdatedHandler>();
        services.AddHostedHandler<IUserSettingsUpdatedEventHandler, UserSettingsUpdateEventArgs, MetaUserSettingsUpdatedHandler>();
        services.AddHostedHandler<IUserUpdatedEventHandler, UserUpdateEventArgs, MetaUserUpdatedHandler>();
        services.AddHostedHandler<IVoiceStateUpdatedEventHandler, VoiceStateUpdateEventArgs, MetaVoiceStateUpdatedHandler>();
        services.AddHostedHandler<IVoiceServerUpdatedEventHandler, VoiceServerUpdateEventArgs, MetaVoiceServerUpdatedHandler>();
        services.AddHostedHandler<IThreadCreatedEventHandler, ThreadCreateEventArgs, MetaThreadCreatedHandler>();
        services.AddHostedHandler<IThreadUpdatedEventHandler, ThreadUpdateEventArgs, MetaThreadUpdatedHandler>();
        services.AddHostedHandler<IThreadDeletedEventHandler, ThreadDeleteEventArgs, MetaThreadDeletedHandler>();
        services.AddHostedHandler<IThreadListSyncedEventHandler, ThreadListSyncEventArgs, MetaThreadListSyncedHandler>();
        services.AddHostedHandler<IThreadMemberUpdatedEventHandler, ThreadMemberUpdateEventArgs, MetaThreadMemberUpdatedHandler>();
        services.AddHostedHandler<IThreadMembersUpdatedEventHandler, ThreadMembersUpdateEventArgs, MetaThreadMembersUpdatedHandler>();
        services.AddHostedHandler<IIntegrationCreatedEventHandler, IntegrationCreateEventArgs, MetaIntegrationCreatedHandler>();
        services.AddHostedHandler<IIntegrationUpdatedEventHandler, IntegrationUpdateEventArgs, MetaIntegrationUpdatedHandler>();
        services.AddHostedHandler<IIntegrationDeletedEventHandler, IntegrationDeleteEventArgs, MetaIntegrationDeletedHandler>();
        services.AddHostedHandler<IStageInstanceCreatedEventHandler, StageInstanceCreateEventArgs, MetaStageInstanceCreatedHandler>();
        services.AddHostedHandler<IStageInstanceUpdatedEventHandler, StageInstanceUpdateEventArgs, MetaStageInstanceUpdatedHandler>();
        services.AddHostedHandler<IStageInstanceDeletedEventHandler, StageInstanceDeleteEventArgs, MetaStageInstanceDeletedHandler>();
        services.AddHostedHandler<IInteractionCreatedEventHandler, InteractionCreateEventArgs, MetaInteractionCreatedHandler>();
        services.AddHostedHandler<IComponentInteractionCreatedEventHandler, ComponentInteractionCreateEventArgs, MetaComponentInteractionCreatedHandler>();
        services.AddHostedHandler<IModalSubmittedEventHandler, ModalSubmitEventArgs, MetaModalSubmittedHandler>();
        services.AddHostedHandler<IContextMenuInteractionCreatedEventHandler, ContextMenuInteractionCreateEventArgs, MetaContextMenuInteractionCreatedHandler>();
        services.AddHostedHandler<ITypingStartedEventHandler, TypingStartEventArgs, MetaTypingStartedHandler>();
        services.AddHostedHandler<IUnknownEventEventHandler, UnknownEventArgs, MetaUnknownEventHandler>();
        services.AddHostedHandler<IWebhooksUpdatedEventHandler, WebhooksUpdateEventArgs, MetaWebhooksUpdatedHandler>();
        services.AddHostedHandler<IClientErroredEventHandler, ClientErrorEventArgs, MetaClientErroredHandler>();
        services.AddHostedHandler<IAutoModerationRuleCreatedEventHandler, AutoModerationRuleCreateEventArgs, MetaAutoModerationRuleCreatedHandler>();
        services.AddHostedHandler<IAutoModerationRuleUpdatedEventHandler, AutoModerationRuleUpdateEventArgs, MetaAutoModerationRuleUpdatedHandler>();
        services.AddHostedHandler<IAutoModerationRuleDeletedEventHandler, AutoModerationRuleDeleteEventArgs, MetaAutoModerationRuleDeletedHandler>();
        services.AddHostedHandler<IAutoModerationRuleExecutedEventHandler, AutoModerationRuleExecuteEventArgs, MetaAutoModerationRuleExecutedHandler>();
    }
}