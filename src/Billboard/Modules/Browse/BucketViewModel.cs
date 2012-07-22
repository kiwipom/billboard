using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Bucket
{
    public class BucketViewModel : IBucketViewModel
    {
        public Models.Bucket Bucket { get; set; }

        public ObservableCollection<UserTask> Tasks { get; private set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}