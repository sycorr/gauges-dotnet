using System;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Models;

namespace Gauges.Resources
{
    public class Resolutions
    {
        private readonly string _apiToken;
        private const string GetTemplate = "https://secure.gaug.es/gauges/{0}/resolutions";
        public Resolutions(string apiToken)
        {
            _apiToken = apiToken;
        }

        public ResolutionCollection GetResolutions(string gaugeId)
        {
            using (var client = _apiToken.AsGaugesHttpClient())
            {
                var url = String.Format(GetTemplate, gaugeId);

                HttpResponseMessage httpResponseMessage = client.GetAsync(url).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<ResolutionCollection>().Result;
                return response;
            }
        }
    }
}