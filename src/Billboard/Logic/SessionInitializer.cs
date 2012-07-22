using Billboard.Models;

namespace Billboard.Logic
{
    public class SessionInitializer
    {
        readonly BucketRepository bucketRepository;
        readonly UserTaskRepository userTaskRepository;

        public SessionInitializer(BucketRepository bucketRepository, UserTaskRepository userTaskRepository)
        {
            this.bucketRepository = bucketRepository;
            this.userTaskRepository = userTaskRepository;
        }

        public void Initialize()
        {
            bucketRepository.Insert(new Bucket { Description = "Backlog", Order = 1 });
            bucketRepository.Insert(new Bucket { Description = "Doing", Order = 2 });
            bucketRepository.Insert(new Bucket { Description = "Done", Order = 3 });
            
            userTaskRepository.Insert(new UserTask { Title = "First task" });
            userTaskRepository.Insert(new UserTask { Title = "Second task" });
            userTaskRepository.Insert(new UserTask { Title = "Third task" });
        }
    }
}
