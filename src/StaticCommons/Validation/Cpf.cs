using System.Linq;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class Cpf
    {
        static Cpf(){}
        public static bool IsValid(string cpf)
        {
            var regex = new Regex("[^0-9]");
            int[] c = regex.Replace(cpf, "").Select(x => int.Parse(x.ToString())).ToArray();
            if (c.Length != 11)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(new Regex($"/^{c[0]}{11}$/").Match(c.ToString()).ToString())) return false;

            var n = 0;
            var i = 0;
            for (var s = 10; s >= 2;)
            {
                n += c[i++] * s--;
            }
            if (c[9] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            n = 0;
            i = 0;
            for (var s = 11; s >= 2;)
            {
                n += c[i++] * s--;
            }
            if (c[10] != (((n %= 11) < 2) ? 0 : 11 - n)) return false;
            return true;
        }
    }
}
