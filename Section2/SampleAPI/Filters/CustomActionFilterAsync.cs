using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace SampleAPI.Filters
{
    public class CustomActionFilterAsync : IAsyncActionFilter
    {

        public CustomActionFilterAsync(ILogger logger)
        {
            _logger = logger;
        }

        private readonly ILogger _logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before
            _logger.LogInformation("Logging Before");

            var resultContext = await next();

            //after
            _logger.LogInformation("Logging OnActionExecuted");
        }


        //SYNCHRONOUS
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    //do something before
        //}
        
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    //do something after
        //}


    }
}
