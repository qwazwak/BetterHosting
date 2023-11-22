using System;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixture(TestOf = typeof(EventReflection))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.EventHandlerBaseInterface))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
public class EventReflectionInvalidTests<TInterface> where TInterface : IDiscordEventHandler
{
    private static readonly Type DebugException = Type.GetType("Microsoft.VisualStudio.TestPlatform.TestHost.DebugAssertException")!;

    [Test]
    public void NoResultsByType() => AssertNoDetails(() => EventReflection.DetailsFor(typeof(TInterface)));

    [Test]
    public void NoResultsByGeneric() => AssertNoDetails(EventReflection.DetailsFor<TInterface>);

    private protected static void AssertNoDetails(Func<EventReflection.DetailsRecord> testDelegate)
    {
        Exception ex = Assert.Throws(Is.AssignableTo<Exception>(), () => testDelegate.Invoke());
        Assert.That(ex.GetType().Name, Is.EqualTo("DebugAssertException"));
    }
}