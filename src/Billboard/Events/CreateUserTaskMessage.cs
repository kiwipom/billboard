using Billboard.Models;

namespace Billboard.Events
{
    public class CreateUserTaskMessage
    {
        public CreateUserTaskMessage(UserTask task)
        {
            Task = task;
        }

        public UserTask Task { get; private set; }
    }
}
