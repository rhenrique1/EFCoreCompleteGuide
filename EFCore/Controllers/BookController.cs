using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess.Data;
using WizLib_DataAccess.Migrations;
using Wizlib_Model.Models;
using Wizlib_Model.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();
            // foreach (var obj in objList)
            // {
            //     //Least Effecient
            //     //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Id == obj.Id);

            //     //Explicit Loading More Efficient
            //     _db.Entry(obj).Reference(u => u.Publisher).Load();
            // }
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _db.Books.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
            if (obj.Book.Id == 0)
            {
                //this is create
                _db.Books.Add(obj.Book);
            }
            else
            {
                //this is an update
                _db.Books.Update(obj.Book);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();

            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _db.Books.Include(u => u.BookDetail).FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {
            if (obj.Book.BookDetail.Id == 0)
            {
                //this is create
                _db.BookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();

                var BookFromDb = _db.Books.FirstOrDefault(u => u.Id == obj.Book.Id);
                BookFromDb.BookDetailId = obj.Book.BookDetail.Id;
                _db.SaveChanges();
            }
            else
            {
                //this is an update
                _db.BookDetails.Update(obj.Book.BookDetail);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Id == id);
            _db.Books.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround()
        {
            // var bookTemp = _db.Books.FirstOrDefault();
            // bookTemp.Price = 100;

            // var bookCollection = _db.Books;
            // double totalPrice = 0;

            // foreach (var book in bookCollection)
            // {
            //     totalPrice += book.Price;
            // }

            // var bookList = _db.Books.ToList();
            // foreach (var book in bookList)
            // {
            //     totalPrice += book.Price;
            // }

            // var bookCollection2 = _db.Books;
            // var bookCount1 = bookCollection2.Count();

            // var bookCount2 = _db.Books.Count();

            IEnumerable<Book> BookList1 = _db.Books;
            var FilteredBook1 = BookList1.Where(b => b.Price > 500).ToList();

            IQueryable<Book> BookList2 = _db.Books;
            var FilteredBook2 = BookList2.Where(b => b.Price > 500).ToList();

            //Updating Related Data
            var bookTemp1 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Id == 2);
            bookTemp1.BookDetail.NumberOfChapters = 2222;
            _db.Books.Update(bookTemp1);
            _db.SaveChanges();

            var bookTemp2 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Id == 2);
            bookTemp2.BookDetail.Weight = 3333;
            _db.Books.Attach(bookTemp2);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}