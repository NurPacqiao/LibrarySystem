using System.ComponentModel.DataAnnotations; // 1. Important for validation

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")] // Must have a title
        [StringLength(100, MinimumLength = 2)] // Must be between 2 and 100 letters
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; }

        // Relationships
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}