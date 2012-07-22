using System;
using System.Collections.Generic;
using Billboard.Logic;
using GalaSoft.MvvmLight.Messaging;
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
            var repository = new BucketRepository(DatabaseConfiguration.Current);
            var viewModel = new DashboardViewModel(Messenger.Default, repository);
            DataContext = viewModel;
            viewModel.Initialize();
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
