using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Bucket.Design
{
    public class DesignBucketViewModel : IBucketViewModel
    {
        public DesignBucketViewModel()
        {
            Tasks = new ObservableCollection<UserTask>();
            Tasks.Add(new UserTask { Title = "Foo" });
            Tasks.Add(new UserTask { Title = "Bar" });
            Tasks.Add(new UserTask { Title = "Baz" });

            Description = "This is a test bucket";
        }

        public Models.Bucket Bucket { get; set; }

        public ObservableCollection<UserTask> Tasks { get; private set; }

        public object Description { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}