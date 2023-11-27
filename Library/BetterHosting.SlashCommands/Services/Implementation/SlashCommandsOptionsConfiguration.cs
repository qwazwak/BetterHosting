using System;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BetterHosting.SlashCommands.Services.Implementation;

internal class SlashCommandsOptionsConfiguration : IConfigureOptions<SlashCommandsConfiguration>
{
    private readonly IServiceProvider rootProvider;

    public SlashCommandsOptionsConfiguration([FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider rootProvider) => this.rootProvider = rootProvider;

    public void Configure(SlashCommandsConfiguration options) => options.Services = rootProvider;
}