using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Services.Interfaces;
using System;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting;

/// <summary>
/// Extension methods to ease working with <see cref="IDefaultActivityProvider"/>
/// </summary>
public static class DefaultActivityProviderExtensions
{
    /// <summary>
    /// Adds a transient implementation of <see cref="IDefaultActivityProvider"/> by <typeparamref name="TImplementation"/> to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="TImplementation">The type of <see cref="IDefaultActivityProvider"/> to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>The same <see cref="IServiceProvider"/> for chaining</returns>
    /// <seealso cref="IDefaultActivityProvider"/>
    public static IServiceCollection AddDefaultActivityProvider<TImplementation>(this IServiceCollection services) where TImplementation : class, IDefaultActivityProvider => services.AddTransient<IDefaultActivityProvider, TImplementation>();

    public static OptionsBuilder<DiscordActivity> AddDefaultActivityProvider(this IServiceCollection services, string path) => services.AddDefaultActivityProvider<DefaultActivityOptionsAdapter>().AddOptions<DiscordActivity>().BindConfiguration(path, o => o.BindNonPublicProperties = true);

    /// <summary>
    /// Adds an implementation of <see cref="IDefaultActivityProvider"/> to the specified <see cref="IServiceCollection"/> which will return the given <paramref name="activity"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="activity">The <see cref="DiscordActivity"/> to return.</param>
    /// <returns>The same <see cref="IServiceProvider"/> for chaining</returns>
    /// <seealso cref="IDefaultActivityProvider"/>
    public static IServiceCollection AddDefaultActivityProvider(this IServiceCollection services, DiscordActivity activity) => services.AddTransient<IDefaultActivityProvider>(_ => new InstanceActivityProvider(activity));
}