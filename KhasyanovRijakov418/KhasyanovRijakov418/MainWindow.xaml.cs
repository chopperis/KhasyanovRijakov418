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
                string IDline = String.Join(
                    ":", db.Users.Select(x => x.Login),
                    ":", db.Users.Select(x => x.Password),
                    ":", db.Users.Select(x => x.Role),
                    ":", db.Users.Select(x => x.FIO),
                    ":", db.Users.Select(x => x.ID));
                sw.WriteLine(IDline);
                sw.Close();

                Process.Start("notepad.exe", path);
            }
        }
    }
}
