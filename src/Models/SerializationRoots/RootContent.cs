using System;

namespace Gauges.Models.SerializationRoots
{
    internal class RootContent
    {
        public string date { get; set; }
        public int page { get; set; }
        public Content[] content { get; set; }
        public int per_page { get; set; }
        public Urls urls { get; set; }
    }
}