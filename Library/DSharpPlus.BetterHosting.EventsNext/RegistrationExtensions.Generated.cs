﻿
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext;

public static partial class RegistrationExtensions
{
    public static partial IServiceCollection AutoRegisterHandler<TImplementation>(this IServiceCollection services) where TImplementation : class, IDiscordEventHandler
    {
        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketErroredEventHandler)))
            services.AddSocketErroredHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketOpenedEventHandler)))
            services.AddSocketOpenedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketClosedEventHandler)))
            services.AddSocketClosedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(ISessionCreatedEventHandler)))
            services.AddSessionCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(ISessionResumedEventHandler)))
            services.AddSessionResumedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IHeartbeatedEventHandler)))
            services.AddHeartbeatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IZombiedEventHandler)))
            services.AddZombiedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)))
            services.AddApplicationCommandPermissionsUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelCreatedEventHandler)))
            services.AddChannelCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelUpdatedEventHandler)))
            services.AddChannelUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelDeletedEventHandler)))
            services.AddChannelDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IDmChannelDeletedEventHandler)))
            services.AddDmChannelDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)))
            services.AddChannelPinsUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildCreatedEventHandler)))
            services.AddGuildCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildAvailableEventHandler)))
            services.AddGuildAvailableHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildUpdatedEventHandler)))
            services.AddGuildUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildDeletedEventHandler)))
            services.AddGuildDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildUnavailableEventHandler)))
            services.AddGuildUnavailableHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)))
            services.AddGuildDownloadCompletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)))
            services.AddGuildEmojisUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)))
            services.AddGuildStickersUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)))
            services.AddGuildIntegrationsUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)))
            services.AddGuildAuditLogCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)))
            services.AddScheduledGuildEventCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)))
            services.AddScheduledGuildEventUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)))
            services.AddScheduledGuildEventDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)))
            services.AddScheduledGuildEventCompletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)))
            services.AddScheduledGuildEventUserAddedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)))
            services.AddScheduledGuildEventUserRemovedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildBanAddedEventHandler)))
            services.AddGuildBanAddedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildBanRemovedEventHandler)))
            services.AddGuildBanRemovedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberAddedEventHandler)))
            services.AddGuildMemberAddedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)))
            services.AddGuildMemberRemovedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)))
            services.AddGuildMemberUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)))
            services.AddGuildMembersChunkedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)))
            services.AddGuildRoleCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)))
            services.AddGuildRoleUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)))
            services.AddGuildRoleDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IInviteCreatedEventHandler)))
            services.AddInviteCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IInviteDeletedEventHandler)))
            services.AddInviteDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageCreatedEventHandler)))
            services.AddMessageCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)))
            services.AddMessageAcknowledgedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageUpdatedEventHandler)))
            services.AddMessageUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageDeletedEventHandler)))
            services.AddMessageDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)))
            services.AddMessagesBulkDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionAddedEventHandler)))
            services.AddMessageReactionAddedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)))
            services.AddMessageReactionRemovedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)))
            services.AddMessageReactionsClearedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)))
            services.AddMessageReactionRemovedEmojiHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IPresenceUpdatedEventHandler)))
            services.AddPresenceUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)))
            services.AddUserSettingsUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IUserUpdatedEventHandler)))
            services.AddUserUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)))
            services.AddVoiceStateUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)))
            services.AddVoiceServerUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadCreatedEventHandler)))
            services.AddThreadCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadUpdatedEventHandler)))
            services.AddThreadUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadDeletedEventHandler)))
            services.AddThreadDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadListSyncedEventHandler)))
            services.AddThreadListSyncedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)))
            services.AddThreadMemberUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)))
            services.AddThreadMembersUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationCreatedEventHandler)))
            services.AddIntegrationCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)))
            services.AddIntegrationUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationDeletedEventHandler)))
            services.AddIntegrationDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)))
            services.AddStageInstanceCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)))
            services.AddStageInstanceUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)))
            services.AddStageInstanceDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IInteractionCreatedEventHandler)))
            services.AddInteractionCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)))
            services.AddComponentInteractionCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IModalSubmittedEventHandler)))
            services.AddModalSubmittedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)))
            services.AddContextMenuInteractionCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(ITypingStartedEventHandler)))
            services.AddTypingStartedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IUnknownEventEventHandler)))
            services.AddUnknownEventHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)))
            services.AddWebhooksUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IClientErroredEventHandler)))
            services.AddClientErroredHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)))
            services.AddAutoModerationRuleCreatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)))
            services.AddAutoModerationRuleUpdatedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)))
            services.AddAutoModerationRuleDeletedHandlers().RegisterHandler(typeof(TImplementation));

        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler)))
            services.AddAutoModerationRuleExecutedHandlers().RegisterHandler(typeof(TImplementation));

        return services;
    }

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketErrored"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketErroredEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ISocketErroredEventHandler> AddSocketErroredHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketErroredEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketOpened"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketOpenedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ISocketOpenedEventHandler> AddSocketOpenedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketOpenedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketClosed"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketClosedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ISocketClosedEventHandler> AddSocketClosedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketClosedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SessionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISessionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ISessionCreatedEventHandler> AddSessionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISessionCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SessionResumed"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISessionResumedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ISessionResumedEventHandler> AddSessionResumedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISessionResumedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.Heartbeated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IHeartbeatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IHeartbeatedEventHandler> AddHeartbeatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IHeartbeatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.Zombied"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IZombiedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IZombiedEventHandler> AddZombiedHandlers(this IServiceCollection services) => services.AddEventHandlers<IZombiedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ApplicationCommandPermissionsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IApplicationCommandPermissionsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IApplicationCommandPermissionsUpdatedEventHandler> AddApplicationCommandPermissionsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IApplicationCommandPermissionsUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IChannelCreatedEventHandler> AddChannelCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IChannelUpdatedEventHandler> AddChannelUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IChannelDeletedEventHandler> AddChannelDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.DmChannelDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IDmChannelDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IDmChannelDeletedEventHandler> AddDmChannelDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IDmChannelDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelPinsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelPinsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IChannelPinsUpdatedEventHandler> AddChannelPinsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelPinsUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildCreatedEventHandler> AddGuildCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildAvailable"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildAvailableEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildAvailableEventHandler> AddGuildAvailableHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildAvailableEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildUpdatedEventHandler> AddGuildUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildDeletedEventHandler> AddGuildDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildUnavailable"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildUnavailableEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildUnavailableEventHandler> AddGuildUnavailableHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildUnavailableEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildDownloadCompleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildDownloadCompletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildDownloadCompletedEventHandler> AddGuildDownloadCompletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildDownloadCompletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildEmojisUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildEmojisUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildEmojisUpdatedEventHandler> AddGuildEmojisUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildEmojisUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildStickersUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildStickersUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildStickersUpdatedEventHandler> AddGuildStickersUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildStickersUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildIntegrationsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildIntegrationsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildIntegrationsUpdatedEventHandler> AddGuildIntegrationsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildIntegrationsUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildAuditLogCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildAuditLogCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildAuditLogCreatedEventHandler> AddGuildAuditLogCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildAuditLogCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventCreatedEventHandler> AddScheduledGuildEventCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventUpdatedEventHandler> AddScheduledGuildEventUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventDeletedEventHandler> AddScheduledGuildEventDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventCompleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventCompletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventCompletedEventHandler> AddScheduledGuildEventCompletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventCompletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUserAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUserAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventUserAddedEventHandler> AddScheduledGuildEventUserAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUserAddedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUserRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUserRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IScheduledGuildEventUserRemovedEventHandler> AddScheduledGuildEventUserRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUserRemovedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildBanAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildBanAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildBanAddedEventHandler> AddGuildBanAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildBanAddedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildBanRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildBanRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildBanRemovedEventHandler> AddGuildBanRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildBanRemovedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildMemberAddedEventHandler> AddGuildMemberAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberAddedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildMemberRemovedEventHandler> AddGuildMemberRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberRemovedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildMemberUpdatedEventHandler> AddGuildMemberUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMembersChunked"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMembersChunkedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildMembersChunkedEventHandler> AddGuildMembersChunkedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMembersChunkedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildRoleCreatedEventHandler> AddGuildRoleCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildRoleUpdatedEventHandler> AddGuildRoleUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IGuildRoleDeletedEventHandler> AddGuildRoleDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InviteCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInviteCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IInviteCreatedEventHandler> AddInviteCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInviteCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InviteDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInviteDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IInviteDeletedEventHandler> AddInviteDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInviteDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageCreatedEventHandler> AddMessageCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageAcknowledged"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageAcknowledgedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageAcknowledgedEventHandler> AddMessageAcknowledgedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageAcknowledgedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageUpdatedEventHandler> AddMessageUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageDeletedEventHandler> AddMessageDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessagesBulkDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessagesBulkDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessagesBulkDeletedEventHandler> AddMessagesBulkDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessagesBulkDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageReactionAddedEventHandler> AddMessageReactionAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionAddedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageReactionRemovedEventHandler> AddMessageReactionRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionRemovedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionsCleared"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionsClearedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageReactionsClearedEventHandler> AddMessageReactionsClearedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionsClearedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionRemovedEmoji"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionRemovedEmojiEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IMessageReactionRemovedEmojiEventHandler> AddMessageReactionRemovedEmojiHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionRemovedEmojiEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.PresenceUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IPresenceUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IPresenceUpdatedEventHandler> AddPresenceUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IPresenceUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UserSettingsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUserSettingsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IUserSettingsUpdatedEventHandler> AddUserSettingsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IUserSettingsUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UserUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUserUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IUserUpdatedEventHandler> AddUserUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IUserUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.VoiceStateUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IVoiceStateUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IVoiceStateUpdatedEventHandler> AddVoiceStateUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IVoiceStateUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.VoiceServerUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IVoiceServerUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IVoiceServerUpdatedEventHandler> AddVoiceServerUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IVoiceServerUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadCreatedEventHandler> AddThreadCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadUpdatedEventHandler> AddThreadUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadDeletedEventHandler> AddThreadDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadListSynced"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadListSyncedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadListSyncedEventHandler> AddThreadListSyncedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadListSyncedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadMemberUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadMemberUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadMemberUpdatedEventHandler> AddThreadMemberUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadMemberUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadMembersUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadMembersUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IThreadMembersUpdatedEventHandler> AddThreadMembersUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadMembersUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IIntegrationCreatedEventHandler> AddIntegrationCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IIntegrationUpdatedEventHandler> AddIntegrationUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IIntegrationDeletedEventHandler> AddIntegrationDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IStageInstanceCreatedEventHandler> AddStageInstanceCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IStageInstanceUpdatedEventHandler> AddStageInstanceUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IStageInstanceDeletedEventHandler> AddStageInstanceDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IInteractionCreatedEventHandler> AddInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInteractionCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ComponentInteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IComponentInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IComponentInteractionCreatedEventHandler> AddComponentInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IComponentInteractionCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ModalSubmitted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IModalSubmittedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IModalSubmittedEventHandler> AddModalSubmittedHandlers(this IServiceCollection services) => services.AddEventHandlers<IModalSubmittedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ContextMenuInteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IContextMenuInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IContextMenuInteractionCreatedEventHandler> AddContextMenuInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IContextMenuInteractionCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.TypingStarted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ITypingStartedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<ITypingStartedEventHandler> AddTypingStartedHandlers(this IServiceCollection services) => services.AddEventHandlers<ITypingStartedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UnknownEvent"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUnknownEventEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IUnknownEventEventHandler> AddUnknownEventHandlers(this IServiceCollection services) => services.AddEventHandlers<IUnknownEventEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.WebhooksUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IWebhooksUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IWebhooksUpdatedEventHandler> AddWebhooksUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IWebhooksUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ClientErrored"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IClientErroredEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IClientErroredEventHandler> AddClientErroredHandlers(this IServiceCollection services) => services.AddEventHandlers<IClientErroredEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IAutoModerationRuleCreatedEventHandler> AddAutoModerationRuleCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleCreatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IAutoModerationRuleUpdatedEventHandler> AddAutoModerationRuleUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleUpdatedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IAutoModerationRuleDeletedEventHandler> AddAutoModerationRuleDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleDeletedEventHandler>();

    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleExecuted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleExecutedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    [ExcludeFromCodeCoverage(Justification = "Generated named wrapper for generic method")]
    public static RegistrationBuilder<IAutoModerationRuleExecutedEventHandler> AddAutoModerationRuleExecutedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleExecutedEventHandler>();
}