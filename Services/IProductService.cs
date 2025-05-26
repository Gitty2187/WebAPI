using DTOs;

namespace Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();
        Task<ProductDTO> getById(int id);
    }
}