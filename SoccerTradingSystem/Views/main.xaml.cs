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
    /// main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
            top_panel TP = new top_panel(this);
            top_frame.Navigate(TP);

            if (App.cookie != null)
            {
                if (App.cookie.userType == enumClass.UserType.Manager)
                {
                    userInfoBtn.Visibility = System.Windows.Visibility.Visible;
                }else
                {
                    userInfoBtn.Visibility = System.Windows.Visibility.Collapsed;
                }
            }else
            {
                userInfoBtn.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void userInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            user_info _user_info = new user_info();
            content_frame.Navigate(_user_info);
        }
    }
}
