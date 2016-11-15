using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class Cnh
    {
        public static bool IsValid(string cnh)
        {
            var regex = new Regex("[^0-9]");
            var c = regex.Replace(cnh, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 11)
            {
                return false;
            }

            var dsc = 0;
            var j = 9;
            var v = 0;
            for (var i = 0; i < 9; ++i, --j)
            {
                v += c[i] * j;
            }
            var vl1 = v % 11;
            if (vl1 >= 10)
            {
                vl1 = 0;
                dsc = 2;
            }
            j = 1;
            v = 0;
            for (var i = 0; i < 9; ++i, ++j)
            {
                v += c[i] * j;
            }
            var vl2 = ((v % 10) >= 10) ? 0 : (v % 10) - dsc;

            return cnh.Substring(9, 2).Equals($"{vl1}{vl2}");
        }
    }
}
