namespace StaticCommons.Validation
{
    public static class Numeric
    {
        public static bool StringIsAnNumber(string input)
        {
            int value;
            long value64;
            return int.TryParse(input, out value) || long.TryParse(input, out value64);
        }
    }
}
