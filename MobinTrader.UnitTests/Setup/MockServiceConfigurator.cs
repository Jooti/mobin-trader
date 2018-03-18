using Microsoft.Extensions.DependencyInjection;
using MobinTrader.Configuration;
using Moq;
using RestSharp;

namespace MobinTrader.UnitTests.Setup
{
    public class MockServiceConfigurator: ServiceConfigurator
    {
        public Mock<IRestClient> MockRestClient = new Mock<IRestClient>();
        public Mock<IRestRequest> MockRequest = new Mock<IRestRequest>();

        public override IServiceCollection Register(IServiceCollection serviceCollection)
        {
            serviceCollection.Add(new ServiceDescriptor(typeof(IRestClient), MockRestClient.Object));

            serviceCollection.Add(new ServiceDescriptor(typeof(IRestRequest), MockRequest.Object));
            return serviceCollection;
        }
    }
}
