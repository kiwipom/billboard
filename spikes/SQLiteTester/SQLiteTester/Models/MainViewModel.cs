using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SQLiteTester.Models
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(
            AsyncDatabaseViewModel asyncDatabaseViewModel, 
            SyncDatabaseViewModel syncDatabaseViewModel)
        {
            SyncTest = syncDatabaseViewModel;
            AsyncTest = asyncDatabaseViewModel;
        }

        AsyncDatabaseViewModel asyncTest;
        public AsyncDatabaseViewModel AsyncTest
        {
            get { return asyncTest; }
            set { Set(() => AsyncTest, ref asyncTest, value); }
        }

        SyncDatabaseViewModel syncTest;
        public SyncDatabaseViewModel SyncTest
        {
            get { return syncTest; }
            set { Set(() => SyncTest, ref syncTest, value); }
        }

        ICommand runCommand;
        public ICommand RunCommand
        {
            get
            {
                return runCommand ?? (runCommand = new RelayCommand(Run));
            }
        }

        private void Run()
        {
            SyncTest.Reset();
            SyncTest.Run();
            AsyncTest.Reset();
            AsyncTest.Run();
        }
    }
}