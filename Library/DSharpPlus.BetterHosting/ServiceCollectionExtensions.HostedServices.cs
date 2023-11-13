using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Services.Hosted;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting;

/// <summary>
/// Extension methods for adding hosted services depending upon discord clients
/// </summary>
public static class HostedDiscordServiceExtensions
{
    /// <summary>
    /// Registers a <see cref="DiscordBackgroundServiceHost{T}"/> which will handle running of <see cref="AddHostedDiscordService{TService}(IServiceCollection)"/>
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddHostedDiscordService<TService>(this IServiceCollection services) where TService : class, IDiscordBackgroundService
    {
        services.AddTransient<TService>();
        services.AddSingleton<IHostedService, DiscordBackgroundServiceHost<TService>>();
        return services;
    }
}