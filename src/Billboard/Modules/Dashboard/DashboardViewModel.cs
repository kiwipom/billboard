using System.Collections.Generic;
using System.Collections.ObjectModel;
using BucketModel = Billboard.Models.Bucket;

namespace Billboard.Modules.Dashboard
{
    public class DashboardViewModel : IDashboardViewModel
    {
        public DashboardViewModel(IEnumerable<BucketModel> buckets)
        {
            Buckets = new ObservableCollection<BucketModel>(buckets);
        }

        public ObservableCollection<BucketModel> Buckets { get; private set; }
    }
}
