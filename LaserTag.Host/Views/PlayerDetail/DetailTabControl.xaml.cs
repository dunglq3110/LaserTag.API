﻿using LaserTag.Host.Models;
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

namespace LaserTag.Host.Views.PlayerDetail
{
    /// <summary>
    /// Interaction logic for DetailTabControl.xaml
    /// </summary>
    public partial class DetailTabControl : UserControl
    {
        private readonly Player _player;

        public DetailTabControl(Player player)
        {
            InitializeComponent();
            _player = player;
            DataContext = _player;
        }
    }
}
