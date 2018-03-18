using System;
using System.Collections.Generic;
using System.Text;

namespace MobinTrader.Enums
{
    public enum OrderSource
    {
        None =0,
        Web = 2,
        Counter= 5,
        Stand = 6,
        Portfolio = 7,
        EquityReport = 9,
        Mobile = 12,
        Metatrader = 14,
        ConditionalOrder = 15,
        CallCenter = 16,
        BasketOrder = 17,
        Sama = 18,
        Robot = 19,
        OnlinePlus = 20,
        API = 21,
        BrokerAPI = 22,
        ClientAPI = 23,
        TestSystem = 24
    }
}
