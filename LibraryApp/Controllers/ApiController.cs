using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ApiController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Api
        // This returns the list of books as raw JSON data
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author) // Include Author details
                .Include(b => b.Genre)  // Include Genre details
                .ToListAsync();

            // We select only the data we want to share to avoid loops
            var result = books.Select(b => new
            {
                b.Id,
                b.Title,
                b.ISBN,
                AuthorName = b.Author?.FirstName + " " + b.Author?.LastName,
                Genre = b.Genre?.Name,
                Available = b.IsAvailable
            });

            return Ok(result);
        }
    }
}