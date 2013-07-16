using System;
using System.Net.Http;

namespace Gauges.Resources
{
    public abstract class ResourceBase
    {
        protected string ApiKey { get; set; }
        protected string BaseAddress { get; private set; }

        protected ResourceBase(string apiToken, string url)
        {
            ApiKey = apiToken;
            BaseAddress = url;
        }
        
        protected T ExecutePost<T, TR>(TR model, string apiUri) where TR : IEncodable
        {
            using (var client = CreateClient())
            {
                HttpContent content = model.AsFormUrlEncodedContent();

                HttpResponseMessage httpResponseMessage = client.PostAsync(apiUri, content).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<T>().Result;
                return response;
            }
        }

        protected T ExecutePost<T>(string apiUri)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage httpResponseMessage = client.PostAsync(apiUri, null).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<T>().Result;
                return response;
            }
        }

        protected HttpClient CreateClient()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("invalid api key", ApiKey);

            var handler = new WebRequestHandler { AllowAutoRedirect = true, UseProxy = true };
            var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) };
            client.DefaultRequestHeaders.Add("X-Gauges-Token", ApiKey);
            return client;
        }
    }
}
