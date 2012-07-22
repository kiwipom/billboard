using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Browse
{
    public interface IBucketViewModel : INotifyPropertyChanged
    {
        Bucket Bucket { get; set; }
        
        ObservableCollection<UserTask> Tasks { get; }
    }
}
