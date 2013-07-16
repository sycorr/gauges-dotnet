using System;

namespace Gauges.Models
{
    public class ReferrerCollection
    {
        public Referrer[] referrers { get; set; }
        public DateTime date { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Urls urls { get; set; }
    }
}