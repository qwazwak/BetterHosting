using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal readonly struct HandlerRegistration : IEquatable<HandlerRegistration>
{
    public readonly Guid Key;

    public HandlerRegistration(Guid key)
    {
        Key = key;
    }

    public override bool Equals(object? obj) => obj is HandlerRegistration other && Equals(other);
    public bool Equals(HandlerRegistration other) => Key.Equals(other.Key);

    public override int GetHashCode() => Key.GetHashCode();
}