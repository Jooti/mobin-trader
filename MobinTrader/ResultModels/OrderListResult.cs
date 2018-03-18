using RestSharp.Deserializers;
using System.Collections.Generic;

namespace MobinTrader.ResultModels
{
    public class OrderListResult:APIResultBase
    {
        [DeserializeAs(Name = "TotalRecord")]
        public int Count { get; set; }

        [DeserializeAs(Name = "List")]
        public List<OrderItemResult> Orders { get; set; }
    }
}
