using System;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Implementations;

internal class DelayedInvocationProvider : IOptions<LavalinkConfiguration>
{
    private readonly Lazy<LavalinkConfiguration> configProvider;
    public DelayedInvocationProvider(Func<LavalinkConfiguration> configProvider) => this.configProvider = new(configProvider);

    public LavalinkConfiguration Value => new(configProvider.Value);
}
