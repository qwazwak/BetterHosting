using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

namespace DSharpPlus.EventsNext.BetterHosting.Services.Configuration;

/// <inheritdoc/>
public sealed class EventsNextSetup : ExtensionAdditionTemplate<EventsNextExtension>
{
    private readonly EventsNextConfiguration configuration;

    /// <inheritdoc/>
    public EventsNextSetup(IOptions<EventsNextConfiguration> configuration, IEnumerable<IEventsNextConfigurator> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<EventsNextExtension>> configurators) : base(explicitConfigurators, configurators) => this.configuration = configuration.Value;

    /// <inheritdoc />
    protected override Task<IReadOnlyDictionary<int, EventsNextExtension>> UseExtension(DiscordShardedClient client) => client.UseEventsNextAsync(configuration);
}
