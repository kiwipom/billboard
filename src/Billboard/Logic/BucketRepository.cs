using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billboard.Models;
using SQLite;

namespace Billboard.Logic
{
    public class BucketRepository
    {
        private readonly DatabaseConfiguration configuration;

        public BucketRepository(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Insert(Bucket bucket)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(configuration.FilePath))
                {
                    db.RunInTransaction(() =>
                    {
                        db.CreateTable<Bucket>(); // only creates if table does not exist
                        db.Insert(bucket);
                    });
                }
            });
        }

        public async Task<IEnumerable<Bucket>> GetAll()
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(configuration.FilePath))
                {
                    var buckets = db.Table<Bucket>().ToList();
                    var tasks = db.Table<UserTask>().ToList();

                    foreach (var b in buckets)
                    {
                        b.Tasks = tasks.Where(t => t.BucketId == b.Id).ToList();
                    }

                    return buckets;
                }
            });

        }
    }
}