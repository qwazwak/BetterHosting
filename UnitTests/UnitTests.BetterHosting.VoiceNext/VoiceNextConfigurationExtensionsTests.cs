using System.Diagnostics.CodeAnalysis;
using System;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.DependencyInjection;
using BetterHosting.VoiceNext;
using Microsoft.Extensions.Options;

namespace UnitTests.BetterHosting.VoiceNext;

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

    [Test]
    public void AddInstanceByOption()
    {
        const string path = "wdfepouhgpiojudrfphuigfr.gfddfgdfg.dgfgdf";
        IServiceCollection mockServices = Mock.Of<IServiceCollection>();

        OptionsBuilder<VoiceNextConfiguration> result = VoiceNextConfigurationExtensions.AddVoiceNextConfig(mockServices, path);
        Assert.Multiple(() =>
        {
            Assert.That(mockServices, Is.SameAs(result.Services));
            Assert.That(result, Is.Not.Null);
        });
        Assert.That(result, Is.AssignableTo<OptionsBuilder<VoiceNextConfiguration>>());
    }
}