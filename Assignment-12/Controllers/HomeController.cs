using Microsoft.AspNetCore.Mvc;

namespace Assignment_12.Controllers
{
    // convention based routing
    public class HomeController : Controller
    {
        // url: /Home/Index
        public IActionResult Index()
        {
            return Content("Convention Based Routing = Home Index Page");
        }

        // url: /Home/About
        public IActionResult About()
        {
            return Content("Convention Based Routing = About Page");
        }
    }
}