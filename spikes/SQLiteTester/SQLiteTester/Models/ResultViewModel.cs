using GalaSoft.MvvmLight;
using Windows.Storage;

namespace SQLiteTester.Models
{
    public abstract class ResultViewModel : ViewModelBase
    {
        public string LocalFolder
        {
            get { return ApplicationData.Current.LocalFolder.Path; }
        }

        string createResult;
        public string CreateResult
        {
            get { return createResult; }
            set { Set(() => CreateResult, ref createResult, value); }
        }

        string readResult;
        public string ReadResult
        {
            get { return readResult; }
            set { Set(() => ReadResult, ref readResult, value); }
        }

        string updateResult;
        public string UpdateResult
        {
            get { return updateResult; }
            set { Set(() => UpdateResult, ref updateResult, value); }
        }

        string deleteResult;
        public string DeleteResult
        {
            get { return deleteResult; }
            set { Set(() => DeleteResult, ref deleteResult, value); }
        }

        public void Clear()
        {
            CreateResult = string.Empty;
            ReadResult = string.Empty;
            UpdateResult = string.Empty;
            DeleteResult = string.Empty;
        }

        public abstract void Run();
        public abstract void Reset();
    }
}