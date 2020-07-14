using System;
using System.Collections.Generic;
using System.Linq;
using SampleAPI.Models;

namespace SampleAPI.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {

        //CONSTRUCTOR
        public MemoryOrderRepository()
        {
            _orders = new List<Order>();
        }

        //LOCAL REPOSITORY LIST
        private IList<Order> _orders { get; set; }

        //
        //FUNCTIONS
        //

        //GET()
        public IEnumerable<Order> Get() => _orders;

        //GET(Guid guid)
        public Order Get(Guid orderId)
        {
            return _orders.FirstOrDefault(order => order.Id == orderId);
        }

        // ADD(Order order)
        public void Add(Order order)
        {
            _orders.Add(order);
        }

        // UPDATE(Guid id, Order order)
        public void Update(Guid orderId, Order order)
        {
            var result = _orders.FirstOrDefault(order => order.Id == orderId);
            if(result != null)
            {
                result.ItemsIds = order.ItemsIds;
            }
        }

        //DELETE(Guid id)
        public Order Delete(Guid orderId)
        {
            var target = _orders.FirstOrDefault(order => order.Id == orderId);

            target.IsInactive = true;
            Update(orderId, target);

            return target;
        }
    }
}












