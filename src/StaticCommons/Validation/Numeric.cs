namespace StaticCommons.Validation
{
    public static class Numeric
    {
        public static bool StringIsAnNumber(string input)
        {
            int value;
            return int.TryParse(input, out value);
        }
    }
}
