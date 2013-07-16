using System;
using Gauges.Models.SerializationRoots;

namespace Gauges.Models
{
    public class ContentCollection
    {
        public DateTime date { get; set; }
        public int page { get; set; }
        public Content[] Content { get; set; }
        public int per_page { get; set; }
        public Urls urls { get; set; }
    }
}