using System;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal class HandlerRegistration<TInterface>([ServiceKey] Guid key) : IHandlerRegistration<TInterface>, IEquatable<HandlerRegistration<TInterface>?> where TInterface : IDiscordEventHandler
{
    public Guid Key { get; } = key;

    public override bool Equals(object? obj) => Equals(obj as HandlerRegistration<TInterface>);
    public virtual bool Equals(HandlerRegistration<TInterface>? other) => ReferenceEquals(this, other) || (other is not null && Key.Equals(other.Key));

    public override int GetHashCode() => Key.GetHashCode();
}