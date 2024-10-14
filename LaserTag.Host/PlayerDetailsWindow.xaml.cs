using LaserTag.Host.Models;
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

namespace LaserTag.Host
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow(Player player)
        {
            InitializeComponent();
            DataContext = player;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
