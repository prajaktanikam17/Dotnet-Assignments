using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace OAuthDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = "/Home/Privacy"
                },
                "Google");
        }

        public IActionResult Secure()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "Google");
        }
    }
}