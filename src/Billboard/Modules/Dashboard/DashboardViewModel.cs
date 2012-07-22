using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using BucketModel = Billboard.Models.Bucket;

namespace Billboard.Modules.Dashboard
{
    public class DashboardViewModel : IDashboardViewModel
    {
        public DashboardViewModel(IEnumerable<BucketModel> buckets, IMessenger messenger)
        {
            Buckets = new ObservableCollection<BucketModel>(buckets);
            NewTask = new NewTaskViewModel(messenger);
        }

        public ObservableCollection<BucketModel> Buckets { get; private set; }

        public INewTaskViewModel NewTask { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}
