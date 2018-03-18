using System.Threading.Tasks;
using MobinTrader.ResultModels;
using MobinTrader.UnitTests.Setup;
using Moq;
using RestSharp;
using Xunit;

namespace MobinTrader.UnitTests.AuthenticateService
{
    public class LogoutTest
    {
        [Fact]
        public async Task Should_SetGetRequestToRequest()
        {
            //Arrange
            MockServiceConfigurator mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();
            mocks.MockRequest.SetupAllProperties();
            mocks.MockRestClient.Setup(x => x.
                ExecuteTaskAsync<LogoutResult>(It.IsAny<IRestRequest>()))
                .ReturnsAsync(new RestResponse<LogoutResult>()
                { Data = new LogoutResult() { IsSuccessful = true } });

            //Act
            var auth = new MobinTrader.AuthenticationService(mocks);
            var result = await auth.Logout();

            //Assert
            Assert.Equal(Method.GET, mocks.MockRequest.Object.Method);
            Assert.Equal("APIAUTHENTICATE/SignOut", mocks.MockRequest.Object.Resource);

        }
    }
}
