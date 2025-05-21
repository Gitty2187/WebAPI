using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> getById(int id);
    }
}