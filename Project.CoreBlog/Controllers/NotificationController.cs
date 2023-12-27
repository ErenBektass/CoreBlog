using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm=new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification()
        {
            var values=nm.GetList();
            return View(values);
            
        }
    }
}
