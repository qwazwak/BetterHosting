using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;

namespace BetterHosting.Services.Implementation.Extensions;

/// <summary>
/// Interface to adapter derived versions of <see cref="IDiscordExtensionConfigurator{TExtension}"/> to the base interface
/// </summary>
public class DiscordExtensionConfiguratorAdapter<TSpecific, TExtension> : IDiscordExtensionConfigurator<TExtension>
    where TSpecific : IDiscordExtensionConfigurator<TExtension>
    where TExtension : BaseExtension
{
    private readonly IEnumerable<TSpecific> configurators;

    static DiscordExtensionConfiguratorAdapter()
    {
        if (typeof(TSpecific) == typeof(IDiscordExtensionConfigurator<TExtension>))
            ThrowInvalidInterface();
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void ThrowInvalidInterface() => throw new ArgumentException($"{nameof(TSpecific)} must be derived from {nameof(IDiscordExtensionConfigurator<TExtension>)} but not exactly equal", nameof(TSpecific));

    /// <summary>
    /// Constructor
    /// </summary>
    public DiscordExtensionConfiguratorAdapter(IEnumerable<TSpecific> configurators) => this.configurators = configurators;

    /// <inheritdoc />
    public void Configure(int shardID, TExtension extension)
    {
        foreach (TSpecific configurator in configurators)
            configurator.Configure(shardID, extension);
    }
}