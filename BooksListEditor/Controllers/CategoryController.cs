using BooksListEditor.Data;
using BooksListEditor.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksListEditor.Controllers
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
            IEnumerable<Category> categoryListObj = _dbContext.Categories.ToList();

            return View(categoryListObj);
		}

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
		public IActionResult CreateNewCategory()
		{
			return View();
		}

        /// <summary>
        /// POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewCategory(Category obj)
        {
	        if (obj.Name == obj.Order.ToString())
	        {
                ModelState.AddModelError("Name", "The Order cannot exactly match the Name");
	        }
	        if (ModelState.IsValid)
	        {
	             _dbContext.Categories.Add(obj);
	             await _dbContext.SaveChangesAsync();
	             TempData["success"] = "Category created successfully";
	             return RedirectToAction("Index");
	        }

	        return View(obj);
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
	        if (id == null || id == 0)
	        {
		        return NotFound();
	        }

	        var currentCategoryById = _dbContext.Categories.Find(id);
	        //var currentCategory = _dbContext.Categories.FirstOrDefault(i => i.Id == id);
	        //var currCategory = _dbContext.Categories.SingleOrDefault(i => i.Id == id);

	        if (currentCategoryById == null)
	        {
		        return NotFound();
	        }

	        return View(currentCategoryById);
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj)
        {
	        if (obj.Name == obj.Order.ToString())
	        {
		        ModelState.AddModelError("Name", "The Order cannot exactly match the Name");
	        }
	        if (ModelState.IsValid)
	        {
		        _dbContext.Categories.Update(obj);
		        await _dbContext.SaveChangesAsync();
		        TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
	        }

	        return View(obj);
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
	        if (id == null || id == 0)
	        {
		        return NotFound();
	        }

	        var currentCategoryById = _dbContext.Categories.Find(id);
	        //var currentCategory = _dbContext.Categories.FirstOrDefault(i => i.Id == id);
	        //var currCategory = _dbContext.Categories.SingleOrDefault(i => i.Id == id);

	        if (currentCategoryById == null)
	        {
		        return NotFound();
	        }

	        return View(currentCategoryById);
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
	        var getCategory = await _dbContext.Categories.FindAsync(id);

	        if (getCategory == null)
	        {
		        return NotFound();
	        }
	        _dbContext.Categories.Remove(getCategory);
		    await _dbContext.SaveChangesAsync();
		    TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
        }
	}
}
