using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Dashboard
{
    public interface IDashboardViewModel : INotifyPropertyChanged
    {
        ObservableCollection<BucketViewModel> Buckets { get; }

        INewTaskViewModel NewTask { get; }
    }
}