using HonglornBL.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HonglornWPF.Converter
{
    [ValueConversion(typeof(DisciplineType), typeof(string))]
    class DisciplineTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(DisciplineType), value.ToString());
        }
    }
}
