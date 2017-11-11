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
    /// MakeContractWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MakeContractWindow : Window
    {
        public MakeContractWindow()
        {
            InitializeComponent();

            if (App.cookie.type == "Club")
            {
                clubIdBox.Text = App.cookie.email;
            }
            else if (App.cookie.type == "Player")
            {
                playerIdBox.Text = App.cookie.email;
            }
            else
            {
                MessageBox.Show("비 정상적인 접근 클럽이나 플레이어로 로그인 되지않음.");
            }

        }

        private void ContractBtn_Click(object sender, RoutedEventArgs e)
        {
            int clubuid = Convert.ToInt32(clubIdBox.Text);
            int playeruid = Convert.ToInt32(playerIdBox.Text);

            if (App.cookie.type == "Club")
            {
                clubuid = App.cookie.uid;
                playeruid = Convert.ToInt32(playerIdBox.Text);
            } else if (App.cookie.type == "Player")
            {
                clubuid = Convert.ToInt32(clubIdBox.Text);
                playeruid = App.cookie.uid;
            }
            else
            {
                MessageBox.Show("비 정상적인 접근 클럽이나 플레이어로 로그인 되지않음.");
            }

            string startDate = startDateBox.Text;
            string endDate = endDateBox.Text;
            int transferFee = Convert.ToInt32(tranferFeeBox.Text);
            int yearlyPay = Convert.ToInt32(yearlyPayBox.Text);
            int penalityFee = Convert.ToInt32(penaltyBox.Text);

            SystemAccountHandler sah = new SystemAccountHandler();
            if (sah.makeContract(clubuid, playeruid, startDate, endDate, transferFee, yearlyPay, penalityFee))
            {
                MessageBox.Show("Contract Success");
            }
            else
            {
                MessageBox.Show("Contract Failed");
            }
        }
    }
}
