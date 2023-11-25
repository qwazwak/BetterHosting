using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using DSharpPlus.BetterHosting.EventsNext.Entities;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// Used to configure event handlers derived from <typeparamref name="TEventInterface"/>
/// </summary>
/// <typeparam name="TEventInterface">The type of handler to be registered as being requested.</typeparam>
public sealed class RegistrationBuilder<TEventInterface> where TEventInterface : class, IDiscordEventHandler
{
    static RegistrationBuilder() => EventReflection.Validation.VerifyExactInterface<TEventInterface>();

    private bool supportKnownAdded;

    /// <summary>
    /// The <see cref="IServiceCollection"/> to add registrations to
    /// </summary>
    public IServiceCollection Services { get; }

    /// <summary>
    /// Constructs a new builder
    /// </summary>
    /// <param name="services"></param>
    public RegistrationBuilder(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Services = services;
    }

    /// <summary>
    /// Registers the handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler<TImplementation>() where TImplementation : class, TEventInterface => RegisterHandler(HandlerDescriptor.Handler<TEventInterface, TImplementation>());

    /// <summary>
    /// Registers a handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler(TEventInterface instance) => RegisterHandler(HandlerDescriptor.OfInstance(instance));

    /// <summary>
    /// Registers a handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler(Func<IServiceProvider, TEventInterface> factory) => RegisterHandler(HandlerDescriptor.Handler<TEventInterface>(factory));

    /// <summary>
    /// Registers a handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to recieve events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    public RegistrationBuilder<TEventInterface> RegisterHandler(HandlerDescriptor descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);
        RegistrationBuilderHelper.RegisterHandler(Services, typeof(TEventInterface), descriptor, supportKnownAdded);
        supportKnownAdded = true;
        return this;
    }
}
