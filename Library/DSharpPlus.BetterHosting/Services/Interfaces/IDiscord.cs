using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IDiscord
{
    //
    // Summary:
    //     Gets the string representing the version of D#+.
    public string VersionString { get; }

    //
    // Summary:
    //     Gets the gateway protocol version.
    public int GatewayVersion { get; /*internal set;*/ }

    //
    // Summary:
    //     Gets the logger for this client.
    public ILogger<BaseDiscordClient> Logger { get; }

    //
    // Summary:
    //     Gets the current user.
    public DiscordUser CurrentUser { get; /*private set;*/ }

    //
    // Summary:
    //     Gets the current application.
    public DiscordApplication CurrentApplication { get; /*internal private set;*/ }

    //
    // Summary:
    //     Gets the list of available voice regions. Note that this property will not contain
    //     VIP voice regions.
    public IReadOnlyDictionary<string, DiscordVoiceRegion> VoiceRegions { get; }
    //
    // Summary:
    //     Updates current user's activity and status.
    //
    // Parameters:
    //   activity:
    //     Activity to set.
    //
    //   userStatus:
    //     Status of the user.
    //
    //   idleSince:
    //     Since when is the client performing the specified activity.
    public Task UpdateStatusAsync(DiscordActivity activity = null!, UserStatus? userStatus = null, DateTimeOffset? idleSince = null);


    #region events
    /// <inheritdoc cref="DiscordClient.SocketErrored"/>
    public event AsyncEventHandler<DiscordClient, SocketErrorEventArgs> SocketErrored;
    /// <inheritdoc cref="DiscordClient.SocketOpened"/>
    public event AsyncEventHandler<DiscordClient, SocketEventArgs> SocketOpened;
    /// <inheritdoc cref="DiscordClient.SocketClosed"/>
    public event AsyncEventHandler<DiscordClient, SocketCloseEventArgs> SocketClosed;
    /// <inheritdoc cref="DiscordClient.SessionCreated"/>
    public event AsyncEventHandler<DiscordClient, SessionReadyEventArgs> SessionCreated;
    /// <inheritdoc cref="DiscordClient.SessionResumed"/>
    public event AsyncEventHandler<DiscordClient, SessionReadyEventArgs> SessionResumed;
    /// <inheritdoc cref="DiscordClient.Heartbeated"/>
    public event AsyncEventHandler<DiscordClient, HeartbeatEventArgs> Heartbeated;
    /// <inheritdoc cref="DiscordClient.Zombied"/>
    public event AsyncEventHandler<DiscordClient, ZombiedEventArgs> Zombied;
    /// <inheritdoc cref="DiscordClient.ApplicationCommandPermissionsUpdated"/>
    public event AsyncEventHandler<DiscordClient, ApplicationCommandPermissionsUpdatedEventArgs> ApplicationCommandPermissionsUpdated;
    /// <inheritdoc cref="DiscordClient.ChannelCreated"/>
    public event AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> ChannelCreated;
    /// <inheritdoc cref="DiscordClient.ChannelUpdated"/>
    public event AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> ChannelUpdated;
    /// <inheritdoc cref="DiscordClient.ChannelDeleted"/>
    public event AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> ChannelDeleted;
    /// <inheritdoc cref="DiscordClient.DmChannelDeleted"/>
    public event AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> DmChannelDeleted;
    /// <inheritdoc cref="DiscordClient.ChannelPinsUpdated"/>
    public event AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> ChannelPinsUpdated;
    /// <inheritdoc cref="DiscordClient.GuildCreated"/>
    public event AsyncEventHandler<DiscordClient, GuildCreateEventArgs> GuildCreated;
    /// <inheritdoc cref="DiscordClient.GuildAvailable"/>
    public event AsyncEventHandler<DiscordClient, GuildCreateEventArgs> GuildAvailable;
    /// <inheritdoc cref="DiscordClient.GuildUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> GuildUpdated;
    /// <inheritdoc cref="DiscordClient.GuildDeleted"/>
    public event AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> GuildDeleted;
    /// <inheritdoc cref="DiscordClient.GuildUnavailable"/>
    public event AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> GuildUnavailable;
    /// <inheritdoc cref="DiscordClient.GuildDownloadCompleted"/>
    public event AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> GuildDownloadCompleted;
    /// <inheritdoc cref="DiscordClient.GuildEmojisUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> GuildEmojisUpdated;
    /// <inheritdoc cref="DiscordClient.GuildStickersUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> GuildStickersUpdated;
    /// <inheritdoc cref="DiscordClient.GuildIntegrationsUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> GuildIntegrationsUpdated;
    /// <inheritdoc cref="DiscordClient.GuildAuditLogCreated"/>
    public event AsyncEventHandler<DiscordClient, GuildAuditLogCreatedEventArgs> GuildAuditLogCreated;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventCreated"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> ScheduledGuildEventCreated;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUpdated"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> ScheduledGuildEventUpdated;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventDeleted"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> ScheduledGuildEventDeleted;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventCompleted"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> ScheduledGuildEventCompleted;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUserAdded"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> ScheduledGuildEventUserAdded;
    /// <inheritdoc cref="DiscordClient.ScheduledGuildEventUserRemoved"/>
    public event AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> ScheduledGuildEventUserRemoved;
    /// <inheritdoc cref="DiscordClient.GuildBanAdded"/>
    public event AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> GuildBanAdded;
    /// <inheritdoc cref="DiscordClient.GuildBanRemoved"/>
    public event AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> GuildBanRemoved;
    /// <inheritdoc cref="DiscordClient.GuildMemberAdded"/>
    public event AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> GuildMemberAdded;
    /// <inheritdoc cref="DiscordClient.GuildMemberRemoved"/>
    public event AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> GuildMemberRemoved;
    /// <inheritdoc cref="DiscordClient.GuildMemberUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> GuildMemberUpdated;
    /// <inheritdoc cref="DiscordClient.GuildMembersChunked"/>
    public event AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> GuildMembersChunked;
    /// <inheritdoc cref="DiscordClient.GuildRoleCreated"/>
    public event AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> GuildRoleCreated;
    /// <inheritdoc cref="DiscordClient.GuildRoleUpdated"/>
    public event AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> GuildRoleUpdated;
    /// <inheritdoc cref="DiscordClient.GuildRoleDeleted"/>
    public event AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> GuildRoleDeleted;
    /// <inheritdoc cref="DiscordClient.InviteCreated"/>
    public event AsyncEventHandler<DiscordClient, InviteCreateEventArgs> InviteCreated;
    /// <inheritdoc cref="DiscordClient.InviteDeleted"/>
    public event AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> InviteDeleted;
    /// <inheritdoc cref="DiscordClient.MessageCreated"/>
    public event AsyncEventHandler<DiscordClient, MessageCreateEventArgs> MessageCreated;
    /// <inheritdoc cref="DiscordClient.MessageAcknowledged"/>
    public event AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> MessageAcknowledged;
    /// <inheritdoc cref="DiscordClient.MessageUpdated"/>
    public event AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> MessageUpdated;
    /// <inheritdoc cref="DiscordClient.MessageDeleted"/>
    public event AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> MessageDeleted;
    /// <inheritdoc cref="DiscordClient.MessagesBulkDeleted"/>
    public event AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> MessagesBulkDeleted;
    /// <inheritdoc cref="DiscordClient.MessageReactionAdded"/>
    public event AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> MessageReactionAdded;
    /// <inheritdoc cref="DiscordClient.MessageReactionRemoved"/>
    public event AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> MessageReactionRemoved;
    /// <inheritdoc cref="DiscordClient.MessageReactionsCleared"/>
    public event AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> MessageReactionsCleared;
    /// <inheritdoc cref="DiscordClient.MessageReactionRemovedEmoji"/>
    public event AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> MessageReactionRemovedEmoji;
    /// <inheritdoc cref="DiscordClient.PresenceUpdated"/>
    public event AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> PresenceUpdated;
    /// <inheritdoc cref="DiscordClient.UserSettingsUpdated"/>
    public event AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> UserSettingsUpdated;
    /// <inheritdoc cref="DiscordClient.UserUpdated"/>
    public event AsyncEventHandler<DiscordClient, UserUpdateEventArgs> UserUpdated;
    /// <inheritdoc cref="DiscordClient.VoiceStateUpdated"/>
    public event AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> VoiceStateUpdated;
    /// <inheritdoc cref="DiscordClient.VoiceServerUpdated"/>
    public event AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> VoiceServerUpdated;
    /// <inheritdoc cref="DiscordClient.ThreadCreated"/>
    public event AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> ThreadCreated;
    /// <inheritdoc cref="DiscordClient.ThreadUpdated"/>
    public event AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> ThreadUpdated;
    /// <inheritdoc cref="DiscordClient.ThreadDeleted"/>
    public event AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> ThreadDeleted;
    /// <inheritdoc cref="DiscordClient.ThreadListSynced"/>
    public event AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> ThreadListSynced;
    /// <inheritdoc cref="DiscordClient.ThreadMemberUpdated"/>
    public event AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> ThreadMemberUpdated;
    /// <inheritdoc cref="DiscordClient.ThreadMembersUpdated"/>
    public event AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> ThreadMembersUpdated;
    /// <inheritdoc cref="DiscordClient.IntegrationCreated"/>
    public event AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> IntegrationCreated;
    /// <inheritdoc cref="DiscordClient.IntegrationUpdated"/>
    public event AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> IntegrationUpdated;
    /// <inheritdoc cref="DiscordClient.IntegrationDeleted"/>
    public event AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> IntegrationDeleted;
    /// <inheritdoc cref="DiscordClient.StageInstanceCreated"/>
    public event AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> StageInstanceCreated;
    /// <inheritdoc cref="DiscordClient.StageInstanceUpdated"/>
    public event AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> StageInstanceUpdated;
    /// <inheritdoc cref="DiscordClient.StageInstanceDeleted"/>
    public event AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> StageInstanceDeleted;
    /// <inheritdoc cref="DiscordClient.InteractionCreated"/>
    public event AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> InteractionCreated;
    /// <inheritdoc cref="DiscordClient.ComponentInteractionCreated"/>
    public event AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> ComponentInteractionCreated;
    /// <inheritdoc cref="DiscordClient.ModalSubmitted"/>
    public event AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> ModalSubmitted;
    /// <inheritdoc cref="DiscordClient.ContextMenuInteractionCreated"/>
    public event AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> ContextMenuInteractionCreated;
    /// <inheritdoc cref="DiscordClient.TypingStarted"/>
    public event AsyncEventHandler<DiscordClient, TypingStartEventArgs> TypingStarted;
    /// <inheritdoc cref="DiscordClient.UnknownEvent"/>
    public event AsyncEventHandler<DiscordClient, UnknownEventArgs> UnknownEvent;
    /// <inheritdoc cref="DiscordClient.WebhooksUpdated"/>
    public event AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> WebhooksUpdated;
    /// <inheritdoc cref="DiscordClient.ClientErrored"/>
    public event AsyncEventHandler<DiscordClient, ClientErrorEventArgs> ClientErrored;
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleCreated"/>
    public event AsyncEventHandler<DiscordClient, AutoModerationRuleCreateEventArgs> AutoModerationRuleCreated;
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleUpdated"/>
    public event AsyncEventHandler<DiscordClient, AutoModerationRuleUpdateEventArgs> AutoModerationRuleUpdated;
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleDeleted"/>
    public event AsyncEventHandler<DiscordClient, AutoModerationRuleDeleteEventArgs> AutoModerationRuleDeleted;
    /// <inheritdoc cref="DiscordClient.AutoModerationRuleExecuted"/>
    public event AsyncEventHandler<DiscordClient, AutoModerationRuleExecuteEventArgs> AutoModerationRuleExecuted;
    #endregion
}

#if UnshardedOnly
    //
    // Summary:
    //     Sends a raw payload to the gateway. This method is not recommended for use unless
    //     you know what you're doing.
    //
    // Parameters:
    //   opCode:
    //     The opcode to send to the Discord gateway.
    //
    //   data:
    //     The data to deserialize.
    //
    // Type parameters:
    //   T:
    //     The type of data that the object belongs to.
    //
    // Returns:
    //     A task representing the payload being sent.
    [Obsolete("This method should not be used unless you know what you're doing. Instead, look towards the other explicitly implemented methods which come with client-side validation.")]
    public Task SendPayloadAsync<T>(GatewayOpCode opCode, T data)
    {
        return SendPayloadAsync(opCode, (object?)data);
    }

    [Obsolete("This method should not be used unless you know what you're doing. Instead, look towards the other explicitly implemented methods which come with client-side validation.")]
    public Task SendPayloadAsync(GatewayOpCode opCode, object? data = null)
    {
        GatewayPayload value = new GatewayPayload
        {
            OpCode = opCode,
            Data = data
        };
        string jsonPayload = DiscordJson.SerializeObject(value);
        return SendRawPayloadAsync(jsonPayload);
    }
#endif