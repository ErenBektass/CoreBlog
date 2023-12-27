using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;

namespace Project.CoreBlog.ViewComponents.Blog
{
	public class BlogLast3Post:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = bm.GetLast3Blog();
			return View(values);
		}
	}
}
