
using System;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventInterfaceValidation
{
    public static partial bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler  =>
        typeof(TInterface) == typeof(ISocketErroredEventHandler) ||
        typeof(TInterface) == typeof(ISocketOpenedEventHandler) ||
        typeof(TInterface) == typeof(ISocketClosedEventHandler) ||
        typeof(TInterface) == typeof(ISessionCreatedEventHandler) ||
        typeof(TInterface) == typeof(ISessionResumedEventHandler) ||
        typeof(TInterface) == typeof(IHeartbeatedEventHandler) ||
        typeof(TInterface) == typeof(IZombiedEventHandler) ||
        typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IChannelCreatedEventHandler) ||
        typeof(TInterface) == typeof(IChannelUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IChannelDeletedEventHandler) ||
        typeof(TInterface) == typeof(IDmChannelDeletedEventHandler) ||
        typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildCreatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildAvailableEventHandler) ||
        typeof(TInterface) == typeof(IGuildUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildDeletedEventHandler) ||
        typeof(TInterface) == typeof(IGuildUnavailableEventHandler) ||
        typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler) ||
        typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler) ||
        typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler) ||
        typeof(TInterface) == typeof(IGuildBanAddedEventHandler) ||
        typeof(TInterface) == typeof(IGuildBanRemovedEventHandler) ||
        typeof(TInterface) == typeof(IGuildMemberAddedEventHandler) ||
        typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler) ||
        typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler) ||
        typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler) ||
        typeof(TInterface) == typeof(IInviteCreatedEventHandler) ||
        typeof(TInterface) == typeof(IInviteDeletedEventHandler) ||
        typeof(TInterface) == typeof(IMessageCreatedEventHandler) ||
        typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler) ||
        typeof(TInterface) == typeof(IMessageUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IMessageDeletedEventHandler) ||
        typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler) ||
        typeof(TInterface) == typeof(IMessageReactionAddedEventHandler) ||
        typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler) ||
        typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler) ||
        typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler) ||
        typeof(TInterface) == typeof(IPresenceUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IUserUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IThreadCreatedEventHandler) ||
        typeof(TInterface) == typeof(IThreadUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IThreadDeletedEventHandler) ||
        typeof(TInterface) == typeof(IThreadListSyncedEventHandler) ||
        typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IIntegrationCreatedEventHandler) ||
        typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IIntegrationDeletedEventHandler) ||
        typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler) ||
        typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler) ||
        typeof(TInterface) == typeof(IInteractionCreatedEventHandler) ||
        typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler) ||
        typeof(TInterface) == typeof(IModalSubmittedEventHandler) ||
        typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler) ||
        typeof(TInterface) == typeof(ITypingStartedEventHandler) ||
        typeof(TInterface) == typeof(IUnknownEventEventHandler) ||
        typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IClientErroredEventHandler) ||
        typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler) ||
        typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler) ||
        typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler) ||
        typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler);

    public static partial bool IsAssignableToAny<THandler>() where THandler : IDiscordEventHandler  =>
        typeof(THandler).IsAssignableTo(typeof(ISocketErroredEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(ISocketOpenedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(ISocketClosedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(ISessionCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(ISessionResumedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IHeartbeatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IZombiedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IChannelCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IChannelUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IChannelDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IDmChannelDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildAvailableEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildUnavailableEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildBanAddedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildBanRemovedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildMemberAddedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IInviteCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IInviteDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageReactionAddedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IPresenceUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IUserUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadListSyncedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IIntegrationCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IIntegrationDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IInteractionCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IModalSubmittedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(ITypingStartedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IUnknownEventEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IClientErroredEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)) ||
        typeof(THandler).IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler));

    public static partial bool IsExactInterface(Type interfaceType)  =>
        interfaceType == typeof(ISocketErroredEventHandler) ||
        interfaceType == typeof(ISocketOpenedEventHandler) ||
        interfaceType == typeof(ISocketClosedEventHandler) ||
        interfaceType == typeof(ISessionCreatedEventHandler) ||
        interfaceType == typeof(ISessionResumedEventHandler) ||
        interfaceType == typeof(IHeartbeatedEventHandler) ||
        interfaceType == typeof(IZombiedEventHandler) ||
        interfaceType == typeof(IApplicationCommandPermissionsUpdatedEventHandler) ||
        interfaceType == typeof(IChannelCreatedEventHandler) ||
        interfaceType == typeof(IChannelUpdatedEventHandler) ||
        interfaceType == typeof(IChannelDeletedEventHandler) ||
        interfaceType == typeof(IDmChannelDeletedEventHandler) ||
        interfaceType == typeof(IChannelPinsUpdatedEventHandler) ||
        interfaceType == typeof(IGuildCreatedEventHandler) ||
        interfaceType == typeof(IGuildAvailableEventHandler) ||
        interfaceType == typeof(IGuildUpdatedEventHandler) ||
        interfaceType == typeof(IGuildDeletedEventHandler) ||
        interfaceType == typeof(IGuildUnavailableEventHandler) ||
        interfaceType == typeof(IGuildDownloadCompletedEventHandler) ||
        interfaceType == typeof(IGuildEmojisUpdatedEventHandler) ||
        interfaceType == typeof(IGuildStickersUpdatedEventHandler) ||
        interfaceType == typeof(IGuildIntegrationsUpdatedEventHandler) ||
        interfaceType == typeof(IGuildAuditLogCreatedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventCreatedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventUpdatedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventDeletedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventCompletedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventUserAddedEventHandler) ||
        interfaceType == typeof(IScheduledGuildEventUserRemovedEventHandler) ||
        interfaceType == typeof(IGuildBanAddedEventHandler) ||
        interfaceType == typeof(IGuildBanRemovedEventHandler) ||
        interfaceType == typeof(IGuildMemberAddedEventHandler) ||
        interfaceType == typeof(IGuildMemberRemovedEventHandler) ||
        interfaceType == typeof(IGuildMemberUpdatedEventHandler) ||
        interfaceType == typeof(IGuildMembersChunkedEventHandler) ||
        interfaceType == typeof(IGuildRoleCreatedEventHandler) ||
        interfaceType == typeof(IGuildRoleUpdatedEventHandler) ||
        interfaceType == typeof(IGuildRoleDeletedEventHandler) ||
        interfaceType == typeof(IInviteCreatedEventHandler) ||
        interfaceType == typeof(IInviteDeletedEventHandler) ||
        interfaceType == typeof(IMessageCreatedEventHandler) ||
        interfaceType == typeof(IMessageAcknowledgedEventHandler) ||
        interfaceType == typeof(IMessageUpdatedEventHandler) ||
        interfaceType == typeof(IMessageDeletedEventHandler) ||
        interfaceType == typeof(IMessagesBulkDeletedEventHandler) ||
        interfaceType == typeof(IMessageReactionAddedEventHandler) ||
        interfaceType == typeof(IMessageReactionRemovedEventHandler) ||
        interfaceType == typeof(IMessageReactionsClearedEventHandler) ||
        interfaceType == typeof(IMessageReactionRemovedEmojiEventHandler) ||
        interfaceType == typeof(IPresenceUpdatedEventHandler) ||
        interfaceType == typeof(IUserSettingsUpdatedEventHandler) ||
        interfaceType == typeof(IUserUpdatedEventHandler) ||
        interfaceType == typeof(IVoiceStateUpdatedEventHandler) ||
        interfaceType == typeof(IVoiceServerUpdatedEventHandler) ||
        interfaceType == typeof(IThreadCreatedEventHandler) ||
        interfaceType == typeof(IThreadUpdatedEventHandler) ||
        interfaceType == typeof(IThreadDeletedEventHandler) ||
        interfaceType == typeof(IThreadListSyncedEventHandler) ||
        interfaceType == typeof(IThreadMemberUpdatedEventHandler) ||
        interfaceType == typeof(IThreadMembersUpdatedEventHandler) ||
        interfaceType == typeof(IIntegrationCreatedEventHandler) ||
        interfaceType == typeof(IIntegrationUpdatedEventHandler) ||
        interfaceType == typeof(IIntegrationDeletedEventHandler) ||
        interfaceType == typeof(IStageInstanceCreatedEventHandler) ||
        interfaceType == typeof(IStageInstanceUpdatedEventHandler) ||
        interfaceType == typeof(IStageInstanceDeletedEventHandler) ||
        interfaceType == typeof(IInteractionCreatedEventHandler) ||
        interfaceType == typeof(IComponentInteractionCreatedEventHandler) ||
        interfaceType == typeof(IModalSubmittedEventHandler) ||
        interfaceType == typeof(IContextMenuInteractionCreatedEventHandler) ||
        interfaceType == typeof(ITypingStartedEventHandler) ||
        interfaceType == typeof(IUnknownEventEventHandler) ||
        interfaceType == typeof(IWebhooksUpdatedEventHandler) ||
        interfaceType == typeof(IClientErroredEventHandler) ||
        interfaceType == typeof(IAutoModerationRuleCreatedEventHandler) ||
        interfaceType == typeof(IAutoModerationRuleUpdatedEventHandler) ||
        interfaceType == typeof(IAutoModerationRuleDeletedEventHandler) ||
        interfaceType == typeof(IAutoModerationRuleExecutedEventHandler);

    public static partial bool IsAssignableToAny(Type handlerType)  =>
        handlerType.IsAssignableTo(typeof(ISocketErroredEventHandler)) ||
        handlerType.IsAssignableTo(typeof(ISocketOpenedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(ISocketClosedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(ISessionCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(ISessionResumedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IHeartbeatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IZombiedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IChannelCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IChannelUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IChannelDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IDmChannelDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildAvailableEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildUnavailableEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildBanAddedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildBanRemovedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildMemberAddedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IInviteCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IInviteDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageReactionAddedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IPresenceUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IUserUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadListSyncedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IIntegrationCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IIntegrationDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IInteractionCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IModalSubmittedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(ITypingStartedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IUnknownEventEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IClientErroredEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)) ||
        handlerType.IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler));
}

