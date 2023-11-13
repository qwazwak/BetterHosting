namespace DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

/// <summary>
/// Interface to signal and allow for configuration of <typeparamref name="TExtension"/>
/// </summary>
public interface IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension
{
    /// <summary>
    /// Configure the <typeparamref name="TExtension"/>, called on each shard
    /// </summary>
    /// <param name="shardID"></param>
    /// <param name="extension"></param>
    void Configure(int shardID, TExtension extension);
}
