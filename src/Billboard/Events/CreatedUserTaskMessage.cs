using Billboard.Models;

namespace Billboard.Events
{
    public class CreatedUserTaskMessage
    {
        public CreatedUserTaskMessage(UserTask task)
        {
            Task = task;
        }

        public UserTask Task { get; private set; }
    }
}