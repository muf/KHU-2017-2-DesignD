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
using System.Data;

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// user_info.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class user_info : Page
    {
        public user_info()
        {
            InitializeComponent();
        }
        private void OnPageLoad(object sender, RoutedEventArgs e)
        {
            Load();
        }
        public void Load()
        {
            try
            {
                // DataTable 생성
                DataTable dataTable = new DataTable();

                // 컬럼 생성
                dataTable.Columns.Add("ID", typeof(string));
                dataTable.Columns.Add("email", typeof(string));
                dataTable.Columns.Add("name", typeof(string));
                dataTable.Columns.Add("birth", typeof(string));
                dataTable.Columns.Add("position", typeof(string));
                dataTable.Columns.Add("weight", typeof(string));
                dataTable.Columns.Add("height", typeof(string));
                dataTable.Columns.Add("status", typeof(string));
                dataTable.Columns.Add("authenticated", typeof(string));

                // 데이터 생성
                dataTable.Rows.Add(new string[] { "1", "fkrlsp2@naver.com", "JinHa Hwang", "1994-01-29", "GW", "80", "192", "FREE", "TRUE" });

                // DataTable의 Default View를 바인딩하기
                playerDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No PDF linked!");
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            // Some operations with this row
        }

    }
}
