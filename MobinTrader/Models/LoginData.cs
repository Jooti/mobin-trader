using System;
using System.Collections.Generic;
using System.Text;

namespace MobinTrader.Models
{
    public class LoginData
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginData() { }
        public LoginData(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
