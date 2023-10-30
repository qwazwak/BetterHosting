using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IDiscordDefaultActivityProvider
{
    public ValueTask<DiscordActivity> DefaultActivity(CancellationToken cancellationToken);
}
