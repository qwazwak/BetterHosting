using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

namespace DSharpPlus.BetterHosting.Tools.Extensions;

/// <summary>
/// Helper extensions for working with <see cref="DiscordChannel"/>
/// </summary>
public static class DiscordChannelExtensions
{
    /// <summary>
    /// Returns a specific message or null
    /// </summary>
    /// <remarks>
    /// A wrapper for <see cref="DiscordChannel.GetMessageAsync(ulong, bool)"/>, except instead of throwing an exception when not found, null will be returned
    /// <para>
    /// Cached message objects will not be returned if DSharpPlus.DiscordConfiguration.MessageCacheSize
    /// is set to zero, if the client does not have the DSharpPlus.DiscordIntents.GuildMessages
    /// or DSharpPlus.DiscordIntents.DirectMessages intents, or if the discord client
    /// is a DSharpPlus.DiscordShardedClient.
    /// </para>
    /// </remarks>
    /// <param name="channel">The channel to read the message from</param>
    /// <param name="id">The ID of the message</param>
    /// <param name="skipCache">Whether to always make a REST request.</param>
    /// <exception cref="UnauthorizedException">Thrown when the client does not have the <see cref="Permissions.ReadMessageHistory"/> permission.</exception>
    /// <exception cref="BadRequestException">Thrown when an invalid parameter was provided.</exception>
    /// <exception cref="ServerErrorException">Thrown when Discord is unable to process the request.</exception>
    public static async Task<DiscordMessage?> GetMessageOrNullAsync(this DiscordChannel channel, ulong id, bool skipCache = false)
    {
        try
        {
            return await channel.GetMessageAsync(id, skipCache);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
