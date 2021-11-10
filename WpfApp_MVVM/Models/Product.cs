using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WpfApp_MVVM.Models
{
    public class Product : NotifyPropertyChanged, ICloneable, INotifyDataErrorInfo
    {
        private string name;
        private DateTime expirationDate = DateTime.Now;
        private decimal price;


        private Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();

        #region INotifyDataErrorInfo
        public bool HasErrors => _errorDictionary.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorDictionary.Where(x => x.Key == propertyName).Select(x => x.Value);
        }
        #endregion INotifyDataErrorInfo

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();

                OnErrorsChanged();
            }
        }

        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                expirationDate = value;
                OnPropertyChanged();

                OnErrorsChanged();
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();

                OnErrorsChanged();
            }
        }
        private void OnErrorsChanged([CallerMemberName] string propertyName = "")
        {
            Validate();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void Validate()
        {
            _errorDictionary.Clear();

            if (ExpirationDate < DateTime.Now)
            {
                _errorDictionary[nameof(ExpirationDate)] = "Date must be in future.";
            }

            if (Name == null || Name.Length > 30 || Name.Length < 1)
            {
                _errorDictionary[nameof(Name)] = "Name is too long. Must have 1-30 characters.";
            }

            if (Price <= 0 || Price > 100)
            {
                _errorDictionary[nameof(Price)] = "Price must be between 1-100.";
            }
        }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
