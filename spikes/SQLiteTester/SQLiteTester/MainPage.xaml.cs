using System;
using SQLiteTester.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace SQLiteTester
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var async = new AsyncDatabaseViewModel();
            var sync = new SyncDatabaseViewModel(Window.Current.Dispatcher);
            var viewModel = new MainViewModel(async, sync);
            DataContext = viewModel;
        }
    }
}
