using System;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Services.Implementation;

public class HandlerRegistrationTests
{
    [TestCaseSource(typeof(HandlerRegistrationTestData), nameof(HandlerRegistrationTestData.Keys))]
    public void KeyIsSaved(Guid key)
    {
        HandlerRegistration registration = new(key);
        Assert.That(registration.Key, Is.EqualTo(key));
    }

    [TestCaseSource(typeof(HandlerRegistrationTestData), nameof(HandlerRegistrationTestData.Keys))]
    public void KeyHashIsSame(Guid key)
    {
        int expectedHash = key.GetHashCode();
        HandlerRegistration registration = new(key);
        int actualHash = registration.GetHashCode();
        Assert.That(actualHash, Is.EqualTo(expectedHash));
    }

    [TestCaseSource(typeof(HandlerRegistrationTestData), nameof(HandlerRegistrationTestData.Keys))]
    public void Equals(Guid key)
    {
        HandlerRegistration first = new(key);
        HandlerRegistration second = new(key);
        bool result = first.Equals(second);
        Assert.That(result, Is.True);
    }

    [TestCaseSource(typeof(HandlerRegistrationTestData), nameof(HandlerRegistrationTestData.Keys))]
    public void EqualsObject(Guid key)
    {
        HandlerRegistration first = new(key);
        HandlerRegistration second = new(key);
        bool result = first.Equals((object)second);
        Assert.That(result, Is.True);
    }

    [TestCaseSource(typeof(HandlerRegistrationTestData), nameof(HandlerRegistrationTestData.Keys))]
    public void EqualsNullObject(Guid key)
    {
        HandlerRegistration first = new(key);
        bool result = first.Equals(null);
        Assert.That(result, Is.False);
    }
}

file static class HandlerRegistrationTestData
{
    const string Format = "D";

    public static Guid[] Keys { get; } = new[]
    {
        Guid.ParseExact("00000000-0000-0000-0000-000000000000", Format),
        Guid.ParseExact("00000000-DEAD-B00F-BEEF-000000000000", Format),
        Guid.ParseExact("12345678-0000-0000-0000-000000000000", Format),

        Guid.ParseExact("9F0F52EA-F32A-4F37-878B-D146FC00B166", Format),
        Guid.ParseExact("A47A19D6-5B9E-4A4B-97EA-9CA58D5217A2", Format),
        Guid.ParseExact("502E0B6F-CD49-4D76-AF04-7518AD776015", Format),
        Guid.ParseExact("C778F9DA-9C55-4516-87FD-116403BA139A", Format),
        Guid.ParseExact("396158A9-F37A-4636-8825-C3AB3AA228C8", Format),
    };
}