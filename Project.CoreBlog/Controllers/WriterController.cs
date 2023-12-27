using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BLL.Concrate;
using Project.BLL.ValidationRules;
using Project.CoreBlog.Models;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{

	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _usermanager;
		MyContext mc=new MyContext();

        public WriterController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			var writername = mc.Writers.Where(x => x.Email == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writername;
			
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
        public IActionResult Test()
        {
            return View();
        }
		public PartialViewResult WriterNavbarPartial() 
		{
			return PartialView();
		}
        public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[HttpGet]
        public async Task<IActionResult> WriterEditProfile()
		{
			
			var userName = User.Identity.Name;
			var userMail = mc.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
			var id = mc.Users.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
			var values = userManager.TGetById(id);
            //var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            //UserUpdateViewModel model = new UserUpdateViewModel();// identiy Null geldiği için yorum satırı yaptım identity gelince yorum satırını kaldır
            //         model.mail = values.Email;
            //         model.nameSurname = values.NameSurName;
            //         model.imageurl = values.ImageUrl;
            //model.username = values.UserName;
            return View(values);
        }
		[HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
		{
			var values = await _usermanager.FindByNameAsync(User.Identity.Name);
			values.NameSurName = model.nameSurname;
			values.ImageUrl = model.imageurl;
			values.Email = model.mail;
			values.PasswordHash = _usermanager.PasswordHasher.HashPassword(values, model.password);	
			var result=await _usermanager.UpdateAsync(values);
			return RedirectToAction("Index", "Dashboard");
		}
		[HttpGet]
        public IActionResult WriterAdd()
		{
			return View();
		}
		[HttpPost]
        public IActionResult WriterAdd(AddProfileImage ap)
        {
			Writer w=new Writer();
			if (ap.Image!=null)
			{
				var extension = Path.GetExtension(ap.Image.FileName);
                var newimage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimage);
                var stream = new FileStream(location, FileMode.Create);
                ap.Image.CopyTo(stream);
                w.Image = newimage;

            }
            w.Email = ap.Email;
            w.WriterName = ap.WriterName;
            w.Password = ap.Password;
            w.Status = true;
            w.About = ap.About;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");


        }



    }
}
