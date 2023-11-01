using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.Net;
using DSharpPlus.Net.Models;
using Microsoft.Extensions.Configuration;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IDiscordClient : IDiscord
{
    //
    // Summary:
    //     Gets the cached guilds for this client.
    //
    // Summary:
    //     Gets a dictionary of guilds that this client is in. The dictionary's key is the
    //     guild ID. Note that the guild objects in this dictionary will not be filled in
    //     if the specific guilds aren't available (the DSharpPlus.DiscordClient.GuildAvailable
    //     or DSharpPlus.DiscordClient.GuildDownloadCompleted events haven't been fired
    //     yet)
    public IReadOnlyDictionary<ulong, DiscordGuild> Guilds { get; }

    //
    // Summary:
    //     Gets the current API application.
    //
    // Returns:
    //     Current API application.
    public Task<DiscordApplication> GetCurrentApplicationAsync();

    //
    // Summary:
    //     Gets a list of regions
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<IReadOnlyList<DiscordVoiceRegion>> ListVoiceRegionsAsync();

    //
    // Summary:
    //     Initializes this client. This method fetches information about current user,
    //     application, and voice regions.
    public Task InitializeAsync();

    //
    // Summary:
    //     Gets the current gateway info for the provided token.
    //
    //     If no value is provided, the configuration value will be used instead.
    //
    // Returns:
    //     A gateway info object.
    public Task<GatewayInfo> GetGatewayInfoAsync(string token = null);

    //
    // Summary:
    //     Gets the gateway URL.
    public Uri GatewayUri { get; /*internal set;*/ }

    //
    // Summary:
    //     Gets the total number of shards the bot is connected to.
    public int ShardCount => (GatewayInfo != null) ? GatewayInfo.ShardCount : base.Configuration.ShardCount;

    //
    // Summary:
    //     Gets the currently connected shard ID.
    public int ShardId => Configuration.ShardId;

    //
    // Summary:
    //     Gets the intents configured for this client.
    public DiscordIntents Intents => Configuration.Intents;

    //
    // Summary:
    //     Gets a dictionary of DM channels that have been cached by this client. The dictionary's
    //     key is the channel ID.
    public IReadOnlyDictionary<ulong, DiscordDmChannel> PrivateChannels { get; }

    // Summary:
    //     Gets the WS latency for this client.
    public int Ping { get; }

    //
    // Summary:
    //     Gets the collection of presences held by this client.
    public IReadOnlyDictionary<ulong, DiscordPresence> Presences { get; }

    internal static TimeSpan EventExecutionLimit { get; } = TimeSpan.FromSeconds(1.0);


    //
    // Summary:
    //     Registers an extension with this client.
    //
    // Parameters:
    //   ext:
    //     Extension to register.
    public void AddExtension(BaseExtension ext);

    //
    // Summary:
    //     Retrieves a previously-registered extension from this client.
    //
    // Type parameters:
    //   T:
    //     Type of extension to retrieve.
    //
    // Returns:
    //     The requested extension.
    public T GetExtension<T>() where T : BaseExtension;

    //
    // Summary:
    //     Connects to the gateway
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when an invalid token was provided.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task ConnectAsync(DiscordActivity activity = null!, UserStatus? status = null, DateTimeOffset? idlesince = null);

    public Task ReconnectAsync(bool startNewSession = false);

    //
    // Summary:
    //     Disconnects from the gateway
    public Task DisconnectAsync();

    //
    // Summary:
    //     Gets a sticker.
    //
    // Parameters:
    //   stickerId:
    //     The ID of the sticker.
    //
    // Returns:
    //     The specified sticker
    public Task<DiscordMessageSticker> GetStickerAsync(ulong stickerId);
    //
    // Summary:
    //     Gets a collection of sticker packs that may be used by nitro users.
    public Task<IReadOnlyList<DiscordMessageStickerPack>> GetStickerPacksAsync();
    //
    // Summary:
    //     Gets a user
    //
    // Parameters:
    //   userId:
    //     ID of the user
    //
    //   updateCache:
    //     Whether to always make a REST request and update cache. Passing true will update
    //     the user, updating stale properties such as DSharpPlus.Entities.DiscordUser.BannerHash.
    //
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordUser> GetUserAsync(ulong userId, bool updateCache = false);

    //
    // Summary:
    //     Gets a channel
    //
    // Parameters:
    //   id:
    //     The ID of the channel to get.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordChannel> GetChannelAsync(ulong id);

    //
    // Summary:
    //     Sends a message
    //
    // Parameters:
    //   channel:
    //     Channel to send to.
    //
    //   content:
    //     Message content to send.
    //
    // Returns:
    //     The Discord Message that was sent.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when the client does not have the DSharpPlus.Permissions.SendMessages
    //     permission.
    //
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordMessage> SendMessageAsync(DiscordChannel channel, string content);
    //
    // Summary:
    //     Sends a message
    //
    // Parameters:
    //   channel:
    //     Channel to send to.
    //
    //   embed:
    //     Embed to attach to the message.
    //
    // Returns:
    //     The Discord Message that was sent.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when the client does not have the DSharpPlus.Permissions.SendMessages
    //     permission.
    //
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordMessage> SendMessageAsync(DiscordChannel channel, DiscordEmbed embed);
    //
    // Summary:
    //     Sends a message
    //
    // Parameters:
    //   channel:
    //     Channel to send to.
    //
    //   content:
    //     Message content to send.
    //
    //   embed:
    //     Embed to attach to the message.
    //
    // Returns:
    //     The Discord Message that was sent.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when the client does not have the DSharpPlus.Permissions.SendMessages
    //     permission.
    //
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordMessage> SendMessageAsync(DiscordChannel channel, string content, DiscordEmbed embed);
    //
    // Summary:
    //     Sends a message
    //
    // Parameters:
    //   channel:
    //     Channel to send to.
    //
    //   builder:
    //     The Discord Message builder.
    //
    // Returns:
    //     The Discord Message that was sent.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when the client does not have the DSharpPlus.Permissions.SendMessages
    //     permission if TTS is false and DSharpPlus.Permissions.SendTtsMessages if TTS
    //     is true.
    //
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordMessage> SendMessageAsync(DiscordChannel channel, DiscordMessageBuilder builder);
    //
    // Summary:
    //     Sends a message
    //
    // Parameters:
    //   channel:
    //     Channel to send to.
    //
    //   action:
    //     The Discord Message builder.
    //
    // Returns:
    //     The Discord Message that was sent.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.UnauthorizedException:
    //     Thrown when the client does not have the DSharpPlus.Permissions.SendMessages
    //     permission if TTS is false and DSharpPlus.Permissions.SendTtsMessages if TTS
    //     is true.
    //
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordMessage> SendMessageAsync(DiscordChannel channel, Action<DiscordMessageBuilder> action);

    //
    // Summary:
    //     Creates a guild. This requires the bot to be in less than 10 guilds total.
    //
    // Parameters:
    //   name:
    //     Name of the guild.
    //
    //   region:
    //     Voice region of the guild.
    //
    //   icon:
    //     Stream containing the icon for the guild.
    //
    //   verificationLevel:
    //     Verification level for the guild.
    //
    //   defaultMessageNotifications:
    //     Default message notification settings for the guild.
    //
    //   systemChannelFlags:
    //     System channel flags fopr the guild.
    //
    // Returns:
    //     The created guild.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the channel does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordGuild> CreateGuildAsync(string name, string region = null, Optional<Stream> icon = default(Optional<Stream>), VerificationLevel? verificationLevel = null, DefaultMessageNotifications? defaultMessageNotifications = null, SystemChannelFlags? systemChannelFlags = null);

    //
    // Summary:
    //     Creates a guild from a template. This requires the bot to be in less than 10
    //     guilds total.
    //
    // Parameters:
    //   code:
    //     The template code.
    //
    //   name:
    //     Name of the guild.
    //
    //   icon:
    //     Stream containing the icon for the guild.
    //
    // Returns:
    //     The created guild.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordGuild> CreateGuildFromTemplateAsync(string code, string name, Optional<Stream> icon = default(Optional<Stream>));

    //
    // Summary:
    //     Gets a guild.
    //
    //     Setting withCounts to true will make a REST request.
    //
    // Parameters:
    //   id:
    //     The guild ID to search for.
    //
    //   withCounts:
    //     Whether to include approximate presence and member counts in the returned guild.
    //
    //
    // Returns:
    //     The requested Guild.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the guild does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordGuild> GetGuildAsync(ulong id, bool? withCounts = null);

    //
    // Summary:
    //     Gets a guild preview
    //
    // Parameters:
    //   id:
    //     The guild ID.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the guild does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordGuildPreview> GetGuildPreviewAsync(ulong id);
    //
    // Summary:
    //     Gets an invite.
    //
    // Parameters:
    //   code:
    //     The invite code.
    //
    //   withCounts:
    //     Whether to include presence and total member counts in the returned invite.
    //
    //   withExpiration:
    //     Whether to include the expiration date in the returned invite.
    //
    // Returns:
    //     The requested Invite.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the invite does not exists.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordInvite> GetInviteByCodeAsync(string code, bool? withCounts = null, bool? withExpiration = null);
    //
    // Summary:
    //     Gets a list of connections
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<IReadOnlyList<DiscordConnection>> GetConnectionsAsync();
    //
    // Summary:
    //     Gets a webhook
    //
    // Parameters:
    //   id:
    //     The ID of webhook to get.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the webhook does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordWebhook> GetWebhookAsync(ulong id);
    //
    // Summary:
    //     Gets a webhook
    //
    // Parameters:
    //   id:
    //     The ID of webhook to get.
    //
    //   token:
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the webhook does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordWebhook> GetWebhookWithTokenAsync(ulong id, string token);
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
    public Task UpdateStatusAsync(DiscordActivity activity = null, UserStatus? userStatus = null, DateTimeOffset? idleSince = null);

    //
    // Summary:
    //     Edits current user.
    //
    // Parameters:
    //   username:
    //     New username.
    //
    //   avatar:
    //     New avatar.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.NotFoundException:
    //     Thrown when the user does not exist.
    //
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordUser> UpdateCurrentUserAsync(string username = null, Optional<Stream> avatar = default(Optional<Stream>));

    //
    // Summary:
    //     Gets a guild template by the code.
    //
    // Parameters:
    //   code:
    //     The code of the template.
    //
    // Returns:
    //     The guild template for the code.
    //
    // Exceptions:
    //   T:DSharpPlus.Exceptions.BadRequestException:
    //     Thrown when an invalid parameter was provided.
    //
    //   T:DSharpPlus.Exceptions.ServerErrorException:
    //     Thrown when Discord is unable to process the request.
    public Task<DiscordGuildTemplate> GetTemplateAsync(string code);
    //
    // Summary:
    //     Gets all the global application commands for this application.
    //
    // Returns:
    //     A list of global application commands.
    public Task<IReadOnlyList<DiscordApplicationCommand>> GetGlobalApplicationCommandsAsync();
    //
    // Summary:
    //     Overwrites the existing global application commands. New commands are automatically
    //     created and missing commands are automatically deleted.
    //
    // Parameters:
    //   commands:
    //     The list of commands to overwrite with.
    //
    // Returns:
    //     The list of global commands.
    public Task<IReadOnlyList<DiscordApplicationCommand>> BulkOverwriteGlobalApplicationCommandsAsync(IEnumerable<DiscordApplicationCommand> commands);
    //
    // Summary:
    //     Creates or overwrites a global application command.
    //
    // Parameters:
    //   command:
    //     The command to create.
    //
    // Returns:
    //     The created command.
    public Task<DiscordApplicationCommand> CreateGlobalApplicationCommandAsync(DiscordApplicationCommand command);
    //
    // Summary:
    //     Gets a global application command by its id.
    //
    // Parameters:
    //   commandId:
    //     The ID of the command to get.
    //
    // Returns:
    //     The command with the ID.
    public Task<DiscordApplicationCommand> GetGlobalApplicationCommandAsync(ulong commandId);

    //
    // Summary:
    //     Gets a global application command by its name.
    //
    // Parameters:
    //   commandName:
    //     The name of the command to get.
    //
    // Returns:
    //     The command with the name.
    public Task<DiscordApplicationCommand> GetGlobalApplicationCommandAsync(string commandName);
    //
    // Summary:
    //     Edits a global application command.
    //
    // Parameters:
    //   commandId:
    //     The ID of the command to edit.
    //
    //   action:
    //     Action to perform.
    //
    // Returns:
    //     The edited command.
    public Task<DiscordApplicationCommand> EditGlobalApplicationCommandAsync(ulong commandId, Action<ApplicationCommandEditModel> action);

    //
    // Summary:
    //     Deletes a global application command.
    //
    // Parameters:
    //   commandId:
    //     The ID of the command to delete.
    public Task DeleteGlobalApplicationCommandAsync(ulong commandId);

    //
    // Summary:
    //     Gets all the application commands for a guild.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild to get application commands for.
    //
    // Returns:
    //     A list of application commands in the guild.
    public Task<IReadOnlyList<DiscordApplicationCommand>> GetGuildApplicationCommandsAsync(ulong guildId);

    //
    // Summary:
    //     Overwrites the existing application commands in a guild. New commands are automatically
    //     created and missing commands are automatically deleted.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild.
    //
    //   commands:
    //     The list of commands to overwrite with.
    //
    // Returns:
    //     The list of guild commands.
    public Task<IReadOnlyList<DiscordApplicationCommand>> BulkOverwriteGuildApplicationCommandsAsync(ulong guildId, IEnumerable<DiscordApplicationCommand> commands);

    //
    // Summary:
    //     Creates or overwrites a guild application command.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild to create the application command in.
    //
    //   command:
    //     The command to create.
    //
    // Returns:
    //     The created command.
    public Task<DiscordApplicationCommand> CreateGuildApplicationCommandAsync(ulong guildId, DiscordApplicationCommand command);

    //
    // Summary:
    //     Gets a application command in a guild by its ID.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild the application command is in.
    //
    //   commandId:
    //     The ID of the command to get.
    //
    // Returns:
    //     The command with the ID.
    public Task<DiscordApplicationCommand> GetGuildApplicationCommandAsync(ulong guildId, ulong commandId);

    //
    // Summary:
    //     Edits a application command in a guild.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild the application command is in.
    //
    //   commandId:
    //     The ID of the command to edit.
    //
    //   action:
    //     Action to perform.
    //
    // Returns:
    //     The edited command.
    public Task<DiscordApplicationCommand> EditGuildApplicationCommandAsync(ulong guildId, ulong commandId, Action<ApplicationCommandEditModel> action);
    //
    // Summary:
    //     Deletes a application command in a guild.
    //
    // Parameters:
    //   guildId:
    //     The ID of the guild to delete the application command in.
    //
    //   commandId:
    //     The ID of the command.
    public Task DeleteGuildApplicationCommandAsync(ulong guildId, ulong commandId);

    //
    // Summary:
    //     Gets the gateway session information for this client.
    public GatewayInfo GatewayInfo { get; /*internal set;*/ }
}