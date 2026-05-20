using Microsoft.AspNetCore.Mvc;
using Assignment_13.Filters;

namespace Assignment_13.Controllers
{
    [CustomAuthorizationFilter]
    [CustomResourceFilter]
    [CustomActionFilter]
    [CustomExceptionFilter]
    [CustomResultFilter]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("All Filters Executed Successfully");
        }

        public IActionResult Error()
        {
            throw new Exception("Custom Exception");
        }
    }
}