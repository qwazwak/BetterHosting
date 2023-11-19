using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(EventsNextBetterHostExtensions))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class EventsNextBetterHostExtensionsTests
{

    [Test]
    public void AddEventsNextIsNOP()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        EventsNextBetterHostExtensions.AddEventsNext(mockServices.Object);

        mockServices.Verify();
    }
}