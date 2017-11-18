using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class Payment
    {
        public String paymentType { get; } = "";
        public int pay { get; set; } = 0;

        public Payment(String paymentType)
        {
            this.paymentType = paymentType;
        }
        public int getYearlyPay()
        {
            int times = 0;
            switch (paymentType) { 
            
                case "Daily":
                    times = enumClass.paymentTimes.Daily;
                    break;
                case "Weekly":
                    times = enumClass.paymentTimes.Weekly;
                    break;
                case "Monthly":
                    times = enumClass.paymentTimes.Monthly;
                    break;
                default:
                    times = 0;
                    break;
            } 
            return pay * times;
        }
    }
}
