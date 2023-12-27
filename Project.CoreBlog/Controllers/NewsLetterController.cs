using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
	{
		NewsLetterManager nm=new NewsLetterManager(new EfNewsLetterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter  newsLetter)
		{
            newsLetter.MailStatus = true;
			nm.AddNewsLetter(newsLetter);
			return PartialView();
		}
	}
}
