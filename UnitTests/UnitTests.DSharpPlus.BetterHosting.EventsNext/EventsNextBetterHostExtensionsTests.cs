using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(EventsNextBetterHostExtensions))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class EventsNextBetterHostExtensionsTests
{
    private static readonly List<Type> ManagerTypes =
    [
        typeof(SocketErroredHandlerManager), typeof(SocketOpenedHandlerManager), typeof(SocketClosedHandlerManager),
        typeof(SessionCreatedHandlerManager), typeof(SessionResumedHandlerManager), typeof(HeartbeatedHandlerManager),
        typeof(ZombiedHandlerManager), typeof(ApplicationCommandPermissionsUpdatedHandlerManager), typeof(ChannelCreatedHandlerManager),
        typeof(ChannelUpdatedHandlerManager), typeof(ChannelDeletedHandlerManager), typeof(DmChannelDeletedHandlerManager),
        typeof(ChannelPinsUpdatedHandlerManager), typeof(GuildCreatedHandlerManager), typeof(GuildAvailableHandlerManager),
        typeof(GuildUpdatedHandlerManager), typeof(GuildDeletedHandlerManager), typeof(GuildUnavailableHandlerManager),
        typeof(GuildDownloadCompletedHandlerManager), typeof(GuildEmojisUpdatedHandlerManager), typeof(GuildStickersUpdatedHandlerManager),
        typeof(GuildIntegrationsUpdatedHandlerManager), typeof(GuildAuditLogCreatedHandlerManager), typeof(ScheduledGuildEventCreatedHandlerManager),
        typeof(ScheduledGuildEventUpdatedHandlerManager), typeof(ScheduledGuildEventDeletedHandlerManager), typeof(ScheduledGuildEventCompletedHandlerManager),
        typeof(ScheduledGuildEventUserAddedHandlerManager), typeof(ScheduledGuildEventUserRemovedHandlerManager), typeof(GuildBanAddedHandlerManager),
        typeof(GuildBanRemovedHandlerManager), typeof(GuildMemberAddedHandlerManager), typeof(GuildMemberRemovedHandlerManager), typeof(GuildMemberUpdatedHandlerManager),
        typeof(GuildMembersChunkedHandlerManager), typeof(GuildRoleCreatedHandlerManager), typeof(GuildRoleUpdatedHandlerManager), typeof(GuildRoleDeletedHandlerManager),
        typeof(InviteCreatedHandlerManager), typeof(InviteDeletedHandlerManager), typeof(MessageCreatedHandlerManager), typeof(MessageAcknowledgedHandlerManager),
        typeof(MessageUpdatedHandlerManager), typeof(MessageDeletedHandlerManager), typeof(MessagesBulkDeletedHandlerManager), typeof(MessageReactionAddedHandlerManager),
        typeof(MessageReactionRemovedHandlerManager), typeof(MessageReactionsClearedHandlerManager), typeof(MessageReactionRemovedEmojiHandlerManager),
        typeof(PresenceUpdatedHandlerManager), typeof(UserSettingsUpdatedHandlerManager), typeof(UserUpdatedHandlerManager), typeof(VoiceStateUpdatedHandlerManager),
        typeof(VoiceServerUpdatedHandlerManager), typeof(ThreadCreatedHandlerManager), typeof(ThreadUpdatedHandlerManager), typeof(ThreadDeletedHandlerManager),
        typeof(ThreadListSyncedHandlerManager), typeof(ThreadMemberUpdatedHandlerManager), typeof(ThreadMembersUpdatedHandlerManager), typeof(IntegrationCreatedHandlerManager),
        typeof(IntegrationUpdatedHandlerManager), typeof(IntegrationDeletedHandlerManager), typeof(StageInstanceCreatedHandlerManager),
        typeof(StageInstanceUpdatedHandlerManager), typeof(StageInstanceDeletedHandlerManager), typeof(InteractionCreatedHandlerManager),
        typeof(ComponentInteractionCreatedHandlerManager), typeof(ModalSubmittedHandlerManager), typeof(ContextMenuInteractionCreatedHandlerManager),
        typeof(TypingStartedHandlerManager), typeof(UnknownEventHandlerManager), typeof(WebhooksUpdatedHandlerManager), typeof(ClientErroredHandlerManager),
        typeof(AutoModerationRuleCreatedHandlerManager), typeof(AutoModerationRuleUpdatedHandlerManager), typeof(AutoModerationRuleDeletedHandlerManager),
        typeof(AutoModerationRuleExecutedHandlerManager)
    ];

    [Test]
    public void AddEventsNext()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        ManagerTypes.ForEach(managerType =>
        {
            mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(managerType)))
                .Verifiable(Times.Once);
            mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<>).MakeGenericType(managerType))))
                .Verifiable(Times.Once);
        });

        EventsNextBetterHostExtensions.AddEventsNext(mockServices.Object);

        mockServices.Verify();
    }
}