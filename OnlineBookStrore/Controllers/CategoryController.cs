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
        [HttpPost]
        public IActionResult CreateCategory(Category clsobj)
        {
            //if(clsobj.Name==clsobj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The Display Order cannot exactly match Name of Category");
            //}
            if(ModelState.IsValid)
            {
                _dbObj.Categories.Add(clsobj);
                _dbObj.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit( int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category CategoryFromDB= _dbObj.Categories.Find(id);//only primary key field can be find
            //Category CategoryFromDB1 = _dbObj.Categories.FirstOrDefault(u=>u.Id==id);//can match any other fields within linq instruction
            //Category CategoryFromDB2 = _dbObj.Categories.Where(u=>u.Id==id).FirstOrDefault();//linq statement to first filter then select;
            if (CategoryFromDB==null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category clsobj)
        {
            //if(clsobj.Name==clsobj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The Display Order cannot exactly match Name of Category");
            //}
            if (ModelState.IsValid)
            {
                _dbObj.Categories.Update(clsobj);
                _dbObj.SaveChanges();
                TempData["success"] = "Category updated  successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDB = _dbObj.Categories.Find(id);
            
            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);    
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
                 Category? CategoryFromDB = _dbObj.Categories.Find(id);
                if(CategoryFromDB==null)
                {
                    return NotFound();
                }
                _dbObj.Categories.Remove(CategoryFromDB);
                _dbObj.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
