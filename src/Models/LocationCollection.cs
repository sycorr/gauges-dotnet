using System;

namespace Gauges.Models
{
    public class LocationCollection
    {
        public DateTime date { get; set; }
        public Location[] locations { get; set; }
        public Urls urls { get; set; }
    }
}