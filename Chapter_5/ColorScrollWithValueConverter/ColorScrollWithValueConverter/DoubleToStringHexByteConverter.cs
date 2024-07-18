using System;
using System.Data;
using System.Globalization;
using System.Windows;

namespace ColorScrollWithValueConverter
{
    public class DoubleToStringHexByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return ((int)(double)value).ToString("X2");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value;
        }

    }
}
