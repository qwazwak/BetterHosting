using System;
using FreddyBot.Services;
using FreddyBot.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FreddyBot.Services.Extensions;
using DSharpPlus.BetterHosting;
using DSharpPlus;
using DSharpPlus.BetterHosting.EventsNext;
using FreddyBot.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting.Internal;
using FreddyBot.Options;
using DSharpPlus.BetterHosting.SlashCommands;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(ConfigureServices)
    .ConfigureServices(s => s.AddSingleton<IHostLifetime, ConsoleLifetime>())
    .Build()
    .RunAsync();

static void ConfigureServices(IServiceCollection services)
{
    services
        .AddLogging(o => o.AddConsole())
        .AddHttpClient();

    services.AddBetterHosting().AddEventsNext().AddSlashCommands();

    services.RegisterSlashCommands();

    services.AddDefaultActivityByOptions("DefaultDiscordActivity");

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

    services.AddTransient<IConnectionStringsProvider, ConnectionStringsProvider>();
    services.AddTransient<IHostLifetime, DBFileSetup<FreddyDbContext>>();

    services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.

    AddDbContext<FreddyDbContext>(services, connectionStringName: "FreddyDB");

    services.AddTransient<ISwearJar, DbSwearJar>();

    services.AddScoped<IProfanityDetector, SimpleSwearDetector>();

    services.AddScoped<ISentimentAnalyzer, ApiNinja>();
    services.AddScoped<IPasswordGenerator, ApiNinja>();

    services.AddOptions<SwearList>().BindConfiguration("Swears");
}

static void AddDbContext<TContext>(IServiceCollection services, string? connectionStringName) where TContext : DbContext
{
    services.AddDbContext<TContext>((IServiceProvider provider, DbContextOptionsBuilder optBuilder) =>
    {
        IConnectionStringsProvider connStringProvider = provider.GetRequiredService<IConnectionStringsProvider>();
        optBuilder.UseSqlite(connStringProvider.GetRequired(connectionStringName));
    });
}