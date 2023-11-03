using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting;
using DSharpPlus.BetterHosting.SlashCommands;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(s =>
    {
        s.AddBetterHosting();
        s.AddSlashCommands();
        s.RegisterSlashCommands(typeof(Program).Assembly);
    })
    .Build()
    .RunAsync();