using System;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.EventsNext.Entities.Internal;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerBuilder<TInterface>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider);
    string Name { get; }
}
