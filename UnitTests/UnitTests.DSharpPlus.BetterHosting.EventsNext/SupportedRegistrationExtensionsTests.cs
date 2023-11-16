using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using UnitTests.DSharpPlus.BetterHosting.EventsNext;
using System;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace DSharpPlus.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(RegistrationExtensions))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class SupportedRegistrationExtensionsTests<TEventInterface> where TEventInterface : class, IDiscordEventHandler
{
    [Test]
    public void AddEventHandlersThrowsOnNull()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => RegistrationExtensions.AddEventHandlers<TEventInterface>(null!));

        Assert.That(ex.ParamName, Is.EqualTo("services"));
    }

    [Test]
    public void AddEventHandlers()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        mockServices.Setup(s => s.Count).Returns(0);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Instance.AddAnySingleton<HandlerRegistry<TEventInterface>>()))
            .Verifiable(Times.Once);

        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        mockServices.Verify();

        Assert.That(result, Is.Not.Null);
    }
}
