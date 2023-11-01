using DSharpPlus.Lavalink;
using Microsoft.Extensions.Configuration;

namespace DSharpPlus.BetterHosting.Lavalink.Options;

internal interface ILavalinkConfigurationFactory
{
    void BindToSection(LavalinkConfiguration lavalink, IConfiguration configuration);
}
