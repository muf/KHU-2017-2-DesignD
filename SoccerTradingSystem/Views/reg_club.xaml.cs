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

namespace SoccerTradingSystem.Views
{
    /// <summary>
    /// reg_club.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class reg_club : Page
    {
        private Window regWindow;
        public reg_club(Window _regWindow)
        {
            InitializeComponent();
            regWindow = _regWindow;
        }
    }
}