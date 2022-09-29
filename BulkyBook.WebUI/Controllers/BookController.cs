using BulkyBook.WebUI.Contexts;
using BulkyBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books = _dbContext.Books;
            foreach (var item in books.ToList())
            {
                SubCategory? subCategory = await _dbContext.SubCategories.FindAsync(item.SubCategoryId);
                if (subCategory != null)
                {
                    item.SubCategory = subCategory;
                    Category? category = await _dbContext.Categories.FindAsync(subCategory.CategoryId);
                    if (category != null)
                        item.SubCategory.Category = category;
                }
            }
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = (from s in _dbContext.SubCategories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = s.Name,
                                                        Value = s.Id.ToString()
                                                    }).ToList();
            ViewBag.subCategorySelectListItems = selectListItems;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                TempData["success"] = "Book created successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            Book? existingBook = _dbContext.Books.Find(id);
            List<SelectListItem> selectListItems = (from s in _dbContext.SubCategories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = s.Name,
                                                        Value = s.Id.ToString()
                                                    }).ToList();
            ViewBag.subCategorySelectListItems = selectListItems;

            if (existingBook == null)
            {
                return NotFound();
            }

            return View(existingBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Update(book);
                _dbContext.SaveChanges();
                TempData["success"] = "Book updated successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            Book? existingBook = _dbContext.Books.Find(id);
            List<SelectListItem> selectListItems = (from s in _dbContext.SubCategories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = s.Name,
                                                        Value = s.Id.ToString()
                                                    }).ToList();
            ViewBag.subCategorySelectListItems = selectListItems;

            if (existingBook == null)
            {
                return NotFound();
            }

            return View(existingBook);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubCategory(int? id)
        {
            Book? existingBook = _dbContext.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(existingBook);
            _dbContext.SaveChanges();
            TempData["success"] = "Book deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
