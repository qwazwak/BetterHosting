using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Constraints;

namespace UnitTestHelpers.Constraints;

public abstract class ServiceDescriptorConstraint : Constraint
{
    /// <summary>
    /// Gets the <see cref="ServiceLifetime"/> of the service.
    /// </summary>
    public ServiceLifetime Lifetime { get; }

    /// <summary>
    /// Get the key of the service, if applicable.
    /// </summary>
    public object? ServiceKey { get; }

    /// <summary>
    /// Gets the <see cref="Type"/> of the service.
    /// </summary>
    public Type ServiceType { get; }

    /// <summary>
    /// The type of the actual argument to which the constraint was applied
    /// </summary>
    protected ServiceDescriptor? ActualDescriptor;

    /// <summary>
    /// Construct a TypeConstraint for a given Type
    /// </summary>
    /// <param name="serviceDescriptor">The expected <see cref="ServiceDescriptor"/></param>
    protected ServiceDescriptorConstraint(ServiceLifetime lifetime, object? serviceKey, Type serviceType) : base(lifetime, serviceKey, serviceType)
    {
        Lifetime = lifetime;
        ServiceKey = serviceKey;
        ServiceType = serviceType;
        //Description = descriptionPrefix + MsgUtils.FormatValue(ExpectedDescriptor);
    }
    /*
    private static string GetDescription(ServiceDescriptor? serviceDescriptor)
    {
        serviceDescriptor
    }*/

    /// <summary>
    /// Applies the constraint to an actual value, returning a ConstraintResult.
    /// </summary>
    /// <param name="actual">The value to be tested</param>
    /// <returns>A ConstraintResult</returns>
    public override sealed ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        if (actual is not ServiceDescriptor actualDescriptor)
            throw new ArgumentException($"{nameof(TActual)} was of type {typeof(TActual).Name}, but {nameof(ServiceDescriptor)} was required");

        ActualDescriptor = actualDescriptor;
        return new ConstraintResult(this, actualDescriptor, Matches(actualDescriptor));
    }

    /// <summary>
    /// The display name of this Constraint for use by ToString().
    /// The default value is the name of the constraint with
    /// trailing "Constraint" removed. Derived classes may set
    /// this to another name in their constructors.
    /// </summary>
    public override string DisplayName => "InstanceOf";

    /// <summary>
    /// Apply the constraint to an actual value, returning true if it succeeds
    /// </summary>
    /// <param name="actual">The actual argument</param>
    /// <returns>True if the constraint succeeds, otherwise false.</returns>
    protected virtual bool Matches(ServiceDescriptor actual) => Lifetime == actual.Lifetime && ServiceType == actual.ServiceType && ServiceKey == actual.ServiceKey;
}