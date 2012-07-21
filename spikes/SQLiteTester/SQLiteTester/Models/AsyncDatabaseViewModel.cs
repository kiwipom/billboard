using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Windows.UI.Core;

namespace SQLiteTester.Models
{
    public class AsyncDatabaseViewModel : ResultViewModel
    {
        readonly CoreDispatcher dispatcher;

        public AsyncDatabaseViewModel(CoreDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public string DatabasePath
        {
            get { return Path.Combine(LocalFolder, "mypeople.async.sqlite"); }
        }

        public override async void Run()
        {
            await RunCreateTest()
                .ContinueWith(t => RunReadTest())
                .ContinueWith(t => RunUpdateTest());
            
        }

        async Task RunCreateTest()
        {
            var db = new SQLiteAsyncConnection(DatabasePath);
            await db.CreateTableAsync<Person>();
            await db.RunInTransactionAsync(async d =>
            {
                for (var i = 0; i < 10; i++)
                    await d.InsertAsync(new Person { FullName = "Person " + i.ToString() });
            });

            int count = 0;

            await db.RunInTransactionAsync(async d =>
            {
                var table = db.Table<Person>();
                count = await table.CountAsync();
            });

            var message = count == 10
                        ? "Completed!"
                        : string.Format("Only inserted {0} rows!", count);

            await dispatcher.RunIdleAsync(a => { CreateResult = message; });
        }

        async Task RunReadTest()
        {
            var db = new SQLiteAsyncConnection(DatabasePath);

            var table = db.Table<Person>();
            var person1 = table.Where(f => f.FullName.EndsWith("8"));
            var person2 = table.Where(f => f.FullName.EndsWith("3"));

            var message = person1 != null && person2 != null
                                        ? "Completed!"
                                        : "Did not find both people!";

            await dispatcher.RunIdleAsync(a => { ReadResult = message; });
        }

        async Task RunUpdateTest()
        {
            var db = new SQLiteAsyncConnection(DatabasePath);
            var person = await db.GetAsync<Person>(f => f.FullName.EndsWith("8"));
            person.OtherField = "ABCD";
            await db.UpdateAsync(person);

            var updatedPerson = await db.GetAsync<Person>(f => f.FullName.EndsWith("8"));
            var message = updatedPerson.OtherField == "ABCD"
                            ? "Completed!"
                            : "Did not update person!";

            await dispatcher.RunIdleAsync(a => { UpdateResult = message; });
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
