using System;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelpers;

public static partial class ItMore
{
    public static partial class ServiceDescriptorFrom
    {
        public static class Instance
        {
            public static ServiceDescriptor AddSingleton<TInterface, TImplementation>(TImplementation instance) where TImplementation : TInterface => AddSingleton(typeof(TInterface), instance!);
            public static ServiceDescriptor AddSingleton(Type serviceType, object implementationInstance) => It.Is<ServiceDescriptor>(d =>
                d.Lifetime == ServiceLifetime.Singleton &&
                d.ServiceType == serviceType &&
                d.ImplementationInstance == implementationInstance &&
                d.ServiceKey == null);

            public static ServiceDescriptor AddAnySingleton<TInterface>() => AddAnySingleton(typeof(TInterface));
            public static ServiceDescriptor AddAnySingleton(Type serviceType) => It.Is<ServiceDescriptor>(d =>
                d.Lifetime == ServiceLifetime.Singleton &&
                d.ServiceType == serviceType &&
                d.ImplementationInstance != null &&
                d.ImplementationInstance.GetType().IsAssignableTo(serviceType) &&
                d.ServiceKey == null);
        }
    }
}
