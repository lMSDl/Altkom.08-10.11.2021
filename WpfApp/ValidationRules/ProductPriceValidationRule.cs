using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp.ValidationRules
{
    public class ProductPriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse((string)value, NumberStyles.Number, CultureInfo.InvariantCulture, out var price))
            {
                if (price <= 0 || price > 100)
                {
                    return new ValidationResult(false, "Price must be between 1-100");
                }
            }
            else
            {
                return new ValidationResult(false, "Bad value");
            }
            return new ValidationResult(true, null);
        }
    }
}
