using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrate;

namespace Project.CoreBlog.Controllers
{
    public class DashboardController : Controller
    {
        MyContext mc=new MyContext();
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerid=mc.Writers.Where(x => x.Email == userMail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.v1=mc.Blogs.Count().ToString();
            ViewBag.v2=mc.Blogs.Where(x=>x.WriterID==writerid).Count(); //Blog sayısını burdan düzeltirsin
            ViewBag.v3=mc.Categories.Count();
            return View();
        }
    }   
}
