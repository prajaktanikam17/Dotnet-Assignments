using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_13.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "Exception Handled By Exception Filter"
            };
        }
    }
}