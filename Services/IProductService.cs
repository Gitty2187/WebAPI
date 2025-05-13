using Entities;

namespace Services
{
    internal interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> getById(int id);
    }
}