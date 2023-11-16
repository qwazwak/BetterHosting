using System;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelpers;

public static partial class ItMore
{
    public static partial class ServiceDescriptorFrom
    {
        public static class SimpleInterface
        {
            public static ServiceDescriptor AddTransient<TImplementation>() => AddTransient(typeof(TImplementation));
            public static ServiceDescriptor AddScoped<TImplementation>() => AddScoped(typeof(TImplementation));
            public static ServiceDescriptor AddSingleton<TImplementation>() => AddSingleton(typeof(TImplementation));

            public static ServiceDescriptor AddTransient(Type serviceType) => AddTransient(serviceType, serviceType);
            public static ServiceDescriptor AddScoped(Type serviceType) => AddScoped(serviceType, serviceType);
            public static ServiceDescriptor AddSingleton(Type serviceType) => AddSingleton(serviceType, serviceType);

            public static ServiceDescriptor AddTransient<TInterface, TImplementation>() => AddTransient(typeof(TInterface), typeof(TImplementation));
            public static ServiceDescriptor AddScoped<TInterface, TImplementation>() => AddScoped(typeof(TInterface), typeof(TImplementation));
            public static ServiceDescriptor AddSingleton<TInterface, TImplementation>() => AddSingleton(typeof(TInterface), typeof(TImplementation));

            public static ServiceDescriptor AddTransient(Type serviceType, Type implementationType) => Add(serviceType, implementationType, ServiceLifetime.Transient);
            public static ServiceDescriptor AddScoped(Type serviceType, Type implementationType) => Add(serviceType, implementationType, ServiceLifetime.Scoped);
            public static ServiceDescriptor AddSingleton(Type serviceType, Type implementationType) => Add(serviceType, implementationType, ServiceLifetime.Singleton);

            public static ServiceDescriptor Add(Type serviceType, Type implementationType, ServiceLifetime lifetime)
                => It.Is<ServiceDescriptor>(d =>
                    d.Lifetime == lifetime &&
                    d.ServiceType == serviceType &&
                    d.ImplementationType == implementationType &&
                    d.ServiceKey == null);
        }
    }
}
