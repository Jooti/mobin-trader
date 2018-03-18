using MobinTrader.Enums;
using RestSharp.Deserializers;

namespace MobinTrader.Models
{
    public class GetOrderData
    {
        [DeserializeAs(Name = "ListReport")]
        public OrderListFilter OrderType { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public GetOrderData()
        {
            PageSize = 10;
            PageIndex = 0;
        }
        public GetOrderData(OrderListFilter orderType):this()
        {
            OrderType = orderType;
        }

    }
}
