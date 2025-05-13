using Entities;

namespace Repositories
{
    internal interface IProductRepositories
    {
        Task<List<Product>> GetAll();
        Task<Product> getById(int ID);
    }
}