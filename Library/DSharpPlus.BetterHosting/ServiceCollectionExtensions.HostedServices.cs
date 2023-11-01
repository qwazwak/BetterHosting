using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Services.Hosted;
using System;

namespace DSharpPlus.BetterHosting;

/// <summary>
/// Extension methods for adding hosted services depending upon discord clients
/// </summary>
public static class HostedDiscordServiceExtensions
{
    public static IServiceCollection AddHostedDiscordService<TService>(this IServiceCollection services) where TService : DiscordBackgroundServiceBase
    {
        if (typeof(TService) == typeof(DiscordBackgroundServiceBase)) throw new ArgumentException($"{typeof(DiscordBackgroundServiceBase).Name} is not a valid service");
        ArgumentNullException.ThrowIfNull(services);
        services.AddHostedService<TService>();
        return services;
    }

    public static IServiceCollection AddSimpleHostedDiscordService<TService>(this IServiceCollection services) where TService : class, IDiscordBackgroundService
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddTransient<TService>();
        services.AddHostedService<DiscordBackgroundServiceHost<TService>>();
        return services;
    }
}