using System;

namespace Gauges.Models
{
    public class Browser
    {
        public string title { get; set; }
        public int views { get; set; }
        public Version[] versions { get; set; }
        public string key { get; set; }
    }
}