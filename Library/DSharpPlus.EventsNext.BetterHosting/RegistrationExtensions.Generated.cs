
using DSharpPlus.EventsNext.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsNext.BetterHosting;

public static partial class RegistrationExtensions
{
    public static partial IServiceCollection AutoRegisterHandler<TImplementation>(this IServiceCollection services) where TImplementation : class, IDiscordEventHandler
    {
        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketErroredEventHandler)))
            services.AddEventHandlers<ISocketErroredEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketOpenedEventHandler)))
            services.AddEventHandlers<ISocketOpenedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(ISocketClosedEventHandler)))
            services.AddEventHandlers<ISocketClosedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(ISessionCreatedEventHandler)))
            services.AddEventHandlers<ISessionCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(ISessionResumedEventHandler)))
            services.AddEventHandlers<ISessionResumedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IHeartbeatedEventHandler)))
            services.AddEventHandlers<IHeartbeatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IZombiedEventHandler)))
            services.AddEventHandlers<IZombiedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IApplicationCommandPermissionsUpdatedEventHandler)))
            services.AddEventHandlers<IApplicationCommandPermissionsUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelCreatedEventHandler)))
            services.AddEventHandlers<IChannelCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelUpdatedEventHandler)))
            services.AddEventHandlers<IChannelUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelDeletedEventHandler)))
            services.AddEventHandlers<IChannelDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IDmChannelDeletedEventHandler)))
            services.AddEventHandlers<IDmChannelDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IChannelPinsUpdatedEventHandler)))
            services.AddEventHandlers<IChannelPinsUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildCreatedEventHandler)))
            services.AddEventHandlers<IGuildCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildAvailableEventHandler)))
            services.AddEventHandlers<IGuildAvailableEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildUpdatedEventHandler)))
            services.AddEventHandlers<IGuildUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildDeletedEventHandler)))
            services.AddEventHandlers<IGuildDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildUnavailableEventHandler)))
            services.AddEventHandlers<IGuildUnavailableEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)))
            services.AddEventHandlers<IGuildDownloadCompletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildEmojisUpdatedEventHandler)))
            services.AddEventHandlers<IGuildEmojisUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildStickersUpdatedEventHandler)))
            services.AddEventHandlers<IGuildStickersUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildIntegrationsUpdatedEventHandler)))
            services.AddEventHandlers<IGuildIntegrationsUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildAuditLogCreatedEventHandler)))
            services.AddEventHandlers<IGuildAuditLogCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventCreatedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUpdatedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventDeletedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventCompletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserAddedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventUserAddedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IScheduledGuildEventUserRemovedEventHandler)))
            services.AddEventHandlers<IScheduledGuildEventUserRemovedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildBanAddedEventHandler)))
            services.AddEventHandlers<IGuildBanAddedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildBanRemovedEventHandler)))
            services.AddEventHandlers<IGuildBanRemovedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberAddedEventHandler)))
            services.AddEventHandlers<IGuildMemberAddedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberRemovedEventHandler)))
            services.AddEventHandlers<IGuildMemberRemovedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMemberUpdatedEventHandler)))
            services.AddEventHandlers<IGuildMemberUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildMembersChunkedEventHandler)))
            services.AddEventHandlers<IGuildMembersChunkedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleCreatedEventHandler)))
            services.AddEventHandlers<IGuildRoleCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleUpdatedEventHandler)))
            services.AddEventHandlers<IGuildRoleUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IGuildRoleDeletedEventHandler)))
            services.AddEventHandlers<IGuildRoleDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IInviteCreatedEventHandler)))
            services.AddEventHandlers<IInviteCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IInviteDeletedEventHandler)))
            services.AddEventHandlers<IInviteDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageCreatedEventHandler)))
            services.AddEventHandlers<IMessageCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageAcknowledgedEventHandler)))
            services.AddEventHandlers<IMessageAcknowledgedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageUpdatedEventHandler)))
            services.AddEventHandlers<IMessageUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageDeletedEventHandler)))
            services.AddEventHandlers<IMessageDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessagesBulkDeletedEventHandler)))
            services.AddEventHandlers<IMessagesBulkDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionAddedEventHandler)))
            services.AddEventHandlers<IMessageReactionAddedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEventHandler)))
            services.AddEventHandlers<IMessageReactionRemovedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionsClearedEventHandler)))
            services.AddEventHandlers<IMessageReactionsClearedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IMessageReactionRemovedEmojiEventHandler)))
            services.AddEventHandlers<IMessageReactionRemovedEmojiEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IPresenceUpdatedEventHandler)))
            services.AddEventHandlers<IPresenceUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IUserSettingsUpdatedEventHandler)))
            services.AddEventHandlers<IUserSettingsUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IUserUpdatedEventHandler)))
            services.AddEventHandlers<IUserUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IVoiceStateUpdatedEventHandler)))
            services.AddEventHandlers<IVoiceStateUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IVoiceServerUpdatedEventHandler)))
            services.AddEventHandlers<IVoiceServerUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadCreatedEventHandler)))
            services.AddEventHandlers<IThreadCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadUpdatedEventHandler)))
            services.AddEventHandlers<IThreadUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadDeletedEventHandler)))
            services.AddEventHandlers<IThreadDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadListSyncedEventHandler)))
            services.AddEventHandlers<IThreadListSyncedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadMemberUpdatedEventHandler)))
            services.AddEventHandlers<IThreadMemberUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IThreadMembersUpdatedEventHandler)))
            services.AddEventHandlers<IThreadMembersUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationCreatedEventHandler)))
            services.AddEventHandlers<IIntegrationCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationUpdatedEventHandler)))
            services.AddEventHandlers<IIntegrationUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IIntegrationDeletedEventHandler)))
            services.AddEventHandlers<IIntegrationDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceCreatedEventHandler)))
            services.AddEventHandlers<IStageInstanceCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceUpdatedEventHandler)))
            services.AddEventHandlers<IStageInstanceUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IStageInstanceDeletedEventHandler)))
            services.AddEventHandlers<IStageInstanceDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IInteractionCreatedEventHandler)))
            services.AddEventHandlers<IInteractionCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IComponentInteractionCreatedEventHandler)))
            services.AddEventHandlers<IComponentInteractionCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IModalSubmittedEventHandler)))
            services.AddEventHandlers<IModalSubmittedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IContextMenuInteractionCreatedEventHandler)))
            services.AddEventHandlers<IContextMenuInteractionCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(ITypingStartedEventHandler)))
            services.AddEventHandlers<ITypingStartedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IUnknownEventEventHandler)))
            services.AddEventHandlers<IUnknownEventEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IWebhooksUpdatedEventHandler)))
            services.AddEventHandlers<IWebhooksUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IClientErroredEventHandler)))
            services.AddEventHandlers<IClientErroredEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleCreatedEventHandler)))
            services.AddEventHandlers<IAutoModerationRuleCreatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleUpdatedEventHandler)))
            services.AddEventHandlers<IAutoModerationRuleUpdatedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleDeletedEventHandler)))
            services.AddEventHandlers<IAutoModerationRuleDeletedEventHandler>().RegisterHandler(typeof(TImplementation));
        if (typeof(TImplementation).IsAssignableTo(typeof(IAutoModerationRuleExecutedEventHandler)))
            services.AddEventHandlers<IAutoModerationRuleExecutedEventHandler>().RegisterHandler(typeof(TImplementation));
        return services;
    }
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketErrored"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketErroredEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ISocketErroredEventHandler> AddSocketErroredHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketErroredEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketOpened"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketOpenedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ISocketOpenedEventHandler> AddSocketOpenedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketOpenedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SocketClosed"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISocketClosedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ISocketClosedEventHandler> AddSocketClosedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISocketClosedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SessionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISessionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ISessionCreatedEventHandler> AddSessionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISessionCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.SessionResumed"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ISessionResumedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ISessionResumedEventHandler> AddSessionResumedHandlers(this IServiceCollection services) => services.AddEventHandlers<ISessionResumedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.Heartbeated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IHeartbeatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IHeartbeatedEventHandler> AddHeartbeatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IHeartbeatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.Zombied"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IZombiedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IZombiedEventHandler> AddZombiedHandlers(this IServiceCollection services) => services.AddEventHandlers<IZombiedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ApplicationCommandPermissionsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IApplicationCommandPermissionsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IApplicationCommandPermissionsUpdatedEventHandler> AddApplicationCommandPermissionsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IApplicationCommandPermissionsUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IChannelCreatedEventHandler> AddChannelCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IChannelUpdatedEventHandler> AddChannelUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IChannelDeletedEventHandler> AddChannelDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.DmChannelDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IDmChannelDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IDmChannelDeletedEventHandler> AddDmChannelDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IDmChannelDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ChannelPinsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IChannelPinsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IChannelPinsUpdatedEventHandler> AddChannelPinsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IChannelPinsUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildCreatedEventHandler> AddGuildCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildAvailable"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildAvailableEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildAvailableEventHandler> AddGuildAvailableHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildAvailableEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildUpdatedEventHandler> AddGuildUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildDeletedEventHandler> AddGuildDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildUnavailable"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildUnavailableEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildUnavailableEventHandler> AddGuildUnavailableHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildUnavailableEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildDownloadCompleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildDownloadCompletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildDownloadCompletedEventHandler> AddGuildDownloadCompletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildDownloadCompletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildEmojisUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildEmojisUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildEmojisUpdatedEventHandler> AddGuildEmojisUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildEmojisUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildStickersUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildStickersUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildStickersUpdatedEventHandler> AddGuildStickersUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildStickersUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildIntegrationsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildIntegrationsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildIntegrationsUpdatedEventHandler> AddGuildIntegrationsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildIntegrationsUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildAuditLogCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildAuditLogCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildAuditLogCreatedEventHandler> AddGuildAuditLogCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildAuditLogCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventCreatedEventHandler> AddScheduledGuildEventCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventUpdatedEventHandler> AddScheduledGuildEventUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventDeletedEventHandler> AddScheduledGuildEventDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventCompleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventCompletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventCompletedEventHandler> AddScheduledGuildEventCompletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventCompletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUserAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUserAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventUserAddedEventHandler> AddScheduledGuildEventUserAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUserAddedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ScheduledGuildEventUserRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IScheduledGuildEventUserRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IScheduledGuildEventUserRemovedEventHandler> AddScheduledGuildEventUserRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IScheduledGuildEventUserRemovedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildBanAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildBanAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildBanAddedEventHandler> AddGuildBanAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildBanAddedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildBanRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildBanRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildBanRemovedEventHandler> AddGuildBanRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildBanRemovedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildMemberAddedEventHandler> AddGuildMemberAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberAddedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildMemberRemovedEventHandler> AddGuildMemberRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberRemovedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMemberUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMemberUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildMemberUpdatedEventHandler> AddGuildMemberUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMemberUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildMembersChunked"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildMembersChunkedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildMembersChunkedEventHandler> AddGuildMembersChunkedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildMembersChunkedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildRoleCreatedEventHandler> AddGuildRoleCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildRoleUpdatedEventHandler> AddGuildRoleUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.GuildRoleDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IGuildRoleDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IGuildRoleDeletedEventHandler> AddGuildRoleDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IGuildRoleDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InviteCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInviteCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IInviteCreatedEventHandler> AddInviteCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInviteCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InviteDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInviteDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IInviteDeletedEventHandler> AddInviteDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInviteDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageCreatedEventHandler> AddMessageCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageAcknowledged"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageAcknowledgedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageAcknowledgedEventHandler> AddMessageAcknowledgedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageAcknowledgedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageUpdatedEventHandler> AddMessageUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageDeletedEventHandler> AddMessageDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessagesBulkDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessagesBulkDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessagesBulkDeletedEventHandler> AddMessagesBulkDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessagesBulkDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionAdded"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionAddedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageReactionAddedEventHandler> AddMessageReactionAddedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionAddedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionRemoved"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionRemovedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageReactionRemovedEventHandler> AddMessageReactionRemovedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionRemovedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionsCleared"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionsClearedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageReactionsClearedEventHandler> AddMessageReactionsClearedHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionsClearedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.MessageReactionRemovedEmoji"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IMessageReactionRemovedEmojiEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IMessageReactionRemovedEmojiEventHandler> AddMessageReactionRemovedEmojiHandlers(this IServiceCollection services) => services.AddEventHandlers<IMessageReactionRemovedEmojiEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.PresenceUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IPresenceUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IPresenceUpdatedEventHandler> AddPresenceUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IPresenceUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UserSettingsUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUserSettingsUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IUserSettingsUpdatedEventHandler> AddUserSettingsUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IUserSettingsUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UserUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUserUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IUserUpdatedEventHandler> AddUserUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IUserUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.VoiceStateUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IVoiceStateUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IVoiceStateUpdatedEventHandler> AddVoiceStateUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IVoiceStateUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.VoiceServerUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IVoiceServerUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IVoiceServerUpdatedEventHandler> AddVoiceServerUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IVoiceServerUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadCreatedEventHandler> AddThreadCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadUpdatedEventHandler> AddThreadUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadDeletedEventHandler> AddThreadDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadListSynced"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadListSyncedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadListSyncedEventHandler> AddThreadListSyncedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadListSyncedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadMemberUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadMemberUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadMemberUpdatedEventHandler> AddThreadMemberUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadMemberUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ThreadMembersUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IThreadMembersUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IThreadMembersUpdatedEventHandler> AddThreadMembersUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IThreadMembersUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IIntegrationCreatedEventHandler> AddIntegrationCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IIntegrationUpdatedEventHandler> AddIntegrationUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.IntegrationDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IIntegrationDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IIntegrationDeletedEventHandler> AddIntegrationDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IIntegrationDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IStageInstanceCreatedEventHandler> AddStageInstanceCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IStageInstanceUpdatedEventHandler> AddStageInstanceUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.StageInstanceDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IStageInstanceDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IStageInstanceDeletedEventHandler> AddStageInstanceDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IStageInstanceDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.InteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IInteractionCreatedEventHandler> AddInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IInteractionCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ComponentInteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IComponentInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IComponentInteractionCreatedEventHandler> AddComponentInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IComponentInteractionCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ModalSubmitted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IModalSubmittedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IModalSubmittedEventHandler> AddModalSubmittedHandlers(this IServiceCollection services) => services.AddEventHandlers<IModalSubmittedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ContextMenuInteractionCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IContextMenuInteractionCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IContextMenuInteractionCreatedEventHandler> AddContextMenuInteractionCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IContextMenuInteractionCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.TypingStarted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="ITypingStartedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<ITypingStartedEventHandler> AddTypingStartedHandlers(this IServiceCollection services) => services.AddEventHandlers<ITypingStartedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.UnknownEvent"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IUnknownEventEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IUnknownEventEventHandler> AddUnknownEventHandlers(this IServiceCollection services) => services.AddEventHandlers<IUnknownEventEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.WebhooksUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IWebhooksUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IWebhooksUpdatedEventHandler> AddWebhooksUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IWebhooksUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.ClientErrored"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IClientErroredEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IClientErroredEventHandler> AddClientErroredHandlers(this IServiceCollection services) => services.AddEventHandlers<IClientErroredEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleCreated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleCreatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IAutoModerationRuleCreatedEventHandler> AddAutoModerationRuleCreatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleCreatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleUpdated"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleUpdatedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IAutoModerationRuleUpdatedEventHandler> AddAutoModerationRuleUpdatedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleUpdatedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleDeleted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleDeletedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IAutoModerationRuleDeletedEventHandler> AddAutoModerationRuleDeletedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleDeletedEventHandler>();
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the <see cref="DiscordShardedClient.AutoModerationRuleExecuted"/> to the underlying service collection
    /// </summary>
    /// <remarks>Handlers must fufill the <see cref="IAutoModerationRuleExecutedEventHandler"/> interface</remarks>
    /// <inheritdoc cref="RegistrationExtensions.AddEventHandlers{T}"/>
    public static RegistrationBuilder<IAutoModerationRuleExecutedEventHandler> AddAutoModerationRuleExecutedHandlers(this IServiceCollection services) => services.AddEventHandlers<IAutoModerationRuleExecutedEventHandler>();

    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.SocketErrored"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddSocketErroredHandler<THandler>(IServiceCollection services) where THandler : class, ISocketErroredEventHandler
    {
        services.AddEventHandlers<ISocketErroredEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.SocketOpened"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddSocketOpenedHandler<THandler>(IServiceCollection services) where THandler : class, ISocketOpenedEventHandler
    {
        services.AddEventHandlers<ISocketOpenedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.SocketClosed"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddSocketClosedHandler<THandler>(IServiceCollection services) where THandler : class, ISocketClosedEventHandler
    {
        services.AddEventHandlers<ISocketClosedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.SessionCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddSessionCreatedHandler<THandler>(IServiceCollection services) where THandler : class, ISessionCreatedEventHandler
    {
        services.AddEventHandlers<ISessionCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.SessionResumed"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddSessionResumedHandler<THandler>(IServiceCollection services) where THandler : class, ISessionResumedEventHandler
    {
        services.AddEventHandlers<ISessionResumedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.Heartbeated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddHeartbeatedHandler<THandler>(IServiceCollection services) where THandler : class, IHeartbeatedEventHandler
    {
        services.AddEventHandlers<IHeartbeatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.Zombied"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddZombiedHandler<THandler>(IServiceCollection services) where THandler : class, IZombiedEventHandler
    {
        services.AddEventHandlers<IZombiedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ApplicationCommandPermissionsUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddApplicationCommandPermissionsUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IApplicationCommandPermissionsUpdatedEventHandler
    {
        services.AddEventHandlers<IApplicationCommandPermissionsUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ChannelCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddChannelCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IChannelCreatedEventHandler
    {
        services.AddEventHandlers<IChannelCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ChannelUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddChannelUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IChannelUpdatedEventHandler
    {
        services.AddEventHandlers<IChannelUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ChannelDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddChannelDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IChannelDeletedEventHandler
    {
        services.AddEventHandlers<IChannelDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.DmChannelDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddDmChannelDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IDmChannelDeletedEventHandler
    {
        services.AddEventHandlers<IDmChannelDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ChannelPinsUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddChannelPinsUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IChannelPinsUpdatedEventHandler
    {
        services.AddEventHandlers<IChannelPinsUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildCreatedEventHandler
    {
        services.AddEventHandlers<IGuildCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildAvailable"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildAvailableHandler<THandler>(IServiceCollection services) where THandler : class, IGuildAvailableEventHandler
    {
        services.AddEventHandlers<IGuildAvailableEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildDeletedEventHandler
    {
        services.AddEventHandlers<IGuildDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildUnavailable"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildUnavailableHandler<THandler>(IServiceCollection services) where THandler : class, IGuildUnavailableEventHandler
    {
        services.AddEventHandlers<IGuildUnavailableEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildDownloadCompleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildDownloadCompletedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildDownloadCompletedEventHandler
    {
        services.AddEventHandlers<IGuildDownloadCompletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildEmojisUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildEmojisUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildEmojisUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildEmojisUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildStickersUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildStickersUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildStickersUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildStickersUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildIntegrationsUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildIntegrationsUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildIntegrationsUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildIntegrationsUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildAuditLogCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildAuditLogCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildAuditLogCreatedEventHandler
    {
        services.AddEventHandlers<IGuildAuditLogCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventCreatedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventUpdatedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventDeletedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventCompleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventCompletedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventCompletedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventCompletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventUserAdded"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventUserAddedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventUserAddedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventUserAddedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ScheduledGuildEventUserRemoved"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddScheduledGuildEventUserRemovedHandler<THandler>(IServiceCollection services) where THandler : class, IScheduledGuildEventUserRemovedEventHandler
    {
        services.AddEventHandlers<IScheduledGuildEventUserRemovedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildBanAdded"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildBanAddedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildBanAddedEventHandler
    {
        services.AddEventHandlers<IGuildBanAddedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildBanRemoved"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildBanRemovedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildBanRemovedEventHandler
    {
        services.AddEventHandlers<IGuildBanRemovedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildMemberAdded"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildMemberAddedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildMemberAddedEventHandler
    {
        services.AddEventHandlers<IGuildMemberAddedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildMemberRemoved"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildMemberRemovedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildMemberRemovedEventHandler
    {
        services.AddEventHandlers<IGuildMemberRemovedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildMemberUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildMemberUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildMemberUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildMemberUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildMembersChunked"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildMembersChunkedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildMembersChunkedEventHandler
    {
        services.AddEventHandlers<IGuildMembersChunkedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildRoleCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildRoleCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildRoleCreatedEventHandler
    {
        services.AddEventHandlers<IGuildRoleCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildRoleUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildRoleUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildRoleUpdatedEventHandler
    {
        services.AddEventHandlers<IGuildRoleUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.GuildRoleDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddGuildRoleDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IGuildRoleDeletedEventHandler
    {
        services.AddEventHandlers<IGuildRoleDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.InviteCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddInviteCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IInviteCreatedEventHandler
    {
        services.AddEventHandlers<IInviteCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.InviteDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddInviteDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IInviteDeletedEventHandler
    {
        services.AddEventHandlers<IInviteDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageCreatedEventHandler
    {
        services.AddEventHandlers<IMessageCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageAcknowledged"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageAcknowledgedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageAcknowledgedEventHandler
    {
        services.AddEventHandlers<IMessageAcknowledgedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageUpdatedEventHandler
    {
        services.AddEventHandlers<IMessageUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageDeletedEventHandler
    {
        services.AddEventHandlers<IMessageDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessagesBulkDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessagesBulkDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IMessagesBulkDeletedEventHandler
    {
        services.AddEventHandlers<IMessagesBulkDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageReactionAdded"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageReactionAddedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageReactionAddedEventHandler
    {
        services.AddEventHandlers<IMessageReactionAddedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageReactionRemoved"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageReactionRemovedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageReactionRemovedEventHandler
    {
        services.AddEventHandlers<IMessageReactionRemovedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageReactionsCleared"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageReactionsClearedHandler<THandler>(IServiceCollection services) where THandler : class, IMessageReactionsClearedEventHandler
    {
        services.AddEventHandlers<IMessageReactionsClearedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.MessageReactionRemovedEmoji"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddMessageReactionRemovedEmojiHandler<THandler>(IServiceCollection services) where THandler : class, IMessageReactionRemovedEmojiEventHandler
    {
        services.AddEventHandlers<IMessageReactionRemovedEmojiEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.PresenceUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddPresenceUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IPresenceUpdatedEventHandler
    {
        services.AddEventHandlers<IPresenceUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.UserSettingsUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddUserSettingsUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IUserSettingsUpdatedEventHandler
    {
        services.AddEventHandlers<IUserSettingsUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.UserUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddUserUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IUserUpdatedEventHandler
    {
        services.AddEventHandlers<IUserUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.VoiceStateUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddVoiceStateUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IVoiceStateUpdatedEventHandler
    {
        services.AddEventHandlers<IVoiceStateUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.VoiceServerUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddVoiceServerUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IVoiceServerUpdatedEventHandler
    {
        services.AddEventHandlers<IVoiceServerUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadCreatedEventHandler
    {
        services.AddEventHandlers<IThreadCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadUpdatedEventHandler
    {
        services.AddEventHandlers<IThreadUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadDeletedEventHandler
    {
        services.AddEventHandlers<IThreadDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadListSynced"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadListSyncedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadListSyncedEventHandler
    {
        services.AddEventHandlers<IThreadListSyncedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadMemberUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadMemberUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadMemberUpdatedEventHandler
    {
        services.AddEventHandlers<IThreadMemberUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ThreadMembersUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddThreadMembersUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IThreadMembersUpdatedEventHandler
    {
        services.AddEventHandlers<IThreadMembersUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.IntegrationCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddIntegrationCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IIntegrationCreatedEventHandler
    {
        services.AddEventHandlers<IIntegrationCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.IntegrationUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddIntegrationUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IIntegrationUpdatedEventHandler
    {
        services.AddEventHandlers<IIntegrationUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.IntegrationDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddIntegrationDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IIntegrationDeletedEventHandler
    {
        services.AddEventHandlers<IIntegrationDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.StageInstanceCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddStageInstanceCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IStageInstanceCreatedEventHandler
    {
        services.AddEventHandlers<IStageInstanceCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.StageInstanceUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddStageInstanceUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IStageInstanceUpdatedEventHandler
    {
        services.AddEventHandlers<IStageInstanceUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.StageInstanceDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddStageInstanceDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IStageInstanceDeletedEventHandler
    {
        services.AddEventHandlers<IStageInstanceDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.InteractionCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddInteractionCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IInteractionCreatedEventHandler
    {
        services.AddEventHandlers<IInteractionCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ComponentInteractionCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddComponentInteractionCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IComponentInteractionCreatedEventHandler
    {
        services.AddEventHandlers<IComponentInteractionCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ModalSubmitted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddModalSubmittedHandler<THandler>(IServiceCollection services) where THandler : class, IModalSubmittedEventHandler
    {
        services.AddEventHandlers<IModalSubmittedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ContextMenuInteractionCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddContextMenuInteractionCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IContextMenuInteractionCreatedEventHandler
    {
        services.AddEventHandlers<IContextMenuInteractionCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.TypingStarted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddTypingStartedHandler<THandler>(IServiceCollection services) where THandler : class, ITypingStartedEventHandler
    {
        services.AddEventHandlers<ITypingStartedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.UnknownEvent"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddUnknownEventHandler<THandler>(IServiceCollection services) where THandler : class, IUnknownEventEventHandler
    {
        services.AddEventHandlers<IUnknownEventEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.WebhooksUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddWebhooksUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IWebhooksUpdatedEventHandler
    {
        services.AddEventHandlers<IWebhooksUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.ClientErrored"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddClientErroredHandler<THandler>(IServiceCollection services) where THandler : class, IClientErroredEventHandler
    {
        services.AddEventHandlers<IClientErroredEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.AutoModerationRuleCreated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddAutoModerationRuleCreatedHandler<THandler>(IServiceCollection services) where THandler : class, IAutoModerationRuleCreatedEventHandler
    {
        services.AddEventHandlers<IAutoModerationRuleCreatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.AutoModerationRuleUpdated"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddAutoModerationRuleUpdatedHandler<THandler>(IServiceCollection services) where THandler : class, IAutoModerationRuleUpdatedEventHandler
    {
        services.AddEventHandlers<IAutoModerationRuleUpdatedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.AutoModerationRuleDeleted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddAutoModerationRuleDeletedHandler<THandler>(IServiceCollection services) where THandler : class, IAutoModerationRuleDeletedEventHandler
    {
        services.AddEventHandlers<IAutoModerationRuleDeletedEventHandler>().RegisterHandler<THandler>();
        return services;
    }


    /// <summary>
    /// Shorthand to register <typeparamref name="THandler"/> to the event <see cref="DiscordShardedClient.AutoModerationRuleExecuted"/>
    /// </summary>
    /// <typeparam name="THandler">The <see cref="IDiscordEventHandler{TArgs}"/> to register for the event</typeparam>
    public static IServiceCollection AddAutoModerationRuleExecutedHandler<THandler>(IServiceCollection services) where THandler : class, IAutoModerationRuleExecutedEventHandler
    {
        services.AddEventHandlers<IAutoModerationRuleExecutedEventHandler>().RegisterHandler<THandler>();
        return services;
    }

}