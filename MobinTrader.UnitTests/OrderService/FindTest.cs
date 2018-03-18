using System.Threading.Tasks;
using MobinTrader.Models;
using MobinTrader.ResultModels;
using MobinTrader.UnitTests.Setup;
using Moq;
using RestSharp;
using Xunit;

namespace MobinTrader.UnitTests.OrderService
{
    public class FindTest
    {
        [Fact]
        public async Task Should_SetGetMethodOnRequest()
        {
            //Arrange
            MockServiceConfigurator mocks = SetupMock();

            //Act
            var order = new MobinTrader.OrderService(mocks);
            var result = await order.Find(new GetOrderData(), "Token");

            //Assert
            Assert.Equal(Method.GET, mocks.MockRequest.Object.Method);
            Assert.Equal("Order", mocks.MockRequest.Object.Resource);

        }

        private static MockServiceConfigurator SetupMock()
        {
            var mocks = new MockServiceConfigurator();
            mocks.MockRestClient.SetupAllProperties();
            mocks.MockRequest.SetupAllProperties();
            mocks.MockRestClient.Setup(x => x.
                ExecuteTaskAsync<OrderListResult>(It.IsAny<IRestRequest>()))
                .ReturnsAsync(new RestResponse<OrderListResult>()
                { Data = new OrderListResult() { IsSuccessful = true } });
            return mocks;
        }

    }
}
