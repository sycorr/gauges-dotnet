using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Search_Engine_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Current_Date_For_Search_Engines()
        {
            //Arrange
            var service = new SearchEngines(ConfigureContext.ApiKey);

            //Act
            SearchEngineCollection searchEngineCollection = service.GetSearchEngines(_generatedGauge.id);

            //Assert
            searchEngineCollection.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}