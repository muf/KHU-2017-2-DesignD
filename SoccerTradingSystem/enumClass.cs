using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{

    public enum Position { GK, RB, LB, CB, CMD, MF, RM, LM, RW, LW, FW, ST };
    public enum Status { Free, Contract, Lease, Expire, Retire };
    public static class enumClass
    {
        public static class contractType
        {
            public static String Offer = "Offer";
            public static String Expire = "Expire";
            public static String Destruct = "Destruct";
            public static String Decline = "Decline";
            public static String Under = "Under";

        }
        public static class tradeType
        {
            public static String Lease = "Lease";
            public static String Belong = "Belong";
            public static String Offer = "Offer";
        }
        public static class AccountRetrieveOption
        {
            public static String Global = "global";
            public static class User
            {
                public static String Uid = "uid";
                public static String Email = "email";
                public static String authenticated = "authenticated";
                public static String logined = "logined";
            }
            public static class Player
            {

            }
            public static class Club
            {

            }
            public static class Manager
            {

            }
        }
        public static class UserType
        {
            public static String Club = "Club";
            public static String Player = "Player";
            public static String Manager = "Manager";

        }
        public static class Status
        {
            public static String Free = "Free";
            public static String Contract = "Contract";
            public static String Lease = "Lease";
            public static String Expire = "Expire";
            public static String Retire = "Retire";
            public static String NearExpire = "NearExpire";
        }
        public static class Position
        {
            public static String GK = "GK";
            public static String RB = "RB";
            public static String LB = "LB";
            public static String CB = "CB";
            public static String CMD = "CMD";
            public static String MF = "MF";
            public static String RM = "RM";
            public static String LM = "LM";
            public static String RW = "RW";
            public static String LW = "LW";
            public static String FW = "FW";
            public static String ST = "ST";
        }
    }
}
