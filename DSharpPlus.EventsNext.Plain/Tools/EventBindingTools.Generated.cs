
using System;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Plain.Tools.Internal;
using QLib.Extensions.Reflection;

namespace DSharpPlus.EventsNext.Plain.Tools;

public static partial class EventBindingTools
{
    private static void BindHandlerCore(DiscordShardedClient client, Type handler)
    {
        if (typeof(ISocketErroredEventHandler).IsAssignableFrom(handler))
            client.SocketErrored += EventBinderWrappers.WrapSocketErrored(handler);
        if (typeof(ISocketOpenedEventHandler).IsAssignableFrom(handler))
            client.SocketOpened += EventBinderWrappers.WrapSocketOpened(handler);
        if (typeof(ISocketClosedEventHandler).IsAssignableFrom(handler))
            client.SocketClosed += EventBinderWrappers.WrapSocketClosed(handler);
        if (typeof(ISessionCreatedEventHandler).IsAssignableFrom(handler))
            client.SessionCreated += EventBinderWrappers.WrapSessionCreated(handler);
        if (typeof(ISessionResumedEventHandler).IsAssignableFrom(handler))
            client.SessionResumed += EventBinderWrappers.WrapSessionResumed(handler);
        if (typeof(IHeartbeatedEventHandler).IsAssignableFrom(handler))
            client.Heartbeated += EventBinderWrappers.WrapHeartbeated(handler);
        if (typeof(IZombiedEventHandler).IsAssignableFrom(handler))
            client.Zombied += EventBinderWrappers.WrapZombied(handler);
        if (typeof(IApplicationCommandPermissionsUpdatedEventHandler).IsAssignableFrom(handler))
            client.ApplicationCommandPermissionsUpdated += EventBinderWrappers.WrapApplicationCommandPermissionsUpdated(handler);
        if (typeof(IChannelCreatedEventHandler).IsAssignableFrom(handler))
            client.ChannelCreated += EventBinderWrappers.WrapChannelCreated(handler);
        if (typeof(IChannelUpdatedEventHandler).IsAssignableFrom(handler))
            client.ChannelUpdated += EventBinderWrappers.WrapChannelUpdated(handler);
        if (typeof(IChannelDeletedEventHandler).IsAssignableFrom(handler))
            client.ChannelDeleted += EventBinderWrappers.WrapChannelDeleted(handler);
        if (typeof(IDmChannelDeletedEventHandler).IsAssignableFrom(handler))
            client.DmChannelDeleted += EventBinderWrappers.WrapDmChannelDeleted(handler);
        if (typeof(IChannelPinsUpdatedEventHandler).IsAssignableFrom(handler))
            client.ChannelPinsUpdated += EventBinderWrappers.WrapChannelPinsUpdated(handler);
        if (typeof(IGuildCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildCreated += EventBinderWrappers.WrapGuildCreated(handler);
        if (typeof(IGuildAvailableEventHandler).IsAssignableFrom(handler))
            client.GuildAvailable += EventBinderWrappers.WrapGuildAvailable(handler);
        if (typeof(IGuildUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildUpdated += EventBinderWrappers.WrapGuildUpdated(handler);
        if (typeof(IGuildDeletedEventHandler).IsAssignableFrom(handler))
            client.GuildDeleted += EventBinderWrappers.WrapGuildDeleted(handler);
        if (typeof(IGuildUnavailableEventHandler).IsAssignableFrom(handler))
            client.GuildUnavailable += EventBinderWrappers.WrapGuildUnavailable(handler);
        if (typeof(IGuildDownloadCompletedEventHandler).IsAssignableFrom(handler))
            client.GuildDownloadCompleted += EventBinderWrappers.WrapGuildDownloadCompleted(handler);
        if (typeof(IGuildEmojisUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildEmojisUpdated += EventBinderWrappers.WrapGuildEmojisUpdated(handler);
        if (typeof(IGuildStickersUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildStickersUpdated += EventBinderWrappers.WrapGuildStickersUpdated(handler);
        if (typeof(IGuildIntegrationsUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildIntegrationsUpdated += EventBinderWrappers.WrapGuildIntegrationsUpdated(handler);
        if (typeof(IGuildAuditLogCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildAuditLogCreated += EventBinderWrappers.WrapGuildAuditLogCreated(handler);
        if (typeof(IScheduledGuildEventCreatedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventCreated += EventBinderWrappers.WrapScheduledGuildEventCreated(handler);
        if (typeof(IScheduledGuildEventUpdatedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUpdated += EventBinderWrappers.WrapScheduledGuildEventUpdated(handler);
        if (typeof(IScheduledGuildEventDeletedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventDeleted += EventBinderWrappers.WrapScheduledGuildEventDeleted(handler);
        if (typeof(IScheduledGuildEventCompletedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventCompleted += EventBinderWrappers.WrapScheduledGuildEventCompleted(handler);
        if (typeof(IScheduledGuildEventUserAddedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUserAdded += EventBinderWrappers.WrapScheduledGuildEventUserAdded(handler);
        if (typeof(IScheduledGuildEventUserRemovedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUserRemoved += EventBinderWrappers.WrapScheduledGuildEventUserRemoved(handler);
        if (typeof(IGuildBanAddedEventHandler).IsAssignableFrom(handler))
            client.GuildBanAdded += EventBinderWrappers.WrapGuildBanAdded(handler);
        if (typeof(IGuildBanRemovedEventHandler).IsAssignableFrom(handler))
            client.GuildBanRemoved += EventBinderWrappers.WrapGuildBanRemoved(handler);
        if (typeof(IGuildMemberAddedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberAdded += EventBinderWrappers.WrapGuildMemberAdded(handler);
        if (typeof(IGuildMemberRemovedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberRemoved += EventBinderWrappers.WrapGuildMemberRemoved(handler);
        if (typeof(IGuildMemberUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberUpdated += EventBinderWrappers.WrapGuildMemberUpdated(handler);
        if (typeof(IGuildMembersChunkedEventHandler).IsAssignableFrom(handler))
            client.GuildMembersChunked += EventBinderWrappers.WrapGuildMembersChunked(handler);
        if (typeof(IGuildRoleCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleCreated += EventBinderWrappers.WrapGuildRoleCreated(handler);
        if (typeof(IGuildRoleUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleUpdated += EventBinderWrappers.WrapGuildRoleUpdated(handler);
        if (typeof(IGuildRoleDeletedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleDeleted += EventBinderWrappers.WrapGuildRoleDeleted(handler);
        if (typeof(IInviteCreatedEventHandler).IsAssignableFrom(handler))
            client.InviteCreated += EventBinderWrappers.WrapInviteCreated(handler);
        if (typeof(IInviteDeletedEventHandler).IsAssignableFrom(handler))
            client.InviteDeleted += EventBinderWrappers.WrapInviteDeleted(handler);
        if (typeof(IMessageCreatedEventHandler).IsAssignableFrom(handler))
            client.MessageCreated += EventBinderWrappers.WrapMessageCreated(handler);
        if (typeof(IMessageAcknowledgedEventHandler).IsAssignableFrom(handler))
            client.MessageAcknowledged += EventBinderWrappers.WrapMessageAcknowledged(handler);
        if (typeof(IMessageUpdatedEventHandler).IsAssignableFrom(handler))
            client.MessageUpdated += EventBinderWrappers.WrapMessageUpdated(handler);
        if (typeof(IMessageDeletedEventHandler).IsAssignableFrom(handler))
            client.MessageDeleted += EventBinderWrappers.WrapMessageDeleted(handler);
        if (typeof(IMessagesBulkDeletedEventHandler).IsAssignableFrom(handler))
            client.MessagesBulkDeleted += EventBinderWrappers.WrapMessagesBulkDeleted(handler);
        if (typeof(IMessageReactionAddedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionAdded += EventBinderWrappers.WrapMessageReactionAdded(handler);
        if (typeof(IMessageReactionRemovedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionRemoved += EventBinderWrappers.WrapMessageReactionRemoved(handler);
        if (typeof(IMessageReactionsClearedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionsCleared += EventBinderWrappers.WrapMessageReactionsCleared(handler);
        if (typeof(IMessageReactionRemovedEmojiEventHandler).IsAssignableFrom(handler))
            client.MessageReactionRemovedEmoji += EventBinderWrappers.WrapMessageReactionRemovedEmoji(handler);
        if (typeof(IPresenceUpdatedEventHandler).IsAssignableFrom(handler))
            client.PresenceUpdated += EventBinderWrappers.WrapPresenceUpdated(handler);
        if (typeof(IUserSettingsUpdatedEventHandler).IsAssignableFrom(handler))
            client.UserSettingsUpdated += EventBinderWrappers.WrapUserSettingsUpdated(handler);
        if (typeof(IUserUpdatedEventHandler).IsAssignableFrom(handler))
            client.UserUpdated += EventBinderWrappers.WrapUserUpdated(handler);
        if (typeof(IVoiceStateUpdatedEventHandler).IsAssignableFrom(handler))
            client.VoiceStateUpdated += EventBinderWrappers.WrapVoiceStateUpdated(handler);
        if (typeof(IVoiceServerUpdatedEventHandler).IsAssignableFrom(handler))
            client.VoiceServerUpdated += EventBinderWrappers.WrapVoiceServerUpdated(handler);
        if (typeof(IThreadCreatedEventHandler).IsAssignableFrom(handler))
            client.ThreadCreated += EventBinderWrappers.WrapThreadCreated(handler);
        if (typeof(IThreadUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadUpdated += EventBinderWrappers.WrapThreadUpdated(handler);
        if (typeof(IThreadDeletedEventHandler).IsAssignableFrom(handler))
            client.ThreadDeleted += EventBinderWrappers.WrapThreadDeleted(handler);
        if (typeof(IThreadListSyncedEventHandler).IsAssignableFrom(handler))
            client.ThreadListSynced += EventBinderWrappers.WrapThreadListSynced(handler);
        if (typeof(IThreadMemberUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadMemberUpdated += EventBinderWrappers.WrapThreadMemberUpdated(handler);
        if (typeof(IThreadMembersUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadMembersUpdated += EventBinderWrappers.WrapThreadMembersUpdated(handler);
        if (typeof(IIntegrationCreatedEventHandler).IsAssignableFrom(handler))
            client.IntegrationCreated += EventBinderWrappers.WrapIntegrationCreated(handler);
        if (typeof(IIntegrationUpdatedEventHandler).IsAssignableFrom(handler))
            client.IntegrationUpdated += EventBinderWrappers.WrapIntegrationUpdated(handler);
        if (typeof(IIntegrationDeletedEventHandler).IsAssignableFrom(handler))
            client.IntegrationDeleted += EventBinderWrappers.WrapIntegrationDeleted(handler);
        if (typeof(IStageInstanceCreatedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceCreated += EventBinderWrappers.WrapStageInstanceCreated(handler);
        if (typeof(IStageInstanceUpdatedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceUpdated += EventBinderWrappers.WrapStageInstanceUpdated(handler);
        if (typeof(IStageInstanceDeletedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceDeleted += EventBinderWrappers.WrapStageInstanceDeleted(handler);
        if (typeof(IInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.InteractionCreated += EventBinderWrappers.WrapInteractionCreated(handler);
        if (typeof(IComponentInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.ComponentInteractionCreated += EventBinderWrappers.WrapComponentInteractionCreated(handler);
        if (typeof(IModalSubmittedEventHandler).IsAssignableFrom(handler))
            client.ModalSubmitted += EventBinderWrappers.WrapModalSubmitted(handler);
        if (typeof(IContextMenuInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.ContextMenuInteractionCreated += EventBinderWrappers.WrapContextMenuInteractionCreated(handler);
        if (typeof(ITypingStartedEventHandler).IsAssignableFrom(handler))
            client.TypingStarted += EventBinderWrappers.WrapTypingStarted(handler);
        if (typeof(IUnknownEventEventHandler).IsAssignableFrom(handler))
            client.UnknownEvent += EventBinderWrappers.WrapUnknownEvent(handler);
        if (typeof(IWebhooksUpdatedEventHandler).IsAssignableFrom(handler))
            client.WebhooksUpdated += EventBinderWrappers.WrapWebhooksUpdated(handler);
        if (typeof(IClientErroredEventHandler).IsAssignableFrom(handler))
            client.ClientErrored += EventBinderWrappers.WrapClientErrored(handler);
        if (typeof(IAutoModerationRuleCreatedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleCreated += EventBinderWrappers.WrapAutoModerationRuleCreated(handler);
        if (typeof(IAutoModerationRuleUpdatedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleUpdated += EventBinderWrappers.WrapAutoModerationRuleUpdated(handler);
        if (typeof(IAutoModerationRuleDeletedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleDeleted += EventBinderWrappers.WrapAutoModerationRuleDeleted(handler);
        if (typeof(IAutoModerationRuleExecutedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleExecuted += EventBinderWrappers.WrapAutoModerationRuleExecuted(handler);
    }
    private static void BindHandlerCore(DiscordClient client, Type handler)
    {
        if (typeof(ISocketErroredEventHandler).IsAssignableFrom(handler))
            client.SocketErrored += EventBinderWrappers.WrapSocketErrored(handler);
        if (typeof(ISocketOpenedEventHandler).IsAssignableFrom(handler))
            client.SocketOpened += EventBinderWrappers.WrapSocketOpened(handler);
        if (typeof(ISocketClosedEventHandler).IsAssignableFrom(handler))
            client.SocketClosed += EventBinderWrappers.WrapSocketClosed(handler);
        if (typeof(ISessionCreatedEventHandler).IsAssignableFrom(handler))
            client.SessionCreated += EventBinderWrappers.WrapSessionCreated(handler);
        if (typeof(ISessionResumedEventHandler).IsAssignableFrom(handler))
            client.SessionResumed += EventBinderWrappers.WrapSessionResumed(handler);
        if (typeof(IHeartbeatedEventHandler).IsAssignableFrom(handler))
            client.Heartbeated += EventBinderWrappers.WrapHeartbeated(handler);
        if (typeof(IZombiedEventHandler).IsAssignableFrom(handler))
            client.Zombied += EventBinderWrappers.WrapZombied(handler);
        if (typeof(IApplicationCommandPermissionsUpdatedEventHandler).IsAssignableFrom(handler))
            client.ApplicationCommandPermissionsUpdated += EventBinderWrappers.WrapApplicationCommandPermissionsUpdated(handler);
        if (typeof(IChannelCreatedEventHandler).IsAssignableFrom(handler))
            client.ChannelCreated += EventBinderWrappers.WrapChannelCreated(handler);
        if (typeof(IChannelUpdatedEventHandler).IsAssignableFrom(handler))
            client.ChannelUpdated += EventBinderWrappers.WrapChannelUpdated(handler);
        if (typeof(IChannelDeletedEventHandler).IsAssignableFrom(handler))
            client.ChannelDeleted += EventBinderWrappers.WrapChannelDeleted(handler);
        if (typeof(IDmChannelDeletedEventHandler).IsAssignableFrom(handler))
            client.DmChannelDeleted += EventBinderWrappers.WrapDmChannelDeleted(handler);
        if (typeof(IChannelPinsUpdatedEventHandler).IsAssignableFrom(handler))
            client.ChannelPinsUpdated += EventBinderWrappers.WrapChannelPinsUpdated(handler);
        if (typeof(IGuildCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildCreated += EventBinderWrappers.WrapGuildCreated(handler);
        if (typeof(IGuildAvailableEventHandler).IsAssignableFrom(handler))
            client.GuildAvailable += EventBinderWrappers.WrapGuildAvailable(handler);
        if (typeof(IGuildUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildUpdated += EventBinderWrappers.WrapGuildUpdated(handler);
        if (typeof(IGuildDeletedEventHandler).IsAssignableFrom(handler))
            client.GuildDeleted += EventBinderWrappers.WrapGuildDeleted(handler);
        if (typeof(IGuildUnavailableEventHandler).IsAssignableFrom(handler))
            client.GuildUnavailable += EventBinderWrappers.WrapGuildUnavailable(handler);
        if (typeof(IGuildDownloadCompletedEventHandler).IsAssignableFrom(handler))
            client.GuildDownloadCompleted += EventBinderWrappers.WrapGuildDownloadCompleted(handler);
        if (typeof(IGuildEmojisUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildEmojisUpdated += EventBinderWrappers.WrapGuildEmojisUpdated(handler);
        if (typeof(IGuildStickersUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildStickersUpdated += EventBinderWrappers.WrapGuildStickersUpdated(handler);
        if (typeof(IGuildIntegrationsUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildIntegrationsUpdated += EventBinderWrappers.WrapGuildIntegrationsUpdated(handler);
        if (typeof(IGuildAuditLogCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildAuditLogCreated += EventBinderWrappers.WrapGuildAuditLogCreated(handler);
        if (typeof(IScheduledGuildEventCreatedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventCreated += EventBinderWrappers.WrapScheduledGuildEventCreated(handler);
        if (typeof(IScheduledGuildEventUpdatedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUpdated += EventBinderWrappers.WrapScheduledGuildEventUpdated(handler);
        if (typeof(IScheduledGuildEventDeletedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventDeleted += EventBinderWrappers.WrapScheduledGuildEventDeleted(handler);
        if (typeof(IScheduledGuildEventCompletedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventCompleted += EventBinderWrappers.WrapScheduledGuildEventCompleted(handler);
        if (typeof(IScheduledGuildEventUserAddedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUserAdded += EventBinderWrappers.WrapScheduledGuildEventUserAdded(handler);
        if (typeof(IScheduledGuildEventUserRemovedEventHandler).IsAssignableFrom(handler))
            client.ScheduledGuildEventUserRemoved += EventBinderWrappers.WrapScheduledGuildEventUserRemoved(handler);
        if (typeof(IGuildBanAddedEventHandler).IsAssignableFrom(handler))
            client.GuildBanAdded += EventBinderWrappers.WrapGuildBanAdded(handler);
        if (typeof(IGuildBanRemovedEventHandler).IsAssignableFrom(handler))
            client.GuildBanRemoved += EventBinderWrappers.WrapGuildBanRemoved(handler);
        if (typeof(IGuildMemberAddedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberAdded += EventBinderWrappers.WrapGuildMemberAdded(handler);
        if (typeof(IGuildMemberRemovedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberRemoved += EventBinderWrappers.WrapGuildMemberRemoved(handler);
        if (typeof(IGuildMemberUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildMemberUpdated += EventBinderWrappers.WrapGuildMemberUpdated(handler);
        if (typeof(IGuildMembersChunkedEventHandler).IsAssignableFrom(handler))
            client.GuildMembersChunked += EventBinderWrappers.WrapGuildMembersChunked(handler);
        if (typeof(IGuildRoleCreatedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleCreated += EventBinderWrappers.WrapGuildRoleCreated(handler);
        if (typeof(IGuildRoleUpdatedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleUpdated += EventBinderWrappers.WrapGuildRoleUpdated(handler);
        if (typeof(IGuildRoleDeletedEventHandler).IsAssignableFrom(handler))
            client.GuildRoleDeleted += EventBinderWrappers.WrapGuildRoleDeleted(handler);
        if (typeof(IInviteCreatedEventHandler).IsAssignableFrom(handler))
            client.InviteCreated += EventBinderWrappers.WrapInviteCreated(handler);
        if (typeof(IInviteDeletedEventHandler).IsAssignableFrom(handler))
            client.InviteDeleted += EventBinderWrappers.WrapInviteDeleted(handler);
        if (typeof(IMessageCreatedEventHandler).IsAssignableFrom(handler))
            client.MessageCreated += EventBinderWrappers.WrapMessageCreated(handler);
        if (typeof(IMessageAcknowledgedEventHandler).IsAssignableFrom(handler))
            client.MessageAcknowledged += EventBinderWrappers.WrapMessageAcknowledged(handler);
        if (typeof(IMessageUpdatedEventHandler).IsAssignableFrom(handler))
            client.MessageUpdated += EventBinderWrappers.WrapMessageUpdated(handler);
        if (typeof(IMessageDeletedEventHandler).IsAssignableFrom(handler))
            client.MessageDeleted += EventBinderWrappers.WrapMessageDeleted(handler);
        if (typeof(IMessagesBulkDeletedEventHandler).IsAssignableFrom(handler))
            client.MessagesBulkDeleted += EventBinderWrappers.WrapMessagesBulkDeleted(handler);
        if (typeof(IMessageReactionAddedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionAdded += EventBinderWrappers.WrapMessageReactionAdded(handler);
        if (typeof(IMessageReactionRemovedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionRemoved += EventBinderWrappers.WrapMessageReactionRemoved(handler);
        if (typeof(IMessageReactionsClearedEventHandler).IsAssignableFrom(handler))
            client.MessageReactionsCleared += EventBinderWrappers.WrapMessageReactionsCleared(handler);
        if (typeof(IMessageReactionRemovedEmojiEventHandler).IsAssignableFrom(handler))
            client.MessageReactionRemovedEmoji += EventBinderWrappers.WrapMessageReactionRemovedEmoji(handler);
        if (typeof(IPresenceUpdatedEventHandler).IsAssignableFrom(handler))
            client.PresenceUpdated += EventBinderWrappers.WrapPresenceUpdated(handler);
        if (typeof(IUserSettingsUpdatedEventHandler).IsAssignableFrom(handler))
            client.UserSettingsUpdated += EventBinderWrappers.WrapUserSettingsUpdated(handler);
        if (typeof(IUserUpdatedEventHandler).IsAssignableFrom(handler))
            client.UserUpdated += EventBinderWrappers.WrapUserUpdated(handler);
        if (typeof(IVoiceStateUpdatedEventHandler).IsAssignableFrom(handler))
            client.VoiceStateUpdated += EventBinderWrappers.WrapVoiceStateUpdated(handler);
        if (typeof(IVoiceServerUpdatedEventHandler).IsAssignableFrom(handler))
            client.VoiceServerUpdated += EventBinderWrappers.WrapVoiceServerUpdated(handler);
        if (typeof(IThreadCreatedEventHandler).IsAssignableFrom(handler))
            client.ThreadCreated += EventBinderWrappers.WrapThreadCreated(handler);
        if (typeof(IThreadUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadUpdated += EventBinderWrappers.WrapThreadUpdated(handler);
        if (typeof(IThreadDeletedEventHandler).IsAssignableFrom(handler))
            client.ThreadDeleted += EventBinderWrappers.WrapThreadDeleted(handler);
        if (typeof(IThreadListSyncedEventHandler).IsAssignableFrom(handler))
            client.ThreadListSynced += EventBinderWrappers.WrapThreadListSynced(handler);
        if (typeof(IThreadMemberUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadMemberUpdated += EventBinderWrappers.WrapThreadMemberUpdated(handler);
        if (typeof(IThreadMembersUpdatedEventHandler).IsAssignableFrom(handler))
            client.ThreadMembersUpdated += EventBinderWrappers.WrapThreadMembersUpdated(handler);
        if (typeof(IIntegrationCreatedEventHandler).IsAssignableFrom(handler))
            client.IntegrationCreated += EventBinderWrappers.WrapIntegrationCreated(handler);
        if (typeof(IIntegrationUpdatedEventHandler).IsAssignableFrom(handler))
            client.IntegrationUpdated += EventBinderWrappers.WrapIntegrationUpdated(handler);
        if (typeof(IIntegrationDeletedEventHandler).IsAssignableFrom(handler))
            client.IntegrationDeleted += EventBinderWrappers.WrapIntegrationDeleted(handler);
        if (typeof(IStageInstanceCreatedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceCreated += EventBinderWrappers.WrapStageInstanceCreated(handler);
        if (typeof(IStageInstanceUpdatedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceUpdated += EventBinderWrappers.WrapStageInstanceUpdated(handler);
        if (typeof(IStageInstanceDeletedEventHandler).IsAssignableFrom(handler))
            client.StageInstanceDeleted += EventBinderWrappers.WrapStageInstanceDeleted(handler);
        if (typeof(IInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.InteractionCreated += EventBinderWrappers.WrapInteractionCreated(handler);
        if (typeof(IComponentInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.ComponentInteractionCreated += EventBinderWrappers.WrapComponentInteractionCreated(handler);
        if (typeof(IModalSubmittedEventHandler).IsAssignableFrom(handler))
            client.ModalSubmitted += EventBinderWrappers.WrapModalSubmitted(handler);
        if (typeof(IContextMenuInteractionCreatedEventHandler).IsAssignableFrom(handler))
            client.ContextMenuInteractionCreated += EventBinderWrappers.WrapContextMenuInteractionCreated(handler);
        if (typeof(ITypingStartedEventHandler).IsAssignableFrom(handler))
            client.TypingStarted += EventBinderWrappers.WrapTypingStarted(handler);
        if (typeof(IUnknownEventEventHandler).IsAssignableFrom(handler))
            client.UnknownEvent += EventBinderWrappers.WrapUnknownEvent(handler);
        if (typeof(IWebhooksUpdatedEventHandler).IsAssignableFrom(handler))
            client.WebhooksUpdated += EventBinderWrappers.WrapWebhooksUpdated(handler);
        if (typeof(IClientErroredEventHandler).IsAssignableFrom(handler))
            client.ClientErrored += EventBinderWrappers.WrapClientErrored(handler);
        if (typeof(IAutoModerationRuleCreatedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleCreated += EventBinderWrappers.WrapAutoModerationRuleCreated(handler);
        if (typeof(IAutoModerationRuleUpdatedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleUpdated += EventBinderWrappers.WrapAutoModerationRuleUpdated(handler);
        if (typeof(IAutoModerationRuleDeletedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleDeleted += EventBinderWrappers.WrapAutoModerationRuleDeleted(handler);
        if (typeof(IAutoModerationRuleExecutedEventHandler).IsAssignableFrom(handler))
            client.AutoModerationRuleExecuted += EventBinderWrappers.WrapAutoModerationRuleExecuted(handler);
    }
}