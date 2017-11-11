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
    /// PlayerDetailWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlayerDetailWindow : Window
    {
        public PlayerDetailWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (App.cookie != null)
            {
                if (App.cookie.type == "Club")
                {
                    PlayerOfferBtn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    PlayerOfferBtn.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void PlayerOfferBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeContractWindow _MakeContractWindow = new MakeContractWindow();
            _MakeContractWindow.Show();
        }
    }
}
