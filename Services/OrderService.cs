using AutoMapper;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using static DTOs.OrderDTO;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task Add(OrderDto order)
        {
            Order orderToAdd = _mapper.Map<OrderDto, Order>(order);
            if (orderToAdd.UserId == null || orderToAdd.Sum == null)
                throw new Exception("Must insert UserId & Sum");
            if (orderToAdd.Date == null)
                orderToAdd.Date = DateTime.Now;
            await _orderRepository.Add(orderToAdd);
        }

       
    }
}
