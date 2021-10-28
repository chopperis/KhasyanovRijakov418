﻿using System;
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

namespace KhasyanovRijakov418.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text) || string.IsNullOrEmpty(password.Password)) {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new Entities())
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password);

                if (user == null) {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }

                MessageBox.Show("Пользователь успешно найден!");

                switch (user.Role) {
                    case "Customer":
                        NavigationService?.Navigate(new Menu());
                        break;
                    case "Director":
                        NavigationService?.Navigate(new DirectorMenu());
                        break;
                }
            }
        }

      

        private void ButtonRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegPage());
        }
    }
}
