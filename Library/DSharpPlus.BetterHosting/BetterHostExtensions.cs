using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Interfaces;
using System.Diagnostics;
using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.BetterHosting.Services.Extensions;
using System.Threading;

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
        AddDiscordConfigurationOption(services);

        services.AddTransient<IClientConstructor, ClientConstructor>();
        services.AddScoped<IConnectedClientProvider>(sp => sp.GetRequiredService<IClientManager>());
        services.AddSingleton<IClientManager, ClientManager>();
        services.AddTransient<DiscordShardedClient>(sp => sp.GetRequiredService<IConnectedClientProvider>().GetClient(CancellationToken.None));
        services.AddTransient<IMasterClientConfigurator, MasterClientConfigurator>();

        services.AddHostedService<DiscordClientHost>();

        #region Internal helpers
        services.AddKeyedSingleton(NamedServices.RootServiceProvider, (IServiceProvider sp, object? key) =>
        {
            Debug.Assert(NamedServices.RootServiceProvider.Equals(key));
            return sp.GetService<IHost>()?.Services ?? sp;
        });

        services.AddTransient(typeof(IShortScopeProvider<>), typeof(ShortScopeProvider<>));
        #endregion Internal helpers
        return services;
    }
}