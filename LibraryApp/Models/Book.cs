using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string ISBN { get; set; }

        // Relationship to Author
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        // Relationship to Genre
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Relationship to Loans
        public List<Loan>? Loans { get; set; }
    }
}