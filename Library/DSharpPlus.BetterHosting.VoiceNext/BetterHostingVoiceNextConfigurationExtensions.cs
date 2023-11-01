using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.VoiceNext;

/// <summary>
/// Extension methods to provide various ways to add an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/>
/// </summary>
public static class BetterHostingVoiceNextConfigurationExtensions
{
    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/> wrapping the input value
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config">The value to provide to <see cref="VoiceNextExtension"/></param>
    /// <returns>An <see cref="OptionsBuilder{TOptions}"/> which can be used to further configure the <see cref="VoiceNextConfiguration"/></returns>
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, VoiceNextConfiguration config) => services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<VoiceNextConfiguration>();

    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}"/> of <see cref="VoiceNextConfiguration"/> which will be bound from the <see cref="IConfiguration"/> by the <paramref name="configSectionPath"/>
    /// </summary>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>An <see cref="OptionsBuilder{TOptions}"/> which can be used to further configure the <see cref="VoiceNextConfiguration"/></returns>
    public static OptionsBuilder<VoiceNextConfiguration> AddVoiceNextConfig(this IServiceCollection services, string configSectionPath) => services.AddOptions<VoiceNextConfiguration>().BindConfiguration(configSectionPath, o => o.BindNonPublicProperties = true);
}
#if false
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
#endif