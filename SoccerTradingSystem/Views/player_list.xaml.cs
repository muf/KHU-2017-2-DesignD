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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// player_list.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class player_list : Page
    {
        public player_list()
        {
            InitializeComponent();
        }

        private void OnPageLoad(object sender, RoutedEventArgs e)
        {
            PlayersDataGridSetting("");
        }

        // 플레이어 그리드에서 더블 클릭시 선수 정보 창을 생성
        private void Player_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerDetailWindow _PlyaerDetailWindow = new PlayerDetailWindow();
            _PlyaerDetailWindow.Show();
        }

        // 플레이어 그리드 구성
        public void PlayersDataGridSetting(string context)
        {
            SystemAccountHandler sah = new SystemAccountHandler();
            List<Player> list = sah.retrievePlayerData(context);

            // DataTable 생성
            DataTable dataTable = new DataTable();

            // 컬럼 생성
            dataTable.Columns.Add("uid", typeof(string));
            dataTable.Columns.Add("pid", typeof(string));
            dataTable.Columns.Add("email", typeof(string));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("birth", typeof(string));
            dataTable.Columns.Add("position", typeof(string));
            dataTable.Columns.Add("weight", typeof(string));
            dataTable.Columns.Add("height", typeof(string));
            dataTable.Columns.Add("status", typeof(string));
            dataTable.Columns.Add("authenticated", typeof(string));

            // 데이터 생성
            for (int i = 0; i < list.Count; i++)
            {
                string uid = Convert.ToString(list[i].uid);
                string pid = Convert.ToString(list[i].playerId);
                string email = list[i].email;
                string name = list[i].firstName + list[i].middleName + list[i].lastName;
                string birth = Convert.ToString(list[i].birth);
                string postion = Convert.ToString(list[i].position);
                string weight = Convert.ToString(list[i].weight);
                string height = Convert.ToString(list[i].height);
                string status = list[i].status;
                string authenticated = (list[i].authenticated) ? "TRUE" : "FALSE";
                dataTable.Rows.Add(new string[] { uid, pid, email, name, birth, postion, weight, height, status, authenticated });
            }

            // DataTable의 Default View를 바인딩하기
            playerDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void plyaerSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayersDataGridSetting(playerSearchBox.Text);
        }
    }
}