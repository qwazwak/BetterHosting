using System;
using System.Collections.Concurrent;

namespace UnitTestHelpers;

public static class MockTools
{
    private static readonly ConcurrentDictionary<Type, Type> mockTypeCache = new();

    public static object CreateMockObject(Type type) => CreateMock(type).Object;
    public static Mock CreateMock(Type type)
    {
        Type creator = mockTypeCache.GetOrAdd(type, t => typeof(Mock<>).MakeGenericType(t));

        try
        {
            return (Mock)Activator.CreateInstance(creator)!;
        }
        catch (Exception ex)
        {
            Assert.Inconclusive($"Unable to create mock for {type.Name}: ({ex.GetType().Name}) {ex.Message}");
            return default!;
        }
    }
}
