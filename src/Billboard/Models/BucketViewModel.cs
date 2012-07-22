using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Billboard.Models
{
    public class BucketViewModel : INotifyPropertyChanged
    {
        public BucketViewModel()
        {
            Tasks = new ObservableCollection<UserTaskViewModel>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public ObservableCollection<UserTaskViewModel> Tasks { get; set; }

        public static BucketViewModel Map(Bucket bucket)
        {
            return new BucketViewModel
                       {
                           Id = bucket.Id,
                           Description = bucket.Description,
                           Order = bucket.Order
                       };
        }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}