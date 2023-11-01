#if true
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.EventHandling;
using Microsoft.Extensions.Configuration;
using Moq;

namespace UnitTests.DSharpPlus.BetterHosting.Interactivity;

[TestFixture(TestOf = typeof(InteractivityConfigurationBinder))]
[TestFixtureSource(typeof(InteractivityConfigurationBinderTestSources), nameof(InteractivityConfigurationBinderTestSources.FixtureArgs))]
public class InteractivityConfigurationBinderTests
{
    public readonly IConfiguration configurationRoot;
    public readonly InteractivityConfiguration ExpectedConfiguration;

    public InteractivityConfigurationBinderTests(InteractivityConfiguration expectedConfiguration)
    {
        ExpectedConfiguration = expectedConfiguration;
        configurationRoot = new ConfigurationBuilder().AddInMemoryCollection(InteractivityConfigurationTestDataFormatter.ToKVPs(expectedConfiguration).Where(v => v.Value != null)!).Build();
        /*string text = @"{""Logging"":{""LogLevel"":{""Default"":""Information"",""Microsoft.AspNetCore"":""Warning"",""System.Net.Http.HttpClient.Default"":""Warning""}},""AllowedHosts"":""*"",""CommandsNextConfiguration"":{""StringPrefixes"":[""!"",""/""]},""LavalinkConfiguration"":{""SocketAutoReconnect"":true,""Password"":""youshallnotpass"",""ResumeTimeoutSeconds"":60,""WebSocketCloseTimeoutMilliseconds"":3000,""RestEndpoint"":{""Hostname"":""127.0.0.1"",""Port"":2333,""Secured"":false},""SocketEndpoint"":{""Hostname"":""127.0.0.1"",""Port"":2333,""Secured"":false}},""DiscordConfiguration"":{""Token"":""your token here"",""TokenType"":""Bot"",""UseRelativeRatelimit"":true,""LogTimestampFormat"":""yyyy-MM-dd HH:mm:ss zzz"",""LargeThreshold"":6969,""ReconnectIndefinitely"":true,""AutoReconnect"":true,""ShardId"":0,""ShardCount"":1,""GatewayCompressionLevel"":""Stream"",""MessageCacheSize"":1024,""HttpTimeout"":""0:00:30"",""AlwaysCacheMembers"":true,""LogUnknownEvents"":true,""LogUnknownAuditlogs"":true}}";
        using MemoryStream stream = new();
        using StreamWriter writer = new(stream);
            writer.Write(text);
            writer.Flush();
        stream.Position = 0;
        configurationRoot = new ConfigurationBuilder().AddJsonStream(stream).Build();
        var test  = new ConfigurationBuilder().Add(stream).Build();*/
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConfigureSimple()
    {
        const string optionsKey = "dfyiousdiuf";
        Mock<IConfiguration> mockRoot = new(MockBehavior.Strict);

        //mockRoot.Setup(c => c.GetSection(optionsKey)).Returns(configurationRoot);
        InteractivityConfigurationConverter.Register();
        var b= configurationRoot.GetSection("DiscordConfiguration").Get<DiscordConfiguration>(a => a.BindNonPublicProperties = true);
        var a= configurationRoot.GetValue(typeof(InteractivityConfiguration), "", default(InteractivityConfiguration));
        InteractivityConfiguration result = new();
        InteractivityConfigurationBinder.ConfigureSimple(result, configurationRoot);
        AssertEqualToExpected(result);
    }

    private void AssertEqualToExpected(InteractivityConfiguration actual) => Assert.Multiple(() =>
    {
        Assert.That(actual.GetButtonBehavior(), Is.EqualTo(ExpectedConfiguration.GetButtonBehavior()));
    });
}

public class InteractivityConfigurationBinderTestSources
{
    private static IEnumerable<InteractivityConfiguration> BaseValues()
    {
        yield return new InteractivityConfiguration();
    }

    public static IEnumerable<InteractivityConfiguration> FixtureArgs()
    {
        IEnumerable<InteractivityConfiguration> result = BaseValues();
        foreach (Func<InteractivityConfiguration, IEnumerable<InteractivityConfiguration>> mutator in AllMutators)
            result = result.SelectMany(mutator);
        return result;
    }

    private static readonly Func<InteractivityConfiguration, IEnumerable<InteractivityConfiguration>>[] AllMutators = new Func<InteractivityConfiguration, IEnumerable<InteractivityConfiguration>>[]
    {
        MutatePollBehaviour
    };
    private static readonly PollBehaviour[] pollBehaviours = Enum.GetValues<PollBehaviour>();
    private static IEnumerable<InteractivityConfiguration> MutatePollBehaviour(InteractivityConfiguration basis)
    {
        return pollBehaviours.SelectMany(b => new InteractivityConfiguration[]
        {
            new(basis)
            {
                PollBehaviour = PollBehaviour.KeepEmojis
            },
            new(basis)
            {
                PollBehaviour = PollBehaviour.DeleteEmojis
            }
        });

    }
}

file static class InteractivityConfigurationTestDataFormatter
{
    public static IEnumerable<KeyValuePair<string, string>> ToKVPs(InteractivityConfiguration value)
    {
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.Timeout), value.GetTimeout().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.PollBehaviour), value.GetPollBehaviour().ToString());
        foreach (KeyValuePair<string, string> innerKvp in ToKVPs(value.GetPaginationEmojis()))
            yield return KeyValuePair.Create(nameof(InteractivityConfiguration.PaginationEmojis) + ":" +  innerKvp.Key, innerKvp.Value);
        //yield return KeyValuePair.Create(nameof(InteractivityConfiguration.PaginationButtons), value.GetPaginationButtons().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.ButtonBehavior), value.GetButtonBehavior().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.PaginationBehaviour), value.GetPaginationBehaviour().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.PaginationDeletion), value.GetPaginationDeletion().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.ResponseBehavior), value.GetResponseBehavior().ToString());
        yield return KeyValuePair.Create(nameof(InteractivityConfiguration.ResponseMessage), value.GetResponseMessage()?.ToString()!);
    }
    public static IEnumerable<KeyValuePair<string, string>> ToKVPs(PaginationEmojis value)
    {
        yield return KeyValuePair.Create(nameof(PaginationEmojis.SkipLeft), value.SkipLeft.Name);
        yield return KeyValuePair.Create(nameof(PaginationEmojis.SkipRight), value.SkipRight.Name);
        yield return KeyValuePair.Create(nameof(PaginationEmojis.Left), value.Left.Name);
        yield return KeyValuePair.Create(nameof(PaginationEmojis.Right), value.Right.Name);
        yield return KeyValuePair.Create(nameof(PaginationEmojis.Stop), value.Stop.Name);
    }

    public static string ToJson(string rootName, InteractivityConfiguration value) =>
@$" ""{nameof(InteractivityConfiguration.PaginationEmojis)}"": {{
	      ""{nameof(PaginationEmojis.SkipLeft)}"": ""{value.GetPaginationEmojis().SkipLeft.Name}"",
	      ""{nameof(PaginationEmojis.SkipRight)}"": ""{value.GetPaginationEmojis().SkipRight.Name}"",
	      ""{nameof(PaginationEmojis.Left)}"": ""{value.GetPaginationEmojis().Left.Name}"",
	      ""{nameof(PaginationEmojis.Right)}"": ""{value.GetPaginationEmojis().Right.Name}"",
	      ""{nameof(PaginationEmojis.Stop)}"": ""{value.GetPaginationEmojis().Stop.Name}"",
    }}
}}";
    public static string ToJson(PaginationEmojis value) =>
@$"""{nameof(InteractivityConfiguration.PaginationEmojis)}"": {{
	  ""{nameof(PaginationEmojis.SkipLeft)}"": ""{value.SkipLeft.Name}"",
	  ""{nameof(PaginationEmojis.SkipRight)}"": ""{value.SkipRight.Name}"",
	  ""{nameof(PaginationEmojis.Left)}"": ""{value.Left.Name}"",
	  ""{nameof(PaginationEmojis.Right)}"": ""{value.Right.Name}"",
	  ""{nameof(PaginationEmojis.Stop)}"": ""{value.Stop.Name}"",
}}";
}
file static class InteractivityConfigurationReflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.Timeout)}")]
    public extern static TimeSpan GetTimeout(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.PollBehaviour)}")]
    public extern static PollBehaviour GetPollBehaviour(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.PaginationEmojis)}")]
    public extern static PaginationEmojis GetPaginationEmojis(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.PaginationButtons)}")]
    public extern static PaginationButtons GetPaginationButtons(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.ButtonBehavior)}")]
    public extern static ButtonPaginationBehavior GetButtonBehavior(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.PaginationBehaviour)}")]
    public extern static PaginationBehaviour GetPaginationBehaviour(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.PaginationDeletion)}")]
    public extern static PaginationDeletion GetPaginationDeletion(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.ResponseBehavior)}")]
    public extern static InteractionResponseBehavior GetResponseBehavior(this InteractivityConfiguration @this);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(InteractivityConfiguration.ResponseMessage)}")]
    public extern static string GetResponseMessage(this InteractivityConfiguration @this);
}
#endif