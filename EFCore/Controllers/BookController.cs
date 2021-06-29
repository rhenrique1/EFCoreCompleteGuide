using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess.Data;
using WizLib_DataAccess.Migrations;
using Wizlib_Model.Models;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _db;

        public BookController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }

        /*
        public IActionResult Upsert(int? id)
        {
            Book obj = new Book();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _db.Books.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Book obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    //this is create
                    _db.Books.Add(obj);
                }
                else
                {
                    //this is an update
                    _db.Books.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Id == id);
            _db.Books.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        */
    }
}