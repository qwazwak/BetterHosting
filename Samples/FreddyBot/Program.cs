using System;
using FreddyBot.Services.Options;
using FreddyBot.Services;
using FreddyBot.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FreddyBot.Services.Implementation.Database;
using FreddyBot.Services.Extensions;
using DSharpPlus.BetterHosting;

IHostBuilder builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddLogging();

    services.AddOptions();
    services.AddHttpClient();

    services.AddBetterHosting();

    services.AddOptions<DiscordClientOptions>();

    services.AddTransient<SystemSetupRunner>();

    services.AddTransient<ISystemSetup, DBFileSetup>();

    //TODO: services.AddTransient<IDiscordClientConfigurator, ConfigureDiscordClientEvents>();
    services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

    AddDbContext<SwearJarContext>(services, connectionStringName: null);
    //    services.AddEventsNextHandlers(typeof(Program).Assembly);

    static void AddDbContext<TContext>(IServiceCollection services, string? connectionStringName) where TContext : DbContext
    {
        services.AddDbContext<TContext>((IServiceProvider provider, DbContextOptionsBuilder optBuilder) =>
        {
            IConnectionStringsProvider connStringProvider = provider.GetRequiredService<IConnectionStringsProvider>();
            optBuilder.UseSqlite((string)connStringProvider.GetRequired(connectionStringName));
        });
    }

    services.AddTransient<ISwearJar, DbSwearJar>();

    services.AddScoped<IProfanityDetector, SimpleSwearDetector>();

    services.AddScoped<ISentimentAnalyzer, ApiNinja>();
    services.AddScoped<IPasswordGenerator, ApiNinja>();
});

await builder.Build().RunAsync();