using Billboard.Models;

namespace Billboard.Events
{
    public class UserTaskAddedMessage
    {
        public UserTaskAddedMessage(UserTaskViewModel task)
        {
            Task = task;
        }

        public UserTaskViewModel Task { get; private set; }
    }
}