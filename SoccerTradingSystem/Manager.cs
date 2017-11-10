using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Manager : User
    {
        public int managerId { get; set; } = -1;
        public String name { get; }
        public String telNumber { get; }
        public Manager(String email, String password, String name, String telNumber, bool authenticated = false, bool logined = false) : base(email, password, authenticated, logined)
        {
            this.name = name;
            this.telNumber = telNumber;
        }
    }
}
