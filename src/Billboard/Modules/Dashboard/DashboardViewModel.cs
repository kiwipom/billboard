using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Billboard.Events;
using Billboard.Models;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Modules.Dashboard
{
    public class DashboardViewModel : IDashboardViewModel
    {
        public DashboardViewModel(IEnumerable<BucketViewModel> buckets, IMessenger messenger)
        {
            Buckets = new ObservableCollection<BucketViewModel>(buckets);
            NewTask = new NewTaskViewModel(messenger);

            messenger.Register<UserTaskAddedMessage>(this, HandleCreatedUserTaskMessage);
        }

        void HandleCreatedUserTaskMessage(UserTaskAddedMessage obj)
        {
            Buckets.First().Tasks.Add(obj.Task);
        }

        public ObservableCollection<BucketViewModel> Buckets { get; private set; }

        public INewTaskViewModel NewTask { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}
