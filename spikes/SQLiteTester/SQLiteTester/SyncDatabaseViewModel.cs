using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace SQLiteTester
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
        }

        private async Task RunCreateTest()
        {
            await Task.Factory.StartNew(async () =>
            {
                using (var db = new SQLiteConnection(DatabasePath))
                {
                    db.CreateTable<Person>();
                    db.RunInTransaction(() =>
                    {
                        for (var i = 0; i < 10; i++)
                            db.Insert(new Person { FullName = "Person " + i.ToString() });
                    });
                }

                await dispatcher.RunIdleAsync(o => { CreateResult = "Completed!"; });
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