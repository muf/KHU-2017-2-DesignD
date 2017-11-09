using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Player : Client
    {
        //public String classification { get; set; } = ""; // 주전 1군, 2군,, 등등..
        public int playerId { get; set; } = -1; 
        public String firstName { get; set; } = ""; 
        public String middleName { get; set; } = "";  
        public String lastName { get; set; } = ""; 
        public int birth { get; set; } = 0;  // 19930831 형식
        public String position { get; set; } = enumClass.Position.GK;
        public int weight { get; set; } = 0; // 
        public int height { get; set; } = 0; //
        public String status { get; set; } = enumClass.Status.Free;

        public Player(String email, String password, bool authenticated = false, bool logined = false) : base(email, password, authenticated, logined)
        {
        }
    }
}
