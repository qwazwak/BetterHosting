using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Tools.Extensions.Internal;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.Tools.Extensions.Internal;

/// <summary>
/// Extension methods for adding configuration related options services to the DI container via <see cref="OptionsBuilder{TOptions}"/>.
/// </summary>
internal static class OptionsBuilderConfigurationWorkaroundExtensions
{
    /// <inheritdoc cref="OptionsBuilderConfigurationExtensions.BindConfiguration"/>
    public static OptionsBuilder<TOptions> BindConfiguration<TOptions>(this OptionsBuilder<TOptions> optionsBuilder, string configSectionPath, bool bindNonPublicProperties)
        where TOptions : class => optionsBuilder.BindConfiguration(configSectionPath, [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = bindNonPublicProperties);
}