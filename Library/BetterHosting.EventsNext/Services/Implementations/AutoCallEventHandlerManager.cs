using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using BetterHosting.Services;
using BetterHosting.EventsNext.Tools;
using System;
using DSharpPlus;

namespace BetterHosting.EventsNext.Services.Implementations;

internal class AutoCallEventHandlerManager<TInterface, TArgument> : EventHandlerManager<TInterface, TArgument>
    where TInterface : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    public AutoCallEventHandlerManager(ILogger<AutoCallEventHandlerManager<TInterface, TArgument>> logger, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider, IHandlerProvider<TInterface> registrations) : base(logger, provider, registrations) { }

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    protected override void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) => AutoEventHandlerAdapter<TInterface, TArgument>.BindHandler(client, handler);

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    protected override void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) => AutoEventHandlerAdapter<TInterface, TArgument>.UnbindHandler(client, handler);

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    protected override ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument eventArg) => AutoEventHandlerAdapter<TInterface, TArgument>.Invoke(handler, sender, eventArg);
}
