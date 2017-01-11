using System;
using System.Linq;
using System.Net;
using System.Reflection;

namespace StaticCommons.Filter.String
{
    public static class Transform
    {
        public static string ToTitleCase(this string str)
        {
            var tokens = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1);
            }

            return string.Join(" ", tokens);
        }

        public static string GetQueryString(this object obj)
        {
            var properties =
                obj.GetType()
                    .GetProperties()
                    .Where(p => p.GetValue(obj, null) != null)
                    .Select(p => p.Name.ToLower() + "=" + WebUtility.HtmlEncode(p.GetValue(obj, null).ToString()));

            return string.Join("&", properties.ToArray());
        }
    }
}
