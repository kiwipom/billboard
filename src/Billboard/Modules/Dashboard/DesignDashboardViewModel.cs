using System.Collections.ObjectModel;
using Billboard.Models;

namespace Billboard.Modules.Dashboard
{
    public class DesignDashboardViewModel : IDashboardViewModel
    {
        public DesignDashboardViewModel()
        {
            Buckets = new ObservableCollection<Models.Bucket>();

            var toDoBucket = new Models.Bucket { Description = "To Do" };
            toDoBucket.Tasks.Add(new UserTask { Title = "Buy Milk" });
            toDoBucket.Tasks.Add(new UserTask { Title = "Buy Eggs" });
            toDoBucket.Tasks.Add(new UserTask { Title = "Walk the dog" });
            Buckets.Add(toDoBucket);

            var doingBucket = new Models.Bucket { Description = "Doing" };
            Buckets.Add(doingBucket);

            var doneBucket = new Models.Bucket { Description = "Done" };
            doneBucket.Tasks.Add(new UserTask { Title = "Foo" });
            doneBucket.Tasks.Add(new UserTask { Title = "Bar" });
            doneBucket.Tasks.Add(new UserTask { Title = "Baz" });

            Buckets.Add(doneBucket);
        }

        public ObservableCollection<Models.Bucket> Buckets { get; private set; }
    }
}