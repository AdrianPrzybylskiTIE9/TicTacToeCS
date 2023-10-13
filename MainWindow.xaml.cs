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
        bool gameStatus = false;
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
            gameStatus = true;
        }

        private void playerMove(object sender, RoutedEventArgs e)
        {
            if (gameStatus)
            {
                var button = (Button)sender;
                currentPLayer = Player.X;
                button.Content = currentPLayer.ToString();
                button.IsEnabled = false;
                buttons.Remove(button);
                CheckGame();
                cpuMove();
            }

        }

        private void cpuMove()
        {
            if(buttons.Count > 0  && gameStatus)
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
            if (IsWinner(Player.X))
            {
                playerWinCount++;
                MessageBox.Show("Gracz X wygrał!");
                gameStatus = false;
                playerWinCount++;
            }
            else if (IsWinner(Player.O))
            {
                cpuWinCount++;
                MessageBox.Show("Gracz O (CPU) wygrał!");
                gameStatus = false;
                cpuWinCount++;
            }
            else if (buttons.Count == 0)
            {
                MessageBox.Show("Remis!");
                gameStatus = false;
            }
        }

        private bool IsWinner(Player player)
        {
            if (
                (btn1.Content == player.ToString() && btn2.Content == player.ToString() && btn3.Content == player.ToString()) ||
                (btn4.Content == player.ToString() && btn5.Content == player.ToString() && btn6.Content == player.ToString()) ||
                (btn7.Content == player.ToString() && btn8.Content == player.ToString() && btn9.Content == player.ToString()) ||
                (btn1.Content == player.ToString() && btn4.Content == player.ToString() && btn7.Content == player.ToString()) ||
                (btn2.Content == player.ToString() && btn5.Content == player.ToString() && btn8.Content == player.ToString()) ||
                (btn3.Content == player.ToString() && btn6.Content == player.ToString() && btn9.Content == player.ToString()) ||
                (btn1.Content == player.ToString() && btn5.Content == player.ToString() && btn9.Content == player.ToString()) ||
                (btn3.Content == player.ToString() && btn5.Content == player.ToString() && btn7.Content == player.ToString()))
            {
                return true;
            }
            return false;
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}
