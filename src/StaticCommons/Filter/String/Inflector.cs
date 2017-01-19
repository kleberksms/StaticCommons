using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StaticCommons.Filter.String
{
    public static class Inflector
    {
        static Inflector(){}
        public static string Slugfy(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string Excerpt(this string phrase, int length = 150, string ommission = "...")
        {
            if (phrase == null || phrase.Length < length)
                return phrase;
            var iNextSpace = phrase.LastIndexOf(" ", length, StringComparison.Ordinal);
            return $"{phrase.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim()}{ommission}";
        }

        public static string OnlyNumbers(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var rgx = new Regex("[^0-9]");
            var result = rgx.Replace(input, "");
            return result;
        }

        public static string OnlyAlphanumerics(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var rgx = new Regex("[^A-Za-z0-9]");
            var result = rgx.Replace(input, "");
            return result;
        }

        public static string GetBetween(string strSource, string strStart, string strEnd, bool inclusive = false)
        {
            if (!strSource.Contains(strStart) || !strSource.Contains(strEnd)) return string.Empty;

            var start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
            var end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
            if (start < 0) return string.Empty;
            if (end < 0) return string.Empty;
            if (inclusive)
            {
                return strStart + strSource.Substring(start, end - start) + strEnd;
            }
            return strSource.Substring(start, end - start).Trim();
        }
    }
}
