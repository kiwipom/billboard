using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Billboard.Common
{
    public class TextToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string)
            {
                var text = value.ToString();
                return string.IsNullOrWhiteSpace(text) ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
