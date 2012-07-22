using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billboard.Logic;
using Billboard.Models;
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

        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var repository = new BucketRepository(DatabaseConfiguration.Current);
            var buckets = await repository.GetAll();
            var viewModel = new DashboardViewModel(buckets, Messenger.Default);
            DataContext = viewModel;
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
