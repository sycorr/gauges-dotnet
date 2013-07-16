using System;

namespace Gauges.Models
{
    public class SearchEngineCollection
    {
        public DateTime date { get; set; }
        public Engine[] engines { get; set; }
        public Urls urls { get; set; }
    }
}