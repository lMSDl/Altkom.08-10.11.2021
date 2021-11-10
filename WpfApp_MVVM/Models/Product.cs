using FluentValidation.Results;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp_MVVM.Models.Validators;

namespace WpfApp_MVVM.Models
{
    public class Product : NotifyPropertyChanged, ICloneable, INotifyDataErrorInfo
    {
        private string name;
        private DateTime expirationDate = DateTime.Now;
        private decimal price;
        private ProductValidator _validator = new ProductValidator();
        private ValidationResult _validationResult; 

        private Dictionary<string, string> _errorDictionary = new Dictionary<string, string>();

        #region INotifyDataErrorInfo
        public bool HasErrors => !_validationResult?.IsValid ?? false;// _errorDictionary.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            //return _errorDictionary.Where(x => x.Key == propertyName).Select(x => x.Value);
            return _validationResult?.Errors.Where(x => x.PropertyName == propertyName).Select(x => x.ErrorMessage).ToList();
        }

        #endregion INotifyDataErrorInfo

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);
            OnErrorsChanged();
        }

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

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        private void OnErrorsChanged([CallerMemberName] string propertyName = "")
        {
            //Validate();
            _validationResult = _validator.Validate(this);
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
