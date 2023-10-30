using System.Collections.Generic;
using DSharpPlus.Entities;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IDiscordShardedClient : IDiscord
{
    
    //
    // Summary:
    //     Gets all client shards.
    public IReadOnlyDictionary<int, DiscordClient> ShardClients { get; }

    //
    // Summary:
    //     Initializes and connects all shards.
    //
    // Exceptions:
    //   T:System.AggregateException:
    //
    //   T:System.InvalidOperationException:
    public async Task StartAsync()
    {
        if (_isStarted)
        {
            throw new InvalidOperationException("This client has already been started.");
        }

        _isStarted = true;
        try
        {
            if (Configuration.TokenType != TokenType.Bot)
            {
                Logger.LogWarning(LoggerEvents.Misc, "You are logging in with a token that is not a bot token. This is not officially supported by Discord, and can result in your account being terminated if you aren't careful.");
            }

            Logger.LogInformation(LoggerEvents.Startup, "DSharpPlus, version {Version}", _versionString.Value);
            int shardc = await InitializeShardsAsync();
            List<Task> connectTasks = new List<Task>();
            Logger.LogInformation(LoggerEvents.ShardStartup, "Booting {ShardCount} shards.", shardc);
            for (int i = 0; i < shardc; i++)
            {
                if (GatewayInfo.SessionBucket.MaxConcurrency < 1)
                {
                    GatewayInfo.SessionBucket.MaxConcurrency = 1;
                }

                if (GatewayInfo.SessionBucket.MaxConcurrency == 1)
                {
                    await ConnectShardAsync(i);
                    continue;
                }

                connectTasks.Add(ConnectShardAsync(i));
                if (connectTasks.Count == GatewayInfo.SessionBucket.MaxConcurrency)
                {
                    await Task.WhenAll(connectTasks);
                    connectTasks.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            await InternalStopAsync(enableLogger: false);
            string message = "Shard initialization failed, check inner exceptions for details: ";
            ILogger<BaseDiscordClient> logger = Logger;
            EventId shardClientError = LoggerEvents.ShardClientError;
            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
            defaultInterpolatedStringHandler.AppendFormatted(message);
            defaultInterpolatedStringHandler.AppendLiteral("\n");
            defaultInterpolatedStringHandler.AppendFormatted(ex);
            logger.LogCritical(shardClientError, defaultInterpolatedStringHandler.ToStringAndClear());
            throw new AggregateException(message, ex);
        }
    }

    //
    // Summary:
    //     Disconnects and disposes of all shards.
    //
    // Exceptions:
    //   T:System.InvalidOperationException:
    public Task StopAsync()
    {
        return InternalStopAsync();
    }

    //
    // Summary:
    //     Gets a shard from a guild ID.
    //
    //     If automatically sharding, this will use the DSharpPlus.Utilities.GetShardId(System.UInt64,System.Int32)
    //     method. Otherwise if manually sharding, it will instead iterate through each
    //     shard's guild caches.
    //
    // Parameters:
    //   guildId:
    //     The guild ID for the shard.
    //
    // Returns:
    //     The found DSharpPlus.DiscordClient shard. Otherwise null if the shard was not
    //     found for the guild ID.
    public DiscordClient GetShard(ulong guildId)
    {
        int num = (_manuallySharding ? GetShardIdFromGuilds(guildId) : Utilities.GetShardId(guildId, ShardClients.Count));
        return (num != -1) ? _shards[num] : null;
    }

    //
    // Summary:
    //     Gets a shard from a guild.
    //
    //     If automatically sharding, this will use the DSharpPlus.Utilities.GetShardId(System.UInt64,System.Int32)
    //     method. Otherwise if manually sharding, it will instead iterate through each
    //     shard's guild caches.
    //
    // Parameters:
    //   guild:
    //     The guild for the shard.
    //
    // Returns:
    //     The found DSharpPlus.DiscordClient shard. Otherwise null if the shard was not
    //     found for the guild.
    public DiscordClient GetShard(DiscordGuild guild)
    {
        return GetShard(guild.Id);
    }

    //
    // Summary:
    //     Updates playing statuses on all shards.
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
    //
    // Returns:
    //     Asynchronous operation.
    public async Task UpdateStatusAsync(DiscordActivity activity = null, UserStatus? userStatus = null, DateTimeOffset? idleSince = null)
    {
        List<Task> tasks = new List<Task>();
        foreach (DiscordClient client in _shards.Values)
        {
            tasks.Add(client.UpdateStatusAsync(activity, userStatus, idleSince));
        }

        await Task.WhenAll(tasks);
    }

    public async Task<int> InitializeShardsAsync()
    {
        if (_shards.Count != 0)
        {
            return _shards.Count;
        }

        GatewayInfo = await GetGatewayInfoAsync();
        int shardc = ((Configuration.ShardCount == 1) ? GatewayInfo.ShardCount : Configuration.ShardCount);
        ShardedLoggerFactory lf = new ShardedLoggerFactory(Logger);
        for (int i = 0; i < shardc; i++)
        {
            DiscordConfiguration cfg = new DiscordConfiguration(Configuration)
            {
                ShardId = i,
                ShardCount = shardc,
                LoggerFactory = lf
            };
            DiscordClient client = new DiscordClient(cfg);
            if (!_shards.TryAdd(i, client))
            {
                throw new InvalidOperationException("Could not initialize shards.");
            }
        }

        return shardc;
    }

    internal void EventErrorHandler<TArgs>(AsyncEvent<DiscordClient, TArgs> asyncEvent, Exception ex, AsyncEventHandler<DiscordClient, TArgs> handler, DiscordClient sender, TArgs eventArgs) where TArgs : AsyncEventArgs
    {
        Logger.LogError(LoggerEvents.EventHandlerException, ex, "Event handler exception for event {Event} thrown from {Method} (defined in {DeclaringType})", asyncEvent.Name, handler.Method, handler.Method.DeclaringType);
        _clientErrored.InvokeAsync(sender, new ClientErrorEventArgs
        {
            EventName = asyncEvent.Name,
            Exception = ex
        }).Wait();
    }
}
