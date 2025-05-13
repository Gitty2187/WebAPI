using Entities;

namespace Repositories
{
    internal interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> getById(int ID);
    }
}