﻿using System;
using System.Threading;

namespace DSharpPlus.BetterHosting.Services.Interfaces.Internal;

internal interface IClientManager : IConnectedClientProvider
{
    void SetConnected(DiscordShardedClient client);
    void SetFailed(Exception exception);
    void SetCancelled(CancellationToken reason = default);
}