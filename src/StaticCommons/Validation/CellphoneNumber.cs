using System;

namespace StaticCommons.Validation
{
    public static class CellphoneNumber
    {
        public static bool IsValid(Country country, string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            if (country.Equals(Country.Br))
            {
                return Convert.ToInt32(number.Substring(0, 1)) >= 6;
            }
            return false;
        }
    }

    public enum Country
    {
        Br
    }
}
