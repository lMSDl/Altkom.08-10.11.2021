using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class DiceWindow : Window, INotifyPropertyChanged
    {
        private int maximumProgress;
        private int progress;
        private bool indeterminateProgress;

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
        public int MaximumProgress
        {
            get => maximumProgress;
            set
            {
                maximumProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaximumProgress)));
            }
        }
        public int Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }
        public bool IndeterminateProgress
        {
            get => indeterminateProgress;
            set
            {
                indeterminateProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IndeterminateProgress)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            var items = Results.Where(x => !x.IsSelected).ToList();
            //MaximumProgress = items.Count * 100;
            MaximumProgress = 1;
            Progress = 0;
            IndeterminateProgress = true;

            Task.Run(() =>
            {
                var random = new Random();

                foreach (var item in Results)
                {
                    if (item.IsSelected)
                        continue;

                    int numberOfRolls = random.Next(25, 75);
                    for (int i = 0; i < numberOfRolls; i++)
                    {
                        item.Value = random.Next(1, 7);
                        Thread.Sleep(25);
                        Progress++;
                    }
                }
                Progress = MaximumProgress;
                IndeterminateProgress = false;

            });
        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dice = button.DataContext as Dice;
            dice.IsSelected = !dice.IsSelected;
        }
    }
}
