using System;
using System.Collections.Specialized;
using System.Web;
using Gauges.Helpers;
using Gauges.Models;
using Ploeh.AutoFixture;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.HelperTests
{
    public class UrlHelper_Tests
    {
        [Fact]
        public void Should_Throw_With_Empty_Url()
        {
            //Arrange
            string url = string.Empty;

            //Act + Assert
            Exception ex = Assert.Throws<ArgumentException>(() => UrlHelper.CreateGaugeQueryUrl(url, null));
        }

        [Fact]
        public void Should_Throw_With_Null_Query()
        {
            //Arrange
            string url = "http://www.example.com/{0}";

            //Act + Assert
            Exception ex = Assert.Throws<ArgumentException>(() => UrlHelper.CreateGaugeQueryUrl(url, null));
        }

        [Fact]
        public void Should_Throw_With_Missing_Gauge_Id()
        {
            //Arrange
            string url = "http://www.example.com/{0}";
            GaugeQuery gaugeQuery = new GaugeQuery();

            //Act + Assert
            Exception ex = Assert.Throws<ArgumentException>(() => UrlHelper.CreateGaugeQueryUrl(url, gaugeQuery));
        }

        [Fact]
        public void Should_Return_Gauge_Url()
        {
            //Arrange
            Fixture fixture = new Fixture();
            string url = "https://www.example.com/{0}";
            GaugeQuery gaugeQuery = new GaugeQuery { id = fixture.Create("id") };

            //Act
            string gaugeQueryUrl = UrlHelper.CreateGaugeQueryUrl(url, gaugeQuery);

            //Assert
            gaugeQueryUrl.ShouldContain(gaugeQuery.id);
        }

        [Fact]
        public void Should_Return_Gauge_Url_With_Date()
        {
            //Arrange
            Fixture fixture = new Fixture();
            string url = "https://www.example.com/{0}/someresource";
            GaugeQuery gaugeQuery = new GaugeQuery { id = fixture.Create("id"), date = fixture.Create<DateTime>() };

            //Act
            string gaugeQueryUrl = UrlHelper.CreateGaugeQueryUrl(url, gaugeQuery);
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(new Uri(gaugeQueryUrl).Query);

            //Assert
            nameValueCollection.AllKeys.ShouldContain("date");
        }

        [Fact]
        public void Should_Return_Gauge_Url_With_Page()
        {
            //Arrange
            Fixture fixture = new Fixture();
            string url = "https://www.example.com/{0}/someresource";
            GaugeQuery gaugeQuery = new GaugeQuery { id = fixture.Create("id"), page = fixture.Create<int?>() };

            //Act
            string gaugeQueryUrl = UrlHelper.CreateGaugeQueryUrl(url, gaugeQuery);
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(new Uri(gaugeQueryUrl).Query);

            //Assert
            nameValueCollection.AllKeys.ShouldContain("page");
        }
    }
}