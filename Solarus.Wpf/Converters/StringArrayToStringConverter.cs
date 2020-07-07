using System;
using System.Globalization;
using System.Windows.Data;

namespace Solarus.Wpf.Converters
{
    [ValueConversion(typeof(string[]), typeof(string))]
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;

            if (value.GetType() != typeof(string[]))
                return value;

            return string.Join(", ", (string[])value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
