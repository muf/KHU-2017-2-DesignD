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
    /// top_panel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class top_panel : Page
    {
        public top_panel()
        {
            InitializeComponent();
            // 체크
        }

        public void logout_Click(object sender, RoutedEventArgs e)
        {
            App.current_user = null;

            MessageBox.Show("logout");
            loginBtn.Visibility = System.Windows.Visibility.Visible;
            logoutBtn.Visibility = System.Windows.Visibility.Collapsed;
            logined_email_change("Unlogined");
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("login");
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.Show();
        }

        private void user_registBtn_Click(object sender, RoutedEventArgs e)
        {
            // regist
            PlayerRegistWindow userRegWindow = new PlayerRegistWindow();
            userRegWindow.Show();
        }

        public void logined_email_change(string e)
        {
            topLoginedEmail.Text = e;
        }
    }
}
