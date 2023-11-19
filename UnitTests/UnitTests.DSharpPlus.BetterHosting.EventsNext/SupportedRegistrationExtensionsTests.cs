using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using UnitTests.DSharpPlus.BetterHosting.EventsNext;
using System;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using System.Collections.Generic;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(RegistrationExtensions))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class SupportedRegistrationExtensionsTests<TEventInterface> where TEventInterface : class, IDiscordEventHandler
{
    private static readonly Dictionary<Type, Type> TypeDict = new()
    {
        { typeof(ISocketErroredEventHandler), typeof(SocketErroredHandlerManager) },
        { typeof(ISocketOpenedEventHandler), typeof(SocketOpenedHandlerManager) },
        { typeof(ISocketClosedEventHandler), typeof(SocketClosedHandlerManager) },
        { typeof(ISessionCreatedEventHandler), typeof(SessionCreatedHandlerManager) },
        { typeof(ISessionResumedEventHandler), typeof(SessionResumedHandlerManager) },
        { typeof(IHeartbeatedEventHandler), typeof(HeartbeatedHandlerManager) },
        { typeof(IZombiedEventHandler), typeof(ZombiedHandlerManager) },
        { typeof(IApplicationCommandPermissionsUpdatedEventHandler), typeof(ApplicationCommandPermissionsUpdatedHandlerManager) },
        { typeof(IChannelCreatedEventHandler), typeof(ChannelCreatedHandlerManager) },
        { typeof(IChannelUpdatedEventHandler), typeof(ChannelUpdatedHandlerManager) },
        { typeof(IChannelDeletedEventHandler), typeof(ChannelDeletedHandlerManager) },
        { typeof(IDmChannelDeletedEventHandler), typeof(DmChannelDeletedHandlerManager) },
        { typeof(IChannelPinsUpdatedEventHandler), typeof(ChannelPinsUpdatedHandlerManager) },
        { typeof(IGuildCreatedEventHandler), typeof(GuildCreatedHandlerManager) },
        { typeof(IGuildAvailableEventHandler), typeof(GuildAvailableHandlerManager) },
        { typeof(IGuildUpdatedEventHandler), typeof(GuildUpdatedHandlerManager) },
        { typeof(IGuildDeletedEventHandler), typeof(GuildDeletedHandlerManager) },
        { typeof(IGuildUnavailableEventHandler), typeof(GuildUnavailableHandlerManager) },
        { typeof(IGuildDownloadCompletedEventHandler), typeof(GuildDownloadCompletedHandlerManager) },
        { typeof(IGuildEmojisUpdatedEventHandler), typeof(GuildEmojisUpdatedHandlerManager) },
        { typeof(IGuildStickersUpdatedEventHandler), typeof(GuildStickersUpdatedHandlerManager) },
        { typeof(IGuildIntegrationsUpdatedEventHandler), typeof(GuildIntegrationsUpdatedHandlerManager) },
        { typeof(IGuildAuditLogCreatedEventHandler), typeof(GuildAuditLogCreatedHandlerManager) },
        { typeof(IScheduledGuildEventCreatedEventHandler), typeof(ScheduledGuildEventCreatedHandlerManager) },
        { typeof(IScheduledGuildEventUpdatedEventHandler), typeof(ScheduledGuildEventUpdatedHandlerManager) },
        { typeof(IScheduledGuildEventDeletedEventHandler), typeof(ScheduledGuildEventDeletedHandlerManager) },
        { typeof(IScheduledGuildEventCompletedEventHandler), typeof(ScheduledGuildEventCompletedHandlerManager) },
        { typeof(IScheduledGuildEventUserAddedEventHandler), typeof(ScheduledGuildEventUserAddedHandlerManager) },
        { typeof(IScheduledGuildEventUserRemovedEventHandler), typeof(ScheduledGuildEventUserRemovedHandlerManager) },
        { typeof(IGuildBanAddedEventHandler), typeof(GuildBanAddedHandlerManager) },
        { typeof(IGuildBanRemovedEventHandler), typeof(GuildBanRemovedHandlerManager) },
        { typeof(IGuildMemberAddedEventHandler), typeof(GuildMemberAddedHandlerManager) },
        { typeof(IGuildMemberRemovedEventHandler), typeof(GuildMemberRemovedHandlerManager) },
        { typeof(IGuildMemberUpdatedEventHandler), typeof(GuildMemberUpdatedHandlerManager) },
        { typeof(IGuildMembersChunkedEventHandler), typeof(GuildMembersChunkedHandlerManager) },
        { typeof(IGuildRoleCreatedEventHandler), typeof(GuildRoleCreatedHandlerManager) },
        { typeof(IGuildRoleUpdatedEventHandler), typeof(GuildRoleUpdatedHandlerManager) },
        { typeof(IGuildRoleDeletedEventHandler), typeof(GuildRoleDeletedHandlerManager) },
        { typeof(IInviteCreatedEventHandler), typeof(InviteCreatedHandlerManager) },
        { typeof(IInviteDeletedEventHandler), typeof(InviteDeletedHandlerManager) },
        { typeof(IMessageCreatedEventHandler), typeof(MessageCreatedHandlerManager) },
        { typeof(IMessageAcknowledgedEventHandler), typeof(MessageAcknowledgedHandlerManager) },
        { typeof(IMessageUpdatedEventHandler), typeof(MessageUpdatedHandlerManager) },
        { typeof(IMessageDeletedEventHandler), typeof(MessageDeletedHandlerManager) },
        { typeof(IMessagesBulkDeletedEventHandler), typeof(MessagesBulkDeletedHandlerManager) },
        { typeof(IMessageReactionAddedEventHandler), typeof(MessageReactionAddedHandlerManager) },
        { typeof(IMessageReactionRemovedEventHandler), typeof(MessageReactionRemovedHandlerManager) },
        { typeof(IMessageReactionsClearedEventHandler), typeof(MessageReactionsClearedHandlerManager) },
        { typeof(IMessageReactionRemovedEmojiEventHandler), typeof(MessageReactionRemovedEmojiHandlerManager) },
        { typeof(IPresenceUpdatedEventHandler), typeof(PresenceUpdatedHandlerManager) },
        { typeof(IUserSettingsUpdatedEventHandler), typeof(UserSettingsUpdatedHandlerManager) },
        { typeof(IUserUpdatedEventHandler), typeof(UserUpdatedHandlerManager) },
        { typeof(IVoiceStateUpdatedEventHandler), typeof(VoiceStateUpdatedHandlerManager) },
        { typeof(IVoiceServerUpdatedEventHandler), typeof(VoiceServerUpdatedHandlerManager) },
        { typeof(IThreadCreatedEventHandler), typeof(ThreadCreatedHandlerManager) },
        { typeof(IThreadUpdatedEventHandler), typeof(ThreadUpdatedHandlerManager) },
        { typeof(IThreadDeletedEventHandler), typeof(ThreadDeletedHandlerManager) },
        { typeof(IThreadListSyncedEventHandler), typeof(ThreadListSyncedHandlerManager) },
        { typeof(IThreadMemberUpdatedEventHandler), typeof(ThreadMemberUpdatedHandlerManager) },
        { typeof(IThreadMembersUpdatedEventHandler), typeof(ThreadMembersUpdatedHandlerManager) },
        { typeof(IIntegrationCreatedEventHandler), typeof(IntegrationCreatedHandlerManager) },
        { typeof(IIntegrationUpdatedEventHandler), typeof(IntegrationUpdatedHandlerManager) },
        { typeof(IIntegrationDeletedEventHandler), typeof(IntegrationDeletedHandlerManager) },
        { typeof(IStageInstanceCreatedEventHandler), typeof(StageInstanceCreatedHandlerManager) },
        { typeof(IStageInstanceUpdatedEventHandler), typeof(StageInstanceUpdatedHandlerManager) },
        { typeof(IStageInstanceDeletedEventHandler), typeof(StageInstanceDeletedHandlerManager) },
        { typeof(IInteractionCreatedEventHandler), typeof(InteractionCreatedHandlerManager) },
        { typeof(IComponentInteractionCreatedEventHandler), typeof(ComponentInteractionCreatedHandlerManager) },
        { typeof(IModalSubmittedEventHandler), typeof(ModalSubmittedHandlerManager) },
        { typeof(IContextMenuInteractionCreatedEventHandler), typeof(ContextMenuInteractionCreatedHandlerManager) },
        { typeof(ITypingStartedEventHandler), typeof(TypingStartedHandlerManager) },
        { typeof(IUnknownEventEventHandler), typeof(UnknownEventHandlerManager) },
        { typeof(IWebhooksUpdatedEventHandler), typeof(WebhooksUpdatedHandlerManager) },
        { typeof(IClientErroredEventHandler), typeof(ClientErroredHandlerManager) },
        { typeof(IAutoModerationRuleCreatedEventHandler), typeof(AutoModerationRuleCreatedHandlerManager) },
        { typeof(IAutoModerationRuleUpdatedEventHandler), typeof(AutoModerationRuleUpdatedHandlerManager) },
        { typeof(IAutoModerationRuleDeletedEventHandler), typeof(AutoModerationRuleDeletedHandlerManager) },
        { typeof(IAutoModerationRuleExecutedEventHandler), typeof(AutoModerationRuleExecutedHandlerManager) },
    };

    [Test]
    public void AddEventHandlersThrowsOnNull()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => RegistrationExtensions.AddEventHandlers<TEventInterface>(null!));

        Assert.That(ex.ParamName, Is.EqualTo("services"));
    }

    [Test]
    public void ConstructorDoesNothing()
    {
        Assert.That(TypeDict.TryGetValue(typeof(TEventInterface), out Type? managerType), Is.True, "Handler manager was not found in the testing dictionary");
        Debug.Assert(managerType != null);

        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        mockServices.Verify();

        Assert.That(result, Is.Not.Null);
    }

#if false
    [Test]
    public void AddEventHandler()
    {
        Assert.That(TypeDict.TryGetValue(typeof(TEventInterface), out Type? managerType), Is.True, "Handler manager was not found in the testing dictionary");
        Debug.Assert(managerType != null);

        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        mockServices.Setup(s => s.Count).Returns(0);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Instance.AddAnySingleton<HandlerRegistry<TEventInterface>>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(managerType)))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<>).MakeGenericType(managerType))))
            .Verifiable(Times.Once);

        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        mockServices.Verify();

        Assert.That(result, Is.Not.Null);
    }
#endif
}
