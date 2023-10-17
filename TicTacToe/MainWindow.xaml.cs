using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public enum Player
        {
            X, O
        }
        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int cpuWinCount = 0;
        bool gameStatus = false;
        List<Button> buttons;
        string[,] board;

        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void RestartGame()
        {
            buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            board = new string[3, 3];

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
                currentPlayer = Player.X;
                button.Content = currentPlayer.ToString();
                button.IsEnabled = false;
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                buttons.Remove(button);
                UpdateBoard(row, col, currentPlayer);
                CheckGame();
                CpuMove();
            }

        }

        private void CpuMove()
        {
            if (buttons.Count > 0 && gameStatus)
            {
                int index = random.Next(buttons.Count);
                currentPlayer = Player.O;
                buttons[index].IsEnabled = false;
                buttons[index].Content = currentPlayer.ToString();
                int row = Grid.GetRow(buttons[index]);
                int col = Grid.GetColumn(buttons[index]);
                buttons.RemoveAt(index);
                UpdateBoard(row, col, currentPlayer);
                CheckGame();
            }
        }

        private void CheckGame()
        {
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
            var playerSymbol = player.ToString();

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == playerSymbol && board[i, 1] == playerSymbol && board[i, 2] == playerSymbol)
                {
                    return true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == playerSymbol && board[1, j] == playerSymbol && board[2, j] == playerSymbol)
                {
                    return true;
                }
            }

            if (board[0, 0] == playerSymbol && board[1, 1] == playerSymbol && board[2, 2] == playerSymbol)
            {
                return true;
            }

            if (board[0, 2] == playerSymbol && board[1, 1] == playerSymbol && board[2, 0] == playerSymbol)
            {
                return true;
            }

            return false;
        }

        private void UpdateBoard(int row, int col, Player player)
        {
            board[row, col] = player.ToString();
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}