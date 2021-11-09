using Models;
using Models.Fakers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Logika interakcji dla klasy ItemsControlsWindow.xaml
    /// </summary>
    public partial class ItemsControlsWindow : Window
    {
        public ItemsControlsWindow()
        {
            DataContext = this;
            StringCollection = "Ala ma kota i trzy psy".Split(' ').ToList();

            Products = new ObservableCollection<Product>(new ProductFaker().Generate(15).OrderBy(x => x.Price).ToList());
            InitializeComponent();
        }

        public IEnumerable<string> StringCollection { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product();
            var window = new ProductWindow(product);
            var result = window.ShowDialog();

            if (result == true)
                Products.Add(product);
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct == null)
                return;
            var product = (Product)SelectedProduct.Clone();
            var window = new ProductWindow(product);
            var result = window.ShowDialog();
            if(result == true)
            {
                Products.Remove(SelectedProduct);
                Products.Add(product);
            }

        }
    }
}
