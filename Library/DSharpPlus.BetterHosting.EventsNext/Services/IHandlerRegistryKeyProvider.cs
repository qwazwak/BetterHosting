using System;
using System.Collections.Immutable;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerRegistryKeyProvider<TInterface>
{
    ImmutableArray<Guid> GetKeys();
}
