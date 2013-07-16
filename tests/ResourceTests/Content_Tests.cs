using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Content_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Current_Date_For_No_Content_Items()
        {
            //Arrange
            var service = new ContentResource(ApiKey);
            var contentQuery = new GaugeQuery { id = _generatedGauge.id };

            //Act
            ContentCollection content = service.GetContentList(contentQuery);

            //Assert
            content.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}