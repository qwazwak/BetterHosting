using System;
using DSharpPlus.BetterHosting.CommandsNext.Options;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.VoiceNext;

public static class BetterHostingVoiceNextExtensions
{
    public static IServiceCollection AddVoiceNext(this IServiceCollection services, VoiceNextConfiguration options) => services.AddVoiceNext().AddVoiceNextConfig(options);
    public static IServiceCollection AddVoiceNext(this IServiceCollection services, string optionsKey = nameof(VoiceNextConfiguration), Action<VoiceNextConfiguration>? configureOptions = null) => services.AddVoiceNext().AddVoiceNextConfig(optionsKey, configureOptions);

    private static IServiceCollection AddVoiceNext(this IServiceCollection services)
    {
        services.AddTransient<IDiscordClientConfigurator, VoiceNextSetup>();
        services.AddOptions<VoiceNextConfiguration>().BindWorkaround(nameof(VoiceNextConfiguration));

        return services;
    }

    private static IServiceCollection AddVoiceNextConfig(this IServiceCollection services, VoiceNextConfiguration config)
    {
        services.RemoveVoiceNextConfig();
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config));
    }

    private static IServiceCollection AddVoiceNextConfig(this IServiceCollection services, string configurationKey, Action<VoiceNextConfiguration>? configureOptions = null)
    {
        services.RemoveVoiceNextConfig();

        OptionsBuilder<VoiceNextConfiguration> options = services.AddOptions<VoiceNextConfiguration>()
            .BindWorkaround(configurationKey, _ => { })
            .Configure<IConfiguration>((o, c) =>
            {
                IConfigurationSection section = c.GetSection(configurationKey).GetSection("AudioFormat");
                AudioFormat defaultFormat = new();
                if (!section.Exists())
                {
                    o.AudioFormat = defaultFormat;
                }
                else
                {
                    int sampleRate = section.GetValue(nameof(AudioFormat.SampleRate), defaultFormat.SampleRate);
                    int channelCount = section.GetValue(nameof(AudioFormat.ChannelCount), defaultFormat.ChannelCount);
                    VoiceApplication voiceApplication = section.GetValue(nameof(AudioFormat.VoiceApplication), defaultFormat.VoiceApplication);

                    o.AudioFormat = new(sampleRate, channelCount, voiceApplication);
                }
            });
        if (configureOptions is not null)
            services.Configure(configureOptions);
        return services;
    }

    private static void RemoveVoiceNextConfig(this IServiceCollection services)
    {
        services.RemoveAll<IOptions<VoiceNextConfiguration>>();
        services.RemoveAll<IConfigureOptions<VoiceNextConfiguration>>();
    }
}