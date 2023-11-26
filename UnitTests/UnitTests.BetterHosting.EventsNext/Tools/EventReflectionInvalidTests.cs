using System;
using BetterHosting.EventsNext.Exceptions;
using BetterHosting.EventsNext.Services;
using BetterHosting.EventsNext.Tools;

namespace UnitTests.BetterHosting.EventsNext.Tools;

[TestFixture(TestOf = typeof(EventReflection))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventReflectionInvalidTests<TInterface> where TInterface : IDiscordEventHandler
{
    [Test]
    public void NoResultsByType()
    {
        Type interfaceType = typeof(TInterface);

        InvalidHandlerInterfaceException invalidHandlerEx = Assert.Throws<InvalidHandlerInterfaceException>(() => EventReflection.DetailsFor(interfaceType));
        Assert.That(invalidHandlerEx.InvalidHandlerInterface, Is.SameAs(interfaceType));
    }
}