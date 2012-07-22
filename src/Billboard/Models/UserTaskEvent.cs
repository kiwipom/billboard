using System;
using System.ComponentModel;
using SQLite;

namespace Billboard.Models
{
    public class UserTaskEvent : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserTaskId { get; set; }

        public int BucketId { get; set; }

        public DateTimeOffset EventTime { get; set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}