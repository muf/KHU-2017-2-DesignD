using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.Common;
using MySql.Data.MySqlClient;
namespace SoccerTradingSystem
{
    using JSON = List<Dictionary<string, object>>;
    class SystemAccountDAC // static 으로 만들까..
    {
        // @@ attributes
        private static String userTable = "User";
        private static String clientTable = "Client";
        private static String playerTable = "Player";

        private String query;
        JSON queryResult = new JSON();
        MariaDBConnector conn = new MariaDBConnector();

        // @@ new methods
        public JSON authenticate(String email, String password)
        {
            // email, password 기반으로 해당하는 user 정보 검색
            query = $"SELECT * from {userTable} where `email` = '{email}' AND `password` = '{password}'";
            queryResult = conn.query(query);
            return queryResult;
        }
        public void updateUserAuth(int uid, bool value)
        {
            query = $"UPDATE {userTable} SET `authenticated` = '{value}' WHERE `uid` = '{uid}'";
            queryResult = conn.query(query);
        }
        public JSON findUser(String email)
        {
            // email, password 기반으로 해당하는 user 정보 검색
            query = $"SELECT * from {userTable} where `email` = '{email}'";
            queryResult = conn.query(query);

            return queryResult;
        }

        public void addPlayerData(Player player)
        {
            //query = "begin; ";
            query = $"INSERT INTO {userTable} (`email`, `password`, `type`) VALUES ('{player.email}', '{player.password}','Client');  ";
            query += $"INSERT INTO {clientTable} (`uid`, `type`) VALUES ( "
                + $" (SELECT `uid` FROM {userTable} WHERE `email` = '{player.email}') , 'Player');  ";
            query += $"INSERT INTO {playerTable} (uid, firstName, middleName, lastName, birth, position, weight, height, status)"
                        + $" VALUES ( (SELECT `uid` FROM {userTable} WHERE `email` = '{player.email}')"
                        + $" ,'{player.firstName}','{player.middleName}','{player.lastName}','{player.birth}','{player.position}','{player.weight}','{player.height}','{player.status}') ";
            //query += "commit";
            System.Diagnostics.Debug.WriteLine(query);
            System.Diagnostics.Trace.WriteLine(query);
            System.Console.WriteLine(query);
            queryResult = conn.query(query);
        }
    }
}