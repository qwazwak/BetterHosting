﻿using System.Diagnostics.CodeAnalysis;
using System;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.VoiceNext;

namespace UnitTests.DSharpPlus.BetterHosting.VoiceNext;

[TestFixture(TestOf = typeof(VoiceNextConfigurationExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class VoiceNextConfigurationExtensionsTests
{
    [Test]
    public void AddInteractivityConfigOption_ThrowsOnNullString() => Assert.Throws<ArgumentNullException>(() => VoiceNextConfigurationExtensions.AddVoiceNextConfig(Mock.Of<IServiceCollection>(), (string)null!));

    [Test]
    public void AddInteractivityConfigOption_ThrowsOnNullCollection() => Assert.Throws<ArgumentNullException>(() => VoiceNextConfigurationExtensions.AddVoiceNextConfig(null!, "string"));

    [Test]
    public void AddInteractivityConfigInstance_ThrowsOnNullInstance() => Assert.Throws<ArgumentNullException>(() => VoiceNextConfigurationExtensions.AddVoiceNextConfig(Mock.Of<IServiceCollection>(), (VoiceNextConfiguration)null!));

    [Test]
    public void AddInteractivityConfigInstance_ThrowsOnNullCollection() => Assert.Throws<ArgumentNullException>(() => VoiceNextConfigurationExtensions.AddVoiceNextConfig(null!, new VoiceNextConfiguration()));

    [Test]
    public void AddInstance()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Loose);
        VoiceNextConfiguration config = new();

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.Options.AddSingletonOption(config))).Verifiable(Times.Once);

        mockServices.Object.AddVoiceNextConfig(config);

        mockServices.Verify();
    }
}