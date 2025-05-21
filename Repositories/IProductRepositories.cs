using Entities;

namespace Repositories
{
    public interface IProductRepositories
    {
        Task<List<Product>> GetAll();
        Task<Product> getById(int ID);
    }
}