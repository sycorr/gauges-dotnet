using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Models;
using Gauges.Models.SerializationRoots;

namespace Gauges.Resources
{
    public class ApiClient : ResourceBase
    {
        public ApiClient(string apiToken, string address = "https://secure.gaug.es/clients")
            : base(apiToken, address)
        {

        }

        public Client[] GetApiClients()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(base.BaseAddress).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootClientCollection>().Result;
                return response.clients;
            }
        }

        public Client CreateApiClient(string description)
        {
            using (var client = CreateClient())
            {
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { "description".ToKvp(description) });
                HttpResponseMessage httpResponseMessage = client.PostAsync(base.BaseAddress, formUrlEncodedContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootClient>().Result;
                return response.client;
            }
        }

        public Client DeleteApiClient(string id)
        {
            using (var client = CreateClient())
            {
                string uri = Path.Combine(base.BaseAddress, id);
                HttpResponseMessage httpResponseMessage = client.DeleteAsync(uri).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootClient>().Result;
                return response.client;
            }
        }
    }
}

