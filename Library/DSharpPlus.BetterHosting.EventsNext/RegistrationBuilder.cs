using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// Used to configure event handlers derived from <typeparamref name="TEventInterface"/>
/// </summary>
/// <typeparam name="TEventInterface">The type of handler to be registered as being requested.</typeparam>
public sealed class RegistrationBuilder<TEventInterface> where TEventInterface : class, IDiscordEventHandler
{
    static RegistrationBuilder() => EventReflection.Verification.VerifyExactInterface<TEventInterface>();

    public IServiceCollection Services { get; }
    private HandlerRegistry<TEventInterface>? registry;
    private HandlerRegistry<TEventInterface> Registry => registry ??= RegistrationBuilderHelper.GetHandlerRegistration<TEventInterface>(services);

    internal RegistrationBuilder(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Services = services;
    }

    /// <summary>
    /// Registers the handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler<TImplementation>() where TImplementation : class, TEventInterface => RegisterHandler(typeof(TImplementation));

    internal RegistrationBuilder<TEventInterface> RegisterHandler(Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(handlerType);
        if (!handlerType.IsAssignableTo(typeof(TEventInterface)))
            throw new ArgumentException("Invalid handler type");

        HandlerRegistration registration = Registry.AddHandler();
        Guid key = registration.Key;
        services.AddKeyedScoped(typeof(TEventInterface), key, handlerType);
        return this;
    }
}
