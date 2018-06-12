using System.Collections.Generic;

namespace StaticCommons.Http.Smtp
{
    public class Content
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<string> Attachments { get; set; }
    }
}