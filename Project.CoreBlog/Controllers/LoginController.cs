using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.CoreBlog.Models;
using Project.DAL.Concrate;
using Project.ENTITIES.Concrete;
using System.Security.Claims;

namespace Project.CoreBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{

		private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            
            _signInManager = signInManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel  usivm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(usivm.UserName, usivm.Password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }

            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
//      public async Task<IActionResult> Index(Writer w)
//{
//	var datavalue = mc.Writers.FirstOrDefault(x => x.Email == w.Email && x.Password == w.Password);
//	if (datavalue != null)
//	{
//		var calims = new List<Claim>
//		{
//			new Claim(ClaimTypes.Name,w.Email)
//		};
//		var useridentity = new ClaimsIdentity(calims, "a");
//		ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
//		await HttpContext.SignInAsync(principal);
//		return RedirectToAction("Index", "Dashboard");
//	}
//	else
//	{
//		return View();
//	}
//}
