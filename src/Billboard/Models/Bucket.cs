using SQLite;

namespace Billboard.Models
{
    public class Bucket
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
    }
}