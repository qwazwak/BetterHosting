using System;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixture]
public class EventInterfaceValidationTests
{
    [Test]
    [TestCaseSource(typeof(DataSources), nameof(DataSources.Supported))]
    public void VerifyExactInterface(Type interfaceType) => Assert.DoesNotThrow(() => EventReflection.Validation.VerifyExactInterface(interfaceType));

    [Test]
    [TestCaseSource(typeof(DataSources), nameof(DataSources.Supported))]
    public void IsExactInterface(Type interfaceType)
    {
        bool isExact = EventReflection.Validation.IsExactInterface(interfaceType);
        Assert.That(isExact, Is.True);
    }

    [Test]
    [TestCaseSource(typeof(DataSources), nameof(DataSources.Supported))]
    public void IsAssignableToAny(Type interfaceType)
    {
        bool isExact = EventReflection.Validation.IsAssignableToAny(interfaceType);
        Assert.That(isExact, Is.True);
    }

    [Test]
    [TestCaseSource(typeof(DataSources), nameof(DataSources.Invalid))]
    public void IsExactInterfaceInvalid(Type interfaceType)
    {
        bool isExact = EventReflection.Validation.IsExactInterface(interfaceType);
        Assert.That(isExact, Is.False);
    }

    [Test]
    [TestCaseSource(typeof(DataSources), nameof(DataSources.Invalid))]
    public void VerifyExactInterfaceThrowsWrong(Type interfaceType)
    {
        InvalidHandlerInterfaceException ex = Assert.Throws<InvalidHandlerInterfaceException>(() => EventReflection.Validation.VerifyExactInterface(interfaceType));

        Assert.That(ex.InvalidHandlerInterface, Is.SameAs(interfaceType));
    }
}

file static class DataSources
{
    public static IEnumerable<Type> Supported => HandlerTypesTestData.SpecificHandlerInterfaces;
    public static IEnumerable<Type> Invalid =>
            HandlerTypesTestData.EventHandlerBaseInterface
                .Concat(InvalidHandlerTypesTestData.InvalidGenericEventHandlerTypes)
                .Concat(HandlerTypesTestData.GenericEventHandlerTypes);
}