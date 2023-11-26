using System.Linq;
using BetterHosting.EventsNext.Services;

namespace UnitTests.BetterHosting.EventsNext;

public static partial class HandlerTypesTestData
{
    public static class Mocks
    {
        public static readonly IDiscordEventHandler[] SpecificHandlerInterfaces = HandlerTypesTestData.SpecificHandlerInterfaces.Select(MockTools.CreateMockObject).Cast<IDiscordEventHandler>().ToArray();
    }
}
