using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class NfeAccessKey
    {
        public static bool IsValid(string accessKey)
        {
            var regex = new Regex("[^0-9]");
            var c = regex.Replace(accessKey, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 44)
            {
                return false;
            }

            var w = new int[44];
            var z = 5;
            const int m = 43;
            for (var i = 0; i <= m; ++i)
            {
                z = (i < m) ? (z - 1) == 1 ? 9 : (z - 1) : 0;
                w[i] = z;
            }
            var s = 0;
            const int k = 44;
            for (var i = 0; i < k; ++i)
            {
                s += c[i] * w[i];
            }

            s -= (int)(11 * Convert.ToInt64(Math.Floor(Convert.ToDecimal(s / 11))));
            var v = (s == 0 || s == 1) ? 0 : (11 - s);

            return v.Equals(c[43]);
        }
    }
}
