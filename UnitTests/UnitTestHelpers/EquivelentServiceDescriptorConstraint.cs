using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Constraints;

namespace UnitTestHelpers;

/// <summary>
/// InstanceOfTypeConstraint is used to test that an object
/// is of the same type provided or derived from it.
/// </summary>
public class EquivelentServiceDescriptorConstraint : Constraint
{
    /// <summary>
    /// The expected Type used by the constraint
    /// </summary>
    protected ServiceDescriptor ExpectedDescriptor;

    /// <summary>
    /// The type of the actual argument to which the constraint was applied
    /// </summary>
    protected ServiceDescriptor ActualDescriptor;

    /// <summary>
    /// Construct a TypeConstraint for a given Type
    /// </summary>
    /// <param name="serviceDescriptor">The expected <see cref="ServiceDescriptor"/></param>
    public EquivelentServiceDescriptorConstraint(ServiceDescriptor serviceDescriptor)
        : base(serviceDescriptor)
    {
        ArgumentNullException.ThrowIfNull(serviceDescriptor);
        ExpectedDescriptor = serviceDescriptor;
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
        if (ExpectedDescriptor is null)
            return new ConstraintResult(this, actual, actual is null);

        if (actual is not ServiceDescriptor actualDescriptor)
        {
            throw new ArgumentException($"{nameof(TActual)} was of type {typeof(TActual).Name}, but {nameof(ServiceDescriptor)} was required");
        }

        ActualDescriptor = actualDescriptor;
        return new ConstraintResult(this, actualDescriptor, this.Matches(actualDescriptor));
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
    protected /*virtual*/ bool Matches(ServiceDescriptor actual)
    {
        ServiceDescriptor expected = ExpectedDescriptor;
        if (expected.Lifetime != actual.Lifetime || expected.ServiceType != actual.ServiceType || expected.ServiceKey != actual.ServiceKey)
            return false;

        if(expected.ServiceType is not null)
        {
            return actual.ServiceType == expected.ServiceType;
        }

        throw new NotImplementedException("Idk what to do now");
    }
}