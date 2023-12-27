using Microsoft.AspNetCore.Mvc;

namespace Project.CoreBlog.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
