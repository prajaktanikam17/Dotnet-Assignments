using Microsoft.AspNetCore.Mvc;

namespace Assignment_12.Controllers
{
    // attribute based routing
    [Route("product")]
    public class ProductController : Controller
    {
        // url: /product/all
        [Route("all")]
        public IActionResult GetAll()
        {
            return Content("Attribute Based Routing - All Products");
        }

        // url: /product/details/5
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            return Content("Attribute Based Routing - Product Id = " + id);
        }
    }
}