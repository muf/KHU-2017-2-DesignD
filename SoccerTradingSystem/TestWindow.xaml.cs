using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoccerTradingSystem
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            //디비_재구성();
            //유저_로그인_시나리오();
            //선수_회원가입_시나리오();
            //매니져_회원가입_시나리오();
            //구단_회원가입_시나리오();
            //매니져_회원가입_승인_시나리오();
            //계정_정보조회_시나리오();
            선수_구단_계약_시나리오();

        }
        public void 선수_구단_계약_시나리오() {
            SystemAccountHandler sah = new SystemAccountHandler();
            int clubUid = 7;
            int playerUid = 1;
            bool flag = sah.makeContract(clubUid, playerUid, "1", "1", 1, 1, 1);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");

        }
        public void 계정_정보조회_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            List<Player> list = sah.retrievePlayerData("");
            List<Club> cist = sah.retrieveClubData("");
            List<Manager> mlist = sah.retrieveManagerData("");
            MessageBox.Show(list.ToString());
        }
        public void 매니져_회원가입_승인_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            bool flag = sah.updateUserAuth(1, false);
            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");
        }
        public void 디비_재구성()
        {
            DBGenerator gen = new DBGenerator();
            try
            {
                //gen.dropAll();
                gen.init();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        public void 유저_로그인_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            String email = "huryip@naver.com";
            String password = "tmxhs822";

            App.cookie = sah.login(email, password);
            if (App.cookie != null)
            {
                MessageBox.Show("로그인 성공");
            }
            else
            {
                MessageBox.Show("인증 실패");
            }
            MessageBox.Show("ok");

        }
        public void 선수_회원가입_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅

            String email = "huryip3@naver.com";
            String password = "tmxhs8282";
            String firstName = "park";
            String middleName = "jin";
            String lastName = "ha";
            int birth = 19940831;
            int weight = 33; // kg
            int height = 17790; // cm
            String position = enumClass.Position.CMD;

            bool flag = sah.registerPlayerAccount(email, password, firstName, middleName, lastName, birth, weight, height, position);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");

        }
        public void 매니져_회원가입_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅

            String email = "manager@naver.com";
            String password = "tmxhs8282";
            String name = "mainManager";
            String telNumber = "010-9061-9570";

            bool flag = sah.registerManagerAccount(email, password, name, telNumber);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");

        }
        public void 구단_회원가입_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅

            String email = "club@naver.com";
            String password = "tmxhs8282";
            String name = "mainManager";
            int birth = 123;
            String contactNumber = "010-9061-9570";

            bool flag = sah.registerClubAccount(email, password, name, birth, contactNumber);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");

        }
    }
}