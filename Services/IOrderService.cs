using Entities;
using DTOs;
using static DTOs.OrderDTO;

namespace Services
{
    public interface IOrderService
    {
        Task Add(OrderDto order);
    }
}