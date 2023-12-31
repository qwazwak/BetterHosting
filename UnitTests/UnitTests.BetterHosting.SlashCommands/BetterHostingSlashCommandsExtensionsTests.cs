﻿using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System;
using BetterHosting.SlashCommands.Services.Configuration;
using BetterHosting.SlashCommands.Services.Implementation;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Options;
using BetterHosting.SlashCommands;
using BetterHosting.SlashCommands.Services;
using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;

namespace UnitTests.BetterHosting.SlashCommands;

[TestFixture(TestOf = typeof(BetterHostingSlashCommandsExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
public class BetterHostingSlashCommandsExtensionsTests
{
    [Test]
    public void AddInteractivityConfig_ThrowOnNull() => Assert.Throws<ArgumentNullException>(() => BetterHostingSlashCommandsExtensions.AddSlashCommands(null!));

    [Test]
    public void ReturnsSame()
    {
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Loose);

        IServiceCollection result = BetterHostingSlashCommandsExtensions.AddSlashCommands(mockServices);

        Assert.That(result, Is.SameAs(mockServices));
    }

    [Test]
    public void AddsSetup()
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IConfigureOptions<SlashCommandsConfiguration>, SlashCommandsOptionsConfiguration>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordClientConfigurator, SlashCommandsSetup>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<IDiscordExtensionConfigurator<SlashCommandsExtension>, DiscordExtensionConfiguratorAdapter<ISlashCommandsExtensionConfigurator, SlashCommandsExtension>>())).Verifiable(Times.Once);

        BetterHostingSlashCommandsExtensions.AddSlashCommands(mockServices.Object);

        mockServices.Verify();
    }
}
