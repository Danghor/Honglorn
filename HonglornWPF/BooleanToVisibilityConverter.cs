using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HonglornWPF
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BooleanToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility trueValue;
            Visibility falseValue;

            if (parameter == null || !((bool) parameter))
            {
                trueValue = Visibility.Visible;
                falseValue = Visibility.Collapsed;
            }
            else
            {
                trueValue = Visibility.Collapsed;
                falseValue = Visibility.Visible;
            }

            return value == null || (bool) value ? trueValue : falseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
