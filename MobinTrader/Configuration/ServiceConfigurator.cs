using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace MobinTrader.Configuration
{
    public class ServiceConfigurator
    {
        public virtual IServiceCollection Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRestClient, RestClient>();
            serviceCollection.AddScoped<IRestRequest,RestRequest>();
            return serviceCollection;
        }
    }
}
