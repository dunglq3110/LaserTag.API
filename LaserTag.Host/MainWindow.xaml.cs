﻿using LaserTag.Host.Logic;
using LaserTag.Host.Models;
using LaserTag.Host.Views;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaserTag.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MatchPage matchPage;
        private GameProgressPage gameProgressPage;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = GameManager.Instance;

            matchPage = new MatchPage();
            gameProgressPage = new GameProgressPage();
            GameManager.Instance.StartWebSocketServer();
            MainFrame.Navigate(matchPage);
        }
        private void WifiConnect_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.StartWebSocketServer();
        }

        private void MatchButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(matchPage);
            //MatchButton.BorderBrush = (SolidColorBrush)FindResource("AccentColorBrush");
            GameProgressButton.BorderBrush = Brushes.Transparent;
        }

        private void GameProgressButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(gameProgressPage);
            //GameProgressButton.BorderBrush = (SolidColorBrush)FindResource("AccentColorBrush");
            MatchButton.BorderBrush = Brushes.Transparent;
        }
        private void NewMatch_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.NewMatch();
        }
        private void StartMatch_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.StartMatch();
        }
        private void EndMatch_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.EndMatch();
        }


        private void NewRound_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.NewRound();
        }
        private void StartRound_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.StartRoundBuyPhase();
        }
        private void BattlePhase_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.BattlePhase();
        }
        private void EndRound_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.EndRound();
        }
        private void PauseRound_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.PauseRound();
        }
        private void ResumeRound_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.ResumeRound();
        }
        

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is "Z" for debugger
            if (e.Key == Key.Z)
            {
                GameManager.Instance.Test();
            }
        }


    }
}