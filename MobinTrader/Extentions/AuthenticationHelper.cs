using RestSharp;
using System;

namespace MobinTrader.Extentions
{
    public static class AuthenticationHelper
    {
        public static void AddMobinAuthenticateHeader(this IRestRequest request, string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException();

            request.AddHeader("Authorization", $"Basic {token}");
        }
    }
}
