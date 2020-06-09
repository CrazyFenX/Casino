using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

namespace Casino
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double delta = 9.7297297;
        int[] numbers = new int[37] {0,32,15,19,4,21,2,25,17,34,6,27,13,36,11,30,8,23,10,5,24,16,33,1,20,14,31,9,22,18,29,7,28,12,35,3,26};
        public MainWindow()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\Универ\ОП\решения для себя\Casino\Casino\Sounds\main_music.wav");
            player.Play();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double board = 350.3;
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10)
            int value = rnd.Next(0, 36);
            //MessageBox.Show(Convert.ToString(value) + "it's: " + Convert.ToString(numbers[value]));

            board = (37-value)*delta;
            Spin(board, value);
        }
        public async void Spin(double board, int value)
        {
            double angle = 0;
            
            for (int j = 0; j < 3; j++)
            {
                angle = 0;
                while (angle < 350.3)
                {
                    //System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@"D:\Универ\ОП\решения для себя\Casino\Casino\Sounds\rouletka.wav");
                    //player1.Play();
                    RotateTransform rt = new RotateTransform(angle += delta, 0.5, 0.5);
                    image1.RenderTransform = rt;
                    await Task.Delay(16);
                }
            }
            //MessageBox.Show("");
            int i = 1;
            angle = 0;
            while (angle < board)
            {
                RotateTransform rt = new RotateTransform(angle += delta, 0.5, 0.5);
                image1.RenderTransform = rt;
                await Task.Delay(16 + i*i);
                i ++;
            }
            MessageBox.Show("it's " + Convert.ToString(numbers[value]));
        }
    }
}
