
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace BetterHosting.EventsNext.Services;

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.SocketErrored"/>
/// </summary>
public interface ISocketErroredEventHandler : IDiscordEventHandler<SocketErrorEventArgs>
{
    /// <inheritdoc cref="DiscordClient.SocketErrored"/>
    public ValueTask OnSocketErrored(DiscordClient client, SocketErrorEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.SocketOpened"/>
/// </summary>
public interface ISocketOpenedEventHandler : IDiscordEventHandler<SocketEventArgs>
{
    /// <inheritdoc cref="DiscordClient.SocketOpened"/>
    public ValueTask OnSocketOpened(DiscordClient client, SocketEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.SocketClosed"/>
/// </summary>
public interface ISocketClosedEventHandler : IDiscordEventHandler<SocketCloseEventArgs>
{
    /// <inheritdoc cref="DiscordClient.SocketClosed"/>
    public ValueTask OnSocketClosed(DiscordClient client, SocketCloseEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.SessionCreated"/>
/// </summary>
public interface ISessionCreatedEventHandler : IDiscordEventHandler<SessionReadyEventArgs>
{
    /// <inheritdoc cref="DiscordClient.SessionCreated"/>
    public ValueTask OnSessionCreated(DiscordClient client, SessionReadyEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.SessionResumed"/>
/// </summary>
public interface ISessionResumedEventHandler : IDiscordEventHandler<SessionReadyEventArgs>
{
    /// <inheritdoc cref="DiscordClient.SessionResumed"/>
    public ValueTask OnSessionResumed(DiscordClient client, SessionReadyEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.Heartbeated"/>
/// </summary>
public interface IHeartbeatedEventHandler : IDiscordEventHandler<HeartbeatEventArgs>
{
    /// <inheritdoc cref="DiscordClient.Heartbeated"/>
    public ValueTask OnHeartbeated(DiscordClient client, HeartbeatEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.Zombied"/>
/// </summary>
public interface IZombiedEventHandler : IDiscordEventHandler<ZombiedEventArgs>
{
    /// <inheritdoc cref="DiscordClient.Zombied"/>
    public ValueTask OnZombied(DiscordClient client, ZombiedEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ApplicationCommandPermissionsUpdated"/>
/// </summary>
public interface IApplicationCommandPermissionsUpdatedEventHandler : IDiscordEventHandler<ApplicationCommandPermissionsUpdatedEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ApplicationCommandPermissionsUpdated"/>
    public ValueTask OnApplicationCommandPermissionsUpdated(DiscordClient client, ApplicationCommandPermissionsUpdatedEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ChannelCreated"/>
/// </summary>
public interface IChannelCreatedEventHandler : IDiscordEventHandler<ChannelCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ChannelCreated"/>
    public ValueTask OnChannelCreated(DiscordClient client, ChannelCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ChannelUpdated"/>
/// </summary>
public interface IChannelUpdatedEventHandler : IDiscordEventHandler<ChannelUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ChannelUpdated"/>
    public ValueTask OnChannelUpdated(DiscordClient client, ChannelUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ChannelDeleted"/>
/// </summary>
public interface IChannelDeletedEventHandler : IDiscordEventHandler<ChannelDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ChannelDeleted"/>
    public ValueTask OnChannelDeleted(DiscordClient client, ChannelDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.DmChannelDeleted"/>
/// </summary>
public interface IDmChannelDeletedEventHandler : IDiscordEventHandler<DmChannelDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.DmChannelDeleted"/>
    public ValueTask OnDmChannelDeleted(DiscordClient client, DmChannelDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ChannelPinsUpdated"/>
/// </summary>
public interface IChannelPinsUpdatedEventHandler : IDiscordEventHandler<ChannelPinsUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ChannelPinsUpdated"/>
    public ValueTask OnChannelPinsUpdated(DiscordClient client, ChannelPinsUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildCreated"/>
/// </summary>
public interface IGuildCreatedEventHandler : IDiscordEventHandler<GuildCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildCreated"/>
    public ValueTask OnGuildCreated(DiscordClient client, GuildCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildAvailable"/>
/// </summary>
public interface IGuildAvailableEventHandler : IDiscordEventHandler<GuildCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildAvailable"/>
    public ValueTask OnGuildAvailable(DiscordClient client, GuildCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildUpdated"/>
/// </summary>
public interface IGuildUpdatedEventHandler : IDiscordEventHandler<GuildUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildUpdated"/>
    public ValueTask OnGuildUpdated(DiscordClient client, GuildUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildDeleted"/>
/// </summary>
public interface IGuildDeletedEventHandler : IDiscordEventHandler<GuildDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildDeleted"/>
    public ValueTask OnGuildDeleted(DiscordClient client, GuildDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildUnavailable"/>
/// </summary>
public interface IGuildUnavailableEventHandler : IDiscordEventHandler<GuildDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildUnavailable"/>
    public ValueTask OnGuildUnavailable(DiscordClient client, GuildDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildDownloadCompleted"/>
/// </summary>
public interface IGuildDownloadCompletedEventHandler : IDiscordEventHandler<GuildDownloadCompletedEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildDownloadCompleted"/>
    public ValueTask OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildEmojisUpdated"/>
/// </summary>
public interface IGuildEmojisUpdatedEventHandler : IDiscordEventHandler<GuildEmojisUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildEmojisUpdated"/>
    public ValueTask OnGuildEmojisUpdated(DiscordClient client, GuildEmojisUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildStickersUpdated"/>
/// </summary>
public interface IGuildStickersUpdatedEventHandler : IDiscordEventHandler<GuildStickersUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildStickersUpdated"/>
    public ValueTask OnGuildStickersUpdated(DiscordClient client, GuildStickersUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildIntegrationsUpdated"/>
/// </summary>
public interface IGuildIntegrationsUpdatedEventHandler : IDiscordEventHandler<GuildIntegrationsUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildIntegrationsUpdated"/>
    public ValueTask OnGuildIntegrationsUpdated(DiscordClient client, GuildIntegrationsUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildAuditLogCreated"/>
/// </summary>
public interface IGuildAuditLogCreatedEventHandler : IDiscordEventHandler<GuildAuditLogCreatedEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildAuditLogCreated"/>
    public ValueTask OnGuildAuditLogCreated(DiscordClient client, GuildAuditLogCreatedEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventCreated"/>
/// </summary>
public interface IScheduledGuildEventCreatedEventHandler : IDiscordEventHandler<ScheduledGuildEventCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventCreated"/>
    public ValueTask OnScheduledGuildEventCreated(DiscordClient client, ScheduledGuildEventCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventUpdated"/>
/// </summary>
public interface IScheduledGuildEventUpdatedEventHandler : IDiscordEventHandler<ScheduledGuildEventUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUpdated"/>
    public ValueTask OnScheduledGuildEventUpdated(DiscordClient client, ScheduledGuildEventUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventDeleted"/>
/// </summary>
public interface IScheduledGuildEventDeletedEventHandler : IDiscordEventHandler<ScheduledGuildEventDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventDeleted"/>
    public ValueTask OnScheduledGuildEventDeleted(DiscordClient client, ScheduledGuildEventDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventCompleted"/>
/// </summary>
public interface IScheduledGuildEventCompletedEventHandler : IDiscordEventHandler<ScheduledGuildEventCompletedEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventCompleted"/>
    public ValueTask OnScheduledGuildEventCompleted(DiscordClient client, ScheduledGuildEventCompletedEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventUserAdded"/>
/// </summary>
public interface IScheduledGuildEventUserAddedEventHandler : IDiscordEventHandler<ScheduledGuildEventUserAddEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUserAdded"/>
    public ValueTask OnScheduledGuildEventUserAdded(DiscordClient client, ScheduledGuildEventUserAddEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ScheduledGuildEventUserRemoved"/>
/// </summary>
public interface IScheduledGuildEventUserRemovedEventHandler : IDiscordEventHandler<ScheduledGuildEventUserRemoveEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUserRemoved"/>
    public ValueTask OnScheduledGuildEventUserRemoved(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildBanAdded"/>
/// </summary>
public interface IGuildBanAddedEventHandler : IDiscordEventHandler<GuildBanAddEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildBanAdded"/>
    public ValueTask OnGuildBanAdded(DiscordClient client, GuildBanAddEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildBanRemoved"/>
/// </summary>
public interface IGuildBanRemovedEventHandler : IDiscordEventHandler<GuildBanRemoveEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildBanRemoved"/>
    public ValueTask OnGuildBanRemoved(DiscordClient client, GuildBanRemoveEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildMemberAdded"/>
/// </summary>
public interface IGuildMemberAddedEventHandler : IDiscordEventHandler<GuildMemberAddEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildMemberAdded"/>
    public ValueTask OnGuildMemberAdded(DiscordClient client, GuildMemberAddEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildMemberRemoved"/>
/// </summary>
public interface IGuildMemberRemovedEventHandler : IDiscordEventHandler<GuildMemberRemoveEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildMemberRemoved"/>
    public ValueTask OnGuildMemberRemoved(DiscordClient client, GuildMemberRemoveEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildMemberUpdated"/>
/// </summary>
public interface IGuildMemberUpdatedEventHandler : IDiscordEventHandler<GuildMemberUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildMemberUpdated"/>
    public ValueTask OnGuildMemberUpdated(DiscordClient client, GuildMemberUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildMembersChunked"/>
/// </summary>
public interface IGuildMembersChunkedEventHandler : IDiscordEventHandler<GuildMembersChunkEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildMembersChunked"/>
    public ValueTask OnGuildMembersChunked(DiscordClient client, GuildMembersChunkEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildRoleCreated"/>
/// </summary>
public interface IGuildRoleCreatedEventHandler : IDiscordEventHandler<GuildRoleCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildRoleCreated"/>
    public ValueTask OnGuildRoleCreated(DiscordClient client, GuildRoleCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildRoleUpdated"/>
/// </summary>
public interface IGuildRoleUpdatedEventHandler : IDiscordEventHandler<GuildRoleUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildRoleUpdated"/>
    public ValueTask OnGuildRoleUpdated(DiscordClient client, GuildRoleUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.GuildRoleDeleted"/>
/// </summary>
public interface IGuildRoleDeletedEventHandler : IDiscordEventHandler<GuildRoleDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.GuildRoleDeleted"/>
    public ValueTask OnGuildRoleDeleted(DiscordClient client, GuildRoleDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.InviteCreated"/>
/// </summary>
public interface IInviteCreatedEventHandler : IDiscordEventHandler<InviteCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.InviteCreated"/>
    public ValueTask OnInviteCreated(DiscordClient client, InviteCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.InviteDeleted"/>
/// </summary>
public interface IInviteDeletedEventHandler : IDiscordEventHandler<InviteDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.InviteDeleted"/>
    public ValueTask OnInviteDeleted(DiscordClient client, InviteDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageCreated"/>
/// </summary>
public interface IMessageCreatedEventHandler : IDiscordEventHandler<MessageCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageCreated"/>
    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageUpdated"/>
/// </summary>
public interface IMessageUpdatedEventHandler : IDiscordEventHandler<MessageUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageUpdated"/>
    public ValueTask OnMessageUpdated(DiscordClient client, MessageUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageDeleted"/>
/// </summary>
public interface IMessageDeletedEventHandler : IDiscordEventHandler<MessageDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageDeleted"/>
    public ValueTask OnMessageDeleted(DiscordClient client, MessageDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessagesBulkDeleted"/>
/// </summary>
public interface IMessagesBulkDeletedEventHandler : IDiscordEventHandler<MessageBulkDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessagesBulkDeleted"/>
    public ValueTask OnMessagesBulkDeleted(DiscordClient client, MessageBulkDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageReactionAdded"/>
/// </summary>
public interface IMessageReactionAddedEventHandler : IDiscordEventHandler<MessageReactionAddEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageReactionAdded"/>
    public ValueTask OnMessageReactionAdded(DiscordClient client, MessageReactionAddEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageReactionRemoved"/>
/// </summary>
public interface IMessageReactionRemovedEventHandler : IDiscordEventHandler<MessageReactionRemoveEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageReactionRemoved"/>
    public ValueTask OnMessageReactionRemoved(DiscordClient client, MessageReactionRemoveEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageReactionsCleared"/>
/// </summary>
public interface IMessageReactionsClearedEventHandler : IDiscordEventHandler<MessageReactionsClearEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageReactionsCleared"/>
    public ValueTask OnMessageReactionsCleared(DiscordClient client, MessageReactionsClearEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.MessageReactionRemovedEmoji"/>
/// </summary>
public interface IMessageReactionRemovedEmojiEventHandler : IDiscordEventHandler<MessageReactionRemoveEmojiEventArgs>
{
    /// <inheritdoc cref="DiscordClient.MessageReactionRemovedEmoji"/>
    public ValueTask OnMessageReactionRemovedEmoji(DiscordClient client, MessageReactionRemoveEmojiEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.PresenceUpdated"/>
/// </summary>
public interface IPresenceUpdatedEventHandler : IDiscordEventHandler<PresenceUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.PresenceUpdated"/>
    public ValueTask OnPresenceUpdated(DiscordClient client, PresenceUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.UserSettingsUpdated"/>
/// </summary>
public interface IUserSettingsUpdatedEventHandler : IDiscordEventHandler<UserSettingsUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.UserSettingsUpdated"/>
    public ValueTask OnUserSettingsUpdated(DiscordClient client, UserSettingsUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.UserUpdated"/>
/// </summary>
public interface IUserUpdatedEventHandler : IDiscordEventHandler<UserUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.UserUpdated"/>
    public ValueTask OnUserUpdated(DiscordClient client, UserUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.VoiceStateUpdated"/>
/// </summary>
public interface IVoiceStateUpdatedEventHandler : IDiscordEventHandler<VoiceStateUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.VoiceStateUpdated"/>
    public ValueTask OnVoiceStateUpdated(DiscordClient client, VoiceStateUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.VoiceServerUpdated"/>
/// </summary>
public interface IVoiceServerUpdatedEventHandler : IDiscordEventHandler<VoiceServerUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.VoiceServerUpdated"/>
    public ValueTask OnVoiceServerUpdated(DiscordClient client, VoiceServerUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadCreated"/>
/// </summary>
public interface IThreadCreatedEventHandler : IDiscordEventHandler<ThreadCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadCreated"/>
    public ValueTask OnThreadCreated(DiscordClient client, ThreadCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadUpdated"/>
/// </summary>
public interface IThreadUpdatedEventHandler : IDiscordEventHandler<ThreadUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadUpdated"/>
    public ValueTask OnThreadUpdated(DiscordClient client, ThreadUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadDeleted"/>
/// </summary>
public interface IThreadDeletedEventHandler : IDiscordEventHandler<ThreadDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadDeleted"/>
    public ValueTask OnThreadDeleted(DiscordClient client, ThreadDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadListSynced"/>
/// </summary>
public interface IThreadListSyncedEventHandler : IDiscordEventHandler<ThreadListSyncEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadListSynced"/>
    public ValueTask OnThreadListSynced(DiscordClient client, ThreadListSyncEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadMemberUpdated"/>
/// </summary>
public interface IThreadMemberUpdatedEventHandler : IDiscordEventHandler<ThreadMemberUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadMemberUpdated"/>
    public ValueTask OnThreadMemberUpdated(DiscordClient client, ThreadMemberUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ThreadMembersUpdated"/>
/// </summary>
public interface IThreadMembersUpdatedEventHandler : IDiscordEventHandler<ThreadMembersUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ThreadMembersUpdated"/>
    public ValueTask OnThreadMembersUpdated(DiscordClient client, ThreadMembersUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.IntegrationCreated"/>
/// </summary>
public interface IIntegrationCreatedEventHandler : IDiscordEventHandler<IntegrationCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.IntegrationCreated"/>
    public ValueTask OnIntegrationCreated(DiscordClient client, IntegrationCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.IntegrationUpdated"/>
/// </summary>
public interface IIntegrationUpdatedEventHandler : IDiscordEventHandler<IntegrationUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.IntegrationUpdated"/>
    public ValueTask OnIntegrationUpdated(DiscordClient client, IntegrationUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.IntegrationDeleted"/>
/// </summary>
public interface IIntegrationDeletedEventHandler : IDiscordEventHandler<IntegrationDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.IntegrationDeleted"/>
    public ValueTask OnIntegrationDeleted(DiscordClient client, IntegrationDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.StageInstanceCreated"/>
/// </summary>
public interface IStageInstanceCreatedEventHandler : IDiscordEventHandler<StageInstanceCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.StageInstanceCreated"/>
    public ValueTask OnStageInstanceCreated(DiscordClient client, StageInstanceCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.StageInstanceUpdated"/>
/// </summary>
public interface IStageInstanceUpdatedEventHandler : IDiscordEventHandler<StageInstanceUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.StageInstanceUpdated"/>
    public ValueTask OnStageInstanceUpdated(DiscordClient client, StageInstanceUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.StageInstanceDeleted"/>
/// </summary>
public interface IStageInstanceDeletedEventHandler : IDiscordEventHandler<StageInstanceDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.StageInstanceDeleted"/>
    public ValueTask OnStageInstanceDeleted(DiscordClient client, StageInstanceDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.InteractionCreated"/>
/// </summary>
public interface IInteractionCreatedEventHandler : IDiscordEventHandler<InteractionCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.InteractionCreated"/>
    public ValueTask OnInteractionCreated(DiscordClient client, InteractionCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ComponentInteractionCreated"/>
/// </summary>
public interface IComponentInteractionCreatedEventHandler : IDiscordEventHandler<ComponentInteractionCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ComponentInteractionCreated"/>
    public ValueTask OnComponentInteractionCreated(DiscordClient client, ComponentInteractionCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ModalSubmitted"/>
/// </summary>
public interface IModalSubmittedEventHandler : IDiscordEventHandler<ModalSubmitEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ModalSubmitted"/>
    public ValueTask OnModalSubmitted(DiscordClient client, ModalSubmitEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ContextMenuInteractionCreated"/>
/// </summary>
public interface IContextMenuInteractionCreatedEventHandler : IDiscordEventHandler<ContextMenuInteractionCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ContextMenuInteractionCreated"/>
    public ValueTask OnContextMenuInteractionCreated(DiscordClient client, ContextMenuInteractionCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.TypingStarted"/>
/// </summary>
public interface ITypingStartedEventHandler : IDiscordEventHandler<TypingStartEventArgs>
{
    /// <inheritdoc cref="DiscordClient.TypingStarted"/>
    public ValueTask OnTypingStarted(DiscordClient client, TypingStartEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.UnknownEvent"/>
/// </summary>
public interface IUnknownEventEventHandler : IDiscordEventHandler<UnknownEventArgs>
{
    /// <inheritdoc cref="DiscordClient.UnknownEvent"/>
    public ValueTask OnUnknownEvent(DiscordClient client, UnknownEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.WebhooksUpdated"/>
/// </summary>
public interface IWebhooksUpdatedEventHandler : IDiscordEventHandler<WebhooksUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.WebhooksUpdated"/>
    public ValueTask OnWebhooksUpdated(DiscordClient client, WebhooksUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.ClientErrored"/>
/// </summary>
public interface IClientErroredEventHandler : IDiscordEventHandler<ClientErrorEventArgs>
{
    /// <inheritdoc cref="DiscordClient.ClientErrored"/>
    public ValueTask OnClientErrored(DiscordClient client, ClientErrorEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.AutoModerationRuleCreated"/>
/// </summary>
public interface IAutoModerationRuleCreatedEventHandler : IDiscordEventHandler<AutoModerationRuleCreateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleCreated"/>
    public ValueTask OnAutoModerationRuleCreated(DiscordClient client, AutoModerationRuleCreateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.AutoModerationRuleUpdated"/>
/// </summary>
public interface IAutoModerationRuleUpdatedEventHandler : IDiscordEventHandler<AutoModerationRuleUpdateEventArgs>
{
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleUpdated"/>
    public ValueTask OnAutoModerationRuleUpdated(DiscordClient client, AutoModerationRuleUpdateEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.AutoModerationRuleDeleted"/>
/// </summary>
public interface IAutoModerationRuleDeletedEventHandler : IDiscordEventHandler<AutoModerationRuleDeleteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleDeleted"/>
    public ValueTask OnAutoModerationRuleDeleted(DiscordClient client, AutoModerationRuleDeleteEventArgs args);
}

/// <summary>
/// Event handler for the discord event <see cref="DiscordShardedClient.AutoModerationRuleExecuted"/>
/// </summary>
public interface IAutoModerationRuleExecutedEventHandler : IDiscordEventHandler<AutoModerationRuleExecuteEventArgs>
{
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleExecuted"/>
    public ValueTask OnAutoModerationRuleExecuted(DiscordClient client, AutoModerationRuleExecuteEventArgs args);
}
