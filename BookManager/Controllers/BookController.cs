using System;
using System.Net;
using System.Web.Mvc;
using BookManager.Models;
using BookManager.Repositories.Interfaces;
using PagedList;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET: Book
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, bool sortDesc = false)
        {            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortDesc = sortDesc;

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Title" : sortOrder;

            var books = bookRepository.GetOrderedAndFiltered(sortOrder, searchString, sortDesc);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize)); 
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book bookModel = bookRepository.GetByID(id.Value);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(bookRepository.GetAuthors(), "ID", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AuthorID,Title,Genre,Price,PublicationDate,ShortDesc")] Book bookModel)
        {
            if (ModelState.IsValid)
            {
                bookRepository.Insert(bookModel);
                bookRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(bookRepository.GetAuthors(), "ID", "Name",bookModel.AuthorID);
            return View(bookModel);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book bookModel = bookRepository.GetByID(id.Value);
            if (bookModel == null)            {
                
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(bookRepository.GetAuthors(), "ID", "Name", bookModel.Author.Id);
            return View(bookModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorID,Title,Genre,Price,PublicationDate,ShortDesc")] Book bookModel)
        {
            if (ModelState.IsValid)
            {
                bookRepository.Update(bookModel);
                bookRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(bookRepository.GetAuthors(), "ID", "Name", bookModel.Id);
            return View(bookModel);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book bookModel = bookRepository.GetByID(id.Value);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book bookModel = bookRepository.GetByID(id);
            bookRepository.Delete(id);
            bookRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bookRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
