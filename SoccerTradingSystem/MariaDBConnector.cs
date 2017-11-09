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
    class MariaDBConnector
    {
        private static String serverIp = "127.0.0.1";
        private static String id = "root";
        private static String password = "admin";
        private static String databaseName = "pms_dev";
        private String connectString;
        private MySqlConnection conn;

        public MariaDBConnector(){
            connectString = 
                "Server=" + MariaDBConnector.serverIp 
                + ";Database = " + MariaDBConnector.databaseName 
                + ";Uid=" + MariaDBConnector.id 
                + ";Pwd=" + MariaDBConnector.password + ";";
        }
        public bool connectOpen()
        {
            conn = new MySqlConnection(this.connectString);
            conn.Open();

            return true;
        }
        public bool connectClose()
        {
            conn.Close();
            return true;
        }
        // 테스트용
        public JSON query(String query)
        {
            // 이부분 동기화 필요
            try{
                connectOpen();
                MySqlCommand cmd = new MySqlCommand(query, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                var results = new List<Dictionary<string, object>>();
                var schema = new List<string>();
                var fieldCount = rdr.FieldCount;
                for (var i = 0; i < fieldCount; i++)
                {
                    schema.Add(rdr.GetName(i));
                }
                while (rdr.Read())
                {
                    var dic = new Dictionary<string, object>();
                    for (var i = 0; i < fieldCount; i++)
                    {
                        dic[schema[i]] = rdr[schema[i]];
                    }
                    results.Add(dic);
                }
                connectClose();
                return results;
            }catch(Exception e)
            {
                throw (e);
            }

        }
    }
}
