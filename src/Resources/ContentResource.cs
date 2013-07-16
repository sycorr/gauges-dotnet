using System;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Helpers;
using Gauges.Models;
using Gauges.Models.SerializationRoots;

namespace Gauges.Resources
{
    public class ContentResource
    {
        private readonly string _apiToken;

        private const string GetTemplate = "https://secure.gaug.es/gauges/{0}/content";

        public ContentResource(string apiToken)
        {
            _apiToken = apiToken;
        }

        public ContentCollection GetContentList(GaugeQuery gaugeQuery)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = UrlHelper.CreateGaugeQueryUrl(GetTemplate, gaugeQuery);

                HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootContent>().Result;
                return new ContentCollection { Content = response.content, page = response.page, date = DateTime.Parse(response.date), per_page = response.per_page, urls = response.urls };
            }
        }
    }
}