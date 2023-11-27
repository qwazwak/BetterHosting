﻿using BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using BetterHosting.EventsNext.Exceptions;
using System;
using BetterHosting.EventsNext;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.BetterHosting.EventsNext;

[TestFixture(TestOf = typeof(RegistrationExtensions))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.GenericEventHandlerTypes))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
public class UnsupportedRegistrationExtensionsTests<TInterface> where TInterface : class, IDiscordEventHandler
{
    [Test]
    public void AddEventHandlers()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Strict);
        TypeInitializationException ex = Assert.Throws<TypeInitializationException>(() => RegistrationExtensions.AddEventHandlers<TInterface>(mockServices));
        Assert.That(ex.InnerException, Is.Not.Null);
        Assert.That(ex.InnerException, Is.TypeOf<InvalidHandlerInterfaceException>());
        InvalidHandlerInterfaceException inner = (InvalidHandlerInterfaceException)ex.InnerException!;
        Assert.That(inner.InvalidHandlerInterface, Is.EqualTo(typeof(TInterface)));
    }
}