using SQLite;

namespace SQLiteTester.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string OtherField { get; set; }
    }
}