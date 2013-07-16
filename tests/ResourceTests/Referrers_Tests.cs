using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Xunit;
using Should;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Referrers_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Current_Date_For_No_Referrers()
        {
            //Arrange
            var service = new Referrers(ApiKey);
            var gaugeQuery = new GaugeQuery { id = _generatedGauge.id };

            //Act
            ReferrerCollection referrers = service.GetReferrers(gaugeQuery);

            //Assert
            referrers.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}