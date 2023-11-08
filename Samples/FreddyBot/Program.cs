using System;
using FreddyBot.Services;
using FreddyBot.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FreddyBot.Services.Implementation.Database;
using FreddyBot.Services.Extensions;
using DSharpPlus.BetterHosting;
using DSharpPlus;
using DSharpPlus.BetterHosting.EventsNext;
using FreddyBot.Handlers;
using Microsoft.Extensions.Logging;

IHostBuilder builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddLogging(o => o.AddConsole());

    services.AddBetterHosting().AddEventsNext();

    services.AddDefaultActivityByOptions("Default" + nameof(DSharpPlus.Entities.DiscordActivity));

    services.AutoRegisterHandler<AtFreddyHandler>();
    services.AutoRegisterHandler<CreepyHandler>();
    services.AutoRegisterHandler<PHPHandler>();
    services.AutoRegisterHandler<SwearJarHandler>();

    services.AddDiscordConfigurationOption(nameof(DiscordConfiguration)).Configure(o =>
    {
        o.Intents =
        /*DiscordIntents.Guilds |*/ DiscordIntents.GuildMembers /* | DiscordIntents.GuildBans */ | DiscordIntents.GuildEmojisAndStickers | DiscordIntents.GuildIntegrations /* | DiscordIntents.GuildWebhooks | DiscordIntents.GuildInvites |  DiscordIntents.ScheduledGuildEvents */ | DiscordIntents.GuildVoiceStates | DiscordIntents.GuildPresences | DiscordIntents.GuildMessages | DiscordIntents.GuildMessageReactions | DiscordIntents.GuildMessageTyping
        | DiscordIntents.DirectMessages | DiscordIntents.DirectMessageReactions | DiscordIntents.DirectMessageTyping
        | DiscordIntents.MessageContents;
    });

    services.AddHttpClient();

    services.AddTransient<SystemSetupRunner>();
    services.AddTransient<ISystemSetup, DBFileSetup<SwearJarContext>>();
    services.AddTransient<ISystemSetup, DBFileSetup<BadPasswordContext>>();

    services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

    AddDbContext<SwearJarContext>(services, connectionStringName: null);

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