using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Player
        {
            X, O
        }
        Player currentPLayer;
        Random random = new Random();
        int playerWinCount = 0;
        int cpuWinCount = 0;
        List<Button> buttons;

        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void RestartGame()
        {
            buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            
            foreach (Button button in buttons) {
                button.IsEnabled = true;
                button.Content = "";

            }
        }

        private void playerMove(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentPLayer = Player.X;
            button.Content = currentPLayer.ToString();
            button.IsEnabled = false;
            buttons.Remove(button);
            CheckGame();
            cpuMove();

        }

        private void cpuMove()
        {
            if(buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                currentPLayer = Player.O;
                buttons[index].IsEnabled = false;
                buttons[index].Content = currentPLayer.ToString();
                buttons.RemoveAt(index);
                CheckGame();
            }
        }

        private void CheckGame()
        {
            
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}
