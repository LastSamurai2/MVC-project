using Library3.AppDbContext;
using Library3.Models;
using Library3.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Controllers
{
    [Authorize(Roles = "Admin, Executive")]
    public class BooksController : Controller
    {
        private readonly LibraryDBContext _db;

        [BindProperty]
        public BooksViewBooks BookVM { get; set; }

        public BooksController(LibraryDBContext db)
        {
            _db = db;
            BookVM = new BooksViewBooks()
            {
                Authors = _db.Authors.ToList(),
                Books = new Models.Books()
            };
        }
        public IActionResult Index()
        {
            var book = _db.Books.Include(m => m.Author);
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            return View(BookVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BookVM);
            }
            _db.Books.Add(BookVM.Books);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Books book = _db.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            BookVM.Books = _db.Books.Include(m => m.Author).SingleOrDefault(m => m.Id == id);

            if (BookVM.Books == null)
            {
                return NotFound();
            }

            return View(BookVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(BookVM);
            }
            _db.Books.Update(BookVM.Books);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
