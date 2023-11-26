using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BetterHosting.VoiceNext;

/// <summary>
/// Extension methods to provide various ways to add an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/>
/// </summary>
public static class VoiceNextConfigurationExtensions
{
    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/> wrapping the input value
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config">The value to provide to <see cref="VoiceNextExtension"/></param>
    /// <returns>An <see cref="OptionsBuilder{TOptions}"/> which can be used to further configure the <see cref="VoiceNextConfiguration"/></returns>
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, VoiceNextConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<VoiceNextConfiguration>();
    }

    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/> which will be bound from the <see cref="IConfiguration"/> by the <paramref name="configSectionPath"/>
    /// </summary>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>An <see cref="OptionsBuilder{TOptions}"/> which can be used to further configure the <see cref="VoiceNextConfiguration"/></returns>
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, string configSectionPath)
    {
        OptionsBuilder<VoiceNextConfiguration> options = services.AddOptions<VoiceNextConfiguration>();
        return options.BindConfiguration(configSectionPath,  [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = true);
    }
}