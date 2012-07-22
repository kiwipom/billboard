using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Billboard.Events;
using Billboard.Logic;
using Billboard.Models;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Modules.Dashboard
{
    public class DashboardViewModel : IDashboardViewModel
    {
        readonly BucketRepository bucketRepository;

        public DashboardViewModel(IMessenger messenger, BucketRepository bucketRepository)
        {
            this.bucketRepository = bucketRepository;

            Buckets = new ObservableCollection<BucketViewModel>();
            NewTask = new NewTaskViewModel(messenger);

            messenger.Register<UserTaskAddedMessage>(this, HandleCreatedUserTaskMessage);
        }

        public async void Initialize()
        {
            var data = await bucketRepository.GetAll();
            Buckets = new ObservableCollection<BucketViewModel>(data);
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
