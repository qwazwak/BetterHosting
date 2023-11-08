using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Services.Interfaces;
using System;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Tools.Extensions.Internal;

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

    /// <summary>
    /// Adds a transient implementation of <see cref="IDefaultActivityProvider"/> by using <see cref="IOptions{TOptions}"/>, from the path <paramref name="configSectionPath"/>, to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="configSectionPath">The path to bind options from.</param>
    /// <returns>A <see cref="OptionsBuilder{DiscordActivity}"/> builder to further configure the options with</returns>
    /// <seealso cref="IDefaultActivityProvider"/>
    public static OptionsBuilder<DiscordActivity> AddDefaultActivityByOptions(this IServiceCollection services, string configSectionPath) => services.AddDefaultActivityProvider<DefaultActivityOptionsAdapter>().AddOptions<DiscordActivity>().BindConfiguration(configSectionPath, bindNonPublicProperties: true);

    /// <summary>
    /// Adds an implementation of <see cref="IDefaultActivityProvider"/> to the specified <see cref="IServiceCollection"/> which will return the given <paramref name="activity"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="activity">The <see cref="DiscordActivity"/> to return.</param>
    /// <returns>The same <see cref="IServiceProvider"/> for chaining</returns>
    /// <seealso cref="IDefaultActivityProvider"/>
    public static IServiceCollection AddDefaultActivityProvider(this IServiceCollection services, DiscordActivity activity) => services.AddTransient<IDefaultActivityProvider>([ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (_) => new InstanceActivityProvider(activity));
}