using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DSharpPlus.EventsNext;

namespace DSharpPlus.EventsNext.Plain;

public static class ExtensionMethods
{
    /// <summary>
    /// Enables EventsNext module on this <see cref="DiscordClient"/>.
    /// </summary>
    /// <param name="client">Client to enable CommandsNext for.</param>
    /// <param name="cfg">CommandsNext configuration to use.</param>
    /// <returns>Created <see cref="EventsNextExtension"/>.</returns>
    public static EventsNextExtension UseEventsNext(this DiscordClient client, EventsNextConfiguration cfg) => client.UseEventsNext<EventsNextExtension, EventsNextConfiguration>(cfg, c => new(c));

    /// <summary>
    /// Enables EventsNext module on all shards in this <see cref="DiscordShardedClient"/>
    /// </summary>
    /// <param name="client">Client to enable CommandsNext for.</param>
    /// <param name="cfg">CommandsNext configuration to use.</param>
    /// <returns>A dictionary of created <see cref="EventsNextExtension"/>, indexed by shard id..</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Task<IReadOnlyDictionary<int, EventsNextExtension>> UseEventsNextAsync(this DiscordShardedClient client, EventsNextConfiguration cfg) => client.UseEventsNextAsync<EventsNextExtension, EventsNextConfiguration>(cfg, c => new(c));

    //
    // Summary:
    //     Gets the active CommandsNext module for this client.
    //
    // Parameters:
    //   client:
    //     Client to get CommandsNext module from.
    //
    // Returns:
    //     The module, or null if not activated.
    public static EventsNextExtension? GetEventsNext(this DiscordClient client) => client.GetEventsNext<EventsNextExtension>();

    //
    // Summary:
    //     Gets the active CommandsNext modules for all shards in this client.
    //
    // Parameters:
    //   client:
    //     Client to get CommandsNext instances from.
    //
    // Returns:
    //     A dictionary of the modules, indexed by shard id.
    public static Task<IReadOnlyDictionary<int, EventsNextExtension>> GetEventsNextAsync(this DiscordShardedClient client) => client.GetEventsNextAsync<EventsNextExtension>();
}