﻿using System;
using SQLiteTester.Models;
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
            var async = new AsyncDatabaseViewModel(Window.Current.Dispatcher);
            var sync = new SyncDatabaseViewModel(Window.Current.Dispatcher);
            var viewModel = new MainViewModel(async, sync);
            DataContext = viewModel;
        }
    }
}
