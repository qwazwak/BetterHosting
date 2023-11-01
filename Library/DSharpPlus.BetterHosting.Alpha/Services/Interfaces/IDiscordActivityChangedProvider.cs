using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IDiscordActivityChangedProvider
{
    public event ActivityChangedHandler ActivityChanged;
}

public interface IDiscordActivityChanger
{
    ValueTask SetActivity(DiscordActivity activity);
    ValueTask SetActivity(UserStatus userStatus);
    ValueTask SetActivity(DateTimeOffset idleSince);
    ValueTask SetActivity(DiscordActivity activity, UserStatus userStatus);
    ValueTask SetActivity(DiscordActivity activity, DateTimeOffset idleSince);
    ValueTask SetActivity(UserStatus userStatus, DateTimeOffset idleSince);
    ValueTask SetActivity(DiscordActivity activity, UserStatus userStatus, DateTimeOffset idleSince);
}

public delegate Task ActivityChangedHandler(IDiscordActivityChangedProvider sender, DiscordActivityChangedArgs args);

internal sealed class DiscordActivityChanger : IDiscordActivityChanger, IDiscordActivityChangedProvider
{
    private readonly ILogger<DiscordActivityChanger> logger;

    public DiscordActivityChanger(ILogger<DiscordActivityChanger> logger)
    {
        this.logger = logger;
    }

    public event ActivityChangedHandler ActivityChanged = default!;
    private ActivityChangedHandler[]? ActivityChangedHandlers => (ActivityChangedHandler[]?)(ActivityChanged?.GetInvocationList());

    public ValueTask SetActivity(DiscordActivity activity) => ChangeActivity(new(activity));
    public ValueTask SetActivity(UserStatus userStatus) => ChangeActivity(new(userStatus));
    public ValueTask SetActivity(DateTimeOffset idleSince) => ChangeActivity(new(idleSince));
    public ValueTask SetActivity(DiscordActivity activity, UserStatus userStatus) => ChangeActivity(new(activity, userStatus));
    public ValueTask SetActivity(DiscordActivity activity, DateTimeOffset idleSince) => ChangeActivity(new(activity, idleSince));
    public ValueTask SetActivity(UserStatus userStatus, DateTimeOffset idleSince) => ChangeActivity(new(userStatus, idleSince));
    public ValueTask SetActivity(DiscordActivity activity, UserStatus userStatus, DateTimeOffset idleSince) => ChangeActivity(new(activity, userStatus, idleSince));

    private ValueTask ChangeActivity(DiscordActivityChangedArgs activity) => OnActivityChanged(activity);

    private ValueTask OnActivityChanged(DiscordActivityChangedArgs args)
    {
        Debug.Assert(args != null);

        ActivityChangedHandler[]? handlers = ActivityChangedHandlers;
        if (handlers == null || handlers.Length == 0)
            return ValueTask.CompletedTask;

        Task whenAll = Task.Factory.StartNew(async () =>
        {
            try
            {
                await Task.WhenAll(handlers.Select(handler => handler.Invoke(this, args)));
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, $"Unexpected exception ({{exceptionType}}) from {nameof(ActivityChangedHandler)}: {{message}} ", ex.GetType(), ex.Message);
                throw;
            }
        }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap();

        return new(whenAll);
    }
}

public class DiscordActivityChangedArgs : DiscordEventArgs
{
    public DiscordActivity? Activity { get; }
    public UserStatus? UserStatus { get; }
    public DateTimeOffset? IdleSince { get; }

    public DiscordActivityChangedArgs(DiscordActivity activity)
    {
        ArgumentNullException.ThrowIfNull(activity);
        Activity = activity;
    }

    public DiscordActivityChangedArgs(UserStatus userStatus)
    {
        UserStatus = userStatus;
    }

    public DiscordActivityChangedArgs(DateTimeOffset idleSince)
    {
        IdleSince = idleSince;
    }
    public DiscordActivityChangedArgs(DiscordActivity activity, UserStatus userStatus) : this(activity)
    {
        UserStatus = userStatus;
    }
    public DiscordActivityChangedArgs(DiscordActivity activity, DateTimeOffset idleSince) : this(activity)
    {
        ArgumentNullException.ThrowIfNull(activity);
        Activity = activity;
        IdleSince = idleSince;
    }
    public DiscordActivityChangedArgs(UserStatus userStatus, DateTimeOffset idleSince)
    {
        UserStatus = userStatus;
        IdleSince = idleSince;
    }

    public DiscordActivityChangedArgs(DiscordActivity activity, UserStatus userStatus, DateTimeOffset idleSince) : this(activity ?? throw new ArgumentNullException(nameof(activity)), (UserStatus?)userStatus, (DateTimeOffset?)idleSince) { }

    private DiscordActivityChangedArgs(DiscordActivity? activity, UserStatus? userStatus, DateTimeOffset? idleSince)
    {
        Debug.Assert(activity != null || userStatus != null || idleSince != null);

        Activity = activity;
        UserStatus = userStatus;
        IdleSince = idleSince;
    }
}