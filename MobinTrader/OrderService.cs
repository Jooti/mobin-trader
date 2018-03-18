using Microsoft.Extensions.DependencyInjection;
using MobinTrader.Configuration;
using MobinTrader.Extentions;
using MobinTrader.Models;
using MobinTrader.ResultModels;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MobinTrader
{
    public class OrderService
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private readonly ServiceProvider _service;
        private readonly IRestClient _client;

        public OrderService() : this(new ServiceConfigurator()) { }

        public OrderService(ServiceConfigurator serviceConfigurator)
        {
            serviceConfigurator.Register(_serviceCollection);
            _service = _serviceCollection.BuildServiceProvider();
            _client = _service.GetRequiredService<IRestClient>();
            _client.BaseUrl = Config.GetBaseUrl();
        }

        /// <summary>
        /// Create an order on MobinSB OMS system. 
        /// </summary>
        /// <param name="order">Buy or Sell order</param>
        /// <param name="token">Login token provided by Authentication service is reqired</param>
        /// <returns>OrderResult object which contains OrderId</returns>
        public async Task<OrderResult> Create(OrderData order, string token)
        {
            order = order ?? throw new ArgumentNullException(nameof(order));
            token = token ?? throw new ArgumentNullException(nameof(token));

            var request = _service.GetRequiredService<IRestRequest>();
            request.AddMobinAuthenticateHeader(token);
            request.Method = Method.POST;
            request.Resource = "Order";
            request.AddJsonBody(order);
            var response = await _client.ExecuteTaskAsync<OrderResult>(request);
            return response.Data;
        }

        /// <summary>
        /// Retrieves a collection of Orders from OMS
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="token">Login token provided by Authentication service is reqired</param>
        /// <returns>OrderListResult, a </returns>
        public async Task<OrderListResult> Find(GetOrderData filter, string token)
        {
            filter = filter ?? throw new ArgumentNullException(nameof(filter));
            token = token ?? throw new ArgumentNullException(nameof(token));

            var request = _service.GetRequiredService<IRestRequest>();
            request.AddMobinAuthenticateHeader(token);
            request.Method = Method.GET;
            request.Resource = "Order";
            request.AddQueryParameter("$filter", 
                $"ListReport eq TadbirAPIModels.Models.Order.APIOrderListReport'{filter.OrderType}' and PageSize eq {filter.PageSize} and PageIndex eq {filter.PageIndex}");
            var response = await _client.ExecuteTaskAsync<OrderListResult>(request);
            return response.Data;
        }
    }
}
