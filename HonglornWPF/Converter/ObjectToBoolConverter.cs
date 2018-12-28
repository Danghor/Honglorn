using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace HonglornWPF.Converter
{
    [ValueConversion(typeof(object[]), typeof(bool))]
    class ObjectsNotNullToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(i => i != null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}