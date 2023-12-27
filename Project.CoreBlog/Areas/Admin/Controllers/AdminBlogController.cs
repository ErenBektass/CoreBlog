using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
