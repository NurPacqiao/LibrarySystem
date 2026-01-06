using System;

namespace LibraryApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        // We will link to the User later (Day 3 task)
        public string? UserId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}