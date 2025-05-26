using Entities;
using DTOs;

namespace Services
{
    public interface IOrderService
    {
        Task Add(OrderDTO order);
    }
}