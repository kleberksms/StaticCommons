using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Filter.String
{
    public static class Mask
    {
        public static object FirstOrDefaultByText(string mask, string text)
        {
            var regex = new Regex(FormatterRegex(mask),
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant);

            var match = regex.Match(text);

            var result = match.Groups[1].Value;

            return result;
        }

        public static List<string> FindByText(string mask, string text)
        {
            var regex = new Regex(FormatterRegex(mask),
            RegexOptions.Compiled |
            RegexOptions.CultureInvariant);

            var matchs = regex.Matches(text);

            return (from Match match in matchs select match.Value).ToList();
        }

        public static string FormatterRegex(string formatter)
        {
            var regex = string.Empty;
            var countLetter = 1;
            var countNumber = 1;
            var aux = string.Empty;

            foreach (var chars in formatter)
            {
                if (countLetter > 1)
                {
                    if (chars.Equals('A'))
                    {
                        aux = "[A-Za-z]{" + Convert.ToString(countLetter) + "}";
                        countLetter++;
                    }
                    if (!chars.Equals('A'))
                    {
                        countLetter = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (countNumber > 1)
                {
                    if (chars.Equals('0'))
                    {
                        aux = @"\d{" + Convert.ToString(countNumber) + "}";
                        countNumber++;
                    }
                    if (!chars.Equals('0'))
                    {
                        countNumber = 1;
                        regex += aux;
                        aux = string.Empty;
                    }
                }
                if (chars.Equals('A') && countLetter.Equals(1))
                {
                    aux = "[A-Za-z]";
                    countLetter++;
                }
                if (chars.Equals('0') && countNumber.Equals(1))
                {
                    aux = @"\d";
                    countNumber++;
                }
                if (chars.Equals(' '))
                {
                    aux = @"\s+";
                    regex += aux;
                    aux = string.Empty;
                }
                if (!chars.Equals('A') && !chars.Equals('0') && !chars.Equals(' '))
                {
                    aux = @"(\" + chars + ")";
                    regex += aux;
                    aux = string.Empty;
                }
            }
            regex += aux;
            return @"(" + regex + ")";
        }



        public static object AddMask(string mask, string source)
        {
            source = Inflector.OnlyAlphanumerics(source);
            for (var i = 0; i < mask.Length; i++)
            {
                if (i > source.Length)
                {
                    continue;
                }
                if (!mask[i].Equals('A') && !mask[i].Equals('0'))
                {
                    source = source.Insert(i, mask[i].ToString());
                }
            }
            return source;
        }
    }
}
