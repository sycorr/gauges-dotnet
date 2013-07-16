using System;
using System.Net.Http;

namespace Gauges
{
    public interface IEncodable
    {
        FormUrlEncodedContent AsFormUrlEncodedContent();
    }
}