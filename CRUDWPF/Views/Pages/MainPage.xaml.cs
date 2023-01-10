using CRUDWPF.Context;
using CRUDWPF.Model;
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

namespace CRUDWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource= Appdata.db.Product.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Action(new Model.Product()));
        }

        private void txb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView.ItemsSource = Appdata.db.Product.Where(item => item.ID.ToString().Contains(txb1.Text) || item.Name.Contains(txb1.Text)).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Product)DataView.SelectedItem;
            if (selectedItem != null)
            {
                Appdata.db.Product.Remove(selectedItem);
                Appdata.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Удаление завершенно! ", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Product)DataView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new Action(selectedItem));
            }
        }
    }
}
