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
            logBtn.Content = "Login";
            logBtn.Click += new RoutedEventHandler(login_Click);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("logout");
            logBtn.Content = "Login";
            logBtn.Click -= new RoutedEventHandler(logout_Click);
            logBtn.Click += new RoutedEventHandler(login_Click);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("login");
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            logBtn.Content = "Logout";
            logBtn.Click += new RoutedEventHandler(logout_Click);
            logBtn.Click -= new RoutedEventHandler(login_Click);
        }
    }
}
