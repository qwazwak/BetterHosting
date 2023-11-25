using DSharpPlus.BetterHosting.EventsNext.Entities.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal readonly struct TypeInstanceFactory<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly ObjectFactory factory;
    public string Name { get; }

    public static TypeInstanceFactory<TInterface> Create(Type handlerType) => new(handlerType);
    public TypeInstanceFactory(Type handlerType)
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

internal readonly struct DelegateInstanceFactory<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly Func<IServiceProvider, object> factory;
    public string Name { get; }

    public DelegateInstanceFactory(Func<IServiceProvider, object> factory)
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

internal readonly struct InstanceFactoryWrapper<TInterface> : IHandlerBuilder<TInterface>
{
    private readonly TInterface instance;
    public string Name => $"{instance!.GetType().Name} ({instance})";

    public InstanceFactoryWrapper(TInterface instance)
    {
        ArgumentNullException.ThrowIfNull(instance);
        this.instance = instance;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public DisposingWrapper<TInterface> CreateInstance(IServiceProvider provider) => new(instance, dispose: false);
}