using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;
using BucketModel = Billboard.Models.Bucket;

namespace Billboard.Modules.Bucket
{
    public interface IBucketViewModel : INotifyPropertyChanged
    {
        BucketModel Bucket { get; set; }
        
        ObservableCollection<UserTask> Tasks { get; }
    }
}
