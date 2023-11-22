using System;
using DSharpPlus.BetterHosting.EventsNext;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

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
    public void ConstructorDoesNothing()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        mockServices.Verify();

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void AddEventHandler()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d =>
                    d.Lifetime == ServiceLifetime.Transient &&
                    d.ServiceType == typeof(IHandlerRegistration<TEventInterface>) &&
                    d.KeyedImplementationType == typeof(HandlerRegistration<TEventInterface>) &&
                    d.ServiceKey is Guid)))
            .Verifiable(Times.Once);

        mockServices.Setup(s => s.Count)
            .Returns(1)
            .Verifiable(Times.Once);

        mockServices.Setup(s => s[0])
            .Returns(ServiceDescriptor.KeyedTransient<IHandlerRegistration<TEventInterface>>(Guid.NewGuid(), (sp, k)  => null!))
            .Verifiable(Times.Once);

        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Services, Is.SameAs(mockServices.Object));

        RegistrationBuilder<TEventInterface> result2 = result.RegisterHandler<TEventInterface>();
        Assert.That(result2, Is.SameAs(result));

        mockServices.Verify();
    }
}
