using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSharpPlus.EventsNext.BetterHosting;

/// <summary>
/// Extension methods to simplify adding EventsNExt to DiscordClients
/// </summary>
public static class EventsNextExtentionMethods
{
    /// <summary>
    /// Enables EventsNext module on all shards in this <see cref="DiscordShardedClient"/>
    /// </summary>
    /// <param name="client">Client to enable CommandsNext for.</param>
    /// <param name="cfg">CommandsNext configuration to use.</param>
    /// <returns>A dictionary of created <see cref="EventsNextExtension"/>, indexed by shard id..</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<IReadOnlyDictionary<int, EventsNextExtension>> UseEventsNextAsync(this DiscordShardedClient client, EventsNextConfiguration cfg) => client.UseEventsNextAsync<EventsNextExtension, EventsNextConfiguration>(cfg, c => new(c));

    /// <summary>
    /// Gets the active <see cref="EventsNextExtension"/> for this client.
    /// </summary>
    /// <param name="client">Client to get EventsNext module from.</param>
    /// <returns>The extension, or null if not activated.</returns>
    public static EventsNextExtension? GetEventsNext(this DiscordClient client) => client.GetEventsNext<EventsNextExtension>();

    /// <summary>
    /// Gets the active <see cref="EventsNextExtension"/> for all shards in this client.
    /// </summary>
    /// <param name="client">Client to get EventsNext instances from.</param>
    /// <returns>A dictionary of the extensions, indexed by shard id.</returns>
    public static Task<IReadOnlyDictionary<int, EventsNextExtension>> GetEventsNextAsync(this DiscordShardedClient client) => client.GetEventsNextAsync<EventsNextExtension>();
}