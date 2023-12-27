using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.CoreBlog.Models;
using Project.ENTITIES.Concrete;

namespace Project.CoreBlog.Controllers
{

    public class RegisterUserController : Controller
    {
        
        private readonly UserManager<AppUser> _usermanager;

        public RegisterUserController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpGet]     
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel usuv)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = usuv.Mail,
                    UserName= usuv.UserName,
                    NameSurName= usuv.NameSurname,

                };
                var result = await _usermanager.CreateAsync(user, usuv.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(usuv);
        }
    }
}
