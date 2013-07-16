using System;
using System.Linq;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Ploeh.AutoFixture;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Client_Tests : ConfigureContext
    {
        /// <summary>
        /// This test exercies the Client resource.  It does this all in a single test with multple assertions.  This is because this is an intergration test.
        /// </summary>
        [Fact]
        public void Should_Create_List_Delete_Client()
        {
            //Create Test
            //Arrange
            var service = new ApiClient(ApiKey);
            var fixture = new Fixture();
            var description = fixture.Create("Description");

            //Act
            Client newClient = service.CreateApiClient(description);

            //Assert
            newClient.description.ShouldEqual(description);
            
            //Act
            Client[] clientCollection = service.GetApiClients();

            //Get Test
            //Assert
            Assert.True(clientCollection.Select(x => x.key).Any(x => x == ApiKey));

            //Delete Test
            //Act
            Client deletedClient = service.DeleteApiClient(newClient.key);

            //Assert
            deletedClient.key.ShouldEqual(newClient.key);
        }
    }
}