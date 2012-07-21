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
            await RunUpdateTest();
        }

        async Task RunCreateTest()
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

                    var count = 0;
                    db.RunInTransaction(() =>
                    {
                        var table = db.Table<Person>();
                        count = table.Count();
                    });

                    var message = count == 10
                                ? "Completed!"
                                : string.Format("Only inserted {0} rows!", count);

                    dispatcher.RunIdleAsync(o => { CreateResult = message; });
                }

                
            });
        }

        async Task RunReadTest()
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(DatabasePath))
                {
                   db.RunInTransaction(async () => {
                        var person1 = db.Find<Person>(f => f.FullName.EndsWith("8"));
                        var person2 = db.Find<Person>(f => f.FullName.EndsWith("3"));

                        var message = person1 != null && person2 != null
                                           ? "Completed!"
                                           : "Did not find both people!";

                        await dispatcher.RunIdleAsync(a => { ReadResult = message; });
                    });
                }
            });
        }

        async Task RunUpdateTest()
        {
            await Task.Factory.StartNew(() =>
            {
                using (var db = new SQLiteConnection(DatabasePath))
                {
                    db.RunInTransaction(async () =>
                    {
                        // run the update operation
                        var person = db.Get<Person>(f => f.FullName.EndsWith("8"));
                        person.OtherField = "ABCD";
                        db.Update(person);

                        // check it was persisted
                        var updatedPerson = db.Get<Person>(f => f.FullName.EndsWith("8"));
                        var message = updatedPerson.OtherField == "ABCD"
                                      ? "Completed!"
                                      : "Did not update person!";

                        await dispatcher.RunIdleAsync(a => { UpdateResult = message; });
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
            catch (Exception ex)
            {
               Debug.WriteLine(ex);
            }
        }
    }
}