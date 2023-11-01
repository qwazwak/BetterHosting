using System;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands.Services.Implementation;

internal class SlashCommandsOptionsConfiguration : IConfigureOptions<SlashCommandsConfiguration>
{
    private readonly IServiceProvider rootProvider;

    public SlashCommandsOptionsConfiguration([FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider rootProvider) => this.rootProvider = rootProvider;

    public void Configure(SlashCommandsConfiguration options) => options.Services = rootProvider;
}