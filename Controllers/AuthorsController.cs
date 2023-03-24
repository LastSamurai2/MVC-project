using Library3.AppDbContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Library3.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Library3.Controllers
{
    [Authorize(Roles = "Admin, Executive")]
    public class AuthorsController : Controller
    {
        public LibraryDBContext _db { get; }

        public AuthorsController(LibraryDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Authors.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Index(string sorting)
        {
            ViewData["AuthorName"] = string.IsNullOrEmpty(sorting) ? "Name" : "";
            ViewData["AuthorSurname"] = string.IsNullOrEmpty(sorting) ? "Surname" : "";

            var sortquery = from x in _db.Authors select x;

            switch (sorting)
            {
                case "Name":
                    sortquery = sortquery.OrderBy(x => x.Name);
                    break;
                case "Surname":
                    sortquery = sortquery.OrderBy(x => x.Name);
                    break;
                default:
                    sortquery = sortquery.OrderByDescending(x => x.Name);
                    break;
            }

            return View(await sortquery.AsNoTracking().ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Authors author)
        {
            if (author.Name.Equals("Kacper") && author.Surname.Equals("Śliwa"))
            {
                ModelState.AddModelError("", "Ja nie jestem pisarzem!");
                
            }
            if (ModelState.IsValid)
            {
                _db.Add(author);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Authors author)
        {
            if (ModelState.IsValid)
            {
                _db.Update(author);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
    }
}

