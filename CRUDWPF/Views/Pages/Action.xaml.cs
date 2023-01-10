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
    /// Логика взаимодействия для Action.xaml
    /// </summary>
    public partial class Action : Page
    {
         public Product Product { get; set; }

        public Action(Product Product)
        {
            InitializeComponent();
            this.Product = Product;
            this.DataContext = this;
        }


        private void Savebtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Product.ID == 0)
            {
                Appdata.db.Product.Add(Product);
            }
            Appdata.db.SaveChanges();
            MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
    }
}
    