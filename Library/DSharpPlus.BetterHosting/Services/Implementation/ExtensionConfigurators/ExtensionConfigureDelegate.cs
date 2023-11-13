using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

/// <summary>
/// A wrapper class to facilitate ease of extension methods configuring an a DSharpPlus extension
/// </summary>
/// <typeparam name="TExtension"></typeparam>
public class ExtensionConfigureDelegate<TExtension> : IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension
{
    private readonly Action<int, TExtension> configurationDelegate;

    /// <inheritdoc cref="ExtensionConfigureDelegate{TExtension}(Action{int, TExtension})"/>
    public ExtensionConfigureDelegate(Action<TExtension> configurationDelegate)
    {
        ArgumentNullException.ThrowIfNull(configurationDelegate);
        this.configurationDelegate = [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (_, extension) => configurationDelegate.Invoke(extension);
    }

    /// <summary>
    /// Constructs a wrapper for <paramref name="configurationDelegate"/> which will be available to DI
    /// </summary>
    /// <param name="configurationDelegate">A delegate to configure all instances of <typeparamref name="TExtension"/> with</param>
    public ExtensionConfigureDelegate(Action<int, TExtension> configurationDelegate)
    {
        ArgumentNullException.ThrowIfNull(configurationDelegate);
        this.configurationDelegate = configurationDelegate;
    }

    /// <inheritdoc/>
    public void Configure(int shardID, TExtension extension) => configurationDelegate.Invoke(shardID, extension);
}
