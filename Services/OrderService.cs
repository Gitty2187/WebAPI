using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Add(Order order)
        {
            if (order.UserId == null || order.Sum == null)
                throw new Exception("Must insert UserId & Sum");
            if (order.Date == null)
                order.Date = DateTime.Now;
            await _orderRepository.Add(order);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> getById(int id)
        {
            if (id == null)
                throw new Exception("Must insert id");
            return await _orderRepository.getById(id);
        }
    }
}
