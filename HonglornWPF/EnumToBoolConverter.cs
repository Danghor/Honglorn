using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HonglornWPF
{
    [ValueConversion(typeof(bool), typeof(Enum))]
    public class EnumToBoolConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => parameter.Equals(value);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ((bool)value) == true ? parameter : DependencyProperty.UnsetValue;
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
