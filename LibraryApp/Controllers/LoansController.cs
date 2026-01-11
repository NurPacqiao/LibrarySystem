using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization; // Added for Authorization

namespace LibraryApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Loans (Public)
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Loans.Include(l => l.Book);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Loans/Details/5 (Public)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create (Restricted)
        [Authorize]
        public IActionResult Create()
        {
            // Display "Title" in the dropdown instead of "Id"
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
            return View();
        }

        // POST: Loans/Create (Restricted)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,BookId,UserId,LoanDate,ReturnDate")] Loan loan)
        {
            // 1. Find the book the user wants to borrow
            var book = await _context.Books.FindAsync(loan.BookId);

            // 2. Check if the book exists
            if (book == null)
            {
                return NotFound();
            }

            // 3. Check if the book is already taken
            if (book.IsAvailable == false)
            {
                ModelState.AddModelError("", "This book is currently borrowed by someone else.");
            }

            if (ModelState.IsValid)
            {
                // 4. Mark the book as NOT available
                book.IsAvailable = false;
                _context.Update(book);

                // 5. Save the Loan
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If error, reload the dropdown with "Title"
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", loan.BookId);
            return View(loan);
        }

        // GET: Loans/Edit/5 (Restricted)
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            // Display "Title" in dropdown
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", loan.BookId);
            return View(loan);
        }

        // POST: Loans/Edit/5 (Restricted)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,UserId,LoanDate,ReturnDate")] Loan loan)
        {
            if (id != loan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.Id))
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
            // Display "Title" in dropdown
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", loan.BookId);
            return View(loan);
        }

        // GET: Loans/Delete/5 (Restricted)
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5 (Restricted)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loans == null)
            {
                return Problem("Entity set 'LibraryContext.Loans'  is null.");
            }
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return (_context.Loans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}