using System;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands;

public static partial class BetterHostingCommandsNextExtensions
{
    public static IServiceCollection AddCommandsNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddTransient<IConfigureOptions<CommandsNextConfiguration>, CommandsNextOptionConfigure>();
        services.TryAddTransient<ICommandsNextConfigurator, HandlerAdder>();

        services.AddTransient<IDiscordClientConfigurator, CommandsNextSetup>();
        return services;
    }
}
#if false
/// <summary>
/// Provides a type converter to convert globally unique identifier objects to and from various
/// other representations.
/// </summary>

public abstract class ConfigurationConverter<TConfiguration> : TypeConverter
{
    /// <summary>
    /// Gets a value indicating whether this converter can convert an object in the given source
    /// type to a globally unique identifier object using the context.
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    /// <summary>
    /// Gets a value indicating whether this converter can convert an object to
    /// the given destination type using the context.
    /// </summary>
    public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
    {
        return false;
        //            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Converts the given object to a globally unique identifier object.
    /// </summary>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string text)
        {
            if (text == null)
                return null;
            else
                return ConvertFrom(context, culture, value);
        }

        return base.ConvertFrom(context, culture, value);
    }

    public abstract TConfiguration ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, string value);

    public abstract TConfiguration BuildToDictionary(ITypeDescriptorContext? context, CultureInfo? culture, string value);

    /// <summary>
    /// Converts the given object to another type. The most common types to convert
    /// are to and from a string object. The default implementation will make a call
    /// to ToString on the object if the object is valid and if the destination
    /// type is string. If this cannot convert to the destination type, this will
    /// throw a NotSupportedException.
    /// </summary>
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type? destinationType) => base.ConvertTo(context, culture, value, destinationType);

    //public virtual string ConvertToString(ITypeDescriptorContext? context, CultureInfo? culture, TConfiguration value) { }
}
/*
public class CommandsNextConfigurationConverter : ConfigurationConverter<CommandsNextConfiguration>
{
}*/

#endif