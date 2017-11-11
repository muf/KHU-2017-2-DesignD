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
using System.Text.RegularExpressions;

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// reg_club.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class reg_club : Page
    {
        private Window regWindow;
        public reg_club(Window _regWindow)
        {
            InitializeComponent();
            regWindow = _regWindow;
        }

        private void resiterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;
            string name = nameBox.Text;
            int birth = Convert.ToInt32(birthBox.Text);
            string contactNumber = contactBox.Text;

            SystemAccountHandler sah = new SystemAccountHandler();
            bool flag = sah.registerClubAccount(email, password, name, birth, contactNumber);

            if (flag)
                MessageBox.Show("성공");
            else
                MessageBox.Show("실패");

            // 윈도우 닫음
            regWindow.Close();
        }

        private void emailBox_Leave(object sender, System.EventArgs e)
        {
            bool emailCheck = Regex.IsMatch(emailBox.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!emailCheck)
            {
                MessageBox.Show("틀린 이메일 주소");
            }
        }
    }
}
