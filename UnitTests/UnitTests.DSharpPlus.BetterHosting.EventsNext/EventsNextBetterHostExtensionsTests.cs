using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext;
using Microsoft.Extensions.Hosting;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(EventsNextBetterHostExtensions))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class EventsNextBetterHostExtensionsTests
{
    private static void SetupFor_AddHostedHandlerCore<TManager, TEventInterface, TArgument>(Mock<IServiceCollection> mockServices)
        where TManager : EventHandlerManager<TEventInterface, TArgument>
        where TEventInterface : IDiscordEventHandler<TArgument>
        where TArgument : DiscordEventArgs
    {
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton<TManager>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton<IHostedService, EventsNextBackgroundHost<TManager>>()))
            .Verifiable(Times.Once);
    }
    [Test]
    public void AddEventsNext()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        SetupFor_AddHostedHandlerCore<SocketErroredHandlerManager, ISocketErroredEventHandler, SocketErrorEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<SocketOpenedHandlerManager, ISocketOpenedEventHandler, SocketEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<SocketClosedHandlerManager, ISocketClosedEventHandler, SocketCloseEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<SessionCreatedHandlerManager, ISessionCreatedEventHandler, SessionReadyEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<SessionResumedHandlerManager, ISessionResumedEventHandler, SessionReadyEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<HeartbeatedHandlerManager, IHeartbeatedEventHandler, HeartbeatEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ZombiedHandlerManager, IZombiedEventHandler, ZombiedEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ApplicationCommandPermissionsUpdatedHandlerManager, IApplicationCommandPermissionsUpdatedEventHandler, ApplicationCommandPermissionsUpdatedEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ChannelCreatedHandlerManager, IChannelCreatedEventHandler, ChannelCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ChannelUpdatedHandlerManager, IChannelUpdatedEventHandler, ChannelUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ChannelDeletedHandlerManager, IChannelDeletedEventHandler, ChannelDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<DmChannelDeletedHandlerManager, IDmChannelDeletedEventHandler, DmChannelDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ChannelPinsUpdatedHandlerManager, IChannelPinsUpdatedEventHandler, ChannelPinsUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildCreatedHandlerManager, IGuildCreatedEventHandler, GuildCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildAvailableHandlerManager, IGuildAvailableEventHandler, GuildCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildUpdatedHandlerManager, IGuildUpdatedEventHandler, GuildUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildDeletedHandlerManager, IGuildDeletedEventHandler, GuildDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildUnavailableHandlerManager, IGuildUnavailableEventHandler, GuildDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildDownloadCompletedHandlerManager, IGuildDownloadCompletedEventHandler, GuildDownloadCompletedEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildEmojisUpdatedHandlerManager, IGuildEmojisUpdatedEventHandler, GuildEmojisUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildStickersUpdatedHandlerManager, IGuildStickersUpdatedEventHandler, GuildStickersUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildIntegrationsUpdatedHandlerManager, IGuildIntegrationsUpdatedEventHandler, GuildIntegrationsUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildAuditLogCreatedHandlerManager, IGuildAuditLogCreatedEventHandler, GuildAuditLogCreatedEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventCreatedHandlerManager, IScheduledGuildEventCreatedEventHandler, ScheduledGuildEventCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventUpdatedHandlerManager, IScheduledGuildEventUpdatedEventHandler, ScheduledGuildEventUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventDeletedHandlerManager, IScheduledGuildEventDeletedEventHandler, ScheduledGuildEventDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventCompletedHandlerManager, IScheduledGuildEventCompletedEventHandler, ScheduledGuildEventCompletedEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventUserAddedHandlerManager, IScheduledGuildEventUserAddedEventHandler, ScheduledGuildEventUserAddEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ScheduledGuildEventUserRemovedHandlerManager, IScheduledGuildEventUserRemovedEventHandler, ScheduledGuildEventUserRemoveEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildBanAddedHandlerManager, IGuildBanAddedEventHandler, GuildBanAddEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildBanRemovedHandlerManager, IGuildBanRemovedEventHandler, GuildBanRemoveEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildMemberAddedHandlerManager, IGuildMemberAddedEventHandler, GuildMemberAddEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildMemberRemovedHandlerManager, IGuildMemberRemovedEventHandler, GuildMemberRemoveEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildMemberUpdatedHandlerManager, IGuildMemberUpdatedEventHandler, GuildMemberUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildMembersChunkedHandlerManager, IGuildMembersChunkedEventHandler, GuildMembersChunkEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildRoleCreatedHandlerManager, IGuildRoleCreatedEventHandler, GuildRoleCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildRoleUpdatedHandlerManager, IGuildRoleUpdatedEventHandler, GuildRoleUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<GuildRoleDeletedHandlerManager, IGuildRoleDeletedEventHandler, GuildRoleDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<InviteCreatedHandlerManager, IInviteCreatedEventHandler, InviteCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<InviteDeletedHandlerManager, IInviteDeletedEventHandler, InviteDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageCreatedHandlerManager, IMessageCreatedEventHandler, MessageCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageAcknowledgedHandlerManager, IMessageAcknowledgedEventHandler, MessageAcknowledgeEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageUpdatedHandlerManager, IMessageUpdatedEventHandler, MessageUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageDeletedHandlerManager, IMessageDeletedEventHandler, MessageDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessagesBulkDeletedHandlerManager, IMessagesBulkDeletedEventHandler, MessageBulkDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageReactionAddedHandlerManager, IMessageReactionAddedEventHandler, MessageReactionAddEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageReactionRemovedHandlerManager, IMessageReactionRemovedEventHandler, MessageReactionRemoveEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageReactionsClearedHandlerManager, IMessageReactionsClearedEventHandler, MessageReactionsClearEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<MessageReactionRemovedEmojiHandlerManager, IMessageReactionRemovedEmojiEventHandler, MessageReactionRemoveEmojiEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<PresenceUpdatedHandlerManager, IPresenceUpdatedEventHandler, PresenceUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<UserSettingsUpdatedHandlerManager, IUserSettingsUpdatedEventHandler, UserSettingsUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<UserUpdatedHandlerManager, IUserUpdatedEventHandler, UserUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<VoiceStateUpdatedHandlerManager, IVoiceStateUpdatedEventHandler, VoiceStateUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<VoiceServerUpdatedHandlerManager, IVoiceServerUpdatedEventHandler, VoiceServerUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadCreatedHandlerManager, IThreadCreatedEventHandler, ThreadCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadUpdatedHandlerManager, IThreadUpdatedEventHandler, ThreadUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadDeletedHandlerManager, IThreadDeletedEventHandler, ThreadDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadListSyncedHandlerManager, IThreadListSyncedEventHandler, ThreadListSyncEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadMemberUpdatedHandlerManager, IThreadMemberUpdatedEventHandler, ThreadMemberUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ThreadMembersUpdatedHandlerManager, IThreadMembersUpdatedEventHandler, ThreadMembersUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<IntegrationCreatedHandlerManager, IIntegrationCreatedEventHandler, IntegrationCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<IntegrationUpdatedHandlerManager, IIntegrationUpdatedEventHandler, IntegrationUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<IntegrationDeletedHandlerManager, IIntegrationDeletedEventHandler, IntegrationDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<StageInstanceCreatedHandlerManager, IStageInstanceCreatedEventHandler, StageInstanceCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<StageInstanceUpdatedHandlerManager, IStageInstanceUpdatedEventHandler, StageInstanceUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<StageInstanceDeletedHandlerManager, IStageInstanceDeletedEventHandler, StageInstanceDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<InteractionCreatedHandlerManager, IInteractionCreatedEventHandler, InteractionCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ComponentInteractionCreatedHandlerManager, IComponentInteractionCreatedEventHandler, ComponentInteractionCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ModalSubmittedHandlerManager, IModalSubmittedEventHandler, ModalSubmitEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ContextMenuInteractionCreatedHandlerManager, IContextMenuInteractionCreatedEventHandler, ContextMenuInteractionCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<TypingStartedHandlerManager, ITypingStartedEventHandler, TypingStartEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<UnknownEventHandlerManager, IUnknownEventEventHandler, UnknownEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<WebhooksUpdatedHandlerManager, IWebhooksUpdatedEventHandler, WebhooksUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<ClientErroredHandlerManager, IClientErroredEventHandler, ClientErrorEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<AutoModerationRuleCreatedHandlerManager, IAutoModerationRuleCreatedEventHandler, AutoModerationRuleCreateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<AutoModerationRuleUpdatedHandlerManager, IAutoModerationRuleUpdatedEventHandler, AutoModerationRuleUpdateEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<AutoModerationRuleDeletedHandlerManager, IAutoModerationRuleDeletedEventHandler, AutoModerationRuleDeleteEventArgs>(mockServices);
        SetupFor_AddHostedHandlerCore<AutoModerationRuleExecutedHandlerManager, IAutoModerationRuleExecutedEventHandler, AutoModerationRuleExecuteEventArgs>(mockServices);

        EventsNextBetterHostExtensions.AddEventsNext(mockServices.Object);

        mockServices.Verify();
    }
}