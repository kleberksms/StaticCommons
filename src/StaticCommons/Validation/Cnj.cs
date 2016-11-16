using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StaticCommons.Validation
{
    public static class Cnj
    {
        static Cnj(){}
        public static bool IsValid(string cnj)
        {
            var regex = new Regex("[^0-9]");
            cnj = regex.Replace(cnj, "");

            if (cnj.Length < 20)
            {
                cnj = cnj.PadLeft(20, Convert.ToChar("0"));
            }

            var result = (98 - (Convert.ToDecimal($"{cnj.Remove(7, 2)}00") % 97)).ToString(CultureInfo.CurrentCulture);

            if (result.Length.Equals(1))
            {
                result = $"0{result}";
            }

            return cnj.Equals(cnj.Remove(7, 2).Insert(7, result));
        }
    }
}
