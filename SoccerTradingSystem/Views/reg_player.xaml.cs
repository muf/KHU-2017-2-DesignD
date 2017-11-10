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
    /// reg_player.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class reg_player : Page
    {
        private Window regWindow;
        public reg_player(Window _regWindow)
        {
            InitializeComponent();
            regWindow = _regWindow;
        }


        private void resiterBtn_Click(object sender, RoutedEventArgs e)
        {
            // value
            string email = emailBox.Text;
            string password = passwordBox.Password;
            string firstName = firstnameBox.Text;
            string middleName = middlenameBox.Text;
            string lastName = lastnameBox.Text;
            int birth = Convert.ToInt32(birthBox.Text);
            MessageBox.Show((Convert.ToInt32(positionComboBox.SelectedIndex) + 1).ToString());
            string position = (Convert.ToInt32(positionComboBox.SelectedIndex) + 1).ToString();
            int height = Convert.ToInt32(heightBox.Text);
            int weight = Convert.ToInt32(weightBox.Text);

            // Validation
            if(email.Trim() == "")
            {

            }

            SystemAccountHandler sah = new SystemAccountHandler();
            try
            {
                bool flag = sah.registerPlayerAccount(email, password, firstName, middleName, lastName, birth, weight, height, position);

                if (flag)
                    MessageBox.Show("성공");
                else
                    MessageBox.Show("실패");
            }
            catch( Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
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
