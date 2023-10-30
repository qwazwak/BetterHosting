using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting;
using DSharpPlus.BetterHosting.Lavalink;
using DSharpPlus.BetterHosting.SlashCommands;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(s =>
    {
        s.AddBetterHosting()
         .AddLavalink()
         .RegisterCommands(typeof(Program).Assembly);
    })
    .Build()
    .RunAsync();