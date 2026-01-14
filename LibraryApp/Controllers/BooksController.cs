using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization; // 1. Added namespace for Authorization

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books (Public Access)// GET: Books (Public Access)
        public async Task<IActionResult> Index(string searchString)
        {
            var books = _context.Books.Include(b => b.Author).Include(b => b.Genre).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                // FIX: Add .ToUpper() to both sides to make it case-insensitive
                books = books.Where(b => b.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await books.ToListAsync());
        }

        // GET: Books/Details/5 (Public Access)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create (Restricted)
        [Authorize(Policy = "AdminOnly")] // 2. Added Authorize
        public IActionResult Create()
        {
            // Create a temporary list with Full Name
            var authorList = _context.Authors.Select(a => new
            {
                Id = a.Id,
                FullName = a.FirstName + " " + a.LastName
            });

            ViewData["AuthorId"] = new SelectList(authorList, "Id", "FullName");
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            return View();
        }

        // POST: Books/Create (Restricted)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")] // 3. Added Authorize
        public async Task<IActionResult> Create([Bind("Id,Title,ISBN,AuthorId,GenreId,IsAvailable")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var authorList = _context.Authors.Select(a => new
            {
                Id = a.Id,
                FullName = a.FirstName + " " + a.LastName
            });

            ViewData["AuthorId"] = new SelectList(authorList, "Id", "FullName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", book.GenreId);
            return View(book);
        }

        // GET: Books/Edit/5 (Restricted)
        [Authorize(Policy = "AdminOnly")] // 4. Added Authorize
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var authorList = _context.Authors.Select(a => new
            {
                Id = a.Id,
                FullName = a.FirstName + " " + a.LastName
            });

            ViewData["AuthorId"] = new SelectList(authorList, "Id", "FullName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", book.GenreId);
            return View(book);
        }

        // POST: Books/Edit/5 (Restricted)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")] // 5. Added Authorize
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ISBN,AuthorId,GenreId,IsAvailable")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var authorList = _context.Authors.Select(a => new
            {
                Id = a.Id,
                FullName = a.FirstName + " " + a.LastName
            });

            ViewData["AuthorId"] = new SelectList(authorList, "Id", "FullName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", book.GenreId);
            return View(book);
        }

        // GET: Books/Delete/5 (Restricted)
        [Authorize(Policy = "AdminOnly")] // 6. Added Authorize
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5 (Restricted)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")] // 7. Added Authorize
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibraryContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}