namespace StaticCommons.Http.Smtp
{
    public class EmailContent
    {
        public Connect Connect { get; set; }
        public To To { get; set; }
        public From From { get; set; }
        public Content Content { get; set; }
    }
}