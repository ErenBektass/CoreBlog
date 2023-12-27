using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrate;

namespace Project.CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        MyContext mc=new MyContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = mc.Admins.Where(x => x.AdminID == 3).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = mc.Admins.Where(x => x.AdminID == 3).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v3 = mc.Admins.Where(x => x.AdminID == 3).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
