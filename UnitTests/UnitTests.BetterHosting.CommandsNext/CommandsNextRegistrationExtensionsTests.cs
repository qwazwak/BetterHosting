using System;
using BetterHosting.CommandsNext.Internal;
using System.Linq;
using BetterHosting.CommandsNext.Services;
using BetterHosting.SlashCommands;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using UnitTests.BetterHosting.CommandsNext.Stubs;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.BetterHosting.CommandsNext;

[TestFixture(TestOf = typeof(CommandsNextRegistrationExtensions))]
[SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
public class CommandsNextRegistrationExtensionsTests
{
    [Test]
    public void RegisterCommand() => RegisterCommandCore(CommandsNextRegistrationExtensions.RegisterCommand<StubCommandNextModule>);

    [Test]
    public void RegisterCommandByType() => RegisterCommandCore((sp) => CommandsNextRegistrationExtensions.RegisterCommand(sp, typeof(StubCommandNextModule)));
    private static void RegisterCommandCore(Func<IServiceCollection, IServiceCollection> invocation)
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);

        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<StubCommandNextModule>()))
            .Verifiable(Times.Once);
        mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder<StubCommandNextModule>>()))
            .Verifiable(Times.Once);

        IServiceCollection result = invocation.Invoke(mockServices.Object);
        Assert.That(result, Is.SameAs(mockServices.Object));
        mockServices.Verify();
    }

    [Test]
    public void RegisterInvalidCommand() => RegisterInvalidCommandByType(CommandsNextRegistrationExtensions.RegisterCommand<BaseCommandModule>);

    [Test]
    public void RegisterInvalidCommandByType() => RegisterInvalidCommandByType(sp => CommandsNextRegistrationExtensions.RegisterCommand(sp, typeof(BaseCommandModule)));

    private static ArgumentException RegisterInvalidCommandByType(Func<IServiceCollection, IServiceCollection> invocation)
    {
        const string paramName = "type";
        IServiceCollection mockServices = Mock.Of<IServiceCollection>(MockBehavior.Strict);

        ArgumentException ex = Assert.Throws<ArgumentException>(() => invocation.Invoke(mockServices));

        Assert.That(ex.Message, Is.EqualTo($"Command type was not a valid CommandsNext command (Parameter '{paramName}')"));
        return ex;
    }

    [Test]
    public void RegisterCommandByEmptyAssembly()
    {
        IServiceCollection services = Mock.Of<IServiceCollection>();
        FakeAssembly assembly = new(Array.Empty<Type>());
        IServiceCollection returned = CommandsNextRegistrationExtensions.RegisterCommands(services, assembly);

        Assert.Multiple(() =>
        {
            Assert.That(returned, Is.SameAs(services));
            Assert.That(assembly.CalledTimes, Is.EqualTo(1));
        });
    }

    [Test]
    public void RegisterCommandByAssembly() => RegisterCommandByAssembly(new[] { typeof(StubCommandNextModule) }, new[] { typeof(BaseCommandModule), typeof(Match), typeof(object) });
    private static void RegisterCommandByAssembly(Type[] expectedTypes, Type[] otherTypes)
    {
        Mock<IServiceCollection> mockServices = new(MockBehavior.Strict);
        foreach (Type type in expectedTypes)
        {
            Assert.That(HandlerExtractor.IsModuleCandidateType(type), Is.True);
            mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient(type)))
                .Verifiable(Times.Once);
            mockServices.Setup(s => s.Add(ItMore.ServiceDescriptorFrom.SimpleInterface.AddTransient(typeof(ICommandsNextConfigurator), typeof(TypeHandlerAdder<>).MakeGenericType(type))))
                .Verifiable(Times.Once);
        }

        FakeAssembly assembly = new(expectedTypes.Concat(otherTypes).ToArray());
        IServiceCollection returned = CommandsNextRegistrationExtensions.RegisterCommands(mockServices.Object, assembly);

        mockServices.Verify();
        Assert.Multiple(() =>
        {
            Assert.That(returned, Is.SameAs(mockServices.Object));
            Assert.That(assembly.CalledTimes, Is.EqualTo(1));
        });
    }
}

file static class TestData
{
    public static IEnumerable<TestCaseData> AssemblyTypesWrapper() => AssemblyTypes().Select(a => new TestCaseData((object)a) { TestName = $"RegisterCommandByAssembly containing \"{string.Join(", ", a.Select(i => i.Name))}\"" });
    public static IEnumerable<Type[]> AssemblyTypes()
    {
        yield return new[] { typeof(StubCommandNextModule) };
    }
}

file class FakeAssembly : Assembly
{
    public int CalledTimes { get; private set; } = 0;
    private readonly Type[] types;
    public FakeAssembly(Type[] types) => this.types = types;

    public override Type[] GetExportedTypes()
    {
        CalledTimes++;
        return types;
    }

    private static object ShouldNotBeCalled()
    {
        Assert.Fail("Should not be called");
        return default!;
    }

    [Obsolete]
    public override string? CodeBase => (string?)ShouldNotBeCalled();

    public override IEnumerable<CustomAttributeData> CustomAttributes => (IEnumerable<CustomAttributeData>)ShouldNotBeCalled();

    public override IEnumerable<TypeInfo> DefinedTypes => (IEnumerable<TypeInfo>)ShouldNotBeCalled();

    public override MethodInfo? EntryPoint => (MethodInfo?)ShouldNotBeCalled();

    [Obsolete]
    public override string EscapedCodeBase => (string)ShouldNotBeCalled();

    public override string? FullName => (string?)ShouldNotBeCalled();

    [Obsolete]
    public override bool GlobalAssemblyCache => (bool)ShouldNotBeCalled();

    public override long HostContext => (long)ShouldNotBeCalled();

    public override string ImageRuntimeVersion => (string)ShouldNotBeCalled();

    public override bool IsCollectible => (bool)ShouldNotBeCalled();

    public override bool IsDynamic => (bool)ShouldNotBeCalled();

    public override string Location => (string)ShouldNotBeCalled();

    public override Module ManifestModule => (Module)ShouldNotBeCalled();

    public override IEnumerable<Module> Modules => (IEnumerable<Module>)ShouldNotBeCalled();

    public override bool ReflectionOnly => (bool)ShouldNotBeCalled();

    public override SecurityRuleSet SecurityRuleSet => (SecurityRuleSet)ShouldNotBeCalled();

    public override event ModuleResolveEventHandler? ModuleResolve
    {
        add => ShouldNotBeCalled();
        remove => ShouldNotBeCalled();
    }

    public override object? CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder? binder, object[]? args, CultureInfo? culture, object[]? activationAttributes) => ShouldNotBeCalled();
    public override bool Equals(object? o) => (bool)ShouldNotBeCalled();
    public override object[] GetCustomAttributes(bool inherit) => (object[])ShouldNotBeCalled();
    public override object[] GetCustomAttributes(Type attributeType, bool inherit) => (object[])ShouldNotBeCalled();
    public override IList<CustomAttributeData> GetCustomAttributesData() => (IList<CustomAttributeData>)ShouldNotBeCalled();
    public override FileStream? GetFile(string name) => (FileStream?)ShouldNotBeCalled();
    public override FileStream[] GetFiles() => (FileStream[])ShouldNotBeCalled();
    public override FileStream[] GetFiles(bool getResourceModules) => (FileStream[])ShouldNotBeCalled();
    public override Type[] GetForwardedTypes() => (Type[])ShouldNotBeCalled();
    public override int GetHashCode() => (int)ShouldNotBeCalled();
    public override Module[] GetLoadedModules(bool getResourceModules) => (Module[])ShouldNotBeCalled();
    public override ManifestResourceInfo? GetManifestResourceInfo(string resourceName) => (ManifestResourceInfo?)ShouldNotBeCalled();
    public override string[] GetManifestResourceNames() => (string[])ShouldNotBeCalled();
    public override Stream? GetManifestResourceStream(string name) => (Stream?)ShouldNotBeCalled();
    public override Stream? GetManifestResourceStream(Type type, string name) => (Stream?)ShouldNotBeCalled();
    public override Module? GetModule(string name) => (Module?)ShouldNotBeCalled();
    public override Module[] GetModules(bool getResourceModules) => (Module[])ShouldNotBeCalled();
    public override AssemblyName GetName() => (AssemblyName)ShouldNotBeCalled();
    public override AssemblyName GetName(bool copiedName) => (AssemblyName)ShouldNotBeCalled();
    [Obsolete]
    public override void GetObjectData(SerializationInfo info, StreamingContext context) => ShouldNotBeCalled();
    public override AssemblyName[] GetReferencedAssemblies() => (AssemblyName[])ShouldNotBeCalled();
    public override Assembly GetSatelliteAssembly(CultureInfo culture) => (Assembly)ShouldNotBeCalled();
    public override Assembly GetSatelliteAssembly(CultureInfo culture, Version? version) => (Assembly)ShouldNotBeCalled();
    public override Type? GetType(string name) => (Type?)ShouldNotBeCalled();
    public override Type? GetType(string name, bool throwOnError) => (Type?)ShouldNotBeCalled();
    public override Type? GetType(string name, bool throwOnError, bool ignoreCase) => (Type?)ShouldNotBeCalled();
    public override Type[] GetTypes() => (Type[])ShouldNotBeCalled();
    public override bool IsDefined(Type attributeType, bool inherit) => (bool)ShouldNotBeCalled();
    public override Module LoadModule(string moduleName, byte[]? rawModule, byte[]? rawSymbolStore) => (Module)ShouldNotBeCalled();
    public override string ToString() => (string)ShouldNotBeCalled();
}