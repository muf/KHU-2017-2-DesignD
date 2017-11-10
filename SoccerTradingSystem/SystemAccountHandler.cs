using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    using JSON = List<Dictionary<string, object>>;
    class SystemAccountHandler
    {
        private SystemAccountDAC saDAC = new SystemAccountDAC();
        private JSON queryResult = new JSON();


        public LocalData new_login(String email, String password)
        {
            queryResult = saDAC.authenticate(email, password);  // 인증 정보로 인증 쿼리 전송 후 결과 저장
            if (queryResult.Count == 1)
            {
                String authenticated = queryResult[0]["authenticated"].ToString();
                String userType = queryResult[0]["type"].ToString();
                LocalData cookie = new LocalData();
                cookie.uid = Convert.ToInt32(queryResult[0]["uid"]);
                cookie.email = email;
                cookie.authenticated = authenticated == "True" ? true : false;
                cookie.userType = userType;

                return cookie; // 정상적인 경우 cookie 셋팅 후 전달
            }
            else
                return null;
        }
        






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
