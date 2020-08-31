using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Book> Books { get; set; }

        // We are getting db using dependency injection
        // Extracting ApplicationDbContext inside the dependency injection container and injecting onto this page
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // When using async and await, instead of void we use async Task
        public async Task OnGet()
        {
            // Assigning all books from database to Books
            Books = await _db.Book.ToListAsync();
        }
    }
}
