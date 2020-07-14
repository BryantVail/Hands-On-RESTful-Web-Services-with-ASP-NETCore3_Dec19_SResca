using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//project namespaces
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SampleAPI.Repositories;


namespace SampleAPI.Filters
{
    public class OrderExistsAttribute : TypeFilterAttribute
    {

        public OrderExistsAttribute() : base(typeof(OrderExistsFilterImpl))
        { }


        private class OrderExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IOrderRepository _orderRepository;

            public OrderExistsFilterImpl(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

           
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                //before
                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                //context.ActionArguments.ContainsKey("id") == true
                //check that the id == guid
                if(!(context.ActionArguments["id"] is Guid id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = _orderRepository.Get(id);

                if(result == null)
                {
                    context.Result =
                        new NotFoundObjectResult(
                            new { Message = $"Item with id {id} does not exist." });
                    return;
                }

                var responseContext = await next();

                //after
            }
        }
        

    }
}
