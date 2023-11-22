using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal partial class AutoCallEventHandlerManager<TInterface, TArgument>(ILogger<EventHandlerManager<TInterface, TArgument>> logger, [FromKeyedServices(NamedServices.RootServiceProvider)] IKeyedServiceProvider provider, IHandlerRegistryKeyProvider<TInterface> registrations) : EventHandlerManager<TInterface, TArgument>(logger, provider, registrations)
    where TInterface : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    const string InvalidVerifiedStateMessage = "Case should already handled by the static constructor. The event interface is NOT fully implemented.";

    [DoesNotReturn]
    [Conditional("DEBUG")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    [ExcludeFromCodeCoverage(Justification = "Not possible to cover because static constructor gaurds this")]
    private static void ThrowInvalid_AlreadyVerified() =>
#if RELEASE
        throw new InvalidOperationException(InvalidVerifiedStateMessage);
#else
        Debug.Fail(InvalidVerifiedStateMessage);
#endif

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    protected override partial void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    protected override partial void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    [ExcludeFromCodeCoverage(Justification = "Code is generated and DSharpPlus cant be tested")]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    protected override partial ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument eventArg);
}
