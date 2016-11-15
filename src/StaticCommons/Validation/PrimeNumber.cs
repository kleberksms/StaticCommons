using System;

namespace StaticCommons.Validation
{
    public static class PrimeNumber
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;

            if (number != 2 && (number % 2) == 0) return false;

            for (var i = 3; i <= Math.Ceiling(Math.Sqrt(number)); i += 2)
            {
                if ((number % i) == 0) return false;
            }
            return true;
        }
    }
}
