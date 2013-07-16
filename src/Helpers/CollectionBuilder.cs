using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Gauges.Helpers
{
    internal class CollectionBuilder
    {
        private readonly List<KeyValuePair<string, string>> _collection = new List<KeyValuePair<string, string>>();

        public CollectionBuilder AddRequired(KeyValuePair<string, string> kvp)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Value))
                _collection.Add(kvp);
            return this;
        }

        public void Add(KeyValuePair<string, string> kvp)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Value))
                _collection.Add(kvp);
        }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(_collection);
        }
    }
}