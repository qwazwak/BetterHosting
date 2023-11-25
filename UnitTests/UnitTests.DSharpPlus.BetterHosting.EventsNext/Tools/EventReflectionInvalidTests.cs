using System;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixture(TestOf = typeof(EventReflection))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventReflectionInvalidTests<TInterface> where TInterface : IDiscordEventHandler
{
    [Test]
    public void NoResultsByType() => AssertNoDetails(() => EventReflection.DetailsFor(typeof(TInterface)));

    [Test]
    public void NoResultsByGeneric() => AssertNoDetails(EventReflection.DetailsFor<TInterface>);

    private protected static void AssertNoDetails(Func<EventReflection.DetailsRecord> testDelegate)
    {
        Exception ex = Assert.Throws(Is.AssignableTo<Exception>(), () => testDelegate.Invoke());
#if DEBUG
        Assert.That(ex.GetType().Name, Is.EqualTo("DebugAssertException"));
#else
        Assert.That(ex, Is.TypeOf<KeyNotFoundException>());
#endif
    }
}