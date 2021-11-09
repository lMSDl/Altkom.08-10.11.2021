using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Dice : INotifyPropertyChanged
    {
        private int _value;
        private bool isSelected;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
