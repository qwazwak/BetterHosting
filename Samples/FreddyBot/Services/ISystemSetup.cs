using System.Threading;
using System.Threading.Tasks;

namespace FreddyBot.Services;

public interface ISystemSetup
{
    public Task Run(CancellationToken cancellationToken);
}