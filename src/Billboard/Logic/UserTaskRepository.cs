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
                        db.CreateTable<UserTask>();    
                        db.Insert(task);
                    });
                }
            });
        }
    }
}
