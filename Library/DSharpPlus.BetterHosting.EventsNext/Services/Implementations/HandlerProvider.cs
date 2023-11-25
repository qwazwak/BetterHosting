using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Linq;
using System.Collections.Immutable;
using DSharpPlus.BetterHosting.EventsNext.Entities;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.EventsNext.Entities.Internal;
using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

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
            return TypeInstanceFactory<TInterface>.Create(descriptor.ImplementationType);
        }
        else if (descriptor.ImplementationFactory is not null)
        {
            return DelegateInstanceFactory<TInterface>.Create(descriptor.ImplementationFactory!);
        }
        else
        {
            Debug.Assert(descriptor.ImplementationInstance is not null, "descriptor had no valid implementations");
            object instance = descriptor.ImplementationInstance;
            Debug.Assert(instance is TInterface);
            return InstanceFactoryWrapper<TInterface>.Create((TInterface)instance);
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

file readonly struct TypeInstanceFactory<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly ObjectFactory factory;
    public string Name { get; }

    public static TypeInstanceFactory<TInterface> Create(Type handlerType) => new(handlerType);
    private TypeInstanceFactory(Type handlerType)
    {
        factory = ActivatorUtilities.CreateFactory(handlerType, Type.EmptyTypes);
        Name = handlerType.Name;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider)
    {
        object instance = factory(provider, null);
        Debug.Assert(instance is TInterface);
        return new((TInterface)instance);
    }
}

file readonly struct DelegateInstanceFactory<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly Func<IServiceProvider, object> factory;
    public string Name { get; }

    public static DelegateInstanceFactory<TInterface> Create(Func<IServiceProvider, object> factory) => new(factory);
    private DelegateInstanceFactory(Func<IServiceProvider, object> factory)
    {
        this.factory = factory;
        Name = factory.GetType().GetGenericArguments()[1].Name;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider)
    {
        object instance = factory(provider);
        Debug.Assert(instance is TInterface);
        return new((TInterface)instance);
    }
}

file readonly struct InstanceFactoryWrapper<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly TInterface instance;
    public string Name => $"{instance!.GetType().Name} ({instance})";

    public static InstanceFactoryWrapper<TInterface> Create(TInterface instance) => new(instance);
    private InstanceFactoryWrapper(TInterface instance)
    {
        ArgumentNullException.ThrowIfNull(instance);
        this.instance = instance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider) => new(instance, dispose: false);
}