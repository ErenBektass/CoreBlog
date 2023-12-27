using Microsoft.AspNetCore.Mvc;
using Project.CoreBlog.Areas.Admin.Models;

namespace Project.CoreBlog.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list=new List<CategoryClass>();
            {
                list.Add(new CategoryClass
                {
                    CategoryName = "Teknoloji",
                    CategoryCount = 10
                });
                list.Add(new CategoryClass
                {
                    CategoryName = "Yazılım",
                    CategoryCount = 14
                });
                list.Add(new CategoryClass
                {
                    CategoryName = "Spor",
                    CategoryCount = 5
                });
                list.Add(new CategoryClass
                {
                    CategoryName = "Sinema",
                    CategoryCount = 4
                });
                return Json(new { jsonlist = list });
            };

        }
    }
}
