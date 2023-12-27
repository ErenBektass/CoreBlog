using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm2 = new Message2Manager(new EfMessage2Repository());
        MyContext mc = new MyContext();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm2.GetInboxByWriter(writerID);
            return View(values);

        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == userMail).Select(y => y.WriterID).FirstOrDefault();
            //var values = mm2.GetSendboxByWriter(writerID);
            return View();
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 message)
        {
            var userName = User.Identity.Name;
            var userMail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == userMail).Select(y => y.WriterID).FirstOrDefault();

            message.SenderID = writerID;
            message.ReceiverID=2;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            mm2.TAdd(message);
            return RedirectToAction("SendBox");
        }
    }
}