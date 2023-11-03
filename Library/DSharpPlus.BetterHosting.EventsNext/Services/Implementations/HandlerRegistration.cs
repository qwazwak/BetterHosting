using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal abstract class HandlerRegistration
{
    public readonly Guid Key;
    public readonly Type InterfaceType;

    protected HandlerRegistration(Guid key, Type interfaceType)
    {
        Key = key;
        InterfaceType = interfaceType;
    }

    public static HandlerRegistration CreateByType(Guid key, Type interfaceType)
    {
        Type targetType = typeof(HandlerRegistration<>).MakeGenericType(interfaceType);
        return (HandlerRegistration)Activator.CreateInstance(targetType, [key, interfaceType])!;
    }

    public sealed override bool Equals(object? obj) => obj is HandlerRegistration other && Equals(other);
    public virtual bool Equals(HandlerRegistration? other)
    {
        if (other is null) return false;
        return Key.Equals(other.Key) && InterfaceType.Equals(other.InterfaceType);
    }

    public override int GetHashCode() => HashCode.Combine(Key);
}

internal sealed class HandlerRegistration<TInterface> : HandlerRegistration// where TInterface : IDiscordEventHandler
{
    public HandlerRegistration(Guid key) : base(key, typeof(TInterface)) { }
}