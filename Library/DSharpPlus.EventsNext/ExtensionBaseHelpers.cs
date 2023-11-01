using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DSharpPlus.EventsNext;

internal static class ExtensionBaseHelpers
{
    private static void EnsureValidExtensionType<TExtension>() where TExtension : EventsNextExtensionBase
    {
        if (typeof(TExtension) == typeof(EventsNextExtensionBase))
            throw new ArgumentNullException(nameof(TExtension), $"{nameof(TExtension)} must be derived from {nameof(EventsNextExtensionBase)} but not exactly {nameof(EventsNextExtensionBase)}");
    }
    private static void EnsureValidConfigurationType<TConfig>() where TConfig : EventsNextConfigurationBase
    {
        if (typeof(TConfig) == typeof(EventsNextConfigurationBase))
            throw new ArgumentNullException(nameof(TConfig), $"{nameof(TConfig)} must be derived from {nameof(EventsNextConfigurationBase)} but not exactly {nameof(EventsNextConfigurationBase)}");
    }
    private static void EnsureValidTypes<TExtension, TConfig>() where TExtension : EventsNextExtensionBase where TConfig : EventsNextConfigurationBase
    {
        EnsureValidExtensionType<TExtension>();
        EnsureValidConfigurationType<TConfig>();
    }

    public static void EnsureEventsNextNotAdded(this DiscordClient client)
    {
        EventsNextExtensionBase? existing = client.GetExtension<EventsNextExtensionBase>();
        if (existing != null)
            throw new InvalidOperationException($"EventsNext is already enabled for that client (by type {existing.GetType().Name}).");
    }

    public static TExtension? GetEventsNext<TExtension>(this DiscordClient client) where TExtension : EventsNextExtensionBase
    {
        EnsureValidExtensionType<TExtension>();
        EventsNextExtensionBase? existing = client.GetExtension<EventsNextExtensionBase>();

        if (existing is null)
            return null;

        if (existing is not TExtension cast)
            throw new InvalidOperationException($"EventsNext is already enabled for that client (by type {existing.GetType().Name}, but {typeof(TExtension).Name} was expected).");

        return cast;
    }

    /// <summary>
    /// Enables EventsNext module on this <see cref="DiscordClient"/>.
    /// </summary>
    /// <param name="client">Client to enable CommandsNext for.</param>
    /// <param name="cfg">CommandsNext configuration to use.</param>
    /// <returns>Created <see cref="EventsNextExtensionBase"/>.</returns>
    public static TExtension UseEventsNext<TExtension, TConfig>(this DiscordClient client, TConfig cfg, Func<TConfig, TExtension> constructor) where TExtension : EventsNextExtensionBase where TConfig : EventsNextConfigurationBase
    {
        client.EnsureEventsNextNotAdded();

        TExtension EventsNextExtension = constructor(cfg);
        client.AddExtension(EventsNextExtension);
        return EventsNextExtension;
    }

    /// <summary>
    /// Enables EventsNext module on all shards in this <see cref="DiscordShardedClient"/>
    /// </summary>
    /// <param name="client">Client to enable CommandsNext for.</param>
    /// <param name="cfg">CommandsNext configuration to use.</param>
    /// <returns>A dictionary of created <typeparamref name="TExtension"/>, indexed by shard id..</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<IReadOnlyDictionary<int, TExtension>> UseEventsNextAsync<TExtension, TConfig>(this DiscordShardedClient client, TConfig cfg, Func<TConfig, TExtension> constructor) where TExtension : EventsNextExtensionBase where TConfig : EventsNextConfigurationBase
    {
        EnsureValidTypes<TExtension, TConfig>();
        EnsureValidExtensionType<TExtension>();

        await client.InitializeShardsAsync();
        return SyncTail(client, cfg, constructor);
        static IReadOnlyDictionary<int, TExtension> SyncTail(DiscordShardedClient client, TConfig cfg, Func<TConfig, TExtension> constructor) => client.ShardClients.Values.ToDictionary(s => s.ShardId, s => s.GetEventsNext<TExtension>() ?? s.UseEventsNext(cfg, constructor))!;
    }

    public static async Task<IReadOnlyDictionary<int, TExtension>> GetEventsNextAsync<TExtension>(this DiscordShardedClient client) where TExtension : EventsNextExtensionBase
    {
        EnsureValidExtensionType<TExtension>();

        await client.InitializeShardsAsync();
        return SyncTail(client);

        static IReadOnlyDictionary<int, TExtension> SyncTail(DiscordShardedClient client) => client.ShardClients.Values.ToDictionary(s => s.ShardId, s => s.GetEventsNext<TExtension>()!);
    }
}