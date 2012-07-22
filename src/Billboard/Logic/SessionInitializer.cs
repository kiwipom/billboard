﻿using System;
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
            await bucketRepository.Insert(new Bucket { Description = "Doing", Order = 2 });
            await bucketRepository.Insert(new Bucket { Description = "Done", Order = 3 });

            await userTaskRepository.Insert(
                new UserTask
                {
                    Title = "First task",
                    TargetDate = DateTime.Now.AddDays(2),
                    Size = "Large",
                    BucketId = firstBucket.Id
                });
            await userTaskRepository.Insert(new UserTask { Title = "Second task", BucketId = firstBucket.Id });
            await userTaskRepository.Insert(new UserTask { Title = "Third task", BucketId = firstBucket.Id });

            ApplicationData.Current.LocalSettings.Values["Initialized"] = true;
        }
    }
}
