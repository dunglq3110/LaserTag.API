﻿using LaserTag.Host.Logic;
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

namespace LaserTag.Host.Views
{
    /// <summary>
    /// Interaction logic for GameProgressPage.xaml
    /// </summary>
    public partial class GameProgressPage : Page
    {
        public GameProgressPage()
        {
            InitializeComponent();
            DataContext = GameManager.Instance;
        }
    }
}