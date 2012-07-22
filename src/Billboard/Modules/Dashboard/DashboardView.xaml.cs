using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Billboard.Modules.Dashboard
{
    public sealed partial class DashboardView
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
        }

        void ItemViewItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void AddNewTask(object sender, RoutedEventArgs e)
        {
            addNewTaskOverlay.Visibility = Visibility.Visible;
        }

        private void HideOverlay(object sender, RoutedEventArgs e)
        {
            addNewTaskOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
