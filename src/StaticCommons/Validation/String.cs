using System;
using System.Linq;
using System.Text.RegularExpressions;
using StaticCommons.Filter.String;

namespace StaticCommons.Validation
{
    public static class String
    {
        public static bool IsTextMatches(string text, string data, string source)
        {
            var result = false;
            foreach (var s in text.Slugfy().Split(new[] { "-" }, StringSplitOptions.None))
            {
                if (Regex.Matches(s, data).Any())
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
