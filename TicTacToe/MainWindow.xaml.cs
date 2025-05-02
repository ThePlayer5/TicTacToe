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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isXTurn = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Content != null) return;

            btn.Content = _isXTurn ? "X" : "0";
            _isXTurn = !_isXTurn; // Отдаём ход ноликам
            CheckWinner();
        }
        private void CheckWinner()
        {
            string[,] field = new string[3, 3];
            int index = 0;

            foreach (Button btn in GameGrid.Children) // Chidlren - хранит все дочерние элементы, в данном случае кнопки внутри UniformGrid
            {
                field[index / 3, index % 3] = btn.Content?.ToString();
                index++;
            }

            for (int i = 0; i < 3; i++)
            {
                // rows
                if (field[i, 0] != null && field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2]) ShowWinner(field[i, 0]);
                // Пишем field[i, 0] для того чтобы положить в место параметра елемент, которыйй стоит по данным координатам, если там 0 или Х выведется победа одной из сторон

                // columns
                if (field[0, i] != null && field[0, i] == field[1, i] && field[1, i] == field[2, i]) ShowWinner(field[0, i]);
            }
            if (field[0, 0] != null && field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) ShowWinner(field[0, 0]);
            if (field[0, 2] != null && field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0]) ShowWinner(field[0, 2]);
        }
        private void ShowWinner(string winner)
        {
            MessageBox.Show($"{winner} победил!", "Игра окончена");
            foreach (Button btn in GameGrid.Children)
            {
                btn.Content = null;
            }
            _isXTurn = true;
        }

        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in GameGrid.Children)
            {
                btn.Content = null;
            }
            _isXTurn = true;
        }
    }
}
