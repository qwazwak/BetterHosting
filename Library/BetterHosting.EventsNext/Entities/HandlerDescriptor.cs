using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace BetterHosting.EventsNext.Entities;

/// <summary>
/// Describes a service with its service type, implementation, and lifetime.
/// </summary>
[DebuggerDisplay("{DebuggerToString(),nq}")]
public class HandlerDescriptor
{
    /// <summary>
    /// Initializes a new instance of <see cref="HandlerDescriptor"/> with the specified <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="implementationType">The <see cref="Type"/> implementing the service.</param>
    public HandlerDescriptor(Type serviceType,[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) : this(serviceType)
    {
        ArgumentNullException.ThrowIfNull(serviceType);
        ArgumentNullException.ThrowIfNull(implementationType);

        ImplementationType = implementationType;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="HandlerDescriptor"/> with the specified <paramref name="instance"/>
    /// as a Singleton.
    /// </summary>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="instance">The instance implementing the service.</param>
    public HandlerDescriptor(Type serviceType, object instance) : this(serviceType)
    {
        ArgumentNullException.ThrowIfNull(serviceType);
        ArgumentNullException.ThrowIfNull(instance);

        if (serviceType.IsAssignableFrom(instance.GetType()))
            throw new ArgumentException($"{nameof(instance)} ({instance.GetType().Name}) must be assignable to {serviceType.Name}", nameof(instance));
        ImplementationInstance = instance;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="HandlerDescriptor"/> with the specified <paramref name="factory"/>.
    /// </summary>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="factory">A factory used for creating service instances.</param>
    public HandlerDescriptor(Type serviceType, Func<IServiceProvider, object> factory) : this(serviceType)
    {
        ArgumentNullException.ThrowIfNull(serviceType);
        ArgumentNullException.ThrowIfNull(factory);

        ImplementationFactory = factory;
    }

    private HandlerDescriptor(Type serviceType) => ServiceType = serviceType;

    /// <summary>
    /// Gets the <see cref="Type"/> of the service.
    /// </summary>
    public Type ServiceType { get; }

    /// <summary>
    /// Gets the <see cref="Type"/> that implements the service.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type? ImplementationType { get; }

    /// <summary>
    /// Gets the instance that implements the service.
    /// </summary>
    public object? ImplementationInstance { get; }

    /// <summary>
    /// Gets the factory used for creating service instances.
    /// </summary>
    public Func<IServiceProvider, object>? ImplementationFactory { get; }

    internal Type GetImplementationType()
    {
        if (ImplementationType != null)
        {
            return ImplementationType;
        }
        else if (ImplementationInstance != null)
        {
            return ImplementationInstance.GetType();
        }
        else if (ImplementationFactory != null)
        {
            Type[]? typeArguments = ImplementationFactory.GetType().GenericTypeArguments;

            Debug.Assert(typeArguments.Length == 2);

            return typeArguments[1];
        }
        else
        {
            Debug.Fail("ImplementationType, ImplementationInstance, ImplementationFactory or KeyedImplementationFactory must be non null");
            return null;
        }
    }

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <typeparamref name="TService"/>, <typeparamref name="TImplementation"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Handler<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>()
        where TService : class
        where TImplementation : class, TService => Describe<TService, TImplementation>();

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <typeparamref name="TService"/>, <paramref name="implementationInstance"/>,
    /// and the Singleton lifetime.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <param name="implementationInstance">The instance of the implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor OfInstance<TService>(TService implementationInstance)
        where TService : class => Describe(typeof(TService), implementationInstance);

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <paramref name="service"/> and <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="service">The type of the service.</param>
    /// <param name="implementationType">The type of the implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Handler(Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(implementationType);

        return Describe(service, implementationType);
    }

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <typeparamref name="TService"/>, <typeparamref name="TImplementation"/>,
    /// <paramref name="implementationFactory"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
    /// <param name="implementationFactory">A factory to create new instances of the service implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Handler<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        ArgumentNullException.ThrowIfNull(implementationFactory);

        return Describe(typeof(TService), implementationFactory);
    }

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <typeparamref name="TService"/>, <paramref name="implementationFactory"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <param name="implementationFactory">A factory to create new instances of the service implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Handler<TService>(Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(implementationFactory);

        return Describe(typeof(TService), implementationFactory);
    }

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <typeparamref name="TService"/>, <typeparamref name="TImplementation"/>.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Describe<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>()
        where TService : class
        where TImplementation : class, TService => Describe(typeof(TService), typeof(TImplementation));

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <paramref name="serviceType"/>, <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="serviceType">The type of the service.</param>
    /// <param name="implementationType">The type of the implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    public static HandlerDescriptor Describe(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => new(serviceType, implementationType);

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <paramref name="serviceType"/>, <paramref name="implementationFactory"/>.
    /// </summary>
    /// <param name="serviceType">The type of the service.</param>
    /// <param name="implementationFactory">A factory to create new instances of the service implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    private static HandlerDescriptor Describe(Type serviceType, Func<IServiceProvider, object> implementationFactory) => new(serviceType, implementationFactory);

    /// <summary>
    /// Creates an instance of <see cref="HandlerDescriptor"/> with the specified
    /// <paramref name="serviceType"/>, <paramref name="implementationInstance"/>,
    /// and the Singleton lifetime.
    /// </summary>
    /// <param name="serviceType">The type of the service.</param>
    /// <param name="implementationInstance">The instance of the implementation.</param>
    /// <returns>A new instance of <see cref="HandlerDescriptor"/>.</returns>
    private static HandlerDescriptor Describe(Type serviceType, object implementationInstance) => new(serviceType, implementationInstance);

    /// <inheritdoc />
    public override string ToString()
    {
        string? lifetime = $"{nameof(ServiceType)}: {ServiceType} Lifetime: {(ImplementationInstance is null ? "Transient" : "Singleton")} ";

        if (ImplementationType != null)
            return lifetime + $"{nameof(ImplementationType)}: {ImplementationType}";
        else if (ImplementationFactory != null)
            return lifetime + $"{nameof(ImplementationFactory)}: {ImplementationFactory.Method}";
        else
            return lifetime + $"{nameof(ImplementationInstance)}: {ImplementationInstance}";
    }

    private string DebuggerToString()
    {
        string debugText = $@"Lifetime = {(ImplementationInstance is null ? "Transient" : "Singleton")}, ServiceType = ""{ServiceType.FullName}""";

        // Either implementation type, factory or instance is set.
        if (ImplementationType != null)
        {
            debugText += $", ImplementationType = \"{ImplementationType.FullName}\"";
        }
        else if (ImplementationFactory != null)
        {
            debugText += $", ImplementationFactory = {ImplementationFactory.Method}";
        }
        else
        {
            debugText += $", ImplementationInstance = {ImplementationInstance}";
        }

        return debugText;
    }
}