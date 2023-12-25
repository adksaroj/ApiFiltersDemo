using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFiltersDemo.Configurations.Filters
{
    public class MyActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _caller;

        public MyActionFilterAttribute(string caller)
        {
            _caller = caller;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{_caller} : OnActionExecuting");
        }

        //executes when response is going back to user.
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{_caller} : OnActionExecuted");
        }
    }
}
