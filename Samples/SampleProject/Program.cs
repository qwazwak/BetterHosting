using Microsoft.Extensions.Hosting;
using BetterHosting;
using BetterHosting.SlashCommands;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(s =>
    {
        s.AddBetterHosting();
        s.AddSlashCommands();
        s.RegisterSlashCommands(typeof(Program).Assembly);
    })
    .Build()
    .RunAsync();