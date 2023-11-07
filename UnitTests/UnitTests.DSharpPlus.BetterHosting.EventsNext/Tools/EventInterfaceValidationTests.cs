using System;
using System.Reflection;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

file static class EventInterfaceValidationTestTypes
{
    public static readonly Type[] Types = new[]
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
[TestFixtureSource(typeof(EventInterfaceValidationTestTypes), nameof(EventInterfaceValidationTestTypes.Types))]
public class EventInterfaceValidationTests
{
    private static readonly MethodInfo genericMethod = typeof(EventInterfaceValidation).GetMethod(nameof(EventInterfaceValidation.IsExactInterface), BindingFlags.Static | BindingFlags.Public, Type.EmptyTypes)!;

    private readonly Type interfaceType;
    private readonly Func<bool> IsExactInterfaceGenericDelegate;

    public EventInterfaceValidationTests(Type interfaceType)
    {
        this.interfaceType = interfaceType;
        IsExactInterfaceGenericDelegate = genericMethod.MakeGenericMethod(interfaceType).CreateDelegate<Func<bool>>();
    }

    [Test]
    public void IsExactInterface_Generic()
    {
        bool isExact = IsExactInterfaceGenericDelegate();
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void IsExactInterface_ByType()
    {
        bool isExact = EventInterfaceValidation.IsExactInterface(interfaceType);
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void VerifyExactInterface_Generic() => Assert.DoesNotThrow(() => IsExactInterfaceGenericDelegate.Invoke());

    [Test]
    public void VerifyExactInterface_ByType() => Assert.DoesNotThrow(() => HandlerVerification.VerifyExactInterface(interfaceType));
}
