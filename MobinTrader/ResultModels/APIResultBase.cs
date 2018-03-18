using RestSharp.Deserializers;

namespace MobinTrader.ResultModels
{
    public class APIResultBase
    {
        public bool IsSuccessful { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        [DeserializeAs(Name = "UniqKey")]
        public string UniqueKey { get; set; }
    }
}