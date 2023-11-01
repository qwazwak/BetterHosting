using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.CommandsNext.Options;

internal static class ConfigurationBuilderExtensions
{
    public static OptionsBuilder<TOption> BindWorkaround<TOption>(this OptionsBuilder<TOption> builder, string sectionPathName, Action<OptionsBuilderToolOptions<TOption>>? toolOptions = null, Action<TOption, IConfiguration>? manualBinding = null) where TOption : class
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(sectionPathName);
        return builder.Configure<ConfigurationBuilderTools<TOption>, IConfiguration>((o, builder, configuration) =>
        {
            OptionsBuilderToolOptions<TOption> options = new();
            toolOptions?.Invoke(options);

            IConfiguration section = configuration.GetSection(sectionPathName);
            builder.AutoBind(o, section, options);
            manualBinding?.Invoke(o, configuration);
        });
    }

    internal class ConfigurationBuilderTools<T>
    {
        private readonly ILogger logger;
        public ConfigurationBuilderTools(ILogger logger) => this.logger = logger;

        public void AutoBind(T instance, IConfiguration configuration, OptionsBuilderToolOptions<T> options)
        {
            if (options.BindProperties)
                AutoBindProperties(instance, configuration, options);
            if (options.BindFields)
                AutoBindFields(instance, configuration, options);
        }

        private void AutoBindProperties(T instance, IConfiguration configuration, OptionsBuilderToolOptions<T> options)
        {
            AutoBindTemplate(instance, configuration,
                typeof(T).GetProperties(options.PropertyBindingFlags), options.IgnoredProperties,
                p => p.PropertyType, (prop, inst, value) => prop.SetValue(inst, value));
        }

        private void AutoBindFields(T instance, IConfiguration configuration, OptionsBuilderToolOptions<T> options)
        {
            AutoBindTemplate(instance, configuration,
                typeof(T).GetFields(options.FieldBindingFlags), options.IgnoredFields,
                f => f.FieldType, (field, inst, value) => field.SetValue(inst, value));
        }

        private void AutoBindTemplate<TMember>(T instance, IConfiguration configuration, IEnumerable<TMember> allMembers, IEnumerable<TMember> ignoredMembers, Func<TMember, Type> getMemberType, Action<TMember, T, object?> assignToMember) where TMember : MemberInfo
        {
            HashSet<TMember> membersToUse = new(allMembers);
            membersToUse.ExceptWith(ignoredMembers);

            foreach (TMember member in membersToUse)
            {
                try
                {
                    Type memberType = getMemberType(member);
                    object? configurationValue = configuration.GetValue(memberType, member.Name);
                    if (configurationValue == null)
                    {
                        logger.LogDebug("No config value found for {name} under {type}", member.Name, typeof(T).Name);
                        continue;
                    }
                    assignToMember(member, instance, configurationValue);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "There was a problem with the config value {name} under {type}", member.Name, typeof(T).Name);
                    Debug.Fail("No exceptions allowed");
                }
            }
        }
    }
}

internal class OptionsBuilderToolOptions<T>
{
    private const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private readonly HashSet<PropertyInfo> ignoredProperties = new();
    private readonly HashSet<FieldInfo> ignoredFields = new();
    internal IReadOnlySet<PropertyInfo> IgnoredProperties => ignoredProperties;
    internal IReadOnlySet<FieldInfo> IgnoredFields => ignoredFields;

    public string Name { get; set; } = Microsoft.Extensions.Options.Options.DefaultName;

    public bool BindProperties { get; set; } = true;
    public BindingFlags PropertyBindingFlags { get; set; } = DefaultBindingFlags;
    public bool BindFields { get; set; } = true;
    public BindingFlags FieldBindingFlags { get; set; } = DefaultBindingFlags;

    public void IgnoreProperty(string property) => IgnoreProperty(typeof(T).GetProperty(property, PropertyBindingFlags) ?? throw new InvalidOperationException("Property not found"));
    public void IgnoreField(string field) => IgnoreField(typeof(T).GetField(field, FieldBindingFlags) ?? throw new InvalidOperationException("Field not found"));

    public void IgnoreProperty(PropertyInfo property) => ignoredProperties.Add(property);
    public void IgnoreField(FieldInfo field) => ignoredFields.Add(field);
}