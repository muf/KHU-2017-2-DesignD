using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Common;
namespace SoccerTradingSystem
{

    using JSON = List<Dictionary<string, object>>;
    class DBGenerator
    {
        String createUserTableQuery =
     "CREATE TABLE `user` ( " +
     "`uid` BIGINT(20) NOT NULL AUTO_INCREMENT," +
     "`email` VARCHAR(50) NOT NULL," +
     "`password` VARCHAR(50) NOT NULL," +
     "`type` ENUM('Client','Manager') NOT NULL DEFAULT 'Client'," +
     "`authenticated` ENUM('True', 'False') NOT NULL DEFAULT 'False'," +

     "`logined` ENUM('True', 'False') NOT NULL DEFAULT 'False'," +
     "PRIMARY KEY (`uid`)," +
     "UNIQUE INDEX `email` (`email`)" +
     ")" +
     "COLLATE = 'latin1_swedish_ci' " +
     "ENGINE = InnoDB " +
     "AUTO_INCREMENT = 1;";


    String createClientTableQuery =
        "CREATE TABLE `client` (" +
        "`cid` BIGINT(20) NOT NULL AUTO_INCREMENT," +
        "`uid` BIGINT(20) NOT NULL," +
        "`type` ENUM('Player','Club') NOT NULL DEFAULT 'Player'," +
        "PRIMARY KEY(`cid`)," +
        "UNIQUE INDEX `uid` (`uid`)" +
        ")" +
        "COLLATE = 'latin1_swedish_ci' " +
        "ENGINE = InnoDB " +
        "AUTO_INCREMENT = 1; ";


    String createPlayerTableQuery =
        "CREATE TABLE `player` (" +
        "`pid` BIGINT(20) NOT NULL AUTO_INCREMENT," +
        "`cid` BIGINT(20) NOT NULL," +
        "`firstName` VARCHAR(50) NOT NULL," +
        "`middleName` VARCHAR(50) NOT NULL," +
        "`lastName` VARCHAR(50) NOT NULL," +
        "`birth` INT(11) NOT NULL," +
        "`position` ENUM('GK','RB','LB','CB','CMD','MF','RM','LM','RW','LW','FW','ST') NOT NULL DEFAULT 'GK'," +
        "`weight` SMALLINT(6) NOT NULL COMMENT 'kg'," +
        "`height` SMALLINT(6) NOT NULL COMMENT 'cm'," +
        "`status` ENUM('Free','Contract','Lease','Expire','Retire') NOT NULL DEFAULT 'Free'," +
        "PRIMARY KEY(`pid`)," +
        "UNIQUE INDEX `cid` (`cid`)" +
        ")" +
        "COLLATE = 'latin1_swedish_ci' " +
        "ENGINE = InnoDB " +
        "AUTO_INCREMENT = 1; ";

        private String query;
        JSON queryResult = new JSON();
        MariaDBConnector conn = new MariaDBConnector();
        public void dropAll()
        {
            conn.query("DROP TABLE user");
            conn.query("DROP TABLE client");
            conn.query("DROP TABLE player");
        }
        public bool init()
        {
            conn.query(createUserTableQuery);
            conn.query(createClientTableQuery);
            conn.query(createPlayerTableQuery);
            return true;
        }
    }
}
