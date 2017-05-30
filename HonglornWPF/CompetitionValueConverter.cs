using System;
using System.Globalization;
using System.Windows.Data;

namespace HonglornWPF
{
    class CompetitionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => string.IsNullOrWhiteSpace(value as string) ? null : value;
    }
}
