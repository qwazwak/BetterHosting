using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BetterHosting.EventsNext;
using BetterHosting.EventsNext.Services;
using BetterHosting.EventsNext.Services.Implementations;
using BetterHosting.EventsNext.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTests.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(RegistrationExtensions))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfaces))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
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
                    d.Lifetime == ServiceLifetime.Singleton &&
                    d.ServiceType == typeof(IHandlerRegistry) &&
                    d.ServiceKey != null &&
                    (Type)d.ServiceKey == typeof(TEventInterface) &&
                    d.KeyedImplementationInstance != null &&
                    d.KeyedImplementationInstance.GetType() == typeof(HandlerRegistry))))
            .Verifiable(Times.Once);

        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d =>
                    d.Lifetime == ServiceLifetime.Singleton &&
                    d.ServiceType == typeof(IEventHandlerManager) &&
                    d.ServiceKey != null &&
                    (Type)d.ServiceKey == typeof(TEventInterface) &&
                    d.KeyedImplementationType == EventReflection.ManagerType.For(typeof(TEventInterface)))))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(It.Is<ServiceDescriptor>(d =>
                    d.Lifetime == ServiceLifetime.Singleton &&
                    d.ServiceType == typeof(IHostedService) &&
                    d.ImplementationType == EventReflection.ManagerHostType.For(typeof(TEventInterface)))))
            .Verifiable(Times.Once);

        mockServices.GetEnumerableReturnsNone();

        RegistrationBuilder<TEventInterface> result = RegistrationExtensions.AddEventHandlers<TEventInterface>(mockServices.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Services, Is.SameAs(mockServices.Object));

        RegistrationBuilder<TEventInterface> result2 = result.RegisterHandler<TEventInterface>();
        Assert.That(result2, Is.SameAs(result));

        mockServices.Verify();
    }
}

public static class MockServiceCollectionExtensions
{
    public static Moq.Language.Flow.IReturnsResult<IServiceCollection> GetEnumerableReturnsNone(this Mock<IServiceCollection> mockServices) => mockServices.GetEnumerableReturnsNone(Times.Once());
    public static Moq.Language.Flow.IReturnsResult<IServiceCollection> GetEnumerableReturnsNone(this Mock<IServiceCollection> mockServices, Times times) => mockServices.GetEnumerableReturnsNone(times, out Mock <IEnumerator<ServiceDescriptor>> _);
    public static Moq.Language.Flow.IReturnsResult<IServiceCollection> GetEnumerableReturnsNone(this Mock<IServiceCollection> mockServices, Times times, out Mock<IEnumerator<ServiceDescriptor>> mockEnumerator)
    {
        mockEnumerator = new(MockBehavior.Strict);
        mockEnumerator.Setup(e => e.MoveNext())
            .Returns(false)
            .Verifiable(times);
        mockEnumerator.Setup(e => e.Dispose())
            .Verifiable(times);
        return mockServices.Setup(s => s.GetEnumerator())
            .Returns(mockEnumerator.Object);
    }
}