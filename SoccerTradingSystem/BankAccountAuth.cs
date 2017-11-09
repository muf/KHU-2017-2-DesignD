using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTradingSystem
{
    class BankAccountAuth
    {
        private int secretKey { get; set; } = 0;

        public BankAccountAuth(){
            makeSecretKey();
        }

        // @@ test code
        public int makeSecretKey()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int key = rnd.Next(1, int.MaxValue);
            this.secretKey = key;
            return key;
        }
    }

    /*
     var buffer = new byte[sizeof(uint)];
new Random().NextBytes(buffer);
uint result = BitConverter.ToUInt32(buffer, 0);

result = (result % (max - min)) + min;
     */
}
