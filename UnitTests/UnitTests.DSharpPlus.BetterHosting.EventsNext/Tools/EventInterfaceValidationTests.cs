using System;
using System.Reflection;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
public class EventInterfaceValidationTests
{
    private static readonly MethodInfo openGenericIsExact = typeof(EventInterfaceValidation).GetMethod(nameof(EventInterfaceValidation.IsExactInterface), BindingFlags.Static | BindingFlags.Public, Type.EmptyTypes)!;
    private static readonly MethodInfo openGenericAssignableAny = typeof(EventInterfaceValidation).GetMethod(nameof(EventInterfaceValidation.IsAssignableToAny), BindingFlags.Static | BindingFlags.Public, Type.EmptyTypes)!;

    private readonly Type interfaceType;
    private readonly Func<bool> IsExactInterfaceGenericDelegate;
    private readonly Func<bool> IsAssignableToAnyGenericDelegate;

    public EventInterfaceValidationTests(Type interfaceType)
    {
        this.interfaceType = interfaceType;
        IsExactInterfaceGenericDelegate = openGenericIsExact.MakeGenericMethod(interfaceType).CreateDelegate<Func<bool>>();
        IsAssignableToAnyGenericDelegate = openGenericAssignableAny.MakeGenericMethod(interfaceType).CreateDelegate<Func<bool>>();
    }

    [Test]
    public void IsExactInterface_Generic()
    {
        bool isExact = IsExactInterfaceGenericDelegate();
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void IsExactInterface_ByType()
    {
        bool isExact = EventInterfaceValidation.IsExactInterface(interfaceType);
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void IsAssignableToAny_Generic()
    {
        bool isExact = IsAssignableToAnyGenericDelegate();
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void IsAssignableToAny_ByType()
    {
        bool isExact = EventInterfaceValidation.IsAssignableToAny(interfaceType);
        Assert.That(isExact, Is.True);
    }

    [Test]
    public void VerifyExactInterface_Generic() => Assert.DoesNotThrow(() => IsExactInterfaceGenericDelegate.Invoke());

    [Test]
    public void VerifyExactInterface_ByType() => Assert.DoesNotThrow(() => HandlerVerification.VerifyExactInterface(interfaceType));
}
