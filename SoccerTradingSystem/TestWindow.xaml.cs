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
            유저_로그인_시나리오();
            //선수_회원가입_시나리오();
            //매니져_회원가입_승인_시나리오();

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
            String password = "tmxhs8282";
            App.current_user = sah.login(email, password);
            var temp = App.current_user;

            MessageBox.Show("ok");

        }
        public void 선수_회원가입_시나리오()
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅
            Player newPlayer = new Player("huryip@naver.com", "tmxhs8282");
            newPlayer.firstName = "hwang";
            newPlayer.middleName = "jin";
            newPlayer.lastName = "ha";
            newPlayer.birth = 19940831;
            newPlayer.weight = 33; // kg
            newPlayer.height = 17790; // cm
            newPlayer.position = enumClass.Position.CMD;

            try
            {
                String message = sah.registerPlayerAccount(newPlayer) == true ? "가입 요청 성공" : "가입 요청 실패";
                MessageBox.Show(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }
        public void 매니져_회원가입_승인_시나리오()
        {

            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅
            Player newPlayer = new Player("huryip@naver.com", "tmxhs8282");

            try
            {
                String message = sah.enrollAccount(newPlayer, true) == true ? "계정 등록 변경 성공" : "계정 등록 변경 실패";
                MessageBox.Show(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }
}
