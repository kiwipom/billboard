using Billboard.Models;

namespace Billboard.Events
{
    public class UserTaskCreatedMessage
    {
        public UserTaskCreatedMessage(UserTask task)
        {
            Task = task;
        }

        public UserTask Task { get; private set; }
    }
}
