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
using System.Windows.Shapes;

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// PlayerRegistWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerRegistWindow : Window
    {
        reg_player regPPage = null;
        reg_club regCPage = null;
        reg_manager regMPage = null;

        public PlayerRegistWindow()
        {
            InitializeComponent();
            regPPage = new reg_player(this);
            regContent.Navigate(regPPage);
            Application.Current.Properties["regSelected"] = "player";
        }

        private void regPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            pageReset();
            regPPage = new reg_player(this);
            regContent.Navigate(regPPage);
            Application.Current.Properties["regSelected"] = "player";
        }

        private void regClubBtn_Click(object sender, RoutedEventArgs e)
        {
            pageReset();
            regCPage = new reg_club(this);
            regContent.Navigate(regCPage);
            Application.Current.Properties["regSelected"] = "club";
        }

        private void regManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            pageReset();
            regMPage = new reg_manager(this);
            regContent.Navigate(regMPage);
            Application.Current.Properties["regSelected"] = "manager";
        }

        private void pageReset()
        {
            regPPage = null;
            regCPage = null;
            regMPage = null;
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            //string email = regPPage.emailBox.Text;
            //string passsword = regPPage.passwordBox.Password;
            //string firstName = regPPage.firstnameBox.Text;
            //string middleName = regPPage.middlenameBox.Text;
            //string lastName = regPPage.lastnameBox.Text;
            //string birth = regPPage.birthBox.Text;
            //string postion = regPPage.positionBox.Text;
            //string height = regPPage.heightBox.Text;
            //string weight = regPPage.weightBox.Text;
        }


    }
}
