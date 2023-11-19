﻿using System.Threading.Tasks;
using FreddyBot.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Services.Implementation;

public class DbSwearJar : ISwearJar
{
    private readonly ILogger<DbSwearJar> logger;
    private readonly FreddyDbContext db;
    private DbSet<SwearJar> SwearJars => db.SwearJars;

    public DbSwearJar(ILogger<DbSwearJar> logger, FreddyDbContext db)
    {
        this.logger = logger;
        this.db = db;
    }

    public async Task<decimal> GetSwearCount(ulong guildID) => (await GetJar(guildID)).SwearCount;

    public async Task SetSingleSwearValue(ulong guildID, decimal value)
    {
        SwearJar jar = await GetJar(guildID);
        if (jar.ValueOfSingleSwear != value)
        {
            logger.LogInformation("Replacing swear value of {old} with {new}", jar.ValueOfSingleSwear, value);
            jar.ValueOfSingleSwear = value;
            await db.SaveChangesAsync();
        }
    }

    public Task IncrementJar(ulong guildID) => IncrementJar(guildID, 1);
    public async Task IncrementJar(ulong guildID, int incrementSize)
    {
        using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = await db.Database.BeginTransactionAsync();
        System.Data.Common.DbCommand cmd = SwearJars.CreateDbCommand();
        SwearJar? jar = await SwearJars.FindAsync(guildID);
        if (jar == null)
        {
            jar = new() { GuildID = guildID };
            SwearJars.Add(jar);
        }
        jar.SwearCount += incrementSize;

        await db.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task<decimal> GetSingleSwearValue(ulong guildID) => (await GetJar(guildID)).ValueOfSingleSwear;
    public async Task<decimal> GetCurrentValue(ulong guildID) => (await GetJar(guildID)).CurrentJarValue;

    private Task<SwearJar> GetJar(ulong guildID) => GetOrCreateJar(guildID);

    private async Task<SwearJar> GetOrCreateJar(ulong guildID)
    {
        SwearJar resultJar;
        using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = await db.Database.BeginTransactionAsync();
        System.Data.Common.DbCommand cmd = SwearJars.CreateDbCommand();
        SwearJar? existingJar = await SwearJars.FindAsync(guildID);
        if (existingJar != null)
        {
            resultJar = existingJar;
        }
        else
        {
            resultJar = new() { GuildID = guildID };
            SwearJars.Add(resultJar);
            await db.SaveChangesAsync();
        }

        await transaction.CommitAsync();
        return resultJar;
    }
}