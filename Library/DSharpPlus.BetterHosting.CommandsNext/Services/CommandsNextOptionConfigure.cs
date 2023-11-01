using DSharpPlus.BetterHosting.Services;
using System;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.CommandsNext.Services;

internal class CommandsNextOptionConfigure : IConfigureOptions<CommandsNextConfiguration>
{
    private readonly IServiceProvider rootProvider;

    public CommandsNextOptionConfigure([FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider rootProvider) => this.rootProvider = rootProvider;
    public void Configure(CommandsNextConfiguration options) => options.Services = rootProvider;
}