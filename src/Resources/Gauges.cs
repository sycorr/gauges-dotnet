using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Helpers;
using Gauges.Models;
using Gauges.Models.SerializationRoots;

namespace Gauges.Resources
{
    public class Gauges : ResourceBase
    {
        public Gauges(string apiToken, string address = "https://secure.gaug.es/gauges")
            : base(apiToken, address)
        {

        }

        public Gauge[] GetGauges()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(base.BaseAddress).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootGaugeCollection>().Result;
                return response.gauges;
            }
        }

        public Gauge GetGauge(string id)
        {
            using (var client = CreateClient())
            {
                string uri = Path.Combine(base.BaseAddress, id);
                HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootGauge>().Result;
                return response.gauge;
            }
        }

        public Gauge CreateGauge(NewGauge newGauge)
        {
            using (var client = CreateClient())
            {
                var collection = new CollectionBuilder();
                collection.Add("title".ToKvp(newGauge.title));
                collection.Add("tz".ToKvp(newGauge.tz));
                if (newGauge.Hosts != null && newGauge.Hosts.Any())
                    collection.Add("allowed_hosts".ToKvp(string.Join(",", newGauge.Hosts)));

                HttpContent content = collection.AsFormUrlEncodedContent();

                HttpResponseMessage httpResponseMessage = client.PostAsync(base.BaseAddress, content).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootGauge>().Result;
                return response.gauge;
            }
        }

        public Gauge DeleteGauge(string id)
        {
            using (var client = CreateClient())
            {
                string uri = Path.Combine(base.BaseAddress, id);
                HttpResponseMessage httpResponseMessage = client.DeleteAsync(uri).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootGauge>().Result;
                return response.gauge;
            }
        }

        public Gauge UpdateGauge(UpdateGauge gauge)
        {
            var collection = new CollectionBuilder();
            collection.Add("title".ToKvp(gauge.title));
            collection.Add("tz".ToKvp(gauge.tz));
            if (gauge.Hosts != null && gauge.Hosts.Any())
                collection.Add("allowed_hosts".ToKvp(string.Join(",", gauge.Hosts)));

            HttpContent content = collection.AsFormUrlEncodedContent();

            using (var client = CreateClient())
            {
                string uri = Path.Combine(base.BaseAddress, gauge.id);
                HttpResponseMessage httpResponseMessage = client.PutAsync(uri, content).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootGauge>().Result;
                return response.gauge;
            }
        }
    }
}