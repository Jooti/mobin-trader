using MobinTrader.Enums;
using RestSharp.Deserializers;
using System;

namespace MobinTrader.ResultModels
{
    public class OrderItemResult
    {
        public FinancialProviders FinancialProvider { get; set; }

        [DeserializeAs(Name = "ParentId")]
        public decimal PrevOrderId { get; set; }

        [DeserializeAs(Name = "UserName")]
        public string Username { get; set; }

        public string Symbol { get; set; }
        public string EnSymbol { get; set; }

        [DeserializeAs(Name = "ExcutedAmount")]
        public int ExcutedVolume { get; set; }

        public int HiddenOrder { get; set; }

        public decimal OrderId { get; set; }
        public OrderStatus OrderState { get; set; }

        [DeserializeAs(Name = "OrderEntryDate")]
        public DateTime OrderCreateDate { get; set; }

        public decimal OrderPrice { get; set; }
        public OrderSide OrderSide { get; set; }
        
        [DeserializeAs(Name = "OrderTotalQuantity")]
        public int Volume { get; set; }

        public OrderValidity OrderValidity { get; set; }
        public DateTime OrderValidityDate { get; set; }

        public decimal HostOrderId { get; set; }
        public MarketType MarketType { get; set; }
        
        [DeserializeAs(Name = "OrderFrom")]
        public OrderSource OrderSource { get; set; }

        public string ErrorCode { get; set; }
        public string SymbolISIN { get; set; }
        public string CustomerISIN { get; set; }
    }
}