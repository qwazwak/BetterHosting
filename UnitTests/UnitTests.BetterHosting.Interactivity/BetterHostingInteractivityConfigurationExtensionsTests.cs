using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.BetterHosting.Interactivity;

[TestFixture(TestOf = typeof(BetterHostingInteractivityExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Clarify SUT ")]
public class BetterHostingInteractivityConfigurationExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_Direct_ThrowsOnNullServices()
    {
        Assert.Throws<ArgumentNullException>(CallMethod);
        static void CallMethod() => BetterHostingInteractivityConfigurationExtensions.AddInteractivityConfig(Mock.Of<IServiceCollection>(), (InteractivityConfiguration)null!);
    }

    [Test]
    public void AddInteractivityConfig_Direct_ThrowsOnNullOptions()
    {
        Assert.Throws<ArgumentNullException>(CallMethod);
        static void CallMethod() => BetterHostingInteractivityConfigurationExtensions.AddInteractivityConfig(null!, new InteractivityConfiguration());
    }

    [Test]
    public void AddInteractivityConfigThrowsOnNullServices()
    {
        Assert.Throws<ArgumentNullException>(CallMethod);
        static void CallMethod() => BetterHostingInteractivityConfigurationExtensions.AddInteractivityConfig(Mock.Of<IServiceCollection>(), (string)null!);
    }

    [Test]
    public void AddInteractivityConfigThrowsOnNullOptions()
    {
        Assert.Throws<ArgumentNullException>(CallMethod);
        static void CallMethod() => BetterHostingInteractivityConfigurationExtensions.AddInteractivityConfig(null!, "TestString");
    }
}
