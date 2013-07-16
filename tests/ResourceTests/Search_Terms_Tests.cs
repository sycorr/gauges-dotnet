using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Search_Terms_Tests : ConfigureContext, IUseFixture<ThatCreatesTempGauge>
    {
        [Fact]
        public void Should_Return_Current_Date_For_No_Referrers()
        {
            //Arrange
            var service = new SearchTerms(ConfigureContext.ApiKey);

            //Act
            SearchTermCollection searchTermCollection = service.GetSearchTerms(_generatedGauge.id);

            //Assert
            searchTermCollection.date.ToString("yyyy-MM-dd").ShouldEqual(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private Gauge _generatedGauge;
        public void SetFixture(ThatCreatesTempGauge data)
        {
            _generatedGauge = data.GeneratedGauge;
        }
    }
}