using MobinTrader.ResultModels;
using System;
using System.Threading.Tasks;

namespace MobinTrader.Client.ConsoleCoreApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            AuthenticationService n = new AuthenticationService();
            Console.WriteLine("MobinSB Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Sending login request");

            LoginResult loginResult;
            try
            {
                loginResult = await n.Login(username, password);
            }
            catch (Exception)
            {
                loginResult = new LoginResult() {IsSuccessful = false};
            }

            if (loginResult.IsSuccessful)
            {

                Console.WriteLine("Recent trades:");
                var o = new OrderService();
                try
                {
                    var orderList = await o.Find(
                        new Models.GetOrderData(Enums.OrderListFilter.TRADES),
                        loginResult.Token);
                    foreach (var order in orderList.Orders)
                    {
                        Console.WriteLine($"{order.OrderSide.ToString()} {order.EnSymbol} Volume: {order.Volume} Price: {order.OrderPrice}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Oops! something bad happend: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
            Console.ReadLine();
        }
    }
}
