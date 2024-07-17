using System;
using System.Globalization;
using System.Windows.Data;

namespace WhatSizeWithBindingConverter
{
    public class FormattedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IFormattable && 
                parameter is string && 
                !String.IsNullOrEmpty(parameter as string) && 
                targetType == typeof(string))
            {
                if (String.IsNullOrEmpty(culture.Name))
                    return (value as IFormattable).ToString(parameter as string, null);

                return (value as IFormattable).ToString(parameter as string, new CultureInfo(culture.Name));
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}