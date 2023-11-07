using System;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixtureSource(typeof(EventsNextHandlersTestData), nameof(EventsNextHandlersTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(EventsNextHandlersTestData), nameof(EventsNextHandlersTestData.GenericEventHandlerTypes))]
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
    public void VerifyExactInterface_ByType() => Assert.Throws<InvalidHandlerInterfaceException>(() => HandlerVerification.VerifyExactInterface(interfaceType));
}