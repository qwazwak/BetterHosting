using System;
using DSharpPlus.BetterHosting.CommandsNext.Options;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace DSharpPlus.BetterHosting.VoiceNext;

public static class BetterHostingVoiceNextExtensions
{
    public static IServiceCollection AddVoiceNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddTransient<IDiscordClientConfigurator, VoiceNextSetup>();
        services.AddOptions<VoiceNextConfiguration>().BindWorkaround(nameof(VoiceNextConfiguration));

        return services;
    }

    public static IServiceCollection AddVoiceNext(this IServiceCollection services, VoiceNextConfiguration options)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(options);
        services.AddVoiceNext().AddVoiceNextConfig(options);
        return services;
    }

    public static IServiceCollection AddVoiceNextWithOptions(this IServiceCollection services, string optionsKey = nameof(VoiceNextConfiguration))
    {
        services.AddVoiceNext().AddVoiceNextConfig(optionsKey);
        return services;
    }

    public static IServiceCollection AddVoiceNextWithOptions(this IServiceCollection services, string optionsKey, Action<VoiceNextConfiguration> configureOptions)
    {
        services.AddVoiceNext().AddVoiceNextConfig(optionsKey).Configure(configureOptions);
        return services;
    }
}
public static class BetterHostingVoiceNextConfigurationExtensions
{
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, VoiceNextConfiguration config) => services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<VoiceNextConfiguration>();
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, string configurationKey) => services.AddOptions<VoiceNextConfiguration>().BindVoiceNextConfiguration(configurationKey);
}
internal static class BetterHostingVoiceNextConfigurationHelper
{
    public static OptionsBuilder<VoiceNextConfiguration> BindVoiceNextConfiguration(this OptionsBuilder<VoiceNextConfiguration> builder, string sectionNamePath) => builder.Configure<IConfiguration>((o, c) => ConfigureVoiceNextConfiguration(o, c, sectionNamePath));
    public static void ConfigureVoiceNextConfiguration(VoiceNextConfiguration options, IConfiguration configuration, string sectionNamePath)
    {
        IConfigurationSection section = configuration.GetRequiredSection(sectionNamePath);
        ConfigureVoiceNextConfiguration(options, section);
    }
    public static void ConfigureVoiceNextConfiguration(VoiceNextConfiguration options, IConfigurationSection configuration)
    {
        options.EnableIncoming = configuration.GetValue<bool>(nameof(VoiceNextConfiguration.EnableIncoming), false);
        options.PacketQueueSize = configuration.GetValue<int>(nameof(VoiceNextConfiguration.PacketQueueSize), 25);

        IConfigurationSection autoFormatSection = configuration.GetSection("AudioFormat");
        AudioFormat defaultFormat = new();
        if (!autoFormatSection.Exists())
        {
            options.AudioFormat = defaultFormat;
        }
        else
        {
            int sampleRate = autoFormatSection.GetValue(nameof(AudioFormat.SampleRate), defaultFormat.SampleRate);
            int channelCount = autoFormatSection.GetValue(nameof(AudioFormat.ChannelCount), defaultFormat.ChannelCount);
            VoiceApplication voiceApplication = autoFormatSection.GetValue(nameof(AudioFormat.VoiceApplication), defaultFormat.VoiceApplication);

            options.AudioFormat = new(sampleRate, channelCount, voiceApplication);
        }
    }
}