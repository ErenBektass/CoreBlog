using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;
using X.PagedList;
namespace Project.CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(category);
            if (result.IsValid)
            {
                category.Status = true;
                cm.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
