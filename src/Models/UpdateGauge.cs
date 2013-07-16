using System;

namespace Gauges.Models
{
    public class UpdateGauge
    {
        public string id { get; set; }
        public string title { get; set; }
        public string tz { get; set; }
        public string[] Hosts { get; set; }
    }
}