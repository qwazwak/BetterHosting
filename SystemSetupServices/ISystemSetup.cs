using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface ISystemSetup
{
    public void Run(CancellationToken cancellationToken);
}

public interface IAsyncSystemSetup
{
    public Task Run(CancellationToken cancellationToken);
}