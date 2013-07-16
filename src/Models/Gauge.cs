using System;
using System.Net.Http;
using Gauges.Helpers;

namespace Gauges.Models
{
    public class Gauge : IEncodable
    {
        public string id { get; set; }
        public string title { get; set; }
        public string tz { get; set; }
        public DateTime? now_in_zone { get; set; }
        public bool? enabled { get; set; }
        public string creator_id { get; set; }
        public Urls urls { get; set; }
        public All_Time all_time { get; set; }
        public Today today { get; set; }
        public Yesterday yesterday { get; set; }
        public Recent_Hours[] recent_hours { get; set; }
        public Recent_Months[] recent_months { get; set; }
        public Recent_Days[] recent_days { get; set; }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            FormUrlEncodedContent asFormUrlEncodedContent = this.AsFormUrlEncodedContent<Gauge>();
            return asFormUrlEncodedContent;
        }
    }
}