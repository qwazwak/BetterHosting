﻿using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

/// <summary>
/// A wrapper class to facilitate ease of extension methods configuring an a DSharpPlus extension
/// </summary>
/// <typeparam name="TExtension"></typeparam>
public class ExtensionConfigureDelegate<TExtension> : IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension
{
    private readonly Action<int, TExtension> configurationDelegate;

    /// <summary>
    /// Constructs a wrapper for <paramref name="configurationDelegate"/> which will be available to DI
    /// </summary>
    /// <param name="configurationDelegate">A delegate to configure all instances of <typeparamref name="TExtension"/> with</param>
    public ExtensionConfigureDelegate(Action<int, TExtension> configurationDelegate) => this.configurationDelegate = configurationDelegate;

    /// <inheritdoc/>
    public void Configure(int shardID, TExtension extension) => configurationDelegate.Invoke(shardID, extension);
}
