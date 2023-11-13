using System;
using Microsoft.Extensions.DependencyInjection;
using UnitTestHelpers.Constraints;

namespace UnitTestHelpers;

public static class IsDescriptor
{
    public static class From
    {
        public static ServiceDescriptorConstraint AddTransient<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Transient);
        public static ServiceDescriptorConstraint AddScoped<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Scoped);
        public static ServiceDescriptorConstraint AddSingleton<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Scoped);

        public static ServiceDescriptorConstraint Add<TInterface, TImplementation>(ServiceLifetime lifetime) => Add(typeof(TInterface), typeof(TImplementation), lifetime);
        public static ServiceDescriptorConstraint Add(Type serviceType, Type implementationType, ServiceLifetime lifetime) => new BasicServiceDescriptorConstraint(lifetime, null, serviceType, implementationType);
    }
}