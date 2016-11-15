using System;
using System.ComponentModel;
using System.Reflection;

namespace StaticCommons.Enum
{
    public static class Inflector
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
