using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HonglornWPF
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    class StringToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility trueValue;
            Visibility falseValue;

            if (parameter == null || !((bool)parameter))
            {
                trueValue = Visibility.Visible;
                falseValue = Visibility.Collapsed;
            }
            else
            {
                trueValue = Visibility.Collapsed;
                falseValue = Visibility.Visible;
            }

            return !string.IsNullOrWhiteSpace(value?.ToString()) ? trueValue : falseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
