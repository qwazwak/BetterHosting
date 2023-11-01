using System;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTests.DSharpPlus.BetterHosting.Interactivity;

[TestFixture(TestOf = typeof(BetterHostingInteractivityExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Clarify SUT ")]
public partial class BetterHostingInteractivityExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_Direct_ThrowsOnNullServices() => Assert.Throws<ArgumentNullException>(() => BetterHostingInteractivityExtensions.AddInteractivityConfig(Mock.Of<IServiceCollection>(), (InteractivityConfiguration)null!));

    [Test]
    public void AddInteractivityConfig_Direct_ThrowsOnNullOptions() => Assert.Throws<ArgumentNullException>(() => BetterHostingInteractivityExtensions.AddInteractivityConfig(null!, new InteractivityConfiguration()));

    [Test]
    public void AddInteractivityConfigThrowsOnNullServices() => Assert.Throws<ArgumentNullException>(() => BetterHostingInteractivityExtensions.AddInteractivityConfig(Mock.Of<IServiceCollection>(), (string)null!));

    [Test]
    public void AddInteractivityConfigThrowsOnNullOptions() => Assert.Throws<ArgumentNullException>(() => BetterHostingInteractivityExtensions.AddInteractivityConfig(null!, "TestString"));
}
