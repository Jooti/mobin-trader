using MobinTrader.Enums;
using RestSharp.Serializers;
using System;

namespace MobinTrader.Models
{
    public class OrderData
    {
        public FinancialProviders FinancialProviders { get; set; }
        public OrderValidity Validity { get; set; }
        public DateTime ValidityDate { get; set; }
        public MarketType MarketType { get; set; }

        public decimal Price { get; set; }

        [SerializeAs(Name = "Quantity")]
        public int Volume { get; set; }

        public OrderSide Side { get; set; }
        public int OrderType => 76;
        public string ReferenceKey { get; set; }
        public int MaxShown { get; set; }

        [SerializeAs(Name = "MinimumQuantity")]
        public int MinimumVolume { get; set; }
        public decimal TriggerPrice { get; set; }
        public string Lan { get; set; }
        public string SymbolISIN { get; set; }
    }
}
