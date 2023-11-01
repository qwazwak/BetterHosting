
using System;
using System.Collections.Generic;
using DSharpPlus.EventsNext.Entities;

namespace DSharpPlus.EventsNext.Tools;

internal static partial class HandlerValidation
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

    internal static partial bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler
    {
        if(typeof(TInterface) == typeof(ISocketErroredEventHandler))
            return true;
        if(typeof(TInterface) == typeof(ISocketOpenedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(ISocketClosedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(ISessionCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(ISessionResumedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IHeartbeatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IZombiedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IChannelCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IChannelUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IChannelDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IDmChannelDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IChannelPinsUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildAvailableEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildUnavailableEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildDownloadCompletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildEmojisUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildStickersUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildIntegrationsUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildAuditLogCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventCompletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventUserAddedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildBanAddedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildBanRemovedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildMemberAddedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildMemberRemovedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildMemberUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildMembersChunkedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildRoleCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildRoleUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IGuildRoleDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IInviteCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IInviteDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageAcknowledgedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessagesBulkDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageReactionAddedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageReactionRemovedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageReactionsClearedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IMessageReactionRemovedEmojiEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IPresenceUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IUserSettingsUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IUserUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IVoiceStateUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IVoiceServerUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadListSyncedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadMemberUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IThreadMembersUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IIntegrationCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IIntegrationUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IIntegrationDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IStageInstanceCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IStageInstanceUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IStageInstanceDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IInteractionCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IComponentInteractionCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IModalSubmittedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IContextMenuInteractionCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(ITypingStartedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IUnknownEventEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IWebhooksUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IClientErroredEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IAutoModerationRuleCreatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IAutoModerationRuleUpdatedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IAutoModerationRuleDeletedEventHandler))
            return true;
        if(typeof(TInterface) == typeof(IAutoModerationRuleExecutedEventHandler))
            return true;
        else
            return false;
    }

    internal static partial bool IsExactInterface(Type interfaceType)
    {
        ArgumentNullException.ThrowIfNull(interfaceType);
        if(interfaceType == typeof(ISocketErroredEventHandler))
            return true;
        if(interfaceType == typeof(ISocketOpenedEventHandler))
            return true;
        if(interfaceType == typeof(ISocketClosedEventHandler))
            return true;
        if(interfaceType == typeof(ISessionCreatedEventHandler))
            return true;
        if(interfaceType == typeof(ISessionResumedEventHandler))
            return true;
        if(interfaceType == typeof(IHeartbeatedEventHandler))
            return true;
        if(interfaceType == typeof(IZombiedEventHandler))
            return true;
        if(interfaceType == typeof(IApplicationCommandPermissionsUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IChannelCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IChannelUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IChannelDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IDmChannelDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IChannelPinsUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildAvailableEventHandler))
            return true;
        if(interfaceType == typeof(IGuildUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildUnavailableEventHandler))
            return true;
        if(interfaceType == typeof(IGuildDownloadCompletedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildEmojisUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildStickersUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildIntegrationsUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildAuditLogCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventCompletedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventUserAddedEventHandler))
            return true;
        if(interfaceType == typeof(IScheduledGuildEventUserRemovedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildBanAddedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildBanRemovedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildMemberAddedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildMemberRemovedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildMemberUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildMembersChunkedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildRoleCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildRoleUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IGuildRoleDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IInviteCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IInviteDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageAcknowledgedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IMessagesBulkDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageReactionAddedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageReactionRemovedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageReactionsClearedEventHandler))
            return true;
        if(interfaceType == typeof(IMessageReactionRemovedEmojiEventHandler))
            return true;
        if(interfaceType == typeof(IPresenceUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IUserSettingsUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IUserUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IVoiceStateUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IVoiceServerUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadListSyncedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadMemberUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IThreadMembersUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IIntegrationCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IIntegrationUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IIntegrationDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IStageInstanceCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IStageInstanceUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IStageInstanceDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IInteractionCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IComponentInteractionCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IModalSubmittedEventHandler))
            return true;
        if(interfaceType == typeof(IContextMenuInteractionCreatedEventHandler))
            return true;
        if(interfaceType == typeof(ITypingStartedEventHandler))
            return true;
        if(interfaceType == typeof(IUnknownEventEventHandler))
            return true;
        if(interfaceType == typeof(IWebhooksUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IClientErroredEventHandler))
            return true;
        if(interfaceType == typeof(IAutoModerationRuleCreatedEventHandler))
            return true;
        if(interfaceType == typeof(IAutoModerationRuleUpdatedEventHandler))
            return true;
        if(interfaceType == typeof(IAutoModerationRuleDeletedEventHandler))
            return true;
        if(interfaceType == typeof(IAutoModerationRuleExecutedEventHandler))
            return true;
        else
            return false;
    }
}