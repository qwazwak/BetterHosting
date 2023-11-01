using System;
using System.Threading.Tasks;
using System.Threading;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class DiscordDefaultActivityProvider : IDiscordDefaultActivityProvider
{
    private readonly DiscordActivity activity;

    public DiscordDefaultActivityProvider(DiscordActivity activity) => this.activity = activity;

    public ValueTask<DiscordActivity> DefaultActivity(CancellationToken cancellationToken) => ValueTask.FromResult(activity);
}