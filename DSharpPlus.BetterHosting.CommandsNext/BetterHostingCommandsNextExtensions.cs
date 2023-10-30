using System;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands;

public static partial class BetterHostingCommandsNextExtensions
{
    public static IHostBuilder AddCommandsNext(this IHostBuilder builder) => builder.ConfigureServices(services => services.AddCommandsNext());
    public static IServiceCollection AddCommandsNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(services);

        services.AddCommandsNextConfiguration();
        services.TryAddTransient<ICommandsNextConfigurator, HandlerAdder>();

        services.AddTransient<IDiscordClientConfigurator, CommandsNextSetup>();
        return services;
    }

    private static OptionsBuilder<CommandsNextConfiguration> AddCommandsNextConfiguration(this IServiceCollection services) => services.AddOptions<CommandsNextConfiguration>().Configure<IServiceProvider>((o, sp) => o.Services = sp.GetRequiredKeyedService<IServiceProvider>(NamedServices.RootServiceProvider));
}