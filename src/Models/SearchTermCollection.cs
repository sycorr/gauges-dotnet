using System;

namespace Gauges.Models
{
    public class SearchTermCollection
    {
        public DateTime date { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Term[] terms { get; set; }
        public Urls urls { get; set; }
    }
}