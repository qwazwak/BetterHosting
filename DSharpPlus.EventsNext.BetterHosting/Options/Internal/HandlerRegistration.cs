using System;
using DSharpPlus.EventsNext.Entities;

namespace DSharpPlus.EventsNext.BetterHosting.Options.Internal;

internal abstract class HandlerRegistration : IEquatable<HandlerRegistration>
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
[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "Not possible, and to achieve the functionality, override Equals(HandlerRegistration)")]
internal sealed class HandlerRegistration<TInterface> : HandlerRegistration, IEquatable<HandlerRegistration<TInterface>>
    where TInterface : IDiscordEventHandler
{
    public HandlerRegistration(Guid key) : base(key, typeof(TInterface)) { }

    public bool Equals(HandlerRegistration<TInterface>? other) => base.Equals(other);
}