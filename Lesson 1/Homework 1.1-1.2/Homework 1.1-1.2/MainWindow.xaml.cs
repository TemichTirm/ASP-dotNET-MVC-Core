using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Homework_1._1_1._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isQuit = false;
        public MainWindow()
        {
            InitializeComponent();
            ThreadStart fibonachi = new ThreadStart(Fibonachi);
            Thread thread = new Thread(fibonachi);
            thread.Start();
        }
        /// <summary> 
        /// Вычисляет в цикле число из последовательности Фибоначчи и обновляет данные в TextBox
        /// </summary>        
        private void Fibonachi()
        {
            int delay = 1000;
            ulong sumPrev = 0;
            ulong sum = 1;
            while (true)
            {
                if (!isQuit)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                    {
                        delay = (int)DelayInput.Value;
                        FibonachiTextBox.Text = sumPrev.ToString();
                    }));
                    Thread.Sleep(delay);
                    ulong next = sum + sumPrev;
                    sumPrev = sum;
                    sum = next;
                }
                else
                {
                    Thread.CurrentThread.Abort();
                }
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Выход"
        /// </summary>
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            isQuit = true;
            Close();
        }
    }
}
