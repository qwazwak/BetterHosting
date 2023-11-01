using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;

/// <summary>
/// Template base class to ease adding of <typeparamref name="TExtension"/> to <see cref="DiscordShardedClient"/>
/// </summary>
/// <typeparam name="TExtension"></typeparam>
public abstract class ExtensionAdditionTemplate<TExtension> : IDiscordClientConfigurator where TExtension : BaseExtension
{
    private readonly List<IDiscordExtensionConfigurator<TExtension>> configurators;

    /// <summary>
    /// Helper constructor for when a library has an explicit configurator (derived from <see cref="IDiscordExtensionConfigurator{TExtension}"/>) and allows any <see cref="IDiscordExtensionConfigurator{TExtension}"/>
    /// </summary>
    /// <param name="explicitConfigurators"></param>
    /// <param name="configurators"></param>
    protected ExtensionAdditionTemplate(IEnumerable<IDiscordExtensionConfigurator<TExtension>> explicitConfigurators, IEnumerable<IDiscordExtensionConfigurator<TExtension>> configurators) : this(explicitConfigurators.Concat(configurators)) { }

    /// <summary>
    /// Constructs the base template
    /// </summary>
    /// <param name="configurators">All registered configurators</param>
    protected ExtensionAdditionTemplate(IEnumerable<IDiscordExtensionConfigurator<TExtension>> configurators) => this.configurators = new(configurators);

    ValueTask IDiscordClientConfigurator.Configure(DiscordShardedClient client) => new(Configure(client));

    /// <inheritdoc cref="IDiscordClientConfigurator.Configure(DiscordShardedClient)"/>
    public async Task Configure(DiscordShardedClient client)
    {
        IReadOnlyDictionary<int, TExtension> configs = await UseExtension(client);

        foreach (KeyValuePair<int, TExtension> kvp in configs)
        {
            int shardID = kvp.Key;
            TExtension extension = kvp.Value;
            foreach (IDiscordExtensionConfigurator<TExtension> configurator in configurators)
                await Configure(configurator, shardID, extension);
        }
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
    protected virtual ValueTask Configure(IDiscordExtensionConfigurator<TExtension> configurator, int shardID, TExtension extension)
        => configurator.Configure(shardID, extension);
}
