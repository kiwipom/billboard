using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace Billboard.Models
{
    public class Bucket : INotifyPropertyChanged
    {
        public Bucket()
        {
            Tasks = new List<UserTask>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        [Ignore]
        public IList<UserTask> Tasks { get; set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}