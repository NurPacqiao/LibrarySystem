namespace LibraryApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationship: One genre can have many books
        public List<Book>? Books { get; set; }
    }
}