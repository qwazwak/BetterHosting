using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.BetterHosting.Options.Internal;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.EventsNext.Tools;

namespace DSharpPlus.EventsNext.BetterHosting;

public sealed class RegistrationBuilder<TInterface> where TInterface : class, IDiscordEventHandler
{
    static RegistrationBuilder() => HandlerValidation.VerifyHandler(typeof(TInterface));

    private readonly IServiceCollection services;
    private readonly HandlerRegistryOptions<TInterface> registry;

    public RegistrationBuilder(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        this.services = services;
        registry = RegistrationBuilderHelper.GetHandlerRegistration<TInterface>(services);
    }

    public RegistrationBuilder<TInterface> RegisterHandler<TImplementation>() where TImplementation : class, TInterface
    {
        HandlerRegistration<TInterface> registration = registry.AddHandler();
        Guid key = registration.Key;
        services.AddKeyedScoped<TInterface, TImplementation>(key);
        return this;
    }
}
