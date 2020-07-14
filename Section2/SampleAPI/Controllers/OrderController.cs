using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.CustomRouting;
//project namespaces
using SampleAPI.Filters;
using SampleAPI.Models;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Controllers
{
    [Route("api/order")]
    //[CustomOrderRoute]
    [ApiController]
    [CustomControllerFilter]
    //[ServiceFilter(typeof(CustomActionFilterAsync))] //old version of the line below
    [CustomActionFilterAttribute]
    public class OrderController : ControllerBase
    {
        //local instance of the IOrderRepository
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //
        // ACTION METHODS
        //

        //GET()
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Map(_orderRepository.Get()));
        }



        //GET(Guid id)
        [HttpGet("{id:guid}")]
        //[HttpGet("{id: int:min(1)}")]
        [OrderExists]
        public IActionResult GetById(Guid id)
        {
            return Ok(Map(_orderRepository.Get(id)));
        }

        private IEnumerable<OrderResponse> Map(IEnumerable<Order> orders)
        {
            return orders.Select(Map).ToList();
        }

        private OrderResponse Map(Order order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                ItemsIds = order.ItemsIds,
                Currency = order.Currency
            };
        }

        //POST(Order request)
        [HttpPost]
        public IActionResult Post(OrderRequest request)
        {
            var order = Map(request);

            _orderRepository.Add(order);

            //return Ok();
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, null); 
            //CreatedAtAction(actionName, routeValues, value)
        }

        private Order Map(OrderRequest request)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                ItemsIds = request.ItemsIds,
                Currency = request.Currency
            };
        }

        [HttpPut("{id:guid}")]
        [OrderExists]
        public IActionResult Put(Guid id, OrderRequest request)
        {
            var order = _orderRepository.Get(id);

            if(request.ItemsIds == null)
            {
                return BadRequest();
            }


            if(order == null)
            {
                return NotFound(new { Message = $"Item with id: {id} does not exist." });
            }

            //Map request to the domain object
            order = Map(request, order);
            
            _orderRepository.Update(id, order);

            return Ok();

        }

        private Order Map(OrderRequest request, Order order)
        {
            order.ItemsIds = request.ItemsIds;
            order.Currency = request.Currency;

            return order;
        }

        [HttpPatch("{id:guid}")]
        [OrderExists]
        public IActionResult Patch(Guid id, JsonPatchDocument<Order> requestOp)
        {
            var order = _orderRepository.Get(id);

            if(order == null)
            {
                return NotFound(new { Message = $"Item with id {id} does not exist" });
            }

            requestOp.ApplyTo(order);
            _orderRepository.Update(id, order);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [OrderExists]
        public IActionResult Delete(Guid id)
        {

            var order = _orderRepository.Get(id);

            if(order == null)
            {
                return NotFound(new { Message = $"Item with id of {id} does not exist" });
            }

            _orderRepository.Delete(id);

            return NoContent();
        }
    }
}

