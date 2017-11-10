using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class BankAccount
    {
        protected String accountId { get; set; } = "";      // 계좌 번호
        protected String bankName { get; set; } = "";    // 은행명
        protected String country { get; set; } = "";        // 국가
        protected BankAccountAuth auth { get; set; } = new BankAccountAuth();    // 인증키 값
        // @@ 추가적으로 돈 빼고 주고 하는 것도 여기 넣을까?
    }
}
