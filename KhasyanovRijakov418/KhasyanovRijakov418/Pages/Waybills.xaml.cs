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

namespace KhasyanovRijakov418.Pages
{
    /// <summary>
    /// Логика взаимодействия для Waybills.xaml
    /// </summary>
    public partial class Waybills : Page
    {
        public Waybills()
        {
            InitializeComponent();
            DataGridCar.ItemsSource = Entities.GetContext().Waybill.ToList();
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
