using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Interfaces;
using System;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.BetterHosting;

/// <summary>
/// The entrypoint of adding BetterHosting to an IHostBuilder/IServiceCollection
/// </summary>
public static partial class BetterHostExtensions
{
    /// <summary>
    /// The entrypoint of adding BetterHosting to an IServiceCollection
    /// </summary>
    public static IServiceCollection AddBetterHosting(this IServiceCollection services)
    {
        services.AddTransient<IClientConstructor, ClientConstructor>();
        services.AddTransient<IShortClientConstructor, ShortClientConstructor>();
        services.AddSingleton<IClientManager, ClientManager>();
        services.AddSingleton<IConnectedClientProvider>(sp => sp.GetRequiredService<IClientManager>());
        //services.AddTransient<DiscordShardedClient>(sp => sp.GetRequiredService<IConnectedClientProvider>().GetClient(CancellationToken.None));
        services.AddTransient<IMasterClientConfigurator, MasterClientConfigurator>();

        services.AddHostedService<DiscordClientHost>();

        #region Internal helpers
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, (IServiceProvider sp, object? _) => sp.GetService<IHost>()?.Services ?? sp);
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, (IServiceProvider sp, object? _) => (IKeyedServiceProvider)sp.GetRequiredKeyedService<IServiceProvider>(NamedServices.RootServiceProvider));

        #endregion Internal helpers
        return services;
    }
}