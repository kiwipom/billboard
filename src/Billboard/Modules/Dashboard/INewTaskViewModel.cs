using System;
using System.ComponentModel;

namespace Billboard.Modules.Dashboard
{
    public interface INewTaskViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime TargetDate { get; set; }
    }
}
