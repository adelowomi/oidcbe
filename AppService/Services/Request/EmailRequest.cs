using System;
using System.Collections.Generic;

namespace AppService.Services.Request
{
    public class EmailRequest
    {
        public From from { get; set; }
        public string subject { get; set; }
        public List<Content> content { get; set; }
        public List<Personalization> personalizations { get; set; }
    }

    public class From
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class To
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class Personalization
    {
        public List<To> to { get; set; }
    }

    public class Root
    {
        public From from { get; set; }
        public string subject { get; set; }
        public List<Content> content { get; set; }
        public List<Personalization> personalizations { get; set; }
    }
}
