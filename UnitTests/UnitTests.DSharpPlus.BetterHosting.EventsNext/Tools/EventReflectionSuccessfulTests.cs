using System;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestOf(typeof(EventReflection))]
[TestFixture]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
public class EventReflectionSuccessfulTests(Type interfaceType)
{
    private readonly Type interfaceType = interfaceType;

    [Test]
    public void InterfaceGetsDetails()
    {
        EventReflection.DetailsRecord detail = EventReflection.DetailsFor(interfaceType);
        Assert.That(detail, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(detail.EventInterface, Is.Not.Null);
            Assert.That(detail.EventInterface, Is.EqualTo(interfaceType));
            Assert.That(detail.ArgumentType, Is.Not.Null);
        });
    }

    const int RepeatCount = 5;

    [Test]
    public void MultipleCallsReturnSameByType()
    {
        List<EventReflection.DetailsRecord> pastResults = new(RepeatCount) { EventReflection.DetailsFor(interfaceType) };
        for (int i = 0; i < RepeatCount; i++)
        {
            EventReflection.DetailsRecord newDetail = EventReflection.DetailsFor(interfaceType);

            Assume.That(pastResults, Has.All.SameAs(newDetail));
            Assert.That(pastResults, Has.All.EqualTo(newDetail));
        }
    }
}
