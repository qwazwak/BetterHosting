using System;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.SlashCommands;

public static class BetterHostingSlashCommandsExtensions
{
    public static IHostBuilder AddSlashCommands(this IHostBuilder builder) => builder.ConfigureServices(services =>
    {
        services.AddTransient<IDiscordClientConfigurator, SlashCommandsSetup>();
        services.AddOptions<SlashCommandsConfiguration>()
            .Configure<IServiceProvider>((option, sp) => option.Services = sp.GetRequiredKeyedService<IServiceProvider>(NamedServices.RootServiceProvider));
    });

    public static void AddSlashCommand<TCommand>(this IServiceCollection services) where TCommand : ApplicationCommandModule => services.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>();
    public static void AddSlashCommand(this IServiceCollection services, Type commandType)
    {
        Type constructed = typeof(SlashCommandRegisterConfigurator<>).MakeGenericType(commandType);
        services.AddTransient(typeof(ISlashCommandsExtensionConfigurator), constructed);
    }
}