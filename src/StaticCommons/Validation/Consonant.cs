using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class Consonant
    {
        static Consonant(){}
        public static bool IsConsonant(string c)
        {
            if (c.Length > 1)
            {
                throw new Exception("Use IsSetOfConsonants");
            }
            var regex = new Regex(@"[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z]");
            return regex.IsMatch(c);
        }

        public static bool IsSetOfConsonants(string c)
        {
            var regex = new Regex(@"^(\s|[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z])*$");
            return regex.IsMatch(c);
        }

        public static bool ContainsConsonant(string c)
        {
            var constains = false;
            var regex = new Regex(@"[b-df-hj-np-tv-zB-DF-HJ-NP-TV-Z]");
            foreach (var c2 in c.Where(c2 => regex.IsMatch(c2.ToString())))
            {
                constains = true;
            }

            return constains;
        }
    }
}
