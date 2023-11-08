using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class BindConfigurationLoggerFactory : IConfigureOptions<DiscordConfiguration>
{
    /// <summary>
    /// The dependency.
    /// </summary>
    private readonly ILoggerFactory factory;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="factory">A dependency.</param>
    public BindConfigurationLoggerFactory(ILoggerFactory factory) => this.factory = factory;

    public void Configure(DiscordConfiguration options) => options.LoggerFactory = factory;
}