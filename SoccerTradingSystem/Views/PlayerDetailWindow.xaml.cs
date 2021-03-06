﻿using System;
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
        private int curPlayerUid;

        public PlayerDetailWindow(int uid)
        {
            InitializeComponent();
            curPlayerUid = uid;
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

            SystemAccountHandler sah = new SystemAccountHandler();
            Player curPlayer = sah.retrievePlayerData(curPlayerUid);

            string pName = curPlayer.firstName + curPlayer.middleName +" "+ curPlayer.lastName;
            string pBirth = curPlayer.birth.ToString();
            string pPosition = curPlayer.position;
            string pWeight = curPlayer.weight.ToString();
            string pHeight = curPlayer.height.ToString();

            nameBlock.Text = pName;
            birthBlock.Text = pBirth;
            positionBlock.Text = pPosition;
            weightBlock.Text = pWeight;
            heightBlock.Text = pHeight;
        }

        private void PlayerOfferBtn_Click(object sender, RoutedEventArgs e)
        {
            MakeContractWindow _MakeContractWindow = new MakeContractWindow(curPlayerUid);
            _MakeContractWindow.Show();
        }
    }
}
