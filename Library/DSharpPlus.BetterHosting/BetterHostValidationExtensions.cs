using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;
using System.Linq;

namespace DSharpPlus.BetterHosting;

internal static class BetterHostValidationExtensions
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(DiscordConfiguration.Intents)}")]
    extern static DiscordIntents GetIntents(DiscordConfiguration @this);

    public static IHostBuilder ValidateRequiredIntents(this IHostBuilder builder, params DiscordIntents[] requiredIntents) => builder.ConfigureServices(s => s.ValidateRequiredIntents(requiredIntents));
    public static IServiceCollection ValidateRequiredIntents(this IServiceCollection services, params DiscordIntents[] requiredIntents)
    {
        services.AddOptions<DiscordConfiguration>().Validate(o =>
        {
            DiscordIntents actualIntents = GetIntents(o);
            return requiredIntents.All(r => actualIntents.HasIntent(r));
        }, $"One or more required {nameof(DiscordIntents)} are not present, required intents are: {string.Join(", ", requiredIntents.Select(e => e.ToString()))}").ValidateOnStart();
        return services;
    }
}
