using System;
using System.Threading.Tasks;
using Billboard.Models;
using Windows.Storage;

namespace Billboard.Logic
{
    public class SessionInitializer
    {
        readonly BucketRepository bucketRepository;
        readonly UserTaskRepository userTaskRepository;

        public SessionInitializer(
            BucketRepository bucketRepository,
            UserTaskRepository userTaskRepository)
        {
            this.bucketRepository = bucketRepository;
            this.userTaskRepository = userTaskRepository;
        }

        public async Task Initialize()
        {
            var o = ApplicationData.Current.LocalSettings.Values["Initialized"];
            if (o != null && (bool)o)
            {
                return;
            }

            var firstBucket = new Bucket { Description = "Backlog", Order = 1 };
            await bucketRepository.Insert(firstBucket);
            var doingBucket = new Bucket { Description = "Doing", Order = 2 };
            await bucketRepository.Insert(doingBucket);
            var doneBucket = new Bucket { Description = "Done", Order = 3 };
            await bucketRepository.Insert(doneBucket);

            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "A simple task",
                    Description = "Capturing the things you need to do is the best way to not forget about them. The sorts of things you need to capture are up to you...",
                    BucketId = firstBucket.Id
                });

            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "Some tasks might not even require a description",
                    BucketId = firstBucket.Id
                });

            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "A task with a goal",
                    Description = "Sometimes you need to get something done soon, otherwise bad things will happen.",
                    TargetDate = DateTime.Now.AddDays(2),
                    BucketId = firstBucket.Id
                });

            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "A big task",
                    Description = "Sometimes a task requires more time compared to the other tasks in the bucket. This is how you can add emphasis to them.",
                    BucketId = firstBucket.Id,
                    Size = "Large"
                });

            await userTaskRepository.Insert(
                new UserTask
                    {
                        Title = "A task underway",
                        Description = "As you work through the tasks on your list, you can move them across from left to right",
                        BucketId = doingBucket.Id,
                    });
            await userTaskRepository.Insert(
                new UserTask
                    {
                        Title = "Beware doing too much at once",
                        Description = "If you find yourself with too many things in this bucket, you may need to move some tasks back to help with focus",
                        BucketId = doingBucket.Id,
                    });
            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "Doesn't that feel awesome?",
                    Description = "Don't forget to move the completed tasks over when you've done them",
                    BucketId = doneBucket.Id,
                });
        
            ApplicationData.Current.LocalSettings.Values["Initialized"] = true;
        }
    }
}
