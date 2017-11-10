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
        reg_player regPage;

        public PlayerRegistWindow()
        {
            InitializeComponent();
            regPage = new reg_player();
            regContent.Navigate(regPage);
            Application.Current.Properties["regSelected"] = "player";
        }

        private void regPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            
            regContent.Navigate(regPage);
            Application.Current.Properties["regSelected"] = "player";
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.Properties["regSelected"].ToString() == "player")
            {
                string email = regPage.emailBox.Text;
                string passsword = regPage.passwordBox.Text;
                string firstName = regPage.firstnameBox.Text;
                string middleName = regPage.middlenameBox.Text;
                string lastName = regPage.lastnameBox.Text;
                string birth = regPage.birthBox.Text;
                string postion = regPage.positionBox.Text;
                string height = regPage.heightBox.Text;
                string weight = regPage.weightBox.Text;

                SystemAccountHandler sah = new SystemAccountHandler();
                // 입력 값 받아서 newPlayer에 셋팅
                Player newPlayer = new Player(email, passsword);
                newPlayer.firstName = firstName;
                newPlayer.middleName = middleName;
                newPlayer.lastName = lastName;
                newPlayer.birth = Convert.ToInt32(birth);
                newPlayer.weight = Convert.ToInt32(weight); // kg
                newPlayer.height = Convert.ToInt32(height); // cm
                newPlayer.position = enumClass.Position.CMD;

                try
                {
                    String message = sah.registerPlayerAccount(newPlayer) == true ? "가입 요청 성공" : "가입 요청 실패";
                    MessageBox.Show(message);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message.ToString());
                }
            }
        }
    }
}
