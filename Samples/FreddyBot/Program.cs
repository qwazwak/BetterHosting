using System;
using FreddyBot.Services;
using FreddyBot.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FreddyBot.Services.Extensions;
using BetterHosting;
using DSharpPlus;
using BetterHosting.EventsNext;
using FreddyBot.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting.Internal;
using FreddyBot.Options;
using BetterHosting.SlashCommands;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ConfigureServices)
    .ConfigureServices(s => s.AddSingleton<IHostLifetime, ConsoleLifetime>());

IHost host = builder.Build();
await host.RunAsync();

static void ConfigureServices(IServiceCollection services)
{
    services
        .AddLogging(o => o.AddConsole())
        .AddHttpClient();

    services.AddBetterHosting().AddEventsNext().AddSlashCommands().RegisterSlashCommands();

    services.AddDefaultActivityByOptions("DefaultDiscordActivity");

    services.AddMessageCreatedHandlers()
        .RegisterHandler<SusHandler>()
        .RegisterHandler<SusImageHandler>()
        .RegisterHandler<AtFreddyHandler>();

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

    services.AddSingleton(Random.Shared); // We're using the shared instance of Random for simplicity.
    services.AddTransient<SusHelper>();
    services.AddSingleton<SusPredictor>();

    services.AddScoped<IProfanityDetector, SimpleSwearDetector>();
     services.AddScoped<ISentimentAnalyzer, ApiNinja>();
    services.AddScoped<IPasswordGenerator, ApiNinja>();

    services.AddTransient<ISwearJar, DbSwearJar>();

    services.AddTransient<IHostLifetime, DBFileSetup>();
    services.AddDbContext<FreddyDbContext>((IServiceProvider provider, DbContextOptionsBuilder optBuilder) => optBuilder.UseSqlite(provider.GetRequiredService<IConnectionStringsProvider>().GetRequired("FreddyDB")));

    services.AddOptions<SwearList>().BindConfiguration("Swears");
}