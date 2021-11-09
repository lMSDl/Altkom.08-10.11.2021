using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp.Converters
{
    public class DateTimeToDaysConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.Subtract(DateTime.Now).TotalDays;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var days = (int)value;
            return DateTime.Now.AddDays(days);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
