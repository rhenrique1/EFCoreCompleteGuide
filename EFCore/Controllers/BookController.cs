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
            List<Book> objList = _db.Books.Include(u => u.Publisher)
                                    .Include(u => u.BookAuthors)
                                    .ThenInclude(u => u.Author)
                                    .ToList();
            /*
            List<Book> objList = _db.Books.ToList();
            foreach (var obj in objList)
            {
                //Least Effecient
                //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Id == obj.Id);
                //Explicit Loading More Efficient
                _db.Entry(obj).Reference(u => u.Publisher).Load();
                _db.Entry(obj).Collection(u => u.BookAuthors).Load();

                foreach (var bookAuth in obj.BookAuthors)
                {
                    _db.Entry(bookAuth).Reference(u => u.Author).Load();
                }
            }
            */
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

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new BookAuthorVM
            {
                BookAuthorList = _db.BookAuthors.Include(u => u.Author).Include(u => u.Book)
                                                .Where(u => u.BookId == id).ToList(),
                BookAuthor = new BookAuthor()
                {
                    BookId = id
                },
                Book = _db.Books.FirstOrDefault(u => u.Id == id)
            };
            List<int> tempListOfAssignedAuthors = obj.BookAuthorList.Select(u => u.AuthorId).ToList();
            //NOT IN Clause in LINQ
            //Get all the authors without id in tempListOfAssignedAuthors
            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthors.Contains(u.Id)).ToList();

            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Id.ToString()
            });

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if (bookAuthorVM.BookAuthor.BookId != 0 && bookAuthorVM.BookAuthor.AuthorId != 0)
            {
                _db.BookAuthors.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.BookId });
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.Id;
            BookAuthor bookAuthor = _db.BookAuthors.FirstOrDefault(u => u.AuthorId == authorId && u.BookId == bookId);

            _db.BookAuthors.Remove(bookAuthor);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
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

            // IEnumerable<Book> BookList1 = _db.Books;
            // var FilteredBook1 = BookList1.Where(b => b.Price > 500).ToList();

            // IQueryable<Book> BookList2 = _db.Books;
            // var FilteredBook2 = BookList2.Where(b => b.Price > 500).ToList();

            // //Updating Related Data
            // var bookTemp1 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Id == 2);
            // bookTemp1.BookDetail.NumberOfChapters = 2222;
            // _db.Books.Update(bookTemp1);
            // _db.SaveChanges();

            // var bookTemp2 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Id == 2);
            // bookTemp2.BookDetail.Weight = 3333;
            // _db.Books.Attach(bookTemp2);
            // _db.SaveChanges();

            //VIEWS
            var viewList = _db.BookDetailsFromView.ToList();
            var viewList1 = _db.BookDetailsFromView.FirstOrDefault();
            var viewList2 = _db.BookDetailsFromView.Where(u => u.Price > 500);

            //RAW SQL
            var bookRaw = _db.Books.FromSqlRaw("SELECT * FROM dbo.books").ToList();

            //SQL INJECTION attack prone
            int id = 1;
            var bookTemp1 = _db.Books.FromSqlInterpolated($"SELECT * FROM dbo.books WHERE id = {id}").ToList();

            var booksSproc = _db.Books.FromSqlInterpolated($" EXEC dbo.GetAllBookDetails {id}").ToList();

            //.NET 5 only 
            var bookFilter1 = _db.Books.Include(e => e.BookAuthors.Where(p => p.AuthorId == 1)).ToList();
            var bookFilter2 = _db.Books.Include(e => e.BookAuthors.OrderByDescending(p => p.AuthorId).Take(5)).ToList();

            return RedirectToAction(nameof(Index));
        }
    }
}