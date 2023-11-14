using DSharpPlus.BetterHosting.Interactivity.Services;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Interactivity;

/// <summary>
/// Extension methods to add <see cref="InteractivityExtension"/> and <see cref="IOptions{TOptions}"/> for <see cref="InteractivityConfiguration"/>
/// </summary>
public static class BetterHostingInteractivityExtensions
{
    /// <summary>
    /// Adds automatic setup of <see cref="InteractivityExtension"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddInteractivity(this IServiceCollection services) => services.AddTransient<IDiscordClientConfigurator, InteractivitySetup>().AddExtensionConfiguratorAdapter<IInteractivityConfigurator, InteractivityExtension>();
}
