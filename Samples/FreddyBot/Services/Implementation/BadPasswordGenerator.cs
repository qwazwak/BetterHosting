using System;
using System.Threading.Tasks;
using FreddyBot.Data.Tables;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace FreddyBot.Services.Implementation;

public class BadPasswordGenerator : IPasswordGenerator
{
    private readonly ILogger<BadPasswordGenerator> logger;
    private readonly FreddyDbContext context;

    public BadPasswordGenerator(ILogger<BadPasswordGenerator> logger, FreddyDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    ValueTask<string> IPasswordGenerator.GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars) => new(GeneratePassword(CancellationToken.None));
    public async Task<string> GeneratePassword(CancellationToken cancellationToken)
    {
        BadPassword? result = await context.BadPasswords.OrderBy(_ => EF.Functions.Random()).FirstOrDefaultAsync(cancellationToken);

        if(result == null)
            ThrowNoPasswords();

        return result.Password;
    }

    [DoesNotReturn]
    private void ThrowNoPasswords()
    {
        const string message = "No passwords exist, cannot give one!";
        InvalidOperationException ex = new(message);
        logger.LogError(ex, message);
        throw ex;
    }
}