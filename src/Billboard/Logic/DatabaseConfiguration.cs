using System.IO;
using Windows.Storage;

namespace Billboard.Logic
{
    public class DatabaseConfiguration
    {
        private static string LocalFolder
        {
            get { return ApplicationData.Current.LocalFolder.Path; }
        }

        public string FilePath
        {
            get { return Path.Combine(LocalFolder, "billboard.sqlite"); }
        }

        static DatabaseConfiguration current;
        public static DatabaseConfiguration Current { get { return current ?? (current = new DatabaseConfiguration()); } }
    }
}