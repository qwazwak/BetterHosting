using System;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BetterHosting.CommandsNext.Services;

internal class CommandsNextOptionConfigure([FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider rootProvider) : IConfigureOptions<CommandsNextConfiguration>
{
    private readonly IServiceProvider rootProvider = rootProvider;
    public void Configure(CommandsNextConfiguration options) => options.Services = rootProvider;
}