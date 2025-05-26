using Entities;
using DTOs;
using static DTOs.CategoryDTO;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
    }
}