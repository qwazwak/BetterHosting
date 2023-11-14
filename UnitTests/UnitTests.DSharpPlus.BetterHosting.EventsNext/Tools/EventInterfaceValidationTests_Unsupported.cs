using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixtureSource(typeof(InvalidHandlerTypesTestData), nameof(InvalidHandlerTypesTestData.InvalidGenericEventHandlerTypes))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventInterfaceValidationTests_Unsupported<TInterface> where TInterface : IDiscordEventHandler
{
    [Test]
    public void IsExactInterface_ByType()
    {
        bool isExact = EventInterfaceValidation.IsExactInterface(typeof(TInterface));
        Assert.That(isExact, Is.False);
    }

    [Test]
    public void VerifyExactInterface_ByType() => Assert.Throws<InvalidHandlerInterfaceException>([ExcludeFromCodeCoverage(Justification = "Method call for unit test")] () => HandlerVerification.VerifyExactInterface(typeof(TInterface)));

    [Test]
    public void IsExactInterface_ByGeneric()
    {
        bool isExact = EventInterfaceValidation.IsExactInterface<TInterface>();
        Assert.That(isExact, Is.False);
    }

    [Test]
    public void VerifyExactInterface_ByGeneric() => Assert.Throws<InvalidHandlerInterfaceException>(HandlerVerification.VerifyExactInterface<TInterface>);
}