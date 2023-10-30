using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Interfaces;
using System.Diagnostics;
using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.ServiceConstruction;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.BetterHosting;

/// <summary>
/// The entrypoint of adding BetterHosting to an IHostBuilder/IServiceCollection
/// </summary>
public static partial class BetterHostExtensions
{
    public static IHostBuilder AddBetterHosting(this IHostBuilder builder)
    {
        if (builder.Properties.ContainsKey(BetterHostPropertyKeys.BetterHostingBaseAdded))
        {
            Debug.WriteLine($"{nameof(BetterHostExtensions)}.{nameof(AddBetterHosting)} used multiple times");
            return builder;
        }

        builder.Properties.Add(BetterHostPropertyKeys.BetterHostingBaseAdded, true);

        return builder.ConfigureServices(services => AddBetterHosting(services));
    }

    /// <summary>
    /// The entrypoint of adding BetterHosting to an IServiceCollection
    /// </summary>
    public static IServiceCollection AddBetterHosting(this IServiceCollection services)
    {
        AddDiscordConfigurationOption(services);

        services.AddTransient<IClientConstructor, ClientConstructor>();
        services.AddScoped<IConnectedClientProvider>(sp => sp.GetRequiredService<IClientManager>());
        services.AddSingleton<IClientManager, ClientManager>();
        services.AddTransient<DiscordShardedClient>(sp => sp.GetRequiredService<IConnectedClientProvider>().GetClient());
        services.AddTransient<IMasterClientConfigurator, MasterClientConfigurator>();

        services.AddHostedService<DiscordClientHost>();

        #region Internal helpers
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, (IServiceProvider sp, object? key) =>
        {
            Debug.Assert(NamedServices.RootServiceProvider.Equals(key));
            return sp.GetService<IHost>()?.Services ?? sp;
        });
        services.TryAddTransient(typeof(CommandsNext.Options.ConfigurationBuilderExtensions.ConfigurationBuilderTools<>));
        services.AddTransient(typeof(IShortScopeProvider<>), typeof(ShortScopeProvider<>));
        #endregion Internal helpers
        return services;
    }
}