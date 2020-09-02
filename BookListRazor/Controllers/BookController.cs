﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    // We need to add api calls for DataTables to retrieve all books in json format and also to delete
    // That is why we needed to create web api (this controller), to make api calls

    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(b => b.Id == id);

            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}