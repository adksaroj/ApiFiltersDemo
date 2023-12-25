using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFiltersDemo.Configurations.Filters
{
    public class MySecondAsyncActionFilterAttribute : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        private readonly string _caller;

        public int Order { get; set; }

        public MySecondAsyncActionFilterAttribute(string caller, int order)
        {
            _caller = caller;
            Order = order;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //logic before action execution
            Console.WriteLine($"Second ASync Filter : OnActionExecutionAsync : From  {_caller} : Before Action Execution ");

            await next();

            //logic after action execution
            Console.WriteLine($"Second ASync Filter : OnActionExecutionAsync : From  {_caller} : AFTER Action Execution ");
        }
    }
}
