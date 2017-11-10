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
            string email = emailBox.Text;
            string password = passwordBox.Password;
            string firstName = firstnameBox.Text;
            string middleName = middlenameBox.Text;
            string lastName = lastnameBox.Text;
            int birth = Convert.ToInt32(birthBox.Text);
            string position = positionBox.Text;
            int height = Convert.ToInt32(heightBox.Text);
            int weight = Convert.ToInt32(weightBox.Text);

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
    }
}
