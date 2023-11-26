using System;
using System.Runtime.CompilerServices;
using BetterHosting.EventsNext.Entities.Internal;

namespace BetterHosting.EventsNext.Services;

internal interface IHandlerBuilder<TInterface>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider);
    string Name { get; }
}
