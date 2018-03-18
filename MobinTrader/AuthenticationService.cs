using Microsoft.Extensions.DependencyInjection;
using MobinTrader.Configuration;
using MobinTrader.Models;
using MobinTrader.ResultModels;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace MobinTrader
{
    public class AuthenticationService
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private readonly ServiceProvider _service;
        private readonly IRestClient _client;

        public AuthenticationService():this(new ServiceConfigurator()) {}

        public AuthenticationService(ServiceConfigurator serviceConfigurator)
        {
            serviceConfigurator.Register(_serviceCollection);
            _service = _serviceCollection.BuildServiceProvider();
            _client = _service.GetRequiredService<IRestClient>();
            _client.BaseUrl = Config.GetBaseUrl();
        }

        /// <summary>
        /// Login to MobinSB OMS system
        /// </summary>
        /// <param name="username">Username provided by MobinSB</param>
        /// <param name="password">Password provided by MobinSB</param>
        /// <returns>LoginResult object contains a login token to use in authenticated requests</returns>
        public async Task<LoginResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new UnauthorizedAccessException();
            var request = _service.GetRequiredService<IRestRequest>();
            request.Method = Method.POST;
            request.Resource = "APIAUTHENTICATE";
            request.AddJsonBody(new LoginData(username,password));
            var response = await _client.ExecuteTaskAsync<LoginResult>(request);

            return response.Data;
        }

        public async Task<LogoutResult> Logout()
        {
            var request = _service.GetRequiredService<IRestRequest>();
            request.Method = Method.GET;
            request.Resource = "APIAUTHENTICATE/SignOut";
            var response = await _client.ExecuteTaskAsync<LogoutResult>(request);

            return response.Data;
        }
    }
}
