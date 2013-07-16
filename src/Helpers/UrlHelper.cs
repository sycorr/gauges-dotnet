using System;
using System.Web;
using Gauges.Models;

namespace Gauges.Helpers
{
    public static class UrlHelper
    {
        /// <summary>
        /// Utility to convert a .net token string (url) into a gauge query
        /// </summary>
        /// <param name="urlTemplate">url containing a .net token string</param>
        /// <param name="gaugeQuery">query object with a required gauge id</param>
        /// <returns></returns>
        public static string CreateGaugeQueryUrl(string urlTemplate, GaugeQuery gaugeQuery)
        {
            if (string.IsNullOrWhiteSpace(urlTemplate))
                throw new ArgumentException("missung url template");

            if (gaugeQuery == null)
                throw new ArgumentException("missung gauge query");

            if (string.IsNullOrWhiteSpace(gaugeQuery.id))
                throw new ArgumentException("missung gauge id query");

            var builder = new UriBuilder(String.Format(urlTemplate, gaugeQuery.id));
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (gaugeQuery.date.HasValue)
                query["date"] = gaugeQuery.date.GetValueOrDefault().ToString("yyyy-MM-dd");
            if (gaugeQuery.page.HasValue)
                query["page"] = gaugeQuery.page.Value.ToString();
            builder.Query = query.ToString();
            var url = builder.ToString();
            return url;
        }
    }
}