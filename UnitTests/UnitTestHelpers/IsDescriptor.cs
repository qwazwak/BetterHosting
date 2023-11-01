using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelpers;

public static class IsDescriptor
{
    public static EquivelentServiceDescriptorConstraint AddTransient<TInterface, TImplementation>() => Add<TInterface, TImplementation>(ServiceLifetime.Transient);

    public static EquivelentServiceDescriptorConstraint Add<TInterface, TImplementation>(ServiceLifetime lifetime) => Add(new ServiceDescriptor(typeof(TInterface), typeof(TImplementation), lifetime));
    public static EquivelentServiceDescriptorConstraint Add(ServiceDescriptor descriptor) => new(descriptor);
}
