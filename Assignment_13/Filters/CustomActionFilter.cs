using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_13.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Executed");
        }
    }
}