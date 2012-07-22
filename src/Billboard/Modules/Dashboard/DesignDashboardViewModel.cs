using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Dashboard
{
    public class DesignDashboardViewModel : IDashboardViewModel
    {
        public DesignDashboardViewModel()
        {
            Buckets = new ObservableCollection<Models.Bucket>();

            var toDoBucket = new Models.Bucket { Description = "To Do" };
            toDoBucket.Tasks.Add(new UserTask { Title = "Buy Milk", Description = "No skim milk or else!" });
            toDoBucket.Tasks.Add(new UserTask { Title = "Buy Eggs", Description = "So many eggs you guys!" });
            toDoBucket.Tasks.Add(new UserTask { Title = "Walk the dog", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras porttitor risus et diam viverra eget consequat erat fermentum. Vivamus metus massa, pretium at fermentum vitae, fringilla sed nibh. Duis posuere, tellus in fermentum sollicitudin, urna nunc molestie felis, et tempor augue orci at dui." });
            toDoBucket.Tasks.Add(new UserTask { Title = "Sed risus odio, sollicitudin quis elementum sit amet", Description = "pretium eget eros. Morbi volutpat, nunc at feugiat molestie, ipsum tortor semper arcu, id tincidunt tortor risus eu eros. Nulla venenatis porta rhoncus. Duis eleifend accumsan tellus at ornare. Curabitur nec nunc nulla, id dapibus nunc. Curabitur eu urna sed quam mattis pharetra." });
            toDoBucket.Tasks.Add(new UserTask { Title = "Phasellus tempor posuere dapibus. Nulla fringilla luctus elit ac pellentesque.", Description = "Donec volutpat dui purus, sit amet mollis ligula. Maecenas pharetra semper eros vitae congue. Integer nulla leo, luctus nec laoreet vitae, aliquam sit amet eros. Quisque commodo aliquam nisl et interdum. In ut porttitor arcu. Mauris ac leo orci, pretium placerat arcu. Duis tempor ante sit amet lorem tempus mollis. Maecenas in enim vitae purus bibendum ornare vel in magna. Nulla facilisi. Nunc quis sapien eget magna aliquet sagittis. Quisque a ornare ligula. Suspendisse potenti." });
            Buckets.Add(toDoBucket);

            var doingBucket = new Models.Bucket { Description = "Doing" };
            Buckets.Add(doingBucket);
            
            var pendingBucket = new Models.Bucket { Description = "Pending Approval" };
            Buckets.Add(pendingBucket);

            var doneBucket = new Models.Bucket { Description = "Done" };
            doneBucket.Tasks.Add(new UserTask { Title = "Foo" });
            doneBucket.Tasks.Add(new UserTask { Title = "Bar" });
            doneBucket.Tasks.Add(new UserTask { Title = "Baz" });

            Buckets.Add(doneBucket);
        }

        public ObservableCollection<Models.Bucket> Buckets { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}