using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixtureSource(typeof(InvalidHandlerTypesTestData), nameof(InvalidHandlerTypesTestData.InvalidGenericEventHandlerTypes))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventInterfaceValidationTests_Unsupported
{
    private readonly Type interfaceType;

    public EventInterfaceValidationTests_Unsupported(Type interfaceType) => this.interfaceType = interfaceType;

    [Test]
    public void IsExactInterface_ByType()
    {
        bool isExact = EventInterfaceValidation.IsExactInterface(interfaceType);
        Assert.That(isExact, Is.False);
    }

    [Test]
    public void VerifyExactInterface_ByType() => Assert.Throws<InvalidHandlerInterfaceException>([ExcludeFromCodeCoverage(Justification = "Method call for unit test")] () => HandlerVerification.VerifyExactInterface(interfaceType));
}