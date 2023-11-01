using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.BetterHosting.Options.Internal;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.EventsNext.Tools;
using DSharpPlus.EventsNext.Tools.Internal;

namespace DSharpPlus.EventsNext.BetterHosting;

/// <summary>
/// Used to configure event handlers derived from <typeparamref name="TEventInterface"/>
/// </summary>
/// <typeparam name="TEventInterface">The type of handler to be registered as being requested.</typeparam>
public sealed class RegistrationBuilder<TEventInterface> where TEventInterface : class, IDiscordEventHandler
{
    static RegistrationBuilder() => HandlerVerification.VerifyExactInterface<TEventInterface>();

    private readonly IServiceCollection services;
    private readonly HandlerRegistryOptions<TEventInterface> registry;

    internal RegistrationBuilder(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        this.services = services;
        registry = RegistrationBuilderHelper.GetHandlerRegistration<TEventInterface>(services);
    }

    /// <summary>
    /// Registers the handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler<TImplementation>() where TImplementation : class, TEventInterface => RegisterHandlerCore(typeof(TImplementation));

    internal RegistrationBuilder<TEventInterface> RegisterHandler(Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType.IsAssignableTo(typeof(TEventInterface)))
            throw new ArgumentException("Invalid handler type");
        return RegisterHandlerCore(handlerType);
    }

    private RegistrationBuilder<TEventInterface> RegisterHandlerCore(Type handlerType)
    {
        HandlerRegistration<TEventInterface> registration = registry.AddHandler();
        Guid key = registration.Key;
        services.AddKeyedScoped(typeof(TEventInterface), key, handlerType);
        return this;
    }
}
