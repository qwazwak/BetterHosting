using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using DSharpPlus.EventsNext.Entities;
using System.Linq;

namespace DSharpPlus.EventsNext.BetterHosting.Options.Internal;

#if false
internal abstract class HandlerRegistryOptions
{
    private readonly Type interfaceType;
    private readonly HashSet<Guid> usedKeys = new();
    private readonly List<HandlerRegistration> registrations = new();
    public virtual IReadOnlyCollection<HandlerRegistration> Registrations => registrations;
    public IEnumerable<Guid> RegisteredKeys => registrations.Select(r => r.Key);

    protected HandlerRegistryOptions(Type interfaceType) => this.interfaceType = interfaceType;

    public static HandlerRegistryOptions CreateByType(Type type)
    {
        Type targetType = typeof(HandlerRegistryOptions<>).MakeGenericType(type);
        return (HandlerRegistryOptions)Activator.CreateInstance(targetType)!;
    }

    private Guid NewKey()
    {
        Guid key = Guid.NewGuid();
        if (usedKeys.Add(key))
            return key;
        else
            return GetKeySlow(usedKeys);

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Guid GetKeySlow(HashSet<Guid> usedKeys)
        {
            Guid key;
            do
            {
                key = Guid.NewGuid();
            } while (!usedKeys.Add(key));
            return key;
        }
    }

    public HandlerRegistration AddHandler()
    {
        Guid key = NewKey();
        return BuildHandler(key);
    }
    protected virtual HandlerRegistration BuildHandler(Guid key)
    {
        HandlerRegistration reg = HandlerRegistration.CreateByType(key, interfaceType);
        registrations.Add(reg);
        return reg;
    }
}
internal class HandlerRegistryOptions<TInterface>() : HandlerRegistryOptions(typeof(TInterface)) where TInterface : IDiscordEventHandler
{
    public override IReadOnlyCollection<HandlerRegistration<TInterface>> Registrations => base.Registrations;

    protected override HandlerRegistration<TInterface> BuildHandler(Guid key) => new(key);
    public new HandlerRegistration<TInterface> AddHandler() => (HandlerRegistration<TInterface>)base.AddHandler();
}
#else

internal abstract class HandlerRegistryOptions
{
    public abstract IReadOnlyCollection<HandlerRegistration> Registrations { get; }
    protected abstract void AddToRegistrations(HandlerRegistration registration);
    private readonly HashSet<Guid> usedKeys = new();
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1163:Unused parameter.", Justification = "For the future")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For the future")]
    protected HandlerRegistryOptions(Type interfaceType) { }

    private Guid NewKey()
    {
        Guid key = Guid.NewGuid();
        if (usedKeys.Add(key))
            return key;
        else
            return GetKeySlow(usedKeys);

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Guid GetKeySlow(HashSet<Guid> usedKeys)
        {
            Guid key;
            do
            {
                key = Guid.NewGuid();
            } while (!usedKeys.Add(key));
            return key;
        }
    }
    public static HandlerRegistryOptions CreateByType(Type type)
    {
        Type targetType = typeof(HandlerRegistryOptions<>).MakeGenericType(type);
        return (HandlerRegistryOptions)Activator.CreateInstance(targetType)!;
    }

    public HandlerRegistration AddHandler()
    {
        Guid key = NewKey();
        HandlerRegistration registration = BuildHandler(key);
        AddToRegistrations(registration);
        return registration;
    }
    protected abstract HandlerRegistration BuildHandler(Guid key);
}
internal class HandlerRegistryOptions<TInterface>() : HandlerRegistryOptions(typeof(TInterface)) where TInterface : IDiscordEventHandler
{
    private readonly List<HandlerRegistration<TInterface>> registrations = new();

    public override IReadOnlyCollection<HandlerRegistration<TInterface>> Registrations => registrations;
    public IEnumerable<Guid> RegisteredKeys => registrations.Select(r => r.Key);

    protected override void AddToRegistrations(HandlerRegistration registration) => throw new NotImplementedException();

    public new HandlerRegistration<TInterface> AddHandler() => (HandlerRegistration<TInterface>)base.AddHandler();
    protected override HandlerRegistration<TInterface> BuildHandler(Guid key)
    {
        HandlerRegistration<TInterface> reg = new(key);
        registrations.Add(reg);
        return reg;
    }
}
#endif