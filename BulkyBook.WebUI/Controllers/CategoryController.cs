using BulkyBook.WebUI.Contexts;
using BulkyBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _dbContext.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            Category? existingCategory = _dbContext.Categories.Find(id);
            //var existingCategory = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            //var existingCategory = _dbContext.Categories.SingleOrDefault(u => u.Id == id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            return View(existingCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            Category? existingCategory = _dbContext.Categories.Find(id);
            //var existingCategory = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            //var existingCategory = _dbContext.Categories.SingleOrDefault(u => u.Id == id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            return View(existingCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            Category? existingCategory = _dbContext.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(existingCategory);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
