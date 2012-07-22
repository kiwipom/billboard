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

        public async void Insert(Bucket bucket)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(configuration.Path))
                {
                    db.RunInTransaction(() =>
                    {
                        db.CreateTable<Bucket>(); // only creates if table does not exist
                        db.Insert(bucket);
                    });
                }
            });

        }
    }
}