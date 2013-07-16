using System;
using System.Net.Http;

namespace Gauges.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient AsGaugesHttpClient(this string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("invalid api key", apiKey);

            var handler = new WebRequestHandler { AllowAutoRedirect = true, UseProxy = true };
            var client = new HttpClient(handler) { BaseAddress = new Uri("https://secure.gaug.es") };
            client.DefaultRequestHeaders.Add("X-Gauges-Token", apiKey);
            return client;
        }
    }
}