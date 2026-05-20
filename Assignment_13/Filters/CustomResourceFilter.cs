using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_13.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Resource Filter Executing");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Resource Filter Executed");
        }
    }
}