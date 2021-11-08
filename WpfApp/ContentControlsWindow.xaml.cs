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
    }
}
