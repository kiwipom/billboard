using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Billboard.Modules.Dashboard
{
    public class NewTaskViewModel : INewTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }

        private ICommand command;
        public ICommand SaveCommand { get { return command ?? (command = new RelayCommand(Run, CanRun)); } }

        private bool CanRun()
        {
            if (string.IsNullOrWhiteSpace(Title))
                return false;

            if (string.IsNullOrWhiteSpace(Description))
                return false;

            return true;
        }

        private void Run()
        {
            
        }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}