using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
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

            foreach (Button button in buttons)
            {
                button.Content = " ";
                button.IsEnabled = true;
                playerScore.Text = $"Player: {playerWinCount}";
                cpuScore.Text = $"CPU: {cpuWinCount}";

            }
            gameStatus = true;
        }

        private void PlayerMove(object sender, RoutedEventArgs e)
        {
            if (gameStatus)
            {
                var button = (Button)sender;
                currentPLayer = Player.X;
                button.Content = currentPLayer.ToString();
                button.IsEnabled = false;
                buttons.Remove(button);
                CheckGame();
                CpuMove();
            }

        }

        private void CpuMove()
        {
            if (buttons.Count > 0 && gameStatus)
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

            //MessageBox.Show($"btn1 = {btn1.Content} btn2 = {btn2.Content} btn3 = {btn3.Content} btn4 = {btn4.Content} btn5 = {btn5.Content} btn6 = {btn6.Content} btn7 = {btn6.Content} btn8 = {btn8.Content} btn9 = {btn9.Content}");
            if (IsWinner(Player.X))
            {
                MessageBox.Show("Gracz X wygrał!");
                gameStatus = false;
                playerWinCount++;
                playerScore.Text = $"Player: {playerWinCount}";
            }
            else if (IsWinner(Player.O))
            {
                MessageBox.Show("Gracz O (CPU) wygrał!");
                gameStatus = false;
                cpuWinCount++;
                cpuScore.Text = $"CPU: {cpuWinCount}";
            }
            else if (buttons.Count == 0)
            {
                MessageBox.Show("Remis!");
                gameStatus = false;
            }
        }

        private bool IsWinner(Player player)
        {
            string playerSymbol = player.ToString();
            return (
                (btn1.Content == playerSymbol && btn2.Content == playerSymbol && btn3.Content == playerSymbol) ||
                (btn4.Content == playerSymbol && btn5.Content == playerSymbol && btn6.Content == playerSymbol) ||
                (btn7.Content == playerSymbol && btn8.Content == playerSymbol && btn9.Content == playerSymbol) ||
                (btn1.Content == playerSymbol && btn4.Content == playerSymbol && btn7.Content == playerSymbol) ||
                (btn2.Content == playerSymbol && btn5.Content == playerSymbol && btn8.Content == playerSymbol) ||
                (btn3.Content == playerSymbol && btn6.Content == playerSymbol && btn9.Content == playerSymbol) ||
                (btn1.Content == playerSymbol && btn5.Content == playerSymbol && btn9.Content == playerSymbol) ||
                (btn3.Content == playerSymbol && btn5.Content == playerSymbol && btn7.Content == playerSymbol)
            );
        }


        private void RestartGame(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}