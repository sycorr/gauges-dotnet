using System;
using System.Net.Http;
using Gauges.Extensions;

namespace Gauges.Helpers
{
    public static class FormUrlEncoderHelper
    {
        /// <summary>
        /// Extension to convert a flat object into encoded POST|PUT able content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static FormUrlEncodedContent AsFormUrlEncodedContent<T>(this object instance)
        {
            var collection = new CollectionBuilder();
            var t = typeof(T);
            foreach (var prop in t.GetProperties())
            {
                var propertyValue = prop.GetValue(instance, null);
                if (propertyValue != null)
                    collection.AddRequired(prop.Name.ToKvp(propertyValue.ToString()));
            }
            return collection.AsFormUrlEncodedContent();
        }
    }
}