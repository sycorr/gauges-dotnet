using System;
using Gauges;
using Gauges.Models;
using Gauges.Resources;
using Gauges_dotnet.tests.Support;
using Should;
using Xunit;

namespace Gauges_dotnet.tests.ResourceTests
{
    public class Your_Information_Tests : ConfigureContext
    {
        [Fact]
        public void Should_List_Update_Account_Information()
        {
            // Get test
            //Arrange
            var service = new YourInformation(ApiKey);

            //Act
            User user = service.GetAccountInformation();

            //Assert
            user.name.ShouldNotBeEmpty();

            // Update test
            //Arrange
            var expectedUserName = string.Format("{0} {1}", user.first_name, user.last_name).Trim();

            //Act
            User updatedUser = service.UpdateAccountInformation(user.first_name, user.last_name);

            //Assert
            updatedUser.name.ShouldEqual(expectedUserName, StringComparer.OrdinalIgnoreCase);
        }
    }
}