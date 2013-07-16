using System;

namespace Gauges.Models
{
    public class Client
    {
        public DateTime created_at { get; set; }
        public Urls urls { get; set; }
        public string description { get; set; }
        public string key { get; set; }
    }
}