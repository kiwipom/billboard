using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;

namespace SQLiteTester
{
    public class AsyncDatabaseViewModel : ResultViewModel
    {
        public string DatabasePath
        {
            get { return Path.Combine(LocalFolder, "mypeople.async.sqlite"); }
        }

        public override async void Run()
        {
            await RunCreateTest();
        }

        private async Task RunCreateTest()
        {
            var db = new SQLiteAsyncConnection(DatabasePath);
            await db.CreateTableAsync<Person>();
            await db.RunInTransactionAsync(async d =>
            {
                for (var i = 0; i < 10; i++)
                    await d.InsertAsync(new Person { FullName = "Person " + i.ToString() });
            });
            CreateResult = "Completed!";
        }

        public override async void Reset()
        {
            try
            {
                var file = await StorageFile.GetFileFromPathAsync(DatabasePath);
                await file.DeleteAsync(StorageDeleteOption.Default);
            }
            catch (Exception)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
            }
        }
    }
}
