﻿using System;
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

        // @@ methods
        public User login(String email, String password)
        {
            User user = new User(email, password);
            int uid = getUserId(user);
            int cid = getClientId(uid);
            
            return user;
        }
        public int getUserId(User user)
        {
            int uid = -1;
            String email = user.email;
            String password = user.password;
            query = $"SELECT * from {userTable} where `email` = '{email}'";
            queryResult = conn.query(query);
            if(queryResult.Count > 0)
            {
                uid = Convert.ToInt32(queryResult[0]["uid"]);
            }
            return uid;
        }

        public int getClientId(int uid)
        {
            int cid = -1;
            query = $"SELECT * from {clientTable} where `uid` = {uid}";
            queryResult = conn.query(query);
            if (queryResult.Count > 0)
            {
                cid = Convert.ToInt32(queryResult[0]["cid"]);
            }
            return cid;
        }
        public bool registerUser(User user)
        {
            String email = user.email;
            String password = user.password;
            String type = user.GetType().BaseType.Name.ToString();
            // email이 존재 하는지 검사.
            int uid = getUserId(user);
            if (uid != -1) return false;
            // 계정이 이미 존재하는지 email 중복 검사
            //// 존재하지 않는 경우 User table에 새로 추가.
            else
            {
                query = $"INSERT INTO {userTable} (`email`, `password`, `type`) VALUES ('{email}', '{password}','{type}') ";
                queryResult = conn.query(query);
                return true;
            } // 존재하지 않는 경우 User table에 새로 추가.
              // Player 테이블에도 정보 추가
        }
        public bool registerClient(Client client)
        {
            bool flag = registerUser(client); // 사용자 db부터 등록
            String type = client.GetType().Name.ToString();
            if (flag) // 사용자 db에 성공한 경우만 client db도 등록
            {
                // client는 unique라서 알아서 체크함.
                int uid = getUserId(client);
                query = $"INSERT INTO {clientTable} (`uid`, `type`) VALUES ('{uid}','{type}') ";
                queryResult = conn.query(query);
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool registerPlayerAccount(Player player)
        {
            bool flag = registerClient(player); // 사용자 db부터 등록
            if (flag) // 사용자 db에 성공한 경우만 client db도 등록
            {
                int cid = getClientId(getUserId(player));
                try
                {
                    query =
                        $"INSERT INTO {playerTable} (cid, firstName, middleName, lastName, birth, position, weight, height, status)"
                        + $" VALUES ('{cid}','{player.firstName}','{player.middleName}','{player.lastName}','{player.birth}','{player.position}','{player.weight}','{player.height}','{player.status}') ";
                    queryResult = conn.query(query);
                    return true;
                }catch(Exception e)
                {
                    throw new Exception(e.Message.ToString() + "\n" + query);
                }
            }
            else
            {
                return false;
            }

        }

        // 관리자가 검증 후, authenticated를 1로 설정하여 정상적인 활동 가능하도록 수정.
        public bool enrollAccount(User user, bool flag)
        {
            int uid = getUserId(user);
            if(uid == -1)
            {
                throw new Exception("invalid user infomation. uid : -1");
            }
            else
            {
                try {
                    query = $"UPDATE {userTable} SET authenticated='{flag}' WHERE uid={uid}";
                    queryResult = conn.query(query);
                    return true;
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message.ToString() + "\n " + query);
                }
            }
        }
    }
}