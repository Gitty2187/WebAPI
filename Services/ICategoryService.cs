using Entities;

namespace Services
{
    internal interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> getById(int id);
    }
}