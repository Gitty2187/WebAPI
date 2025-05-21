using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task<List<Order>> GetAll();
        Task<Order> getById(int ID);
    }
}