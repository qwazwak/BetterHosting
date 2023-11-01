using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.CommandsNext.Options;

/// <summary>
/// Implementation of <see cref="IConfigureNamedOptions{TOptions}"/>.
/// </summary>
/// <typeparam name="TOptions">Options type being configured.</typeparam>
public abstract class ConfigureNamedOptionsWorkaround<TOptions> : IConfigureOptions<TOptions> where TOptions : class
{
    /// <summary>
    /// The root of the <see cref="IConfiguration"/>
    /// </summary>
    //private readonly IConfiguration rootConfiguration;

    //private readonly string configSectionPath;

    protected readonly IConfigurationSection configuration;

    /// <summary>
    /// Constructor.
    /// </summary>
    protected ConfigureNamedOptionsWorkaround(string configSectionPath, IConfiguration rootConfiguration)
    {
        if (string.IsNullOrEmpty(configSectionPath))
            throw new ArgumentException(configSectionPath);
        configuration = rootConfiguration.GetRequiredSection(configSectionPath);
    }

    /// <summary>
    /// Invoked to configure a <typeparamref name="TOptions"/> instance with the <see cref="Microsoft.Extensions.Options.Options.DefaultName"/>.
    /// </summary>
    /// <param name="options">The options instance to configure.</param>
    public void Configure(TOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        ConfigureCore(options);
    }

    protected abstract void ConfigureCore(TOptions options);
}