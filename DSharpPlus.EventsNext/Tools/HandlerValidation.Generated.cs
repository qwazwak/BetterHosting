
using System;
using System.Collections.Generic;
using DSharpPlus.EventsNext.Entities;

namespace DSharpPlus.EventsNext.Tools;

public static partial class HandlerValidation
{
    private static partial HashSet<Type> InitHandlerInterfaces() => new()
    {
        typeof(ISocketErroredEventHandler),

        typeof(ISocketOpenedEventHandler),

        typeof(ISocketClosedEventHandler),

        typeof(ISessionCreatedEventHandler),

        typeof(ISessionResumedEventHandler),

        typeof(IHeartbeatedEventHandler),

        typeof(IZombiedEventHandler),

        typeof(IApplicationCommandPermissionsUpdatedEventHandler),

        typeof(IChannelCreatedEventHandler),

        typeof(IChannelUpdatedEventHandler),

        typeof(IChannelDeletedEventHandler),

        typeof(IDmChannelDeletedEventHandler),

        typeof(IChannelPinsUpdatedEventHandler),

        typeof(IGuildCreatedEventHandler),

        typeof(IGuildAvailableEventHandler),

        typeof(IGuildUpdatedEventHandler),

        typeof(IGuildDeletedEventHandler),

        typeof(IGuildUnavailableEventHandler),

        typeof(IGuildDownloadCompletedEventHandler),

        typeof(IGuildEmojisUpdatedEventHandler),

        typeof(IGuildStickersUpdatedEventHandler),

        typeof(IGuildIntegrationsUpdatedEventHandler),

        typeof(IGuildAuditLogCreatedEventHandler),

        typeof(IScheduledGuildEventCreatedEventHandler),

        typeof(IScheduledGuildEventUpdatedEventHandler),

        typeof(IScheduledGuildEventDeletedEventHandler),

        typeof(IScheduledGuildEventCompletedEventHandler),

        typeof(IScheduledGuildEventUserAddedEventHandler),

        typeof(IScheduledGuildEventUserRemovedEventHandler),

        typeof(IGuildBanAddedEventHandler),

        typeof(IGuildBanRemovedEventHandler),

        typeof(IGuildMemberAddedEventHandler),

        typeof(IGuildMemberRemovedEventHandler),

        typeof(IGuildMemberUpdatedEventHandler),

        typeof(IGuildMembersChunkedEventHandler),

        typeof(IGuildRoleCreatedEventHandler),

        typeof(IGuildRoleUpdatedEventHandler),

        typeof(IGuildRoleDeletedEventHandler),

        typeof(IInviteCreatedEventHandler),

        typeof(IInviteDeletedEventHandler),

        typeof(IMessageCreatedEventHandler),

        typeof(IMessageAcknowledgedEventHandler),

        typeof(IMessageUpdatedEventHandler),

        typeof(IMessageDeletedEventHandler),

        typeof(IMessagesBulkDeletedEventHandler),

        typeof(IMessageReactionAddedEventHandler),

        typeof(IMessageReactionRemovedEventHandler),

        typeof(IMessageReactionsClearedEventHandler),

        typeof(IMessageReactionRemovedEmojiEventHandler),

        typeof(IPresenceUpdatedEventHandler),

        typeof(IUserSettingsUpdatedEventHandler),

        typeof(IUserUpdatedEventHandler),

        typeof(IVoiceStateUpdatedEventHandler),

        typeof(IVoiceServerUpdatedEventHandler),

        typeof(IThreadCreatedEventHandler),

        typeof(IThreadUpdatedEventHandler),

        typeof(IThreadDeletedEventHandler),

        typeof(IThreadListSyncedEventHandler),

        typeof(IThreadMemberUpdatedEventHandler),

        typeof(IThreadMembersUpdatedEventHandler),

        typeof(IIntegrationCreatedEventHandler),

        typeof(IIntegrationUpdatedEventHandler),

        typeof(IIntegrationDeletedEventHandler),

        typeof(IStageInstanceCreatedEventHandler),

        typeof(IStageInstanceUpdatedEventHandler),

        typeof(IStageInstanceDeletedEventHandler),

        typeof(IInteractionCreatedEventHandler),

        typeof(IComponentInteractionCreatedEventHandler),

        typeof(IModalSubmittedEventHandler),

        typeof(IContextMenuInteractionCreatedEventHandler),

        typeof(ITypingStartedEventHandler),

        typeof(IUnknownEventEventHandler),

        typeof(IWebhooksUpdatedEventHandler),

        typeof(IClientErroredEventHandler),

        typeof(IAutoModerationRuleCreatedEventHandler),

        typeof(IAutoModerationRuleUpdatedEventHandler),

        typeof(IAutoModerationRuleDeletedEventHandler),

        typeof(IAutoModerationRuleExecutedEventHandler),

    };
}