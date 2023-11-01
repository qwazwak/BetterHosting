using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTestHelpers;

public static class ItMore
{
    public static class IsServiceAddition
    {
        public static ServiceDescriptor AddTransient<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Transient);

        public static ServiceDescriptor Add<TInterface, TImplementation>(ServiceLifetime lifetime) => It.Is<ServiceDescriptor>(d =>
                                                                                                               d.Lifetime == lifetime &&
                                                                                                               d.ServiceType == typeof(TInterface) &&
                                                                                                               d.ImplementationType == typeof(TImplementation) &&
                                                                                                               d.ServiceKey == null);
    }
}
