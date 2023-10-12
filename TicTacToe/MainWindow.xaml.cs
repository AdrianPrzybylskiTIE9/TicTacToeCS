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

        public MainWindow()
        {
            InitializeComponent();
            RestartGame();
        }

        private void RestartGame()
        {
            List<Button> buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            
            foreach (Button button in buttons) {
                button.IsEnabled = true;
                button.Content = "";

            }
        }

        private void playerMove(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
