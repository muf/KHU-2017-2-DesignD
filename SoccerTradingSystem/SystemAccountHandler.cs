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
        public bool registerClubAccount(String email, String password, String name, int birth, String contactNumber) {
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
        public bool registerPlayerAccount(String email, String password, String firstName, String middleName, String lastName, int birth, int weight, int height, String position)
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
                cookie.type = cookie.userType == "Client" ? getClientType(cookie.uid) : cookie.userType;
                return cookie; // 정상적인 경우 cookie 셋팅 후 전달
            }
            else
                return null;
        }
        public String getClientType(int uid)
        {
            JSON result = saDAC.getAccountData(uid);
            if(result.Count == 0)
            {
                return "NONE";
            }
            else
            {
                return result[0]["client_type"].ToString();
            }
        }
        public List<Player> retrievePlayerData(String keyword)
        {
            List<Player> players = new List<Player>();

            JSON result = saDAC.getPlayersData();
            for (int i = 0; i < result.Count; i++)
            {
                String globalString = "";
                Dictionary<string, object> data = result[i];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Player player = new Player(data["email"].ToString(), data["password"].ToString(), auth, logined);
                player.weight = Convert.ToInt32(data["weight"]);
                player.height = Convert.ToInt32(data["height"]);
                player.birth = Convert.ToInt32(data["birth"]);
                player.playerId = Convert.ToInt32(data["pid"]);
                player.clientId = Convert.ToInt32(data["cid"]);
                player.uid = Convert.ToInt32(data["uid"]);
                player.firstName = data["firstName"].ToString();
                player.middleName = data["middleName"].ToString();
                player.lastName = data["lastName"].ToString();
                player.position = data["position"].ToString();
                player.status = data["status"].ToString();

                globalString += player.email + player.uid + +player.birth + player.firstName + player.middleName + player.lastName + player.position + player.status + player.playerId;
                globalString.Replace(" ", "");
                if (globalString.IndexOf(keyword) != -1)
                {
                    players.Add(player);
                }
            }
            return players;
        }
        public Player retrievePlayerData(int uid)
        {
            JSON result = saDAC.getPlayersData(uid);
            if(result.Count > 0)
            {
                Dictionary<string, object> data = result[0];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Player player = new Player(data["email"].ToString(), data["password"].ToString(), auth, logined);
                player.weight = Convert.ToInt32(data["weight"]);
                player.height = Convert.ToInt32(data["height"]);
                player.birth = Convert.ToInt32(data["birth"]);
                player.playerId = Convert.ToInt32(data["pid"]);
                player.clientId = Convert.ToInt32(data["cid"]);
                player.uid = Convert.ToInt32(data["uid"]);
                player.firstName = data["firstName"].ToString();
                player.middleName = data["middleName"].ToString();
                player.lastName = data["lastName"].ToString();
                player.position = data["position"].ToString();
                player.status = data["status"].ToString();

                return player;
            }
            else
            {
                return null;
            }
        }
        public List<Club> retrieveClubData(String keyword)
        {
            List<Club> clubs = new List<Club>();
            JSON result = saDAC.getClubsData();
            for (int i = 0; i < result.Count; i++)
            {
                String globalString = "";
                Dictionary<string, object> data = result[i];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Club club = new Club(data["email"].ToString(), data["password"].ToString(), auth, logined);
                club.clientId = Convert.ToInt32(data["clientId"]);
                club.clubId = Convert.ToInt32(data["cid"]);
                club.uid = Convert.ToInt32(data["uid"]);
                club.birth = Convert.ToInt32(data["birth"]);
                club.name = data["name"].ToString();
                club.contactNumber = data["contactNumber"].ToString();

                globalString += club.email + club.uid + +club.birth + club.name + club.contactNumber + club.clubId;
                globalString.Replace(" ", "");
                if (globalString.IndexOf(keyword) != -1)
                {
                    clubs.Add(club);
                }
            }
            return clubs;
        }
        public Club retrieveClubData(int uid)
        {
            JSON result = saDAC.getClubsData();
            if(result.Count>0)
            {
                Dictionary<string, object> data = result[0];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Club club = new Club(data["email"].ToString(), data["password"].ToString(), auth, logined);
                club.clientId = Convert.ToInt32(data["clientId"]);
                club.clubId = Convert.ToInt32(data["cid"]);
                club.uid = Convert.ToInt32(data["uid"]);
                club.birth = Convert.ToInt32(data["birth"]);
                club.name = data["name"].ToString();
                club.contactNumber = data["contactNumber"].ToString();

                return club;
            }
            else
            {
                return null;
            }
        }
        public List<Manager> retrieveManagerData(String keyword)
        {
            List<Manager> managers = new List<Manager>();
            JSON result = saDAC.getManagersData();
            for (int i = 0; i < result.Count; i++)
            {
                String globalString = "";
                Dictionary<string, object> data = result[i];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Manager manager = new Manager(data["email"].ToString(), data["password"].ToString(), data["name"].ToString(), data["telNumber"].ToString(), auth, logined);
                manager.managerId = Convert.ToInt32(data["mid"]);
                manager.uid = Convert.ToInt32(data["uid"]);

                globalString += manager.email + manager.uid + +manager.managerId + manager.uid + manager.name + manager.telNumber;
                globalString.Replace(" ", "");
                if (globalString.IndexOf(keyword) != -1)
                {
                    managers.Add(manager);
                }
            }
            return managers;
        }
        public Manager retrieveManagerData(int uid)
        {
            JSON result = saDAC.getManagersData();

            if (result.Count > 0)
            {
                Dictionary<string, object> data = result[0];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                Manager manager = new Manager(data["email"].ToString(), data["password"].ToString(), data["name"].ToString(), data["telNumber"].ToString(), auth, logined);
                manager.managerId = Convert.ToInt32(data["mid"]);
                manager.uid = Convert.ToInt32(data["uid"]);

                return manager;
            }
            else
            {
                return null;
            }
        }
        public List<User> retrieveUserData(String keyword)
        {
            List<User> users = new List<User>();
            JSON result = saDAC.getUserData();
            for (int i = 0; i < result.Count; i++)
            {
                String globalString = "";
                Dictionary<string, object> data = result[i];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                User user = new User(data["email"].ToString(), data["password"].ToString(), auth, logined);
                user.uid = Convert.ToInt32(data["uid"]);
                globalString += user.email + user.uid;
                globalString.Replace(" ", "");
                if (globalString.IndexOf(keyword) != -1)
                {
                    users.Add(user);
                }
            }
            return users;

        }
        public User retrieveUserData(int uid)
        {
            JSON result = saDAC.getUserData();
            if (result.Count > 0) {
                Dictionary<string, object> data = result[0];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                User user = new User(data["email"].ToString(), data["password"].ToString(), auth, logined);
                user.uid = Convert.ToInt32(data["uid"]);

                return user;
            }
            else{
                return null;
            }
        }
        public List<User> retrieveUnauthedUserData(String keyword)
        {
            List<User> users = new List<User>();
            JSON result = saDAC.getUnauthedUserData();
            for (int i = 0; i < result.Count; i++)
            {
                String globalString = "";
                Dictionary<string, object> data = result[i];
                bool auth = data["authenticated"].ToString() == "True" ? true : false;
                bool logined = data["logined"].ToString() == "True" ? true : false;
                User user = new User(data["email"].ToString(), data["password"].ToString(), auth, logined);
                user.uid = Convert.ToInt32(data["uid"]);

                globalString += user.email + user.uid;
                globalString.Replace(" ", "");
                if (globalString.IndexOf(keyword) != -1)
                {
                    users.Add(user);
                }
            }
            return users;

        }
        // 임시 함수
        public bool makeContract(int clubUid, int playerUid, 
            String startDate, String endData, int transferFee, int yearlyPay, int penalityFee, 
            bool leasePossibility = true)
        {
            try
            {
                int clubId = retrieveClubData(clubUid).clubId;
                int playerId = retrievePlayerData(playerUid).playerId;
                Contract contract = new Contract(clubId, playerId, startDate, endData, transferFee, yearlyPay, penalityFee, leasePossibility);
                saDAC.addContractData(contract);
                return true;
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
                return false;
            }
            // 선수,구단 조합인지 체크
            String contractType = enumClass.contractType.Offer;
            String tradeType = enumClass.tradeType.Offer;


        }
        public void accepctContract()
        {

        } 
    }
}