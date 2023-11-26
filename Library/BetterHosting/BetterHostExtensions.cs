using BetterHosting.Services.Hosted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BetterHosting.Services.Interfaces;
using System;
using BetterHosting.Services;
using BetterHosting.Services.Interfaces.Internal;
using BetterHosting.Services.Implementation.Internal;
using BetterHosting.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus;

namespace BetterHosting;

/// <summary>
/// The entrypoint of adding BetterHosting to an IHostBuilder/IServiceCollection
/// </summary>
public static class BetterHostExtensions
{
    // Internal for unit testing
    internal static IServiceProvider ServiceProviderFactory(IServiceProvider sp, object? _) => sp.GetService<IHost>()?.Services ?? sp;
    // Internal for unit testing
    internal static IKeyedServiceProvider KeyedServiceProviderFactory(IServiceProvider sp, object? _) => (IKeyedServiceProvider)sp.GetRequiredKeyedService<IServiceProvider>(NamedServices.RootServiceProvider);

    /// <summary>
    /// The entrypoint of adding BetterHosting to an IServiceCollection
    /// </summary>
    public static IServiceCollection AddBetterHosting(this IServiceCollection services)
    {
        services.AddTransient<IClientConstructor, ClientConstructor>();
        services.AddTransient<IMasterClientConfigurator, MasterClientConfigurator>();
        services.AddTransient<IShortClientConstructor, ShortClientConstructor>();

        services.AddSingleton<IClientManager, ClientManager>();
        services.AddTransient<IConnectedClientProvider, ClientProvider>();

        services.AddSingleton<IHostedService, DiscordClientHost>();

        #region Internal helpers
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, ServiceProviderFactory);
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, KeyedServiceProviderFactory);

        #endregion Internal helpers
        return services;
    }
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
        => services.AddTransient<IConfigureOptions<DiscordConfiguration>, BindConfigurationLoggerFactory>().AddOptions<DiscordConfiguration>().BindConfiguration(configSectionPath, [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = true);
}