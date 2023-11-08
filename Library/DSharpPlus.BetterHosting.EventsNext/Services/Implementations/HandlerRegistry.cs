using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal class HandlerRegistry<TInterface> where TInterface : IDiscordEventHandler
{
    public ReadOnlyCollection<HandlerRegistration> Registrations { get; }

    private readonly List<HandlerRegistration> registrations = new();
    public IEnumerable<Guid> RegisteredKeys => usedKeys;
    private readonly HashSet<Guid> usedKeys = new();

    public HandlerRegistry() => Registrations = new(registrations);

    public HandlerRegistration AddHandler()
    {
        Guid key = HandlerRegistryHelper.GenerateKey(usedKeys);
        HandlerRegistration reg = new(key);
        registrations.Add(reg);
        return reg;
    }
}