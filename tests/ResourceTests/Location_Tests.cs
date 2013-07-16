using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Location_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Current_Date_For_No_Locations()
        {
            //Arrange
            var service = new Locations(ConfigureContext.ApiKey);

            //Act
            LocationCollection locationCollection = service.GetLocations(_generatedGauge.id);

            //Assert
            locationCollection.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}