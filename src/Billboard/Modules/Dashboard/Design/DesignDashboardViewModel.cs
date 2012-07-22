using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Billboard.Models;

namespace Billboard.Modules.Dashboard.Design
{
    public class DesignDashboardViewModel : IDashboardViewModel
    {
        public DesignDashboardViewModel()
        {
            Buckets = new ObservableCollection<BucketViewModel>();

            var toDoBucket = new BucketViewModel { Description = "To Do" };
            toDoBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "A simple task",
                Description = "Capturing the things you need to do is the best way to not forget about them. The sorts of things you need to capture are up to you..."
            });
            toDoBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Some tasks might not even require a description"
            });
            toDoBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "A task with a goal",
                Description = "Sometimes you need to get something done soon, otherwise bad things will happen.",
                TargetDate = DateTime.Now.AddDays(2),
            });
            toDoBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "A big task",
                Description = "Sometimes a task requires more time compared to the other tasks in the bucket. This is how you can add emphasis to them.",
                Size = "Large"
            });
            Buckets.Add(toDoBucket);

            var doingBucket = new BucketViewModel { Description = "Doing" };
            doingBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "A task underway",
                Description = "As you work through the tasks on your list, you can move them across from left to right",
            });
            doingBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Beware doing too much at once",
                Description = "If you find yourself with too many things in this bucket, you may need to move some tasks back to help with focus",
                TargetDate = DateTime.Now.AddDays(-2),
            });
            doingBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Beware doing too much at once",
                Description = "If you find yourself with too many things in this bucket, you may need to move some tasks back to help with focus",
                TargetDate = DateTime.Now.AddDays(-3),
            });
            doingBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Beware doing too much at once",
                Description = "If you find yourself with too many things in this bucket, you may need to move some tasks back to help with focus",
                TargetDate = DateTime.Now.AddDays(-4),
            });


            Buckets.Add(doingBucket);

            var doneBucket = new BucketViewModel { Description = "Done" };
            doneBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Doesn't that feel awesome?",
                Description = "Don't forget to move the completed tasks over when you've done them",
            });
            doneBucket.Tasks.Add(new UserTaskViewModel
            {
                Title = "Focus on what's important?",
                Description = "After a while, these completed tasks will be hidden automatically, so you don't need to manually cleanup after.",
            });
        


            Buckets.Add(doneBucket);
        }

        public ObservableCollection<BucketViewModel> Buckets { get; private set; }

        public INewTaskViewModel NewTask { get { return new DesignNewTaskViewModel(); } }

#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067
    }
}