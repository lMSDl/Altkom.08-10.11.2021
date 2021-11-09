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
    /// Logika interakcji dla klasy DiceWindow.xaml
    /// </summary>
    public partial class DiceWindow : Window
    {
        public DiceWindow()
        {
            InitializeComponent();
            DataContext = this;

            Results = new ObservableCollection<Dice>();
            NumberOfDice = 10;
            Button_Clear_Click(null, null);
        }

        public int NumberOfDice { get; set; }
        public ObservableCollection<Dice> Results { get; set; }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Results.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                Results.Add(new Dice());
            }
        }
        private void Button_Roll_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            foreach (var item in Results)
            {
                if (!item.IsSelected)
                    item.Value = random.Next(1, 7);
            }
        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = !dice.IsSelected;
        }
    }
}
