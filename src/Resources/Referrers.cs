using System;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Helpers;
using Gauges.Models;

namespace Gauges.Resources
{
    public class Referrers
    {
        private readonly string _apiToken;
        private const string GetTemplate = "https://secure.gaug.es/gauges/{0}/referrers";
        public Referrers(string apiToken)
        {
            _apiToken = apiToken;
        }

        public ReferrerCollection GetReferrers(GaugeQuery gaugeQuery)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = UrlHelper.CreateGaugeQueryUrl(GetTemplate, gaugeQuery);

                HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<ReferrerCollection>().Result;
                return new ReferrerCollection { referrers = response.referrers, page = response.page, date = response.date, per_page = response.per_page, urls = response.urls };
            }
        }
    }
}