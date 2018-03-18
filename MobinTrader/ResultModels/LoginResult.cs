namespace MobinTrader.ResultModels
{
    public class LoginResult:APIResultBase
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string LsToken { get; set; }
    }
}