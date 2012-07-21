using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Windows.UI.Core;

namespace SQLiteTester.Models
{
    public class SyncDatabaseViewModel : ResultViewModel
    {
        readonly CoreDispatcher dispatcher;

        public SyncDatabaseViewModel(CoreDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public string DatabasePath
        {
            get { return Path.Combine(LocalFolder, "mypeople.sqlite"); }
        }

        public override async void Run()
        {
            await RunCreateTest();
            await RunReadTest();
        }

        private async Task RunCreateTest()
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(DatabasePath))
                {
                    db.CreateTable<Person>();
                    db.RunInTransaction(() =>
                    {
                        for (var i = 0; i < 10; i++)
                            db.Insert(new Person { FullName = "Person " + i });
                    });

                    dispatcher.RunIdleAsync(o => { CreateResult = "Completed!"; });
                }
            });
        }

        private async Task RunReadTest()
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(DatabasePath))
                {
                    db.RunInTransaction(() => {
                        var person1 = db.Get<Person>(f => f.FullName.EndsWith("8"));
                        var person2 = db.Get<Person>(f => f.FullName.EndsWith("3"));

                        if (person1 != null && person2 != null)
                        {
                            dispatcher.RunIdleAsync(o => { ReadResult = "Found both people!"; });
                        }
                        else
                        {
                            dispatcher.RunIdleAsync(o => { ReadResult = "Error!"; });
                        }
                    });
                }
            });
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