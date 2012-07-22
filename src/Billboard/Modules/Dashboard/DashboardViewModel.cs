using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Modules.Dashboard
{
    public class DashboardViewModel : IDashboardViewModel
    {
        public DashboardViewModel(IEnumerable<Bucket> buckets, IMessenger messenger)
        {
            Buckets = new ObservableCollection<Bucket>(buckets);
            NewTask = new NewTaskViewModel(messenger);
        }

        public ObservableCollection<Bucket> Buckets { get; private set; }

        public INewTaskViewModel NewTask { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}
