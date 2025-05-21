using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> getById(int id);
    }
}