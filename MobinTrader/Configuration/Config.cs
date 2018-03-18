using System;

namespace MobinTrader.Configuration
{
    internal static class Config
    {
        internal static Uri GetBaseUrl()
        {
            return new Uri("https://restapi.mobinsb.com/Client/V1/");
        }
    }
}
