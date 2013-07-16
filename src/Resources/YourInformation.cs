using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Gauges.Extensions;
using Gauges.Models;
using Gauges.Models.SerializationRoots;

namespace Gauges.Resources
{
    public class YourInformation : ResourceBase
    {
        public YourInformation(string apiToken, string address = "https://secure.gaug.es/me")
            : base(apiToken, address)
        {

        }

        public User GetAccountInformation()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(base.BaseAddress).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootUser>().Result;
                return response.user;
            }
        }

        public User UpdateAccountInformation(string first_name, string last_name)
        {
            using (var client = CreateClient())
            {
                var nameValueCollection = new List<KeyValuePair<string, string>>();

                if (!string.IsNullOrWhiteSpace(first_name))
                    nameValueCollection.Add("first_name".ToKvp(first_name));

                if (!string.IsNullOrWhiteSpace(last_name))
                    nameValueCollection.Add("last_name".ToKvp(last_name));

                if (!nameValueCollection.Any())
                    return new User();

                var formUrlEncodedContent = new FormUrlEncodedContent(nameValueCollection);

                HttpResponseMessage httpResponseMessage = client.PutAsync(base.BaseAddress, formUrlEncodedContent).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<RootUser>().Result;
                return response.user;
            }
        }
    }
}