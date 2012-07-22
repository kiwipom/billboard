using System;
using System.ComponentModel;

namespace Billboard.Modules.Dashboard
{
    public class NewTaskViewModel : INewTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}