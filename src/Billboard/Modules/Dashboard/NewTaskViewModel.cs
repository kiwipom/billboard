using System;
using System.Windows.Input;
using Billboard.Events;
using Billboard.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Modules.Dashboard
{
    public class NewTaskViewModel : ViewModelBase, INewTaskViewModel
    {
        readonly IMessenger messenger;

        public NewTaskViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        string title;
        public string Title
        {
            get { return title; }
            set
            {
                Set(() => Title, ref title, value);
                command.RaiseCanExecuteChanged();
            }
        }

        string description;
        public string Description
        {
            get { return description; }
            set
            {
                Set(() => Description, ref description, value);
                command.RaiseCanExecuteChanged();
            }
        }

        public DateTime TargetDate { get; set; }

        RelayCommand command;
        public ICommand SaveCommand { get { return command ?? (command = new RelayCommand(Save, CanSave)); } }

        bool CanSave()
        {
            if (string.IsNullOrWhiteSpace(Title))
                return false;

            if (string.IsNullOrWhiteSpace(Description))
                return false;

            return true;
        }

        void Save()
        {
            var model = new UserTask {Title = Title, Description = Description, TargetDate = TargetDate};

            messenger.Send(new CreateUserTaskMessage(model));
        }
    }
}