using System.Collections.ObjectModel;

namespace Billboard.Modules.Dashboard
{
    public interface IDashboardViewModel
    {
        ObservableCollection<Models.Bucket> Buckets { get; }
    }
}