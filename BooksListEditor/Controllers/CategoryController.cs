using Microsoft.AspNetCore.Mvc;

namespace BooksListEditor.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
