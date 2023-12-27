using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{

	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult PartialAddComment(Comment comment)
		{
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Status = true;

            cm.CommentAdd(comment);

            return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogID });
        }
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}
