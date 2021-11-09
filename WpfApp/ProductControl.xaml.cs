using Models;
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

namespace WpfApp
{
    /// <summary>
    /// Logika interakcji dla klasy ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register(nameof(Product), typeof(Product), typeof(ProductControl), new PropertyMetadata(null, ProductPropertyChanged));

        private static void ProductPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ((ProductControl)obj).Product = (Product)args.NewValue;
        }

        public Product Product {
            get => (Product)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }
    }
}
