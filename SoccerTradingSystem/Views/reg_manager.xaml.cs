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

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// reg_manager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class reg_manager : Page
    {
        private Window regWindow;
        public reg_manager(Window _regWindow)
        {
            InitializeComponent();
            regWindow = _regWindow;
        }

        private void resiterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;
            string name = nameBox.Text;
            string telNumber = telBox.Text;

            // 유효성 검사

            // 레지스트
            SystemAccountHandler sah = new SystemAccountHandler();
            // 입력 값 받아서 newPlayer에 셋팅
            bool flag = sah.registerManagerAccount(email, password, name, telNumber);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");


            // 윈도우 닫음
            regWindow.Close();
        }
    }
}
