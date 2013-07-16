using System;
using System.Linq;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Shares_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        /// <summary>
        /// This test exercies the Share resource.  It does this all in a single test with multple assertions.  This is because this is an intergration test.
        /// </summary>
        [Fact]
        public void Should_Create_List_Delete_Share()
        {
            // Create Test
            //Arrange
            var service = new Sharing(ApiKey);

            //Act
            Share newShare = service.CreateShare(_generatedGauge.id, WellKnownEmailAddress);

            //Assert
            newShare.id.ShouldNotBeEmpty();

            //List Test
            //Arrange
            var gaugeQuery = new GaugeQuery { id = _generatedGauge.id };

            //Act
            Share[] shares = service.ListShares(gaugeQuery);

            //Assert
            shares.FirstOrDefault(x => x.email.Equals(WellKnownEmailAddress)).ShouldNotBeNull();

            //Delete Test
            //Arrange

            //Act
            Share deletedShare = service.DeleteShare(_generatedGauge.id, newShare.id);

            //Assert
            deletedShare.id.ShouldNotBeEmpty();
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}