using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal sealed class SetupRunnerService : BackgroundService /*IHostedLifecycleService*/
{
    private readonly ILogger<SetupRunnerService> logger;
    private IServiceScopeFactory scopeProvider;

    public SetupRunnerService(ILogger<SetupRunnerService> logger, IServiceScopeFactory scopeProvider)
    {
        this.logger = logger;
        this.scopeProvider = scopeProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Debug.Assert(scopeProvider != null);
        await using AsyncServiceScope scope = scopeProvider.CreateAsyncScope();
        List<IAsyncSystemSetup> asyncSetups = new(scope.ServiceProvider.GetServices<IAsyncSystemSetup>());
        List<ISystemSetup> syncSetups = new(scope.ServiceProvider.GetServices<ISystemSetup>());

        if (syncSetups.Count == 0 && asyncSetups.Count == 0)
        {
            logger.LogInformation("No setups provided");
            return;
        }

        Task allAsync = SetupAsync(asyncSetups, cancellationToken);
        SetupSync(syncSetups, cancellationToken);
        await allAsync;
    }
    private void SetupSync(List<ISystemSetup> syncSetups, CancellationToken cancellationToken)
    {
        if (syncSetups.Count == 0)
        {
            logger.LogTrace("No sync setup to run, exiting fast");
            return;
        }

        Stopwatch sw = Stopwatch.StartNew();
        logger.LogTrace("Starting running of ({count}) setup tasks", syncSetups.Count);
        Parallel.ForEach(syncSetups, setup => setup.Run(cancellationToken));
        sw.Stop();
        logger.LogInformation("Finished ({count}) setup tasks in {elapsed}", syncSetups.Count, sw.Elapsed);
    }
    private async Task SetupAsync(List<IAsyncSystemSetup> asyncSetups, CancellationToken cancellationToken)
    {
        if(asyncSetups.Count == 0)
        {
            logger.LogTrace("No async setup to run, exiting fast");
            return;
        }

        Stopwatch asyncSW = Stopwatch.StartNew();
        logger.LogTrace("Starting running of ({count}) async setup tasks", asyncSetups.Count);
        await Task.WhenAll(asyncSetups.Select(setup => setup.Run(cancellationToken)));
        asyncSW.Stop();
        logger.LogInformation("Finished ({count}) async setup tasks in {elapsed} (including sync setups)", asyncSetups.Count, asyncSW.Elapsed);
    }
}