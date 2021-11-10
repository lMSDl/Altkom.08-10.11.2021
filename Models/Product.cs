using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Product : NotifyPropertyChanged, ICloneable, IDataErrorInfo, INotifyDataErrorInfo
    {
        private string name;
        private DateTime expirationDate;


        private Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();

        #region IDataErrorInfo
        public string this[string columnName] => _errorDictionary.TryGetValue(columnName, out var value) ? value : null;
        public string Error => string.Join("\n", _errorDictionary.Select(x => x.Value));
        #endregion IDataErrorInfo

        # region INotifyDataErrorInfo
        public bool HasErrors => _errorDictionary.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorDictionary.Where(x => x.Key == propertyName).Select(x => x.Value);
        }
        #endregion INotifyDataErrorInfo


        //Exception Validation - podczas bindingu w XAML ustawiamy ValidatesOnExceptions
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 30 || value.Length < 1)
                {
                    throw new ArgumentException("Name is too long. Must have 1-30 characters");
                }
                else
                {
                    name = value;
                }
                OnPropertyChanged();
            }
        }

        //IDataErrorInfo/INotifyDataErrorInfo - podczas bindingu w XAML ustawiamy odpowiednio ValidatesOnDataErrors/ValidatesOnNotifyDataErrors
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                if (value < DateTime.Now)
                {
                    _errorDictionary[nameof(ExpirationDate)] = "Date must be in future.";
                }
                else
                {
                    _errorDictionary.Remove(nameof(ExpirationDate));
                    expirationDate = value;
                }
                OnErrorsChanged();
                OnPropertyChanged();
            }
        }

        private void OnErrorsChanged([CallerMemberName] string propertyName = "")
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }

        //Validation Rules - walidacja całkowicie po stronie XAML
        public decimal Price { get; set; }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
