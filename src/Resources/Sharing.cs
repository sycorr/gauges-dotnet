using System;
using System.Collections.Generic;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Helpers;
using Gauges.Models;
using Gauges.Models.SerializationRoots;

namespace Gauges.Resources
{
    public class Sharing
    {
        private readonly string _apiToken;
        private const string GetTemplate = "https://secure.gaug.es/gauges/{0}/shares";
        private const string DeleteTemplate = "https://secure.gaug.es/gauges/{0}/shares/{1}";

        public Sharing(string apiToken)
        {
            _apiToken = apiToken;
        }

        public Share[] ListShares(GaugeQuery gaugeQuery)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = UrlHelper.CreateGaugeQueryUrl(GetTemplate, gaugeQuery);

                HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootShareCollection>().Result;
                return response.shares;
            }
        }

        public Share CreateShare(string gaugeId, string emailAddress)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = String.Format(GetTemplate, gaugeId);
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { "email".ToKvp(emailAddress) });
                HttpResponseMessage httpResponseMessage = client.PostAsync(url, formUrlEncodedContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootShare>().Result;
                return response.share;
            }
        }

        public Share DeleteShare(string gaugeId, string userId)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = String.Format(DeleteTemplate, gaugeId, userId);

                HttpResponseMessage httpResponseMessage = client.DeleteAsync(url).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootShare>().Result;
                return response.share;
            }
        }
    }
}