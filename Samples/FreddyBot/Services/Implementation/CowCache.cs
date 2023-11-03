using System.Threading.Tasks;
using Cowsay.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FreddyBot.Services.Implementation;
public interface ICowCache
{
    ValueTask<ICow> GetCow(string? name);
}

public sealed class CowCache
{
    private readonly ILogger<CowCache> logger;
    private readonly ICattleFarmer cattleFarmer;
    private readonly IMemoryCache cache;

    public CowCache(ILogger<CowCache> logger, ICattleFarmer cattleFarmer, IMemoryCache cache)
    {
        this.logger = logger;
        this.cattleFarmer = cattleFarmer;
        this.cache = cache;
    }

    public ValueTask<ICow> GetCow(string? name)
    {
        return new(cache.GetOrCreate(name ?? "default", entry =>
        {
            logger.LogInformation("loading cow {cowName}", entry);
            return cattleFarmer.RearCowAsync((string)entry.Key);
        })!);
    }
}
