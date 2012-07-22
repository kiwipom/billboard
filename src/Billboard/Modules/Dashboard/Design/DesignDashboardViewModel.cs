using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Dashboard.Design
{
    public class DesignDashboardViewModel : IDashboardViewModel
    {
        public DesignDashboardViewModel()
        {
            Buckets = new ObservableCollection<BucketViewModel>();

            var toDoBucket = new BucketViewModel { Description = "To Do" };
            toDoBucket.Tasks.Add(new UserTaskViewModel { Title = "Buy Milk", Description = "No skim milk or else!" });
            toDoBucket.Tasks.Add(new UserTaskViewModel { Title = "Buy Eggs", Description = "So many eggs you guys!" });
            toDoBucket.Tasks.Add(new UserTaskViewModel { Title = "Walk the dog", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras porttitor risus et diam viverra eget consequat erat fermentum. Vivamus metus massa, pretium at fermentum vitae, fringilla sed nibh. Duis posuere, tellus in fermentum sollicitudin, urna nunc molestie felis, et tempor augue orci at dui." });
            toDoBucket.Tasks.Add(new UserTaskViewModel { Title = "Sed risus odio, sollicitudin quis elementum sit amet", Description = "pretium eget eros. Morbi volutpat, nunc at feugiat molestie, ipsum tortor semper arcu, id tincidunt tortor risus eu eros. Nulla venenatis porta rhoncus. Duis eleifend accumsan tellus at ornare. Curabitur nec nunc nulla, id dapibus nunc. Curabitur eu urna sed quam mattis pharetra." });
            toDoBucket.Tasks.Add(new UserTaskViewModel { Title = "Phasellus tempor posuere dapibus. Nulla fringilla luctus elit ac pellentesque.", Description = "Donec volutpat dui purus, sit amet mollis ligula. Maecenas pharetra semper eros vitae congue. Integer nulla leo, luctus nec laoreet vitae, aliquam sit amet eros. Quisque commodo aliquam nisl et interdum. In ut porttitor arcu. Mauris ac leo orci, pretium placerat arcu. Duis tempor ante sit amet lorem tempus mollis. Maecenas in enim vitae purus bibendum ornare vel in magna. Nulla facilisi. Nunc quis sapien eget magna aliquet sagittis. Quisque a ornare ligula. Suspendisse potenti." });
            Buckets.Add(toDoBucket);

            var doingBucket = new BucketViewModel { Description = "Doing" };
            Buckets.Add(doingBucket);

            var pendingBucket = new BucketViewModel { Description = "Pending Approval" };
            Buckets.Add(pendingBucket);

            var doneBucket = new BucketViewModel { Description = "Done" };
            doneBucket.Tasks.Add(new UserTaskViewModel { Title = "Foo" });
            doneBucket.Tasks.Add(new UserTaskViewModel { Title = "Bar" });
            doneBucket.Tasks.Add(new UserTaskViewModel { Title = "Baz" });

            Buckets.Add(doneBucket);
        }

        public ObservableCollection<BucketViewModel> Buckets { get; private set; }
        
        public INewTaskViewModel NewTask { get { return new DesignNewTaskViewModel(); } }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}