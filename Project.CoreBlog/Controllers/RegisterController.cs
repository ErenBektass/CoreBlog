using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.BLL.ValidationRules;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult result = wv.Validate(writer);
			if (result.IsValid)
			{
                writer.Status = true;
                writer.About = "Deneme Test";
				wm.TAdd(writer);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}	
