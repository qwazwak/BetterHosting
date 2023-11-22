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
        Assume.That(DebugException, Is.Not.Null, "Could not find exception type");
        Assert.Throws(Is.AssignableTo<Exception>().And.TypeOf(DebugException), () => testDelegate.Invoke());
    }
}