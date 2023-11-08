using System;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestHelpers.Constraints;

public class BasicServiceDescriptorConstraint : ServiceDescriptorConstraint
{
    protected readonly Type ImplementationType;
    public BasicServiceDescriptorConstraint(ServiceLifetime lifetime, object? serviceKey, Type serviceType, Type implementationType) : base(lifetime, serviceKey, serviceType) => ImplementationType = implementationType;

    protected override bool Matches(ServiceDescriptor actual) => base.Matches(actual) && ImplementationType.Equals(actual.ImplementationType);
}
