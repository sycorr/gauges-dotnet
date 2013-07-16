using System;

namespace Gauges.Models
{
    public class TechnologyCollection
    {
        public Browser[] browsers { get; set; }
        public Platform[] platforms { get; set; }
        public DateTime date { get; set; }
        public Urls urls { get; set; }
    }
}