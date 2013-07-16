using System;

namespace Gauges.Models
{
    public class GaugeQuery
    {
        public string id { get; set; }
        public DateTime? date { get; set; }
        public int? page { get; set; }
    }
}