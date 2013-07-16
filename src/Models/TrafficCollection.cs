using System;

namespace Gauges.Models
{
    public class TrafficCollection
    {
        public DateTime date { get; set; }
        public int views { get; set; }
        public int people { get; set; }
        public Traffic[] traffic { get; set; }
        public Urls urls { get; set; }
    }
}