using System;
using System.ComponentModel;
using System.Reflection;

namespace StaticCommons.Validation
{
    public static class Enum
    {
        public static bool ExistFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return true;
                }
                else
                {
                    if (field.Name == description)
                        return true;
                }
            }
            return false;
        }
    }
}
