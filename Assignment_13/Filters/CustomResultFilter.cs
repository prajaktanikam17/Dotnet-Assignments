using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_13.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Result Executing");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Result Executed");
        }
    }
}