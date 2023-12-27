using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrate;

namespace Project.CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        MyContext mc = new MyContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = mc.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.Title).Take(1).FirstOrDefault();//Blog Id'ye göre listele listeledikten sonra en alttaki değeri blog titleyi seç burdan da sadece 1 tane değer al
            ViewBag.v3 = mc.Comments.Count();
            return View();
        }
    }
}
