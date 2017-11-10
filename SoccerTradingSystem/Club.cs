using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Club : Client
    {
        public String name { get; set; }
        public String contactNumber { get; set; }
        public int birth { get; set; }
        //protected List<Player> players = new List<Player>();
        public Club(String email, String password, bool authenticated = false, bool logined = false) : base(email, password, authenticated, logined)
        {

        }
    }
}
