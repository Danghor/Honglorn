using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HonglornWPF.Converter
{
    class ResultGridVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var isLoading = (bool)values[0];
            string message = values[1]?.ToString();

            return isLoading || !string.IsNullOrWhiteSpace(message) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}