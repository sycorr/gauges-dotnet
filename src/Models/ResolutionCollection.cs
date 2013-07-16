using System;

namespace Gauges.Models
{
    public class ResolutionCollection
    {
        public Browser_Heights[] browser_heights { get; set; }
        public Screen_Widths[] screen_widths { get; set; }
        public DateTime date { get; set; }
        public Browser_Widths[] browser_widths { get; set; }
        public Urls urls { get; set; }
    }
}