using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Technology_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Some_Resolution_Items_For_Current_Month()
        {
            //Arrange
            var service = new Technology(ConfigureContext.ApiKey);

            //Act
            TechnologyCollection technologyCollection = service.GetTechnology(_generatedGauge.id);

            //Assert
            technologyCollection.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}