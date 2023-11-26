#if false
using System;
using System.Collections.Immutable;
using BetterHosting.EventsNext;
using BetterHosting.EventsNext.Services;
using BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTests.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(EventsNextBetterHostExtensions.Helpers))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class EventsNextBetterHostExtensionsHelpersTests
{
    private static readonly ImmutableList<(Type interfaceType, Type argType)> implementedTypes = ImmutableList.CreateRange(
    [
        (interfaceType: typeof(ISocketErroredEventHandler), argType: typeof(SocketErrorEventArgs)),
        (interfaceType: typeof(ISocketOpenedEventHandler), argType: typeof(SocketEventArgs)),
        (interfaceType: typeof(ISocketClosedEventHandler), argType: typeof(SocketCloseEventArgs)),
        (interfaceType: typeof(ISessionCreatedEventHandler), argType: typeof(SessionReadyEventArgs)),
        (interfaceType: typeof(ISessionResumedEventHandler), argType: typeof(SessionReadyEventArgs)),
        (interfaceType: typeof(IHeartbeatedEventHandler), argType: typeof(HeartbeatEventArgs)),
        (interfaceType: typeof(IZombiedEventHandler), argType: typeof(ZombiedEventArgs)),
        (interfaceType: typeof(IApplicationCommandPermissionsUpdatedEventHandler), argType: typeof(ApplicationCommandPermissionsUpdatedEventArgs)),
        (interfaceType: typeof(IChannelCreatedEventHandler), argType: typeof(ChannelCreateEventArgs)),
        (interfaceType: typeof(IChannelUpdatedEventHandler), argType: typeof(ChannelUpdateEventArgs)),
        (interfaceType: typeof(IChannelDeletedEventHandler), argType: typeof(ChannelDeleteEventArgs)),
        (interfaceType: typeof(IDmChannelDeletedEventHandler), argType: typeof(DmChannelDeleteEventArgs)),
        (interfaceType: typeof(IChannelPinsUpdatedEventHandler), argType: typeof(ChannelPinsUpdateEventArgs)),
        (interfaceType: typeof(IGuildCreatedEventHandler), argType: typeof(GuildCreateEventArgs)),
        (interfaceType: typeof(IGuildAvailableEventHandler), argType: typeof(GuildCreateEventArgs)),
        (interfaceType: typeof(IGuildUpdatedEventHandler), argType: typeof(GuildUpdateEventArgs)),
        (interfaceType: typeof(IGuildDeletedEventHandler), argType: typeof(GuildDeleteEventArgs)),
        (interfaceType: typeof(IGuildUnavailableEventHandler), argType: typeof(GuildDeleteEventArgs)),
        (interfaceType: typeof(IGuildDownloadCompletedEventHandler), argType: typeof(GuildDownloadCompletedEventArgs)),
        (interfaceType: typeof(IGuildEmojisUpdatedEventHandler), argType: typeof(GuildEmojisUpdateEventArgs)),
        (interfaceType: typeof(IGuildStickersUpdatedEventHandler), argType: typeof(GuildStickersUpdateEventArgs)),
        (interfaceType: typeof(IGuildIntegrationsUpdatedEventHandler), argType: typeof(GuildIntegrationsUpdateEventArgs)),
        (interfaceType: typeof(IGuildAuditLogCreatedEventHandler), argType: typeof(GuildAuditLogCreatedEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventCreatedEventHandler), argType: typeof(ScheduledGuildEventCreateEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventUpdatedEventHandler), argType: typeof(ScheduledGuildEventUpdateEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventDeletedEventHandler), argType: typeof(ScheduledGuildEventDeleteEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventCompletedEventHandler), argType: typeof(ScheduledGuildEventCompletedEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventUserAddedEventHandler), argType: typeof(ScheduledGuildEventUserAddEventArgs)),
        (interfaceType: typeof(IScheduledGuildEventUserRemovedEventHandler), argType: typeof(ScheduledGuildEventUserRemoveEventArgs)),
        (interfaceType: typeof(IGuildBanAddedEventHandler), argType: typeof(GuildBanAddEventArgs)),
        (interfaceType: typeof(IGuildBanRemovedEventHandler), argType: typeof(GuildBanRemoveEventArgs)),
        (interfaceType: typeof(IGuildMemberAddedEventHandler), argType: typeof(GuildMemberAddEventArgs)),
        (interfaceType: typeof(IGuildMemberRemovedEventHandler), argType: typeof(GuildMemberRemoveEventArgs)),
        (interfaceType: typeof(IGuildMemberUpdatedEventHandler), argType: typeof(GuildMemberUpdateEventArgs)),
        (interfaceType: typeof(IGuildMembersChunkedEventHandler), argType: typeof(GuildMembersChunkEventArgs)),
        (interfaceType: typeof(IGuildRoleCreatedEventHandler), argType: typeof(GuildRoleCreateEventArgs)),
        (interfaceType: typeof(IGuildRoleUpdatedEventHandler), argType: typeof(GuildRoleUpdateEventArgs)),
        (interfaceType: typeof(IGuildRoleDeletedEventHandler), argType: typeof(GuildRoleDeleteEventArgs)),
        (interfaceType: typeof(IInviteCreatedEventHandler), argType: typeof(InviteCreateEventArgs)),
        (interfaceType: typeof(IInviteDeletedEventHandler), argType: typeof(InviteDeleteEventArgs)),
        (interfaceType: typeof(IMessageCreatedEventHandler), argType: typeof(MessageCreateEventArgs)),
        (interfaceType: typeof(IMessageAcknowledgedEventHandler), argType: typeof(MessageAcknowledgeEventArgs)),
        (interfaceType: typeof(IMessageUpdatedEventHandler), argType: typeof(MessageUpdateEventArgs)),
        (interfaceType: typeof(IMessageDeletedEventHandler), argType: typeof(MessageDeleteEventArgs)),
        (interfaceType: typeof(IMessagesBulkDeletedEventHandler), argType: typeof(MessageBulkDeleteEventArgs)),
        (interfaceType: typeof(IMessageReactionAddedEventHandler), argType: typeof(MessageReactionAddEventArgs)),
        (interfaceType: typeof(IMessageReactionRemovedEventHandler), argType: typeof(MessageReactionRemoveEventArgs)),
        (interfaceType: typeof(IMessageReactionsClearedEventHandler), argType: typeof(MessageReactionsClearEventArgs)),
        (interfaceType: typeof(IMessageReactionRemovedEmojiEventHandler), argType: typeof(MessageReactionRemoveEmojiEventArgs)),
        (interfaceType: typeof(IPresenceUpdatedEventHandler), argType: typeof(PresenceUpdateEventArgs)),
        (interfaceType: typeof(IUserSettingsUpdatedEventHandler), argType: typeof(UserSettingsUpdateEventArgs)),
        (interfaceType: typeof(IUserUpdatedEventHandler), argType: typeof(UserUpdateEventArgs)),
        (interfaceType: typeof(IVoiceStateUpdatedEventHandler), argType: typeof(VoiceStateUpdateEventArgs)),
        (interfaceType: typeof(IVoiceServerUpdatedEventHandler), argType: typeof(VoiceServerUpdateEventArgs)),
        (interfaceType: typeof(IThreadCreatedEventHandler), argType: typeof(ThreadCreateEventArgs)),
        (interfaceType: typeof(IThreadUpdatedEventHandler), argType: typeof(ThreadUpdateEventArgs)),
        (interfaceType: typeof(IThreadDeletedEventHandler), argType: typeof(ThreadDeleteEventArgs)),
        (interfaceType: typeof(IThreadListSyncedEventHandler), argType: typeof(ThreadListSyncEventArgs)),
        (interfaceType: typeof(IThreadMemberUpdatedEventHandler), argType: typeof(ThreadMemberUpdateEventArgs)),
        (interfaceType: typeof(IThreadMembersUpdatedEventHandler), argType: typeof(ThreadMembersUpdateEventArgs)),
        (interfaceType: typeof(IIntegrationCreatedEventHandler), argType: typeof(IntegrationCreateEventArgs)),
        (interfaceType: typeof(IIntegrationUpdatedEventHandler), argType: typeof(IntegrationUpdateEventArgs)),
        (interfaceType: typeof(IIntegrationDeletedEventHandler), argType: typeof(IntegrationDeleteEventArgs)),
        (interfaceType: typeof(IStageInstanceCreatedEventHandler), argType: typeof(StageInstanceCreateEventArgs)),
        (interfaceType: typeof(IStageInstanceUpdatedEventHandler), argType: typeof(StageInstanceUpdateEventArgs)),
        (interfaceType: typeof(IStageInstanceDeletedEventHandler), argType: typeof(StageInstanceDeleteEventArgs)),
        (interfaceType: typeof(IInteractionCreatedEventHandler), argType: typeof(InteractionCreateEventArgs)),
        (interfaceType: typeof(IComponentInteractionCreatedEventHandler), argType: typeof(ComponentInteractionCreateEventArgs)),
        (interfaceType: typeof(IModalSubmittedEventHandler), argType: typeof(ModalSubmitEventArgs)),
        (interfaceType: typeof(IContextMenuInteractionCreatedEventHandler), argType: typeof(ContextMenuInteractionCreateEventArgs)),
        (interfaceType: typeof(ITypingStartedEventHandler), argType: typeof(TypingStartEventArgs)),
        (interfaceType: typeof(IUnknownEventEventHandler), argType: typeof(UnknownEventArgs)),
        (interfaceType: typeof(IWebhooksUpdatedEventHandler), argType: typeof(WebhooksUpdateEventArgs)),
        (interfaceType: typeof(IClientErroredEventHandler), argType: typeof(ClientErrorEventArgs)),
        (interfaceType: typeof(IAutoModerationRuleCreatedEventHandler), argType: typeof(AutoModerationRuleCreateEventArgs)),
        (interfaceType: typeof(IAutoModerationRuleUpdatedEventHandler), argType: typeof(AutoModerationRuleUpdateEventArgs)),
        (interfaceType: typeof(IAutoModerationRuleDeletedEventHandler), argType: typeof(AutoModerationRuleDeleteEventArgs)),
        (interfaceType: typeof(IAutoModerationRuleExecutedEventHandler), argType: typeof(AutoModerationRuleExecuteEventArgs))
    ]);

    [Test]
    public void AddEventHandlersThrowsOnNull()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => EventsNextBetterHostExtensions.AddEventsNext(null!));
        Assert.That(ex.ParamName, Is.EqualTo("services"));
    }

    [Test]
    public void AddEventsNext()
    {
        const int fixedServiceCount = 2;
        const int servicesPerType = 2;
        int expectedServiceCount = fixedServiceCount + (servicesPerType * implementedTypes.Count);

        Mock<IServiceCollection> services = new(MockBehavior.Strict);
        services.Setup(s => s.Count)
            .Returns(0)
            .Verifiable(Times.Exactly(expectedServiceCount));

        services.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient(typeof(IHandlerRegistry), typeof(HandlerRegistry))))
            .Verifiable(Times.Once);
        services.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient(typeof(IHandlerRegistryKeyProvider), typeof(HandlerRegistryKeyProvider))))
            .Verifiable(Times.Once);

        foreach ((Type interfaceType, Type argType) in implementedTypes)
        {
            services.Setup(s => s.Add(It.Is<ServiceDescriptor>(d =>
                    d.Lifetime == ServiceLifetime.Singleton &&
                    d.ServiceType == typeof(IEventHandlerManager) &&
                    d.KeyedImplementationType == typeof(AutoCallEventHandlerManager<,>).MakeGenericType(interfaceType, argType) &&
                    d.ServiceKey != null && interfaceType.IsEquivalentTo(d.ServiceKey as Type))))
                .Verifiable(Times.Once);

            services.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<>).MakeGenericType(interfaceType))))
                .Verifiable(Times.Once);
        }

        IServiceCollection result = EventsNextBetterHostExtensions.AddEventsNext(services.Object);

        Assert.That(result, Is.SameAs(services.Object));
        services.Verify();
    }
}
#endif