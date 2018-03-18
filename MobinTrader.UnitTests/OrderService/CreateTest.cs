using System;
using System.Threading.Tasks;
using MobinTrader.Models;
using MobinTrader.ResultModels;
using MobinTrader.UnitTests.Setup;
using Moq;
using RestSharp;
using Xunit;

namespace MobinTrader.UnitTests.OrderService
{
    public class CreateTest
    {
        [Fact]
        public void Should_SetBaseUrl()
        {
            //Arrange
            var mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();

            //Act
            var auth = new MobinTrader.OrderService(mocks);

            //Assert
            Assert.NotNull(mocks.MockRestClient.Object.BaseUrl);
            Assert.False(string.IsNullOrWhiteSpace(mocks.MockRestClient.Object.BaseUrl.ToString()));
        }

        [Fact]
        public async Task Should_SetPostMethodToRequest()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            //Act
            var order = new MobinTrader.OrderService(mocks);
            var result = await order.Create(new OrderData(), "Token");

            //Assert
            Assert.Equal(Method.POST, mocks.MockRequest.Object.Method);
            Assert.Equal("Order", mocks.MockRequest.Object.Resource);
        }

        [Fact]
        public async Task Should_SetTokenToRequestHead_When_UserAuthorized()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();
            string tokenString = null;
            mocks.MockRequest.Setup(x => 
                x.AddHeader(It.Is<string>(a=>a.Equals("Authorization")) ,It.IsAny<string>()))
                .Callback<string,string>((arg1,arg2) => { tokenString = arg2; });

            string token = "TheTokenIsHere";
            //Act
            var order = new MobinTrader.OrderService(mocks);
            var result = await order.Create(new OrderData(), token);

            //Assert
            Assert.Equal($"Basic {token}", tokenString);
        }

        [Fact]
        public async Task Should_ThrowException_When_UserUnauthorized()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            //Act & Assert
            var order = new MobinTrader.OrderService(mocks);
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => order.Create(new OrderData(), ""));
        }

        [Fact]
        public async Task Should_ThrowException_When_OrderArgumentIsNull()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            //Act & Assert
            var order = new MobinTrader.OrderService(mocks);
            await Assert.ThrowsAsync<ArgumentNullException>(() => order.Create(null, "test"));
        }

        private static MockServiceConfigurator SetupMock()
        {
            var mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();
            mocks.MockRequest.SetupAllProperties();
            mocks.MockRestClient.Setup(x => x.
                ExecuteTaskAsync<OrderResult>(It.IsAny<IRestRequest>()))
                .ReturnsAsync(new RestResponse<OrderResult>()
                { Data = new OrderResult() { IsSuccessful = true } });
            return mocks;
        }

        [Fact]
        public async Task Should_AddTheInputParameterToRequestBody()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            OrderData data = null;
            mocks.MockRequest.Setup(x => x.AddJsonBody(It.IsAny<OrderData>()))
                .Callback<Object>((arg) => { data = (OrderData)arg; });
            OrderData dataSent = new OrderData();
            //Act
            var order = new MobinTrader.OrderService(mocks);
            var result = await order.Create(dataSent,"Token");

            //Assert
            Assert.Same(dataSent, data);
        }

    }
}
