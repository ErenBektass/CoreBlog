using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        MyContext mc=new MyContext();

        public  IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.name = userName;
            var usermail= mc.Users.Where(x=>x.UserName== userName).Select(y=>y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v2 = writerID;
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
