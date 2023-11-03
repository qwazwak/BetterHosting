#if false
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.Tools.AsyncEventBlock;

[DebuggerDisplay("Signaled: {IsSet}")]
internal sealed partial class OneTimeAsyncEvent
{
    public partial void SetOpen() => SetCore(LockState.SetOpen, transition: tcs => tcs.TrySetResult());
    private partial string ToString_PreLocked() => $"state: {state}";
}
#endif