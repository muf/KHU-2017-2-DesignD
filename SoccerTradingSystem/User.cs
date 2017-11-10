using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    public class User
    {
        public int uid { get; set; } = -1;
        public String email { get; } = "";                 // 사용자의 계정 이메일
        public String password { get; } = "";             // 사용자의 게정 패스워드 @@ 이게 필요한건가?
        public bool authenticated { get; } = false;     // @@ 수정.. 회원가입 승인 되었는지 여부로 대체  
        public bool logined { get; } = false; //@@ 추가.. 로그인 여부를 이 변수로 대체
        
        public User(String email, String password, bool authenticated = false, bool logined = false)
        {
            this.email = email;
            this.password = password;
            this.authenticated = authenticated;
            this.logined = logined;
        }
    }
}
