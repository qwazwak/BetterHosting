using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal class DiscordActivityOptionsAdapter : IDiscordDefaultActivityProvider
{
    private readonly DiscordActivity activity;

    public DiscordActivityOptionsAdapter(IOptions<DiscordActivity> activity) => this.activity = activity.Value;

    ValueTask<DiscordActivity> IDiscordDefaultActivityProvider.DefaultActivity(CancellationToken cancellationToken) => ValueTask.FromResult(activity);
}