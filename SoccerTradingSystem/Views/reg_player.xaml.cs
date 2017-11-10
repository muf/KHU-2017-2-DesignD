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
        public reg_player()
        {
            InitializeComponent();
        }

        private void resiterBtn_Click(object sender, RoutedEventArgs e)
        {
            string userType = "player";
            string email = emailBox.Text;
            string passsword = passwordBox.Password;
            string firstName = firstnameBox.Text;
            string middleName = middlenameBox.Text;
            string lastName = lastnameBox.Text;
            string birth = birthBox.Text;
            string postion = positionBox.Text;
            string height = heightBox.Text;
            string weight = weightBox.Text;
        }
    }
}
