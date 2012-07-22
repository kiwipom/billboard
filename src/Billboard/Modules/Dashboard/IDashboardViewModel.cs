using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Billboard.Modules.Dashboard
{
    public interface IDashboardViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Models.Bucket> Buckets { get; }
    }
}