using Models;
using Models.Fakers;
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
            InitializeComponent();
            DataContext = this;
            StringCollection = "Ala ma kota i trzy psy".Split(' ').ToList();

            Products = new ProductFaker().Generate(15);

        }

        public IEnumerable<string> StringCollection { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
