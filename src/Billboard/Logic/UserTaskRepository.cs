using System;
using System.Threading.Tasks;
using Billboard.Models;
using SQLite;

namespace Billboard.Logic
{
    public class UserTaskRepository
    {
        private readonly DatabaseConfiguration configuration;

        public UserTaskRepository(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Insert(UserTask task)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(configuration.FilePath))
                {
                    db.RunInTransaction(() =>
                    {
                        var first = db.Table<Bucket>().OrderBy(c => c.Order).FirstOrDefault();
                        if (first == null)
                        {
                            throw new InvalidOperationException("how the hell did we get here?");
                        }
                        task.BucketId = first.Id;
                    });

                    db.RunInTransaction(() =>
                    {
                        db.CreateTable<UserTask>();    
                        db.Insert(task);
                    });
                }
            });
        }
    }
}
