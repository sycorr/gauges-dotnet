using System;
using System.Data;
using Gauges;
using Gauges.Models;
using Ploeh.AutoFixture;

namespace Gauges_dotnet.tests.Support
{
    /// <summary>
    /// This Fixture will generate and tear down a temp. gauge
    /// </summary>
    public class ThatCreatesTempGauge : ConfigureContext, IDisposable
    {
        protected internal Gauge GeneratedGauge;
        protected internal string[] RequestedHosts;
        protected internal string RequestedTitle;
        protected internal string RequestedTimeZone;
        private readonly Gauges.Resources.Gauges _service;

        public ThatCreatesTempGauge()
        {
            var fixture = new Fixture();
            _service = new Gauges.Resources.Gauges(ConfigureContext.ApiKey);

            RequestedHosts = new[] { "http://www.example.com" };
            RequestedTitle = fixture.Create("Name");
            RequestedTimeZone = TimeZones.Eastern_Time_US_Canada;

            var newGauge = new NewGauge { Hosts = RequestedHosts, title = RequestedTitle, tz = RequestedTimeZone };
            GeneratedGauge = _service.CreateGauge(newGauge);
        }

        public void Dispose()
        {
            var deleteGauge = _service.DeleteGauge(GeneratedGauge.id);
            if (deleteGauge.id != GeneratedGauge.id)
            {
                var generatedGaugeUrl = string.Format("https://secure.gaug.es/dashboard#/gauges/{0}/settings", GeneratedGauge.id);
                throw new DataException(string.Format("Could not clean up generated gauge please visit {0} and remove it manually", generatedGaugeUrl));
            }
        }
    }
}