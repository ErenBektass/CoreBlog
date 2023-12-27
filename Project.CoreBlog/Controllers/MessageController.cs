using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Concrate;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        MyContext mc=new MyContext();
        public IActionResult InBox()
        {
            //var userName = User.Identity.Name; identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            //var values = mm.GetInboxByWriter(writerID);


            int id = 2;
            var values = mm.GetInboxByWriter(id);
            return View(values);
        }
        public IActionResult SendBox()
        {
            //var userName = User.Identity.Name; identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            //var values = mm.GetSendBoxByWriter(writerID);
            return View();
        }

        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
          

        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            var userName = User.Identity.Name; //identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxByWriter(writerID);
            message.SenderID = writerID;
            message.Status = true;
            message.ReceiverID = 2;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(message);
            return RedirectToAction("Inbox");
        }
    }
}
