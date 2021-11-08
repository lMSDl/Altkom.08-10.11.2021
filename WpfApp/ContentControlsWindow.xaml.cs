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

namespace WpfApp
{
    /// <summary>
    /// Logika interakcji dla klasy ContentControlsWindow.xaml
    /// </summary>
    public partial class ContentControlsWindow : Window
    {
        public ContentControlsWindow()
        {
            InitializeComponent();
            MyTextBlock.Inlines.Add(new Run("underline") { TextDecorations = TextDecorations.Underline });
            MyTextBlock.Inlines.Add(new Run("bold") { FontWeight = FontWeights.Bold });        

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Projekt zapisany", "Zapis", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckBox_Master_Click(object sender, RoutedEventArgs e)
        {
            CheckBox1.IsChecked = CheckBox2.IsChecked = CheckBox3.IsChecked = (sender as CheckBox).IsChecked;
        }

        private void CheckBox_Slave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked == true && CheckBox2.IsChecked == true && CheckBox3.IsChecked == true)
                CheckBox.IsChecked = true;
            else if (CheckBox1.IsChecked == true || CheckBox2.IsChecked == true || CheckBox3.IsChecked == true)
                CheckBox.IsChecked = null;
            else
                CheckBox.IsChecked = false;
        }
    }
}
