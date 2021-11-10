using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_MVVM.Commands;
using WpfApp_MVVM.Models;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>();

            AddCommand = new RelayCommand(x => AddProduct(new Product()), x => true);
            EditCommand = new RelayCommand(x => EditProduct(), x => SelectedProduct != null);
            RemoveCommand = new RelayCommand(x => RemoveProduct(), x => SelectedProduct != null);
        }

        private void RemoveProduct()
        {
            Products.Remove(SelectedProduct);
        }

        private void AddProduct(Product product)
        {
            var dialog = new AlternativeProductWindow(new ProductViewModel(product));
            var result = dialog.ShowDialog();
            if(result == true)
            {
                Products.Add(product);
            }
        }
        private void EditProduct()
        {
            var product = (Product)SelectedProduct.Clone();
            AddProduct(product);
            if (Products.Contains(product))
                Products.Remove(SelectedProduct);
        }

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
    }


}
