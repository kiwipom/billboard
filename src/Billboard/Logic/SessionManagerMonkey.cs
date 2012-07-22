using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billboard.Events;
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

        private void HandleUserTaskCreatedMessage(CreateUserTaskMessage obj)
        {
            taskRepository.Insert(obj.Task);
            messenger.Send(new CreatedUserTaskMessage(obj.Task));
        }
    }
}
