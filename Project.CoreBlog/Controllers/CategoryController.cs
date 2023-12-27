using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values=cm.GetList();
            return View(values);
        }
    }
}
