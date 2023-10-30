using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Hosted;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHostedDiscordService<TService>(this IServiceCollection services) where TService : class, IDiscordBackgroundService
    {
        ArgumentNullException.ThrowIfNull(services);
        services.TryAddTransient<TService>();
        services.AddHostedService<DiscordBackgroundServiceHost<TService>>();
        return services;
    }
    internal static IServiceCollection AddHostedDiscordService(this IServiceCollection services, Type serviceType)
    {
        Debug.Assert(serviceType.IsAssignableTo(typeof(IDiscordBackgroundService)));
        services.AddTransient(serviceType);
        Type hostedType = typeof(DiscordBackgroundServiceHost<>).MakeGenericType(serviceType);
        services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IHostedService), hostedType));

        return services;
    }
}