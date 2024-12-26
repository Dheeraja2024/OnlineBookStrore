using Microsoft.AspNetCore.Mvc;
using OnlineBookStrore.Data;
using OnlineBookStrore.Models;

namespace OnlineBookStrore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbObj;
        public CategoryController(ApplicationDBContext db)
        {
            _dbObj = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _dbObj.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
    }
}
