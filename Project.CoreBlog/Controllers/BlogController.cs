using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Concrate;
using Project.BLL.ValidationRules;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;
using System.Security.Claims;

namespace Project.CoreBlog.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        MyContext mc= new MyContext();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id) 
        { 
            ViewBag.i = id;
            var values =bm.GetBlogById(id);
            return View(values);
        }
        public  IActionResult BlogListByWriter()
        {
           var usermail = User.Identity.Name;
            //var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();// identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values= bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; //ViewBag komutu ile categoryvalues'dan gelen  değişkenleri veya değerleri dropdown'a taşıyacağız
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            //var usermail = User.Identity.Name;
            //var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();// identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();



            var usermail = User.Identity.Name;
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator wv = new BlogValidator();
            ValidationResult result = wv.Validate(blog);
            if (result.IsValid)
            {
                blog.Status = true;
                blog.CreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter","Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; //ViewBag komutu ile categoryvalues'dan gelen  değişkenleri veya değerleri dropdown'a taşıyacağız
            return View(blogvalue);
            
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            //var usermail = User.Identity.Name;
            //var usermail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();// identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();

            var usermail = User.Identity.Name;
            var writerID = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID= writerID;
            blog.CreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
