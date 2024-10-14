using LaserTag.Host.Logic;
using LaserTag.Host.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MatchPage.xaml
    /// </summary>
    public partial class MatchPage : Page
    {
        public MatchPage()
        {
            InitializeComponent();
            DataContext = GameManager.Instance;
        }
        private void PlayerCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Player player)
            {
                PlayerDetailsWindow detailsWindow = new PlayerDetailsWindow(player);
                detailsWindow.Owner = Window.GetWindow(this);
                detailsWindow.ShowDialog();
            }
        }

        private void PlayerCard_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement element)
            {
                DragDrop.DoDragDrop(element, element.DataContext, DragDropEffects.Move);
            }
        }

        private void TeamListView_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListView targetListView && e.Data.GetData(typeof(Player)) is Player player)
            {
                var sourceTeam = GetSourceTeam(player);
                var targetTeam = GetTargetTeam(targetListView);

                if (sourceTeam != null && targetTeam != null && sourceTeam != targetTeam)
                {
                    GameManager.Instance.MovePlayer(player, sourceTeam, targetTeam);
                }
            }
        }

        private ObservableCollection<Player> GetSourceTeam(Player player)
        {
            if (GameManager.Instance.Team1Players.Contains(player)) return GameManager.Instance.Team1Players;
            if (GameManager.Instance.Team2Players.Contains(player)) return GameManager.Instance.Team2Players;
            if (GameManager.Instance.Team3Players.Contains(player)) return GameManager.Instance.Team3Players;
            if (GameManager.Instance.Team4Players.Contains(player)) return GameManager.Instance.Team4Players;
            return null;
        }

        private ObservableCollection<Player> GetTargetTeam(ListView listView)
        {
            if (listView.Name == "Team1ListView") return GameManager.Instance.Team1Players;
            if (listView.Name == "Team2ListView") return GameManager.Instance.Team2Players;
            if (listView.Name == "Team3ListView") return GameManager.Instance.Team3Players;
            if (listView.Name == "Team4ListView") return GameManager.Instance.Team4Players;
            return null;
        }
    }
}
