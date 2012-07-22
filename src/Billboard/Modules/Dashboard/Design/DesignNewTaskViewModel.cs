using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Billboard.Modules.Dashboard.Design
{
    public class DesignNewTaskViewModel : INewTaskViewModel
    {
        public DesignNewTaskViewModel()
        {
            Title = "New Title";
            Description = "Donec volutpat dui purus, sit amet mollis ligula. Maecenas pharetra semper eros vitae congue. Integer nulla leo, luctus nec laoreet vitae, aliquam sit amet eros. Quisque commodo aliquam nisl et interdum. In ut porttitor arcu. Mauris ac leo orci, pretium placerat arcu. Duis tempor ante sit amet lorem tempus mollis. Maecenas in enim vitae purus bibendum ornare vel in magna. Nulla facilisi. Nunc quis sapien eget magna aliquet sagittis. Quisque a ornare ligula. Suspendisse potenti.";
            TargetDate = DateTime.Now.AddDays(4).Date;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public ICommand SaveCommand { get { return null; } }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}