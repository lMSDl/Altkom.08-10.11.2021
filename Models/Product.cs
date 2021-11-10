using System;
using System.ComponentModel;

namespace Models
{
    public class Product : NotifyPropertyChanged, ICloneable
    {
        private string name;
        private DateTime expirationDate;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                expirationDate = value;
                OnPropertyChanged();
            }
        }
        public decimal Price { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
