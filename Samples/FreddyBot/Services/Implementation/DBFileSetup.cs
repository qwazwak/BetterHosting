using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Services.Implementation;

public class DBFileSetup<TContext> : ISystemSetup where TContext : DbContext
{
    private readonly ILogger<DBFileSetup<TContext>> logger;
    private readonly TContext context;

    public DBFileSetup(ILogger<DBFileSetup<TContext>> logger, TContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task Run(CancellationToken cancellationToken)
    {
        if(await context.Database.EnsureCreatedAsync(cancellationToken))
            logger.LogInformation("Created DB file for {ContextName}", typeof(TContext).Name);
        else
            logger.LogDebug("DB file for {ContextName} already existed", typeof(TContext).Name);
    }
}