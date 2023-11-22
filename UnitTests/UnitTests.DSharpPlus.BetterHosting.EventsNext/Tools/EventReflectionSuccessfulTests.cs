using System;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Reflection;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestOf(typeof(EventReflection))]
[TestFixture]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
public class EventReflectionSuccessfulTests
{
    const int RepeatCount = 5;
    private static readonly MethodInfo CallGenericCoreInfo = typeof(EventReflectionSuccessfulTests).GetMethod(nameof(CallGenericCore), BindingFlags.Static | BindingFlags.NonPublic, Type.EmptyTypes)!;
    private static EventReflection.DetailsRecord CallGenericCore<TInterface>() where TInterface : IDiscordEventHandler => EventReflection.DetailsFor<TInterface>();

    private readonly Type interfaceType;
    private readonly Func<EventReflection.DetailsRecord> genericMethod;

    public EventReflectionSuccessfulTests(Type interfaceType)
    {
        this.interfaceType = interfaceType;
        Assume.That(CallGenericCoreInfo, Is.Not.Null, $"Did not find {nameof(CallGenericCore)}");
        genericMethod = CallGenericCoreInfo.MakeGenericMethod(interfaceType).CreateDelegate<Func<EventReflection.DetailsRecord>>();
    }

    [Test]
    public void InterfaceGetsDetailsByType() => InterfaceGetsDetailsCore(() => EventReflection.DetailsFor(interfaceType));

    [Test]
    public void InterfaceGetsDetailsGeneric() => InterfaceGetsDetailsCore(genericMethod);

    private void InterfaceGetsDetailsCore(Func<EventReflection.DetailsRecord> method)
    {
        EventReflection.DetailsRecord detail = method();
        Assert.That(detail, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(detail.EventInterface, Is.Not.Null);
            Assert.That(detail.EventInterface, Is.EqualTo(interfaceType));
            Assert.That(detail.ArgumentType, Is.Not.Null);
            Assert.That(detail.BinderAdapter, Is.Not.Null);
            Assert.That(detail.CallAdapter, Is.Not.Null);
        });
    }

    [Test]
    public void MultipleCallsReturnSameByType() => MultipleCallsReturnSame(() => EventReflection.DetailsFor(interfaceType));

    [Test]
    public void MultipleCallsReturnSameGeneric() => MultipleCallsReturnSame(genericMethod);

    private protected static void MultipleCallsReturnSame(Func<EventReflection.DetailsRecord> getDetail)
    {
        List<EventReflection.DetailsRecord> pastResults = new(RepeatCount) { getDetail.Invoke() };
        for (int i = 0; i < RepeatCount; i++)
        {
            EventReflection.DetailsRecord newDetail = getDetail();

            Assume.That(pastResults, Has.All.SameAs(newDetail));
            Assert.That(pastResults, Has.All.EqualTo(newDetail));
        }
    }
}
