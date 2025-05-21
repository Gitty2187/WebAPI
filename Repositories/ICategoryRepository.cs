using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> getById(int ID);
    }
}