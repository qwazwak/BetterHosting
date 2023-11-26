using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using BetterHosting.EventsNext.Services;
using BetterHosting.EventsNext.Tools;
using DSharpPlus.EventArgs;
using Moq.AutoMock;

namespace UnitTests.BetterHosting.EventsNext.Tools;

[TestOf(typeof(AutoEventHandlerAdapter<,>))]
[TestFixtureSource(typeof(HandlerTypesTestData), nameof(HandlerTypesTestData.SpecificHandlerInterfacesWithArgumentType))]
public class AutoEventHandlerAdapterTests<TInterface, TArgument>
    where TInterface : class, IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    private static string GetMethodName()
    {
        MethodInfo[] methods = typeof(TInterface).GetMethods();
        Assume.That(methods.Length, Is.EqualTo(1), "Unexpected number of methods found");
        return methods[0].Name;
    }

    [Test]
    public void CallSupportedHandler()
    {
        DiscordClient sender = new(new() { Token = "Fake Token" });
        TArgument argument = ArgumentConstructor<TArgument>.ConstructArgument();
        string methodName = GetMethodName();
        Mock<TInterface> mock = new();
        mock.SetupWithAny<TInterface, ValueTask>(methodName)
            .Returns(ValueTask.CompletedTask)
            .Verifiable(Times.Once);
        ValueTask result = AutoEventHandlerAdapter<TInterface, TArgument>.Invoke(mock.Object, sender, argument);
        Assert.That(result.IsCompletedSuccessfully, Is.True);

        mock.Verify();
        IReadOnlyList<object> calledArguments = mock.Invocations[0].Arguments;
        Assert.Multiple(() =>
        {
            Assert.That(calledArguments[0], Is.SameAs(sender));
            Assert.That(calledArguments[1], Is.SameAs(argument));
        });
    }
}