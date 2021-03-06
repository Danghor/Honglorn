﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HonglornWPF.Converter
{
    [ValueConversion(typeof(bool), typeof(Enum))]
    public class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => parameter.Equals(value);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value ? parameter : DependencyProperty.UnsetValue;
    }
}