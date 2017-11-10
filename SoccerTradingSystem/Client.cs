using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Client : User
    {

        public int clientId { get; set; } = -1;
        protected List<BankAccount> bankAccounts = new List<BankAccount>();
        public Client(String email, String password, bool authenticated = false, bool logined =false) : base(email, password, authenticated, logined)
        {
        
        }
    }
}
