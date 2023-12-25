using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFiltersDemo.Configurations.Filters
{
    public class MyAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _caller;

        public MyAsyncActionFilterAttribute(string caller)
        {
            _caller = caller;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //logic before action execution
            Console.WriteLine($"ASync Filter : OnActionExecutionAsync : From  {_caller} : Before Action Execution ");

            await next();

            //logic after action execution
            Console.WriteLine($"ASync Filter : OnActionExecutionAsync : From  {_caller} : AFTER Action Execution ");
        }
    }
}
