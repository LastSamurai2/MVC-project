using Library3.Models;
using Library3.Models.ViewModels;
using Library3.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library3.Controllers
{
    [Authorize(Roles = "Admin, Executive")]
    public class CopyOfTheBooksController : Controller
    {
        private readonly LibraryDBContext _db;

        [BindProperty]
        public CopyBooksViewCopyBooks CpBookVM { get; set; }

        public CopyOfTheBooksController(LibraryDBContext db)
        {
            _db = db;
            CpBookVM = new CopyBooksViewCopyBooks()
            {
                Book = _db.Books.ToList(),
                CpBook = new Models.CopyOfTheBook()
            };
        }
        public IActionResult Index()
        {
            var book = _db.CpBooks.Include(m => m.Book);
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            return View(CpBookVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(CpBookVM);
            }
            _db.CpBooks.Add(CpBookVM.CpBook);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CopyOfTheBook cpBook = _db.CpBooks.Find(id);

            if (cpBook == null)
            {
                return NotFound();
            }
            _db.CpBooks.Remove(cpBook);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            CpBookVM.CpBook = _db.CpBooks.Include(m => m.Book).SingleOrDefault(m => m.Id == id);

            if (CpBookVM.CpBook == null)
            {
                return NotFound();
            }

            return View(CpBookVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(CpBookVM);
            }
            _db.CpBooks.Update(CpBookVM.CpBook);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
