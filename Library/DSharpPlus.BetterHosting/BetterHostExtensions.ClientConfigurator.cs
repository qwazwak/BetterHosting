using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace DSharpPlus.BetterHosting;

public static partial class BetterHostExtensions
{
    /// <summary>
    /// Registers <typeparamref name="TService"/> as a <see cref="IDiscordClientConfigurator"/> which will be run before the client connects
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddConfigurator<TService>(this IServiceCollection services) where TService : class, IDiscordClientConfigurator => services.AddTransient<IDiscordClientConfigurator, TService>();

    /// <summary>
    /// Registers <typeparamref name="TConfigurator"/> as a <see cref=" IDiscordExtensionConfigurator{TExtension}"/> which will be run to configure the <typeparamref name="TExtension"/> before discord connects
    /// </summary>
    /// <typeparam name="TConfigurator"></typeparam>
    /// <typeparam name="TExtension"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddExtensionConfigurator<TConfigurator, TExtension>(this IServiceCollection services) where TConfigurator : class, IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension => services.AddTransient<IDiscordExtensionConfigurator<TExtension>, TConfigurator>();
}