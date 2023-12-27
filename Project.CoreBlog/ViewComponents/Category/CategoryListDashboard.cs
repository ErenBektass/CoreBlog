using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
