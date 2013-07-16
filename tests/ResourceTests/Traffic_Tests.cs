using System;
using Gauges;
using Gauges.Models;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;
using Traffic = Gauges.Resources.Traffic;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Traffic_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Some_Traffic_Items_For_Current_Month()
        {
            //Arrange
            var service = new Traffic(ConfigureContext.ApiKey);

            //Act
            TrafficCollection trafficCollection = service.GetTraffic(_generatedGauge.id);

            //Assert
            trafficCollection.traffic.Length.ShouldBeGreaterThan(0);
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}