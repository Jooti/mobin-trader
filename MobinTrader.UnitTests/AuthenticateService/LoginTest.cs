using System;
using System.Threading.Tasks;
using MobinTrader.Models;
using MobinTrader.ResultModels;
using MobinTrader.UnitTests.Setup;
using Moq;
using RestSharp;
using Xunit;

namespace MobinTrader.UnitTests.AuthenticateService
{
    public class LoginTest
    {

        [Fact]
        public void Should_SetsABaseUrl()
        {
            //Arrange
            var mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();

            //Act
            var auth = new AuthenticationService(mocks);

            //Assert
            Assert.NotNull(mocks.MockRestClient.Object.BaseUrl);
            Assert.False(string.IsNullOrWhiteSpace(mocks.MockRestClient.Object.BaseUrl.ToString()));
        }

        [Fact]
        public async Task Should_SetPostMethodOnRequestObject_When_UserPassProvided()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            //Act
            var auth = new MobinTrader.AuthenticationService(mocks);
            var result = await auth.Login("user1", "pass1");

            //Assert
            Assert.Equal(Method.POST, mocks.MockRequest.Object.Method);
            Assert.Equal("APIAUTHENTICATE", mocks.MockRequest.Object.Resource);
        }

        [Fact]
        public async Task Should_AddUsernameAndPasswordToRequestBody_When_UserPassProvided()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            LoginData userObject = null;
            mocks.MockRequest.Setup(x => x.AddJsonBody(It.IsAny<LoginData>()))
                .Callback<Object>((arg) => { userObject = (LoginData)arg; });
            string user = "user1";
            string pass = "pass1";

            //Act
            var auth = new MobinTrader.AuthenticationService(mocks);
            var result = await auth.Login(user, pass);

            //Assert
            Assert.Equal(user, userObject.UserName);
            Assert.Equal(pass, userObject.Password);
        }

        [Fact]
        public async Task Should_ThrowException_When_NoUserOrPassProvided()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            string user = "";
            string pass = "pass1";

            //Act and Assert
            var auth = new MobinTrader.AuthenticationService(mocks);
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => auth.Login(user, pass));
        }

        private static MockServiceConfigurator SetupMock()
        {
            var mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();
            mocks.MockRequest.SetupAllProperties();
            mocks.MockRestClient.Setup(x => x.
                ExecuteTaskAsync<LoginResult>(It.IsAny<IRestRequest>()))
                .ReturnsAsync(new RestResponse<LoginResult>()
                { Data = new LoginResult() { IsSuccessful = true } });
            return mocks;
        }
    }
}
