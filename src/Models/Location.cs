using System;

namespace Gauges.Models
{
    public class Location
    {
        public Region[] regions { get; set; }
        public string title { get; set; }
        public int views { get; set; }
        public string key { get; set; }
    }
}