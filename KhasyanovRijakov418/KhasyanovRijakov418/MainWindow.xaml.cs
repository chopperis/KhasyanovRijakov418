using KhasyanovRijakov418.Pages;
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
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace KhasyanovRijakov418
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";

            if (page is AuthPage)
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible;
            }

            if (!(e.Content is Page Calc)) return;
            if (Calc is calc)
            {
                ButtonCalc.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonCalc.Visibility = Visibility.Visible;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }

        private void button_calc(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new calc();
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            string path = "export.txt";
            StreamWriter sw = new StreamWriter(path);

            using (var db = new Entities())
            {
                string IDline;

                IDline = String.Join(
                    ":", db.Users.Select(x => x.ID));
                IDline = DelP(IDline);
                sw.WriteLine(IDline);

                IDline = String.Join(
                    ":", db.Users.Select(x => x.FIO));
                IDline = DelP(IDline);
                sw.WriteLine(IDline);

                IDline = String.Join(
                    ":", db.Users.Select(x => x.Login));
                IDline = DelP(IDline);
                sw.WriteLine(IDline);

                IDline = String.Join(
                    ":", db.Users.Select(x => x.Password));
                IDline = DelP(IDline);
                sw.WriteLine(IDline);

                IDline = String.Join(
                    ":", db.Users.Select(x => x.Role));
                IDline = DelP(IDline);
                sw.WriteLine(IDline);

                sw.Close();

                Process.Start("notepad.exe", path);
            }
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader sr = new StreamReader(ofd.FileName); //открываем файл
                while (!sr.EndOfStream) // перебираем строки, пока они не
                {
                    string[] lines = new string[5];// массив данных
                    for (int i = 0; i < 5; i++) // читаем 5 строк
                    {
                        string line = sr.ReadLine(); // читаем строку
                        string[] data = line.Split(':');
                        line = ""; // обнуляем переменную
                        if (data.Length >= 2) // проверяем на целостностьданных
                        {
                            for (int j = 1; j < data.Length; j++) // складываем данные
                            {
                                line += data[j]; // собираем строку
                            }
                        }
                        lines[i] = line; // записываем значения в массив
                    }
                    // выводим данные
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] +
                    "\nФИО: " + lines[1] + "\nЛогин: " + lines[2] + "\nПароль: " +
                    lines[3] + "\nРоль: " + lines[4]);
                }
            }
            else MessageBox.Show("Файл для импорта не выбран!");
        }

        public string DelP(string text) {
            return text = text.Trim(new char[] { ' ' });
        }
    }
}
