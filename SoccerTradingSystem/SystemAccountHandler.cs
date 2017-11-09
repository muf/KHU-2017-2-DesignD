using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class SystemAccountHandler
    {
        private SystemAccountDAC saDAC = new SystemAccountDAC();
        public User login(String email, String password)
        {
            return saDAC.login(email, password);
        }
        public bool registerPlayerAccount(Player player)
        {
            bool flag = saDAC.registerPlayerAccount(player);
            return flag;
        }
        public bool enrollAccount(User user, bool flagCommand)
        {
            bool flag = saDAC.enrollAccount(user, flagCommand);
            return flag;
        }
    }
}
