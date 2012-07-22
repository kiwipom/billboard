using System.Collections.Generic;
using System.ComponentModel;

namespace Billboard.Models
{
    public class Bucket : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public IEnumerable<UserTask> Tasks { get; set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}