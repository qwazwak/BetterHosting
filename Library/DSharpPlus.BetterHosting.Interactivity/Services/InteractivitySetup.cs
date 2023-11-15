using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.Extensions;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Interactivity.Services;

internal sealed class InteractivitySetup : ExtensionAdditionTemplate<InteractivityExtension>
{
    private readonly InteractivityConfiguration configuration;

    public InteractivitySetup(IOptions<InteractivityConfiguration> configuration, IEnumerable<IDiscordExtensionConfigurator<InteractivityExtension>> configurators) : base(configurators) => this.configuration = configuration.Value;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    protected override Task<IReadOnlyDictionary<int, InteractivityExtension>> UseExtension(DiscordShardedClient shard) => shard.UseInteractivityAsync(configuration);
}