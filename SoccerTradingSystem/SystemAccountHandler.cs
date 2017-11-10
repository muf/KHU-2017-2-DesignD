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


        // uid 정보로 update 시도. 성공 여부에 따라서 boolean type으로 반환
        public bool updateUserAuth(int uid, bool value)
        {
            try
            {
                saDAC.updateUserAuth(uid, value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool registerManagerAccount(String email, String password, String name, String telNumber)
        {
            try
            {
                queryResult = saDAC.findUser(email);
                if (queryResult.Count > 0)
                {
                    return false;  // email 중복
                }
                else
                {
                    Manager newManager = new Manager(email, password, name, telNumber);
                    saDAC.addManagerData(newManager);
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }


        public bool registerClubAccount( String email, String password, String name, int birth, String contactNumber ){
            try
            {
                queryResult = saDAC.findUser(email);
                if (queryResult.Count > 0)
                {
                    return false;  // email 중복
                }
                else
                {
                    Club newClub = new Club(email, password);
                    newClub.name = name;
                    newClub.birth = birth;
                    newClub.contactNumber = contactNumber;
                    saDAC.addClubData(newClub);
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }


        public bool registerPlayerAccount(
    String email, String password, String firstName,
    String middleName, String lastName,
    int birth, int weight, int height, String position)
        {
            try
            {
                queryResult = saDAC.findUser(email);
                if (queryResult.Count > 0)
                {
                    return false;  // email 중복
                }
                else
                {
                    Player newPlayer = new Player(email, password);
                    newPlayer.firstName = firstName;
                    newPlayer.middleName = middleName;
                    newPlayer.lastName = lastName;
                    newPlayer.birth = birth;
                    newPlayer.weight = weight; // kg
                    newPlayer.height = height; // cm
                    newPlayer.position = position;
                    saDAC.addPlayerData(newPlayer);
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }



        public LocalData login(String email, String password)
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
    }
}