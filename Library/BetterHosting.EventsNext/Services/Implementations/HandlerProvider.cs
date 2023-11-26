using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Linq;
using System.Collections.Immutable;
using BetterHosting.EventsNext.Entities;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;

namespace BetterHosting.EventsNext.Services.Implementations;

internal class HandlerProvider<TInterface> : IHandlerProvider<TInterface>
{
    private readonly ImmutableArray<IHandlerBuilder<TInterface>> core;

    [ActivatorUtilitiesConstructor]
    public HandlerProvider(IServiceProvider provider) : this(provider.GetKeyedService<IHandlerRegistry>(typeof(TInterface)) ) { }
    public HandlerProvider(IHandlerRegistry? registry) : this((IEnumerable<HandlerDescriptor>?)registry ?? Enumerable.Empty<HandlerDescriptor>()) { }
    private HandlerProvider(IEnumerable<HandlerDescriptor> registry) => core = ImmutableArray.CreateRange(registry.Select(Build));

    private static IHandlerBuilder<TInterface> Build(HandlerDescriptor descriptor)
    {
        if (descriptor.ImplementationType is not null)
        {
            return new TypeInstanceFactory<TInterface>(descriptor.ImplementationType);
        }
        else if (descriptor.ImplementationFactory is not null)
        {
            return new DelegateInstanceFactory<TInterface>(descriptor.ImplementationFactory!);
        }
        else
        {
            Debug.Assert(descriptor.ImplementationInstance is not null, "descriptor had no valid implementations");
            object instance = descriptor.ImplementationInstance;
            Debug.Assert(instance is TInterface);
            return new InstanceFactoryWrapper<TInterface>((TInterface)instance);
        }
    }

    public int Count => core.Length;

    public IHandlerBuilder<TInterface> this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => core[index];
    }

    public IEnumerator<IHandlerBuilder<TInterface>> GetEnumerator() => ((IEnumerable<IHandlerBuilder<TInterface>>)core).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)core).GetEnumerator();
}