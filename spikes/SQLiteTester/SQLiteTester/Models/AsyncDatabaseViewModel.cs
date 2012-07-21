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
            await RunCreateTest();
            await RunReadTest();
        }

        async Task RunReadTest()
        {
            var db = new SQLiteAsyncConnection(DatabasePath);
            await db.CreateTableAsync<Person>();
            await db.RunInTransactionAsync(async d =>
            {
                var person1 = await d.GetAsync<Person>(f => f.FullName.EndsWith("8"));
                var person2 = await d.GetAsync<Person>(f => f.FullName.EndsWith("3"));

                var message = person1 != null && person2 != null 
                    ? "Found both people!" 
                    : "Error!";

                await dispatcher.RunIdleAsync(a => { ReadResult = message; });
            });
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
            await dispatcher.RunIdleAsync(a => { CreateResult = "Completed!"; });
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
