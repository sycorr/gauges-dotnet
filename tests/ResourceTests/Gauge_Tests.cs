using System;
using System.Linq;
using Gauges;
using Gauges.Models;
using Gauges_dotnet.tests.Support;
using Ploeh.AutoFixture;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Gauge_Tests : ConfigureContext
    {
        /// <summary>
        /// This test exercies the Gauge resource.  It does this all in a single test with multple assertions.  This is because this is an intergration test.
        /// </summary>
        [Fact]
        public void Should_Create_List__Update_Delete_Gauge()
        {
            // Create test
            //Arrange
            var service = new Gauges.Resources.Gauges(ApiKey);
            var fixture = new Fixture();
            var newTitle = fixture.Create("Title");
            var updatedTitle = "Updated " + newTitle;

            var newGaugeModel = new NewGauge { title = newTitle, tz = TimeZones.Eastern_Time_US_Canada, Hosts = new[] { "http://www.example.com" } };

            //Act
            Gauge newGauge = service.CreateGauge(newGaugeModel);

            //Assert
            newGauge.title.ShouldEqual(newGaugeModel.title, StringComparer.OrdinalIgnoreCase);

            // Get collection test
            //Arrange

            //Act
            Gauge[] gaugeCollection = service.GetGauges();

            //Assert
            gaugeCollection.ShouldContain(gaugeCollection.FirstOrDefault(x => x.title.Equals(newGaugeModel.title, StringComparison.OrdinalIgnoreCase)));

            // Get instance test
            //Arrange
            string id = gaugeCollection.First().id;

            //Act
            Gauge gauge = service.GetGauge(id);

            //Assert
            gauge.id.ShouldEqual(id);

            //Arrange
            UpdateGauge updateGaugeModel = new UpdateGauge { id = newGauge.id, title = updatedTitle, tz = newGauge.tz, Hosts = newGaugeModel.Hosts };

            //Act
            Gauge updatedGauge = service.UpdateGauge(updateGaugeModel);

            //Assert
            updatedGauge.title.ShouldEqual(updatedTitle);

            // Delete Test
            //Arrange

            //Act
            Gauge deletedGauge = service.DeleteGauge(newGauge.id);

            //Assert
            deletedGauge.id.ShouldEqual(newGauge.id);
        }

    }
}