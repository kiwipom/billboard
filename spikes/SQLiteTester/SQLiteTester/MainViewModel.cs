using GalaSoft.MvvmLight;

namespace SQLiteTester
{
    public class MainViewModel : ViewModelBase
    {
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
    }
}
