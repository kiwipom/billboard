using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Billboard.Converters
{
    public class DateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (value is DateTime)
            {
                var dateTime = (DateTime) value;

                return string.Format("/Assets/calendar/{0}/{1}.png", "june", "23");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
