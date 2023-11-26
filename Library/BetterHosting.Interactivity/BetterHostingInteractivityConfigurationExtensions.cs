using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BetterHosting.Interactivity;

/// <summary>
/// Extension methods to add <see cref="IOptions{TOptions}"/> for <see cref="InteractivityConfiguration"/>
/// </summary>
[ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.SimpleWrapperExtension)]
public static class BetterHostingInteractivityConfigurationExtensions
{
    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}">IOptions{InteractivityConfiguration}</see> which provides the input <paramref name="configuration"/> to the <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">The collection to add <paramref name="configuration"/> to</param>
    /// <param name="configuration">The configuration to use</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that configure calls can be chained in it.</returns>
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, InteractivityConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        InteractivityConfiguration copy = new(configuration);
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(copy)).AddOptions<InteractivityConfiguration>();
    }

    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}">IOptions{InteractivityConfiguration}</see> which will read from the <see cref="IConfiguration"/>to the <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">The collection to add the configuration to</param>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that configure calls can be chained in it.</returns>s
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, string configSectionPath) => services.AddOptions<InteractivityConfiguration>().BindConfiguration(configSectionPath,  [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = true);
}