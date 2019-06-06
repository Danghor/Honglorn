using System;
using System.Globalization;
using System.Windows.Data;

namespace HonglornWPF.Converter
{
    public class DateTimeToDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as DateTime?)?.ToShortDateString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}