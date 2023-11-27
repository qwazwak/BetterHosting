using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DSharpPlus.AsyncEvents;
using BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;
using DSharpPlus;

namespace BetterHosting.EventsNext.Tools;

internal partial class AutoEventHandlerAdapter<TInterface, TArgument>
    where TInterface : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    static AutoEventHandlerAdapter() => EventReflection.Validation.VerifyExactInterface(typeof(TInterface));

    /// <inheritdoc />
    [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
    public static partial void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    /// <inheritdoc />
    [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
    public static partial void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static partial ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument eventArg);

    [DoesNotReturn]
    [Conditional("DEBUG")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    [ExcludeFromCodeCoverage(Justification = "Not possible to cover because static constructor guards this")]
    private static void ThrowInvalid_AlreadyVerified()
    {
        const string message = "Case already handled by the static constructor. The event interface is NOT fully implemented.";
        throw new InvalidOperationException(message);
    }
}