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
            string email = regPPage.emailBox.Text;
            string passsword = regPPage.passwordBox.Password;
            string firstName = regPPage.firstnameBox.Text;
            string middleName = regPPage.middlenameBox.Text;
            string lastName = regPPage.lastnameBox.Text;
            string birth = regPPage.birthBox.Text;
            string postion = regPPage.positionBox.Text;
            string height = regPPage.heightBox.Text;
            string weight = regPPage.weightBox.Text;

            

            //if(Application.Current.Properties["regSelected"].ToString() == "player")
            //{
            //    string email = regPPage.emailBox.Text;
            //    string passsword = regPPage.passwordBox.Password;
            //    string firstName = regPPage.firstnameBox.Text;
            //    string middleName = regPPage.middlenameBox.Text;
            //    string lastName = regPPage.lastnameBox.Text;
            //    string birth = regPPage.birthBox.Text;
            //    string postion = regPPage.positionBox.Text;
            //    string height = regPPage.heightBox.Text;
            //    string weight = regPPage.weightBox.Text;

            //    SystemAccountHandler sah = new SystemAccountHandler();
            //    // 입력 값 받아서 newPlayer에 셋팅
            //    Player newPlayer = new Player(email, passsword);
            //    newPlayer.firstName = firstName;
            //    newPlayer.middleName = middleName;
            //    newPlayer.lastName = lastName;
            //    newPlayer.birth = Convert.ToInt32(birth);
            //    newPlayer.weight = Convert.ToInt32(weight); // kg
            //    newPlayer.height = Convert.ToInt32(height); // cm
            //    newPlayer.position = enumClass.Position.CMD;

            //    try
            //    {
            //        String message = sah.registerPlayerAccount(newPlayer) == true ? "가입 요청 성공" : "가입 요청 실패";
            //        MessageBox.Show(message);
            //    }
            //    catch (Exception err)
            //    {
            //        MessageBox.Show(err.Message.ToString());
            //    }
            //}
        }


    }
}
