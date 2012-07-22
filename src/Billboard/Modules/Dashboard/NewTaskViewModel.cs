using System;
using System.ComponentModel;
using System.Windows.Input;
using Billboard.Events;
using Billboard.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Modules.Dashboard
{
    public class NewTaskViewModel : INewTaskViewModel
    {
        readonly IMessenger messenger;

        public NewTaskViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
        }

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
            var model = new UserTask();
            model.Title = Title;
            model.Description = Description;
            model.TargetDate = TargetDate;

            messenger.Send(new CreateUserTaskMessage(model));
        }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}