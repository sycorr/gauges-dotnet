﻿using System;

namespace Gauges.Models
{
    public class NewGauge
    {
        public string title { get; set; }
        public string tz { get; set; }
        public string[] Hosts { get; set; }
    }
}