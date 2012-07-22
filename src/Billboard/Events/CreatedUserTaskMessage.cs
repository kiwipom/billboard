using Billboard.Models;

namespace Billboard.Events
{
    public class CreatedUserTaskMessage
    {
        public CreatedUserTaskMessage(UserTaskViewModel task)
        {
            Task = task;
        }

        public UserTaskViewModel Task { get; private set; }
    }
}