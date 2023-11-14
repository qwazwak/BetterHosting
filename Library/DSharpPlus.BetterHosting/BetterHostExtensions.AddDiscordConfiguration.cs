using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System;
using DSharpPlus.BetterHosting.Services.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting;

public static partial class BetterHostExtensions
{
    /// <summary>
    /// Registers the dependency injection container to bind <see cref="DiscordConfiguration"/> against
    /// the <see cref="IConfiguration"/> obtained from the DI service provider.
    /// </summary>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="services"/> or <paramref name="configSectionPath" /> is <see langword="null"/>.
    /// </exception>
    /// <seealso cref="OptionsBuilderConfigurationExtensions.Bind{TOptions}(OptionsBuilder{TOptions}, IConfiguration, Action{BinderOptions})"/>
    public static OptionsBuilder<DiscordConfiguration> AddDiscordConfigurationOption(this IServiceCollection services, string configSectionPath = nameof(DiscordConfiguration))
        => services.AddTransient<IConfigureOptions<DiscordConfiguration>, BindConfigurationLoggerFactory>().AddOptions<DiscordConfiguration>().BindConfiguration(configSectionPath,  [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = true);
}