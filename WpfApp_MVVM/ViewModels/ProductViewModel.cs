using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;
using WpfApp_MVVM.Models;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            Product = product;

            OkCommand = new RelayCommand(x => Ok((Window)x), x => !Product.HasErrors);
        }

        private void Ok(Window window)
        {
            window.DialogResult = true;
        }

        public bool? DialogResult { get; set; }

        public Product Product { get; set; }

        public ICommand OkCommand { get; set; }
    }
}
