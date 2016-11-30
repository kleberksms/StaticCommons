using System.Collections.Generic;
using System.Linq;

namespace StaticCommons.Enum
{
    public static class Through
    {
        public static IEnumerable<T> Values<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
