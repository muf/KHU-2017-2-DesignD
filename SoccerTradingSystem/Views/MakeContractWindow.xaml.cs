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
        private int targetID;
        public MakeContractWindow(int uid)
        {
            InitializeComponent();
            targetID = uid;
            SystemAccountHandler sah = new SystemAccountHandler();
            if (App.cookie.type == "Club")
            {
                clubNameBox.Text = sah.retrieveClubData(App.cookie.uid).name;
                playerNameBox.Text = sah.retrievePlayerData(uid).lastName + " " + sah.retrievePlayerData(uid).firstName + sah.retrievePlayerData(uid).middleName;
            }
            else if (App.cookie.type == "Player")
            {
                clubNameBox.Text = sah.retrieveClubData(uid).name;
                playerNameBox.Text = sah.retrievePlayerData(App.cookie.uid).lastName + " " + sah.retrievePlayerData(App.cookie.uid).firstName + sah.retrievePlayerData(App.cookie.uid).middleName;
            }
            else
            {
                MessageBox.Show("비 정상적인 접근 입니다.");
                Close();
            }
        }

        private void ContractBtn_Click(object sender, RoutedEventArgs e)
        {
            int clubuid = 0, playeruid = 0;

            if (App.cookie.type == "Club")
            {
                clubuid = App.cookie.uid;
                playeruid = targetID;
            } else if (App.cookie.type == "Player")
            {
                clubuid = targetID;
                playeruid = App.cookie.uid;
            }
            else
            {
                MessageBox.Show("비 정상적인 접근 입니다.");
                Close();
            }

            // Validation


            // Value
            string startDate = startDateBox.Text;
            string endDate = endDateBox.Text;
            int transferFee = Convert.ToInt32(tranferFeeBox.Text);
            int yearlyPay = Convert.ToInt32(yearlyPayBox.Text);
            int penalityFee = Convert.ToInt32(penaltyBox.Text);

            SystemAccountHandler sah = new SystemAccountHandler();
            if (sah.makeContract(clubuid, playeruid, startDate, endDate, transferFee, yearlyPay, penalityFee))
            {
                MessageBox.Show("계약서를 성공적으로 전달했습니다.");
                Close();
            }
            else
            {
                MessageBox.Show("계약서를 전달하는데 실패했습니다.");
                Close();
            }
        }
    }
}
