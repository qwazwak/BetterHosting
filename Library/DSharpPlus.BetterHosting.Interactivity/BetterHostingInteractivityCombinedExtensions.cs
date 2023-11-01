using System;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Interactivity;

public static class BetterHostingInteractivityCombinedExtensions
{
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivity(this IServiceCollection services, InteractivityConfiguration options) => services.AddInteractivity().AddInteractivityConfig(options);
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivity(this IServiceCollection services, string optionsKey)
    {
        ArgumentNullException.ThrowIfNull(optionsKey);
        return services.AddInteractivity().AddInteractivityConfig(optionsKey);
    }
}
