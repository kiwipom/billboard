using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Billboard.Modules.Dashboard
{
    public sealed partial class WelcomeControl
    {
        public WelcomeControl()
        {
            this.InitializeComponent();
        }

        private void DismissWelcome(object sender, RoutedEventArgs e)
        {
            var parent = Parent as Panel;

            parent.Children.Remove(this);
        }
    }
}
