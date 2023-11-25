using System;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixture(TestOf = typeof(EventReflection))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventReflectionInvalidTests<TInterface> where TInterface : IDiscordEventHandler
{
    [Test]
    public void NoResultsByType()
    {
        Type interfaceType = typeof(TInterface);
        
        InvalidHandlerInterfaceException ex = Assert.Throws<InvalidHandlerInterfaceException>(() => EventReflection.DetailsFor(interfaceType));
        Assert.That(ex.InvalidHandlerInterface, Is.SameAs(interfaceType));
    }
}