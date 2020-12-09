using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public struct EnumApi
{
    public object Id { get; set; }
    public string Key { get; set; }
    public string DisplayName { get; set; }
}

namespace EKadry.Domain
{
    public static class EnumHelper<T>
        where T : struct, Enum // This constraint requires C# 7.3 or later.
    {
        public static IList GetValues(Type value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T) Enum.Parse(value, fi.Name, false));
            }

            return enumValues;
        }

        public static IList<EnumApi> GetMaps(Type value)
        {
            var enumValues = new List<EnumApi>();

            foreach (var fi in value.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add(new EnumApi
                {
                    Id = Enum.Parse(value, fi.Name, false),
                    Key = fi.Name,
                    DisplayName = (fi.GetCustomAttribute(typeof(DisplayAttribute), false) as DisplayAttribute).Name,
                });
            }

            return enumValues;
        }

        public static EnumApi GetMap(Enum enumValue)
        {
            return new EnumApi
            {
                Id = enumValue,
                Key = enumValue.ToString(),
                DisplayName = (enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttribute(typeof(DisplayAttribute), false) as DisplayAttribute).Name,
            };
        }

        public static T Parse(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Type value)
        {
            return value.GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Type value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager) staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}