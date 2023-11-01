using System.Threading;

namespace DSharpPlus.BetterHosting.Tools.AsyncEventBlock;

/// <summary>
/// A flavor of <see cref="ManualResetEvent"/> that can be asynchronously awaited on.
/// </summary>
internal sealed partial class OneTimeAsyncEvent<T>
{
    private T? value;

    public partial void SetOpen(T value) => SetCore(LockState.SetOpen, transition: tcs => tcs.TrySetResult(value), value: value);

    /// <summary>
    /// Without the weight of asyncronous blocking, quickly checks if the event is completed.
    /// </summary>
    /// <param name="value"></param>
    public bool TryGetNow(out T value)
    {
        lock (syncObject)
        {
            if (PreLockedIsCompletedSuccessfully)
            {
                value = this.value!;
                return true;
            }
        }
        value = default!;
        return false;
    }

    private partial string ToString_PreLocked()
    {
        string valueByState = state == LockState.SetOpen ? value?.ToString() ?? "null" : "<not available>";
        return $"state: {state}, value: {valueByState}";
    }
}
