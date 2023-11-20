using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace FreddyBot.Services.Implementation;

public class DBFileSetup : IHostLifetime
{
    private readonly ILogger<DBFileSetup> logger;
    private readonly FreddyDbContext context;

    public DBFileSetup(ILogger<DBFileSetup> logger, FreddyDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task WaitForStartAsync(CancellationToken cancellationToken)
    {
        if(await context.Database.EnsureCreatedAsync(CancellationToken.None))
            logger.LogInformation("Created DB file");
        else
            logger.LogDebug("DB file already existed");
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}