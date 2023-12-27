using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        MyContext mc = new MyContext();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;// identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();

            int id = 2;
            var values=mm.GetInboxByWriter(id);
            return View(values);
        }
    }
}
