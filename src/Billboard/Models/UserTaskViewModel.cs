using System;
using System.ComponentModel;

namespace Billboard.Models
{
    public class UserTaskViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? TargetDate { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }

        public static UserTaskViewModel Map(UserTask task)
        {
            return new UserTaskViewModel
                       {
                           Id = task.Id,
                           Category = task.Category,
                           Description = task.Description,
                           Title = task.Title,
                           TargetDate = task.TargetDate,
                           Size = task.Size
                       };
        }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}