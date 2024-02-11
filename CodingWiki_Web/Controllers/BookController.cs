using CodingWiki_DataAccess.Data;
using CodingWiki_Models.Models;
using CodingWiki_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objlist = _db.Books.Include(u => u.Publisher).ToList();
            foreach(var obj in objlist)
            {
                //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
                // Explicit Loading as the above statement is not efficient as ,
                // It goes to DB to query & fetch each record 
                //_db.Entry(obj).Reference(u => u.Publisher).Load();
            }

            return View(objlist);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new ();

            obj.PublisherList = _db.Publishers.Select(x => new SelectListItem { 
                  Text = x.Name,
                  Value = x.Publisher_Id.ToString()
            });

            if (id == null | id == 0)
            {
                //create
                return View(obj);
            }
            //edit

            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
                if (obj.Book.BookId == 0)
                {
                    //create
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                    // update
                    _db.Books.Update(obj.Book);
                }

                await _db.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            
            return View(obj);
        }


        public IActionResult Details(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();
            //edit

            //obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            { 
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                //create
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                // update
                _db.BookDetails.Update(obj);
            }

            await _db.SaveChangesAsync();
            RedirectToAction(nameof(Index));

            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new Book();
            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Playground()
        {
            // IEnumerable VS Iqueryable

            IEnumerable<Book> booklist1 = _db.Books;
            var filteredBook1 = booklist1.Where(u => u.Price > 10).ToList();

            IQueryable<Book> booklist2 = _db.Books;
            var filteredBook2 = booklist2.Where(u => u.Price > 10).ToList();

            // Deffered Execution Example
            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}
