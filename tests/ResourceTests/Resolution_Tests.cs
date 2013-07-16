using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Resolution_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Some_Resolution_Items_For_Current_Month()
        {
            //Arrange
            var service = new Resolutions(ConfigureContext.ApiKey);

            //Act
            ResolutionCollection resolutionCollection = service.GetResolutions(_generatedGauge.id);

            //Assert
            resolutionCollection.screen_widths.Length.ShouldBeGreaterThan(0);
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}