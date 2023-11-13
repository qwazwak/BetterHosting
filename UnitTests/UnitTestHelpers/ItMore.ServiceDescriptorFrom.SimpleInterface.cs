using System;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelpers;

public static partial class ItMore
{
    public static partial class ServiceDescriptorFrom
    {
        public static class SimpleInterface
        {
            public static ServiceDescriptor AddTransient<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Transient);
            public static ServiceDescriptor AddScoped<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Scoped);
            public static ServiceDescriptor AddSingleton<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Singleton);

            public static ServiceDescriptor Add<TInterface, TImplementation>(ServiceLifetime lifetime) => Add(typeof(TInterface), typeof(TImplementation), lifetime);

            public static ServiceDescriptor Add(Type serviceType, Type implementationType, ServiceLifetime lifetime) => It.Is<ServiceDescriptor>(d =>
                                                                                                                   d.Lifetime == lifetime &&
                                                                                                                   d.ServiceType == serviceType &&
                                                                                                                   d.ImplementationType == implementationType &&
                                                                                                                   d.ServiceKey == null);
        }
    }
}
