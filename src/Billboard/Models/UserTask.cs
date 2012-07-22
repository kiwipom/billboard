﻿using System;
using System.ComponentModel;
using SQLite;

namespace Billboard.Models
{
    public class UserTask 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int BucketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }
    }

    public class UserTaskViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TargetDate { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }

        public static UserTaskViewModel Map(UserTask bucket)
        {
            return new UserTaskViewModel(); // TODO
        }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}
