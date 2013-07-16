using System;
using System.Linq;
using System.Net.Http;
using Gauges.Extensions;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.HelperTests
{
    public class HttpClientExtensions_Tests
    {
        private const string GaugesAuthHeader = "X-Gauges-Token";

        [Fact]
        public void Should_Throw_With_No_API_Key()
        {
            //Arrange
            string apiToken = string.Empty;

            //Act + Assert
            Exception ex = Assert.Throws<ArgumentException>(() => apiToken.AsGaugesHttpClient());
        }

        [Fact]
        public void Should_Create_Gauges_Token_Header()
        {
            //Arrange
            string apiToken = Guid.NewGuid().ToString();

            //Act
            HttpClient httpClient = apiToken.AsGaugesHttpClient();

            //Assert
            httpClient.DefaultRequestHeaders.Any(x => x.Key.Equals(GaugesAuthHeader)).ShouldBeTrue();
        }

        [Fact]
        public void Should_Set_Gauges_Token_Header_Value()
        {
            //Arrange
            string apiToken = Guid.NewGuid().ToString();

            //Act
            HttpClient httpClient = apiToken.AsGaugesHttpClient();

            //Assert
            httpClient.DefaultRequestHeaders.Single(x => x.Key.Equals(GaugesAuthHeader)).Value.Any(x => x.Equals(apiToken)).ShouldBeTrue();
        }
    }
}