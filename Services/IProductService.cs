using DTOs;
using static DTOs.ProductDTO;

namespace Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> getById(int id);
    }
}