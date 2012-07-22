using Billboard.Events;
using Billboard.Models;
using GalaSoft.MvvmLight.Messaging;

namespace Billboard.Logic
{
    // need a better name for this class
    public class SessionManagerMonkey
    {
        readonly IMessenger messenger;
        readonly UserTaskRepository taskRepository;

        public SessionManagerMonkey(IMessenger messenger, UserTaskRepository taskRepository)
        {
            this.messenger = messenger;
            this.taskRepository = taskRepository;

            messenger.Register<CreateUserTaskMessage>(this, HandleUserTaskCreatedMessage);
        }

        private async void HandleUserTaskCreatedMessage(CreateUserTaskMessage obj)
        {
            await taskRepository.Insert(obj.Task);
            messenger.Send(new UserTaskAddedMessage(UserTaskViewModel.Map(obj.Task)));
        }
    }
}
