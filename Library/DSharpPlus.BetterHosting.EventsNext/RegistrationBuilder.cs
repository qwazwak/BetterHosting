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

    /// <inheritdoc cref="RegisterHandlerCore(HandlerDescriptor)"/>
    public RegistrationBuilder<TEventInterface> RegisterHandler<TImplementation>() where TImplementation : class, TEventInterface => RegisterHandlerCore(HandlerDescriptor.Handler<TEventInterface, TImplementation>());

    /// <inheritdoc cref="RegisterHandlerCore(HandlerDescriptor)"/>
    public RegistrationBuilder<TEventInterface> RegisterHandler(TEventInterface instance)
    {
        ArgumentNullException.ThrowIfNull(instance);
        return RegisterHandlerCore(HandlerDescriptor.OfInstance(instance));
    }

    /// <inheritdoc cref="RegisterHandlerCore(HandlerDescriptor)"/>
    public RegistrationBuilder<TEventInterface> RegisterHandler(Func<IServiceProvider, TEventInterface> factory)
    {
        ArgumentNullException.ThrowIfNull(factory);
        return RegisterHandlerCore(HandlerDescriptor.Handler<TEventInterface>(factory));
    }

    /// <inheritdoc cref="RegisterHandlerCore(HandlerDescriptor)"/>
    public RegistrationBuilder<TEventInterface> RegisterHandler(HandlerDescriptor descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);
        return RegisterHandlerCore(descriptor);
    }

    /// <summary>
    /// Registers a handler <typeparamref name="TEventInterface"/> in the <see cref="IServiceCollection"/> to receive events for <typeparamref name="TEventInterface"/>
    /// </summary>
    /// <returns>The same <see cref="RegistrationBuilder{TInterface}"/> for chaining</returns>
    private RegistrationBuilder<TEventInterface> RegisterHandlerCore(HandlerDescriptor descriptor)
    {
        RegistrationBuilderHelper.RegisterHandler(Services, typeof(TEventInterface), descriptor, supportKnownAdded);
        supportKnownAdded = true;
        return this;
    }
}
