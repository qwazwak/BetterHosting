using DSharpPlus.BetterHosting.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace DSharpPlus.BetterHosting.Barriers;

public static partial class ServiceCollectionExtensions
{
    public static void AddBarrier(this IHostBuilder builder, object key) => builder.ConfigureServices(s => s.AddBarrier(key));

    public static void AddBarrier(this IServiceCollection services, object key)
    {
        services.AddKeyedSingleton<IBarrierManager, BarrierManager>(key);
        services.AddKeyedTransient<IBarrierProvider>(key, (sp, key) => sp.GetRequiredKeyedService<IBarrierManager>(key));
        services.AddKeyedTransient(key, (sp, key) => sp.GetRequiredKeyedService<IBarrierProvider>(key).GetBarrier());
    }
}