using System;
using System.Collections.Generic;
using System.Linq;
using BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;

namespace UnitTests.BetterHosting.EventsNext;

public static partial class HandlerTypesTestData
{
    public static readonly Type[] EventHandlerBaseInterface = new[] { typeof(IDiscordEventHandler) };

    public static IEnumerable<Type> GenericEventHandlerTypes => EventArgTypes.Select(a => typeof(IDiscordEventHandler<>).MakeGenericType(a)).ToArray();
    public static IEnumerable<Type> SpecificHandlerInterfaces => SpecificHandlerInterfacesWithArgumentTypeTuple.Select(i => i.interfaceType);
    public static IEnumerable<Type> EventArgTypes => SpecificHandlerInterfacesWithArgumentTypeTuple.Select(i => i.argumentType);
    public static IEnumerable<object[]> SpecificHandlerInterfacesWithArgumentType => SpecificHandlerInterfacesWithArgumentTypeTuple.Select(i => new object[] { i.interfaceType, i.argumentType });
    private static readonly IEnumerable<(Type interfaceType, Type argumentType)> SpecificHandlerInterfacesWithArgumentTypeTuple =
    [
        (typeof(ISocketErroredEventHandler), typeof(SocketErrorEventArgs)),
        (typeof(ISocketOpenedEventHandler), typeof(SocketEventArgs)),
        (typeof(ISocketClosedEventHandler), typeof(SocketCloseEventArgs)),
        (typeof(ISessionCreatedEventHandler), typeof(SessionReadyEventArgs)),
        (typeof(ISessionResumedEventHandler), typeof(SessionReadyEventArgs)),
        (typeof(IHeartbeatedEventHandler), typeof(HeartbeatEventArgs)),
        (typeof(IZombiedEventHandler), typeof(ZombiedEventArgs)),
        (typeof(IApplicationCommandPermissionsUpdatedEventHandler), typeof(ApplicationCommandPermissionsUpdatedEventArgs)),
        (typeof(IChannelCreatedEventHandler), typeof(ChannelCreateEventArgs)),
        (typeof(IChannelUpdatedEventHandler), typeof(ChannelUpdateEventArgs)),
        (typeof(IChannelDeletedEventHandler), typeof(ChannelDeleteEventArgs)),
        (typeof(IDmChannelDeletedEventHandler), typeof(DmChannelDeleteEventArgs)),
        (typeof(IChannelPinsUpdatedEventHandler), typeof(ChannelPinsUpdateEventArgs)),
        (typeof(IGuildCreatedEventHandler), typeof(GuildCreateEventArgs)),
        (typeof(IGuildAvailableEventHandler), typeof(GuildCreateEventArgs)),
        (typeof(IGuildUpdatedEventHandler), typeof(GuildUpdateEventArgs)),
        (typeof(IGuildDeletedEventHandler), typeof(GuildDeleteEventArgs)),
        (typeof(IGuildUnavailableEventHandler), typeof(GuildDeleteEventArgs)),
        (typeof(IGuildDownloadCompletedEventHandler), typeof(GuildDownloadCompletedEventArgs)),
        (typeof(IGuildEmojisUpdatedEventHandler), typeof(GuildEmojisUpdateEventArgs)),
        (typeof(IGuildStickersUpdatedEventHandler), typeof(GuildStickersUpdateEventArgs)),
        (typeof(IGuildIntegrationsUpdatedEventHandler), typeof(GuildIntegrationsUpdateEventArgs)),
        (typeof(IGuildAuditLogCreatedEventHandler), typeof(GuildAuditLogCreatedEventArgs)),
        (typeof(IScheduledGuildEventCreatedEventHandler), typeof(ScheduledGuildEventCreateEventArgs)),
        (typeof(IScheduledGuildEventUpdatedEventHandler), typeof(ScheduledGuildEventUpdateEventArgs)),
        (typeof(IScheduledGuildEventDeletedEventHandler), typeof(ScheduledGuildEventDeleteEventArgs)),
        (typeof(IScheduledGuildEventCompletedEventHandler), typeof(ScheduledGuildEventCompletedEventArgs)),
        (typeof(IScheduledGuildEventUserAddedEventHandler), typeof(ScheduledGuildEventUserAddEventArgs)),
        (typeof(IScheduledGuildEventUserRemovedEventHandler), typeof(ScheduledGuildEventUserRemoveEventArgs)),
        (typeof(IGuildBanAddedEventHandler), typeof(GuildBanAddEventArgs)),
        (typeof(IGuildBanRemovedEventHandler), typeof(GuildBanRemoveEventArgs)),
        (typeof(IGuildMemberAddedEventHandler), typeof(GuildMemberAddEventArgs)),
        (typeof(IGuildMemberRemovedEventHandler), typeof(GuildMemberRemoveEventArgs)),
        (typeof(IGuildMemberUpdatedEventHandler), typeof(GuildMemberUpdateEventArgs)),
        (typeof(IGuildMembersChunkedEventHandler), typeof(GuildMembersChunkEventArgs)),
        (typeof(IGuildRoleCreatedEventHandler), typeof(GuildRoleCreateEventArgs)),
        (typeof(IGuildRoleUpdatedEventHandler), typeof(GuildRoleUpdateEventArgs)),
        (typeof(IGuildRoleDeletedEventHandler), typeof(GuildRoleDeleteEventArgs)),
        (typeof(IInviteCreatedEventHandler), typeof(InviteCreateEventArgs)),
        (typeof(IInviteDeletedEventHandler), typeof(InviteDeleteEventArgs)),
        (typeof(IMessageCreatedEventHandler), typeof(MessageCreateEventArgs)),
        //TODO: removed? (typeof(IMessageAcknowledgedEventHandler), typeof(MessageAcknowledgeEventArgs)),
        (typeof(IMessageUpdatedEventHandler), typeof(MessageUpdateEventArgs)),
        (typeof(IMessageDeletedEventHandler), typeof(MessageDeleteEventArgs)),
        (typeof(IMessagesBulkDeletedEventHandler), typeof(MessageBulkDeleteEventArgs)),
        (typeof(IMessageReactionAddedEventHandler), typeof(MessageReactionAddEventArgs)),
        (typeof(IMessageReactionRemovedEventHandler), typeof(MessageReactionRemoveEventArgs)),
        (typeof(IMessageReactionsClearedEventHandler), typeof(MessageReactionsClearEventArgs)),
        (typeof(IMessageReactionRemovedEmojiEventHandler), typeof(MessageReactionRemoveEmojiEventArgs)),
        (typeof(IPresenceUpdatedEventHandler), typeof(PresenceUpdateEventArgs)),
        (typeof(IUserSettingsUpdatedEventHandler), typeof(UserSettingsUpdateEventArgs)),
        (typeof(IUserUpdatedEventHandler), typeof(UserUpdateEventArgs)),
        (typeof(IVoiceStateUpdatedEventHandler), typeof(VoiceStateUpdateEventArgs)),
        (typeof(IVoiceServerUpdatedEventHandler), typeof(VoiceServerUpdateEventArgs)),
        (typeof(IThreadCreatedEventHandler), typeof(ThreadCreateEventArgs)),
        (typeof(IThreadUpdatedEventHandler), typeof(ThreadUpdateEventArgs)),
        (typeof(IThreadDeletedEventHandler), typeof(ThreadDeleteEventArgs)),
        (typeof(IThreadListSyncedEventHandler), typeof(ThreadListSyncEventArgs)),
        (typeof(IThreadMemberUpdatedEventHandler), typeof(ThreadMemberUpdateEventArgs)),
        (typeof(IThreadMembersUpdatedEventHandler), typeof(ThreadMembersUpdateEventArgs)),
        (typeof(IIntegrationCreatedEventHandler), typeof(IntegrationCreateEventArgs)),
        (typeof(IIntegrationUpdatedEventHandler), typeof(IntegrationUpdateEventArgs)),
        (typeof(IIntegrationDeletedEventHandler), typeof(IntegrationDeleteEventArgs)),
        (typeof(IStageInstanceCreatedEventHandler), typeof(StageInstanceCreateEventArgs)),
        (typeof(IStageInstanceUpdatedEventHandler), typeof(StageInstanceUpdateEventArgs)),
        (typeof(IStageInstanceDeletedEventHandler), typeof(StageInstanceDeleteEventArgs)),
        (typeof(IInteractionCreatedEventHandler), typeof(InteractionCreateEventArgs)),
        (typeof(IComponentInteractionCreatedEventHandler), typeof(ComponentInteractionCreateEventArgs)),
        (typeof(IModalSubmittedEventHandler), typeof(ModalSubmitEventArgs)),
        (typeof(IContextMenuInteractionCreatedEventHandler), typeof(ContextMenuInteractionCreateEventArgs)),
        (typeof(ITypingStartedEventHandler), typeof(TypingStartEventArgs)),
        (typeof(IUnknownEventEventHandler), typeof(UnknownEventArgs)),
        (typeof(IWebhooksUpdatedEventHandler), typeof(WebhooksUpdateEventArgs)),
        (typeof(IClientErroredEventHandler), typeof(ClientErrorEventArgs)),
        (typeof(IAutoModerationRuleCreatedEventHandler), typeof(AutoModerationRuleCreateEventArgs)),
        (typeof(IAutoModerationRuleUpdatedEventHandler), typeof(AutoModerationRuleUpdateEventArgs)),
        (typeof(IAutoModerationRuleDeletedEventHandler), typeof(AutoModerationRuleDeleteEventArgs)),
        (typeof(IAutoModerationRuleExecutedEventHandler), typeof(AutoModerationRuleExecuteEventArgs)),
    ];
}