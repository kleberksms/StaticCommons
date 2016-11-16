using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class Vowel
    {
        static Vowel()
        {
            
        }
        public static bool IsVowel(string v)
        {
            if (v.Length > 1)
            {
                throw new Exception("Use IsSetOfVowels");
            }
            var regex = new Regex(@"[aeiouAEIOU]");
            return regex.IsMatch(v);
        }

        public static bool IsSetOfVowels(string v)
        {
            var regex = new Regex(@"^(\s|[aeiouAEIOU])*$");
            return regex.IsMatch(v);
        }

        public static bool ContainsVowel(string v)
        {
            var constains = false;
            var regex = new Regex(@"[aeiouAEIOU]");
            foreach (var v2 in v.Where(v2 => regex.IsMatch(v2.ToString())))
            {
                constains = true;
            }

            return constains;
        }
    }
}
