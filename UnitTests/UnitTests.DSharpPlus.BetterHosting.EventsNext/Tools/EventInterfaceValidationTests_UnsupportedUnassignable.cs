using System;
using System.Reflection;
using System.Security;
using DSharpPlus.BetterHosting.EventsNext.Tools;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Tools;

file static class EventInterfaceValidationTests_UnsupportedUnassignableTypes
{
    public static readonly Type[] Types = new[]
    {
        typeof(object),
        typeof(string),
    };
};

[TestFixtureSource(typeof(EventInterfaceValidationTests_UnsupportedUnassignableTypes), nameof(EventInterfaceValidationTests_UnsupportedUnassignableTypes.Types))]
public class EventInterfaceValidationTests_UnsupportedUnassignable : EventInterfaceValidationTests_Unsupported
{
    private static readonly MethodInfo genericMethod = typeof(EventInterfaceValidation).GetMethod(nameof(EventInterfaceValidation.IsExactInterface), BindingFlags.Static | BindingFlags.Public, Type.EmptyTypes)!;

    private readonly Type interfaceType;

    public EventInterfaceValidationTests_UnsupportedUnassignable(Type interfaceType) : base(interfaceType)
    {
        this.interfaceType = interfaceType;
    }

    [Test]
    public new void IsExactInterface_ByType() => base.IsExactInterface_ByType();
    [Test]
    public new void VerifyExactInterface_ByType() => base.IsExactInterface_ByType();

    [Test]
    public void IsExactInterface_Generic()
    {
        ArgumentException argumentException = Assert.Throws<ArgumentException>(() => genericMethod.MakeGenericMethod(interfaceType)/*.CreateDelegate<Func<bool>>()*/);
        Assert.That(argumentException.InnerException, Is.TypeOf<VerificationException>());
    }
}