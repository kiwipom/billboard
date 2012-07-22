using System;
using Windows.UI.Xaml.Data;

namespace Billboard.Converters
{
    public class TaskSizeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (value is string)
            {
                var text = value.ToString();
                if (text == "Large") // TODO: represent this as an enum
                    return "/Assets/icons/caret.png";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}