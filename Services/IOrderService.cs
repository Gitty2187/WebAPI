using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task Add(Order order);
        Task<List<Order>> GetAll();
        Task<Order> getById(int id);
    }
}