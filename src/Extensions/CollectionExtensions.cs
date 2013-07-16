using System;
using System.Collections.Generic;

namespace Gauges.Extensions
{
    internal static class CollectionExtensions
    {
        public static KeyValuePair<string, string> ToKvp(this string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
        public static KeyValuePair<string, string> ToKvp(this string key, decimal value)
        {
            return new KeyValuePair<string, string>(key, value.ToString());
        }
    }
}