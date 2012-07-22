using System.Threading.Tasks;
using Billboard.Events;
using Billboard.Models;
using GalaSoft.MvvmLight.Messaging;
using Windows.Storage;

namespace Billboard.Logic
{
    public class SessionInitializer
    {
        readonly BucketRepository bucketRepository;
        readonly UserTaskRepository userTaskRepository;
        readonly IMessenger messenger;

        public SessionInitializer(
            BucketRepository bucketRepository, 
            UserTaskRepository userTaskRepository,
            IMessenger messenger)
        {
            this.bucketRepository = bucketRepository;
            this.userTaskRepository = userTaskRepository;
            this.messenger = messenger;
        }

        public async Task Initialize()
        {
            var o = ApplicationData.Current.LocalSettings.Values["Initialized"];
            if (o != null && (bool) o)
            {
                return;
            }

            var firstBucket = new Bucket {Description = "Backlog", Order = 1};
            await bucketRepository.Insert(firstBucket);
            await bucketRepository.Insert(new Bucket { Description = "Doing", Order = 2 });
            await bucketRepository.Insert(new Bucket { Description = "Done", Order = 3 });

            await userTaskRepository.Insert(new UserTask { Title = "First task", BucketId = firstBucket.Id});
            await userTaskRepository.Insert(new UserTask { Title = "Second task", BucketId = firstBucket.Id });
            await userTaskRepository.Insert(new UserTask { Title = "Third task", BucketId = firstBucket.Id });

            ApplicationData.Current.LocalSettings.Values["Initialized"] = true;
        }
    }
}
