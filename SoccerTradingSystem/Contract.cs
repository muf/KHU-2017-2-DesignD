using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Contract
    {
        public int contractId { get; set; } = -1;
        public int clubId { get; } = -1;
        public int playerId { get; } = -1;
        public String startDate { get; set; }
        public String endDate { get; set; }
        public int transferFee { get; set; }
        public int yearlyPay { get; set; }
        public int penaltyFee { get; set; }
        public bool leasePossibility { get; set; }
        public String contractType { get; set; } = enumClass.contractType.Offer;
        public String tradeType{ get; set; } = enumClass.contractType.Offer;


        public Contract(int clubId, int playerId, String startDate, String endDate, int transferFee, int yearlyPay, int penaltyFee, 
            bool leasePossibility = true)
        {
            this.clubId = clubId;
            this.playerId = playerId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.transferFee = transferFee;
            this.yearlyPay = yearlyPay;
            this.penaltyFee = penaltyFee;
            this.leasePossibility = leasePossibility;
        }
    }
}
