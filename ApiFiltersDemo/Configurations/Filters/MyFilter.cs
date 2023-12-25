using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFiltersDemo.Configurations.Filters
{
    public class MyFilter : IActionFilter
    {
        private readonly ILogger<MyFilter> _logger;

        public MyFilter(ILogger<MyFilter> logger)
        {
            _logger = logger;
        }
        
        //executes when the request is coming in
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Global MyFilter Executed on : OnActionExecuting");
        }

        //executes when response is going back to user.
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Global MyFilter Executed on : OnActionExecuted");
        }

    }
}
