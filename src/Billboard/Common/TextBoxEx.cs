using System;
using System.Reactive.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Billboard.Common
{
    // source: http://weblogs.asp.net/broux/archive/2012/07/03/windows-8-update-textbox-s-binding-on-textchanged.aspx

    public static class TextBoxEx
    {
        public static string GetRealTimeText(TextBox obj)
        {
            return (string)obj.GetValue(RealTimeTextProperty);
        }

        public static void SetRealTimeText(TextBox obj, string value)
        {
            obj.SetValue(RealTimeTextProperty, value);
        }

        public static readonly DependencyProperty RealTimeTextProperty =
            DependencyProperty.RegisterAttached("RealTimeText", typeof(string), typeof(TextBoxEx), null);

        public static bool GetIsAutoUpdate(TextBox obj)
        {
            return (bool)obj.GetValue(IsAutoUpdateProperty);
        }

        public static void SetIsAutoUpdate(TextBox obj, bool value)
        {
            obj.SetValue(IsAutoUpdateProperty, value);
        }

        public static readonly DependencyProperty IsAutoUpdateProperty =
            DependencyProperty.RegisterAttached("IsAutoUpdate", typeof(bool), typeof(TextBoxEx), new PropertyMetadata(false, OnIsAutoUpdateChanged));

        private static void OnIsAutoUpdateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var value = (bool)e.NewValue;
            var textbox = (TextBox)sender;

            if (value)
            {
                Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
                              o => textbox.TextChanged += o,
                              o => textbox.TextChanged -= o)
                          .Do(_ => textbox.SetValue(TextBoxEx.RealTimeTextProperty, textbox.Text))
                          .Subscribe();
            }
        }
    }
}
