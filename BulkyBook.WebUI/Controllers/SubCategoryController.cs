using BulkyBook.WebUI.Contexts;
using BulkyBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.WebUI.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SubCategory> subCategories = _dbContext.SubCategories;
            foreach (var item in subCategories.ToList())
            {
                Category? category = await _dbContext.Categories.FindAsync(item.CategoryId);
                item.Category = category;
            }
            return View(subCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> selectListItems = (from c in _dbContext.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString()
                                                    }).ToList();
            ViewBag.categorySelectListItems = selectListItems;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.SubCategories.Add(subCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "Subcategory created successfully!";
                return RedirectToAction("Index");
            }
            return View(subCategory);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            SubCategory? existingSubCategory = _dbContext.SubCategories.Find(id);
            List<SelectListItem> selectListItems = (from c in _dbContext.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString()
                                                    }).ToList();
            ViewBag.categorySelectListItems = selectListItems;

            if (existingSubCategory == null)
            {
                return NotFound();
            }

            return View(existingSubCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.SubCategories.Update(subCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "Subcategory updated successfully!";
                return RedirectToAction("Index");
            }
            return View(subCategory);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            SubCategory? existingSubCategory = _dbContext.SubCategories.Find(id);
            List<SelectListItem> selectListItems = (from c in _dbContext.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString()
                                                    }).ToList();
            ViewBag.categorySelectListItems = selectListItems;

            if (existingSubCategory == null)
            {
                return NotFound();
            }

            return View(existingSubCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubCategory(int? id)
        {
            SubCategory? existingSubCategory = _dbContext.SubCategories.Find(id);
            if (existingSubCategory == null)
            {
                return NotFound();
            }

            _dbContext.SubCategories.Remove(existingSubCategory);
            _dbContext.SaveChanges();
            TempData["success"] = "Subcategory deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
