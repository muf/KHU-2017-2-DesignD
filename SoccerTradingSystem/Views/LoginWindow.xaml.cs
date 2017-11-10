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
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private top_panel TP;
        public LoginWindow(top_panel top_panel)
        {
            InitializeComponent();
            this.TP = top_panel;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            // get email & password
            string email_string = emailBox.Text;
            string password_string = passwordBox.Password;

            // Validation Check (null)
            if(email_string == "" || password_string == "")
            {
                MessageBox.Show("Null Error");
                return;
            }

            // user login
            SystemAccountHandler sah = new SystemAccountHandler();
            String email = email_string;
            String password = password_string;
            App.cookie = sah.login(email, password);

            // Dismatch Error
            if(App.cookie == null)
            {
                MessageBox.Show("Login Failed");
                return;
            }

            // No Auth Error
            if (!App.cookie.authenticated)
            {
                MessageBox.Show("You can not log in without administrator approval.");
                return;
            }

            // Top Panel & Main logined form setting
            TP.logined_success(email);
            this.Close();
        }
    }
}
