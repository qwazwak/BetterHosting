using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.Extensions;

namespace DSharpPlus.BetterHosting.Services.Implementation.Extensions;

/// <summary>
/// Template base class to ease adding of <typeparamref name="TExtension"/> to <see cref="DiscordShardedClient"/>
/// </summary>
/// <typeparam name="TExtension"></typeparam>
public abstract class ExtensionAdditionTemplate<TExtension> : IDiscordClientConfigurator where TExtension : BaseExtension
{
    private readonly List<IDiscordExtensionConfigurator<TExtension>> configurators;

    /// <summary>
    /// Constructs the base template
    /// </summary>
    /// <param name="configurators">All registered configurators</param>
    protected ExtensionAdditionTemplate(IEnumerable<IDiscordExtensionConfigurator<TExtension>> configurators) => this.configurators = new(configurators);

    ValueTask IDiscordClientConfigurator.Configure(DiscordShardedClient client, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return ValueTask.FromCanceled(cancellationToken);

        return new(Configure(client, cancellationToken));
    }

    /// <inheritdoc cref="IDiscordClientConfigurator.Configure(DiscordShardedClient, CancellationToken)"/>
    public async Task Configure(DiscordShardedClient client, CancellationToken cancellationToken)
    {
        IReadOnlyDictionary<int, TExtension> configs = await UseExtension(client);

        Parallel.ForEach(configs, new ParallelOptions() { CancellationToken = cancellationToken }, ConfigureOne);
    }

    private void ConfigureOne(KeyValuePair<int, TExtension> kvp)
    {
        int shardID = kvp.Key;
        TExtension extension = kvp.Value;
        foreach (IDiscordExtensionConfigurator<TExtension> configurator in configurators)
            Configure(configurator, shardID, extension);
    }

    /// <summary>
    /// Add the extension to the <paramref name="client"/>
    /// </summary>
    /// <param name="client">The <see cref="DiscordShardedClient"/> to add and configure the extension with</param>
    /// <returns>The extensions by shard</returns>
    protected abstract Task<IReadOnlyDictionary<int, TExtension>> UseExtension(DiscordShardedClient client);

    /// <summary>
    /// Applies configurator to the extension
    /// </summary>
    /// <remarks>
    /// virtual to allow for extension specific configurations</remarks>
    /// <param name="configurator"></param>
    /// <param name="shardID"></param>
    /// <param name="extension"></param>
    /// <returns>A <see cref="ValueTask"/> representing configuration completion</returns>
    protected virtual void Configure(IDiscordExtensionConfigurator<TExtension> configurator, int shardID, TExtension extension) => configurator.Configure(shardID, extension);
}
