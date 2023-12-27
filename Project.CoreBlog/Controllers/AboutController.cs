using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm=new AboutManager(new EfAboutRepository());

		public IActionResult Index()
		{
			var values = abm.GetList();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
   
}
