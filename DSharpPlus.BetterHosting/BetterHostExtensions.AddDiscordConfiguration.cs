using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.CommandsNext.Options;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting;

public static partial class BetterHostExtensions
{
    private static void AddDiscordConfigurationOption(this IServiceCollection services)
    {
        Microsoft.Extensions.Options.OptionsBuilder<DiscordConfiguration> builder = services.AddOptions<DiscordConfiguration>();
        builder
#if true
        .BindWorkaround(nameof(DiscordConfiguration))
#else
        .Configure<IConfiguration>((config, c) =>
        {
            IConfigurationSection section = c.GetRequiredSection(nameof(DiscordConfiguration));

            bool TryGet<T>(string key, out T value) where T : class => (value = section.GetValue<T?>(key, null)!) != null;
            bool TryGetValue<T>(string key, out T value) where T : struct
            {
                T? temp = section.GetValue<T?>(key, null);
                if (temp.HasValue)
                {
                    value = temp.Value;
                    return true;
                }
                value = default;
                return false;
            }

            if (TryGet(nameof(DiscordConfiguration.Token), out string Token))
                config.Token = Token;

            if (TryGetValue(nameof(DiscordConfiguration.TokenType), out TokenType TokenType))
                config.TokenType = TokenType;

            if (TryGetValue(nameof(DiscordConfiguration.UseRelativeRatelimit), out bool UseRelativeRatelimit))
                config.UseRelativeRatelimit = UseRelativeRatelimit;

            if (TryGet(nameof(DiscordConfiguration.LogTimestampFormat), out string LogTimestampFormat))
                config.LogTimestampFormat = LogTimestampFormat;

            if (TryGetValue(nameof(DiscordConfiguration.LargeThreshold), out int LargeThreshold))
                config.LargeThreshold = LargeThreshold;
            if (TryGetValue(nameof(DiscordConfiguration.ReconnectIndefinitely), out bool ReconnectIndefinitely))
                config.ReconnectIndefinitely = ReconnectIndefinitely;
            if (TryGetValue(nameof(DiscordConfiguration.AutoReconnect), out bool AutoReconnect))
                config.AutoReconnect = AutoReconnect;
            if (TryGetValue(nameof(DiscordConfiguration.ShardId), out int ShardId))
                config.ShardId = ShardId;
            if (TryGetValue(nameof(DiscordConfiguration.ShardCount), out int ShardCount))
                config.ShardCount = ShardCount;
            if (TryGetValue(nameof(DiscordConfiguration.GatewayCompressionLevel), out GatewayCompressionLevel GatewayCompressionLevel))
                config.GatewayCompressionLevel = GatewayCompressionLevel;
            if (TryGetValue(nameof(DiscordConfiguration.MessageCacheSize), out int MessageCacheSize))
                config.MessageCacheSize = MessageCacheSize;
            if (TryGetValue(nameof(DiscordConfiguration.HttpTimeout), out TimeSpan HttpTimeout))
                config.HttpTimeout = HttpTimeout;
            if (TryGetValue(nameof(DiscordConfiguration.AlwaysCacheMembers), out bool AlwaysCacheMembers))
                config.AlwaysCacheMembers = AlwaysCacheMembers;
            if (TryGetValue(nameof(DiscordConfiguration.Intents), out DiscordIntents Intents))
                config.Intents = Intents;
            if (TryGetValue(nameof(DiscordConfiguration.LogUnknownEvents), out bool LogUnknownEvents))
                config.LogUnknownEvents = LogUnknownEvents;
            if (TryGetValue(nameof(DiscordConfiguration.LogUnknownAuditlogs), out bool LogUnknownAuditlogs))
                config.LogUnknownAuditlogs = LogUnknownAuditlogs;
        })
#endif
        .Configure<ILoggerFactory>((o, f) => o.LoggerFactory = f);
    }
}