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
	             return RedirectToAction("Index");
	        }

	        return View(obj);
        }
	}
}
